using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Identity.Client;
using MimeKit;

namespace PortailTE44.Common.Mail
{
    public static class MailEngineTest
    {
        //NICH passer ces données dans le app.settings
        private static readonly string _clientID = "752a7130-fc03-4abb-9722-44b4e9964b96";  // ID de l'application POT-PORTAIL dans notre tenant 365
        private static readonly string _tenantId = "0a9b5e7b-39ba-4de1-a8ef-ab3f2080e841";  // ID du tenant
        private static readonly string _mailServerURL = "outlook.office365.com";

        private static readonly string _mailUser = "portail@te44.fr";                       // Email qui sera utilisé pour envoyer des emails au nom de pot-portail
        private static readonly string _mailPassword = "Abc1234!"; 								// Mot de passe de la boite mail

        public static IPublicClientApplication BuildPublicApp()
        {
            IPublicClientApplication app;

            PublicClientApplicationOptions pcaOptions = new PublicClientApplicationOptions
            {
                ClientId = _clientID,
                TenantId = _tenantId,
                // Il s'agît d'une authentification silencieuse de l'application
                // dans le but de pouvoir utiliser une boite mail d'exchange365
                // par conséquent l'URL de redirection n'est pas importante
                RedirectUri = "http://localhost"
            };

            app = PublicClientApplicationBuilder.CreateWithApplicationOptions(pcaOptions).Build();

            return app;
        }

        public static AuthenticationResult? XOAuthAuthenticate(IPublicClientApplication app)
        {
            AuthenticationResult? authenticationResult_R323 = null;

            // Ici le scope des autorisations demandées par l'application
            // Si l'autorisation n'est pas paramétrée côté 365 pour cette application
            // (_clientId), nous n'obtiendrons pas de Token
            string[] scopes = new string[] {"email", "EWS.AccessAsUser.All", "IMAP.AccessAsUser.All", "offline_access", "openid",
            "POP.AccessAsUser.All", "profile", "SMTP.Send", "User.Read", "User.Read.All", "EWS.AccessAsUser.All" };

            try
            {
                authenticationResult_R323 = app.AcquireTokenByUsernamePassword(scopes, _mailUser, _mailPassword).ExecuteAsync().Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return authenticationResult_R323;
        }

        public static async Task SendMailTestNICH(MimeMessage mail)
        {
            // On constuit une interface d'application pot-portail
            IPublicClientApplication app = BuildPublicApp();

            // On s'authentifie avec les credentials de notre boite mail
            AuthenticationResult? authenticationResult = XOAuthAuthenticate(app);

            if (authenticationResult == null)
                throw new Exception("Authentication failed");

            if (authenticationResult.AccessToken == string.Empty)
                throw new Exception("Access token is empty");


            using (var client = new SmtpClient())
            {
                var oauth2Smtp = new SaslMechanismOAuth2(_mailServerURL, authenticationResult.AccessToken);
                await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(oauth2Smtp);
                await client.SendAsync(mail);
            }
        }
    }
}
