using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace PortailTE44.Common.Utils
{
    #region "JSON Class"

    public class EudoAPI_Auth
    {
        public string SubscriberLogin { get; set; } = string.Empty;
        public string SubscriberPassword { get; set; } = string.Empty;
        public string BaseName { get; set; } = string.Empty;
        public string UserLogin { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserLang { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public bool ExtendedProperties { get; set; } = false;
        public bool UseRegionalSettings { get; set; } = false;
    }

    public class EudoAPI_EudoFont
    {
        public string Eot { get; set; } = string.Empty;
        public string Svg { get; set; } = string.Empty;
        public string Ttf { get; set; } = string.Empty;
        public string Woff { get; set; } = string.Empty;
        public string Woff2 { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
    }

    public class EudoAPI_ResultData
    {
        public string ExpirationDate { get; set; } = string.Empty;
        public string ServerDate { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public EudoAPI_UserInfos UserInfos { get; set; } = new EudoAPI_UserInfos();
        public EudoAPI_EudoFont EudoFont { get; set; } = new EudoAPI_EudoFont();
    }

    public class EudoAPI_ResultInfos
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ApiMessage { get; set; } = string.Empty;
        public int ErrorNumber { get; set; } = 0;
    }

    public class EudoAPI_UserInfos
    {
        public string UserAvatarUrl { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
        public int GroupId { get; set; } = 0;
        public string UserDisplayName { get; set; } = string.Empty;
        public string UserMail { get; set; } = string.Empty;
        public string UserTel { get; set; } = string.Empty;
        public string UserFax { get; set; } = string.Empty;
        public string UserMobile { get; set; } = string.Empty;
        public string UserFunction { get; set; } = string.Empty;
        public string UserAdress { get; set; } = string.Empty;
        public string UserZipCode { get; set; } = string.Empty;
        public string UserCity { get; set; } = string.Empty;
        public string UserCountry { get; set; } = string.Empty;
        public string UserSignature { get; set; } = string.Empty;
        public string UserOtherMail { get; set; } = string.Empty;
    }

    public class EudoAPI_Root
    {
        public EudoAPI_ResultInfos ResultInfos { get; set; } = new EudoAPI_ResultInfos();
        public EudoAPI_ResultData ResultData { get; set; } = new EudoAPI_ResultData();
    }

    public class EudoAPI_Rootobject
    {
        public EudoAPI_Resultinfos ResultInfos { get; set; } = new EudoAPI_Resultinfos();
        public EudoAPI_Resultdata ResultData { get; set; } = new EudoAPI_Resultdata();
        public EudoAPI_Resultmetadata ResultMetaData { get; set; } = new EudoAPI_Resultmetadata();
    }

    public class EudoAPI_Resultinfos
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ApiMessage { get; set; } = string.Empty;
        public int ErrorNumber { get; set; } = 0;
    }

    public class EudoAPI_Resultdata
    {
        public EudoAPI_Row[]? Rows { get; set; }
    }

    public class EudoAPI_Row
    {
        public bool DelAllowed { get; set; } = false;
        public EudoAPI_Field[]? Fields { get; set; }
        public int FileId { get; set; } = 0;
        public bool UpdateAllowed { get; set; } = false;
    }

    public class EudoAPI_Field
    {
        public string DbValue { get; set; } = string.Empty;
        public int DescId { get; set; } = 0;
        public bool UpdateAllowed { get; set; } = false;
        public int FileId { get; set; } = 0;
        public string Value { get; set; } = string.Empty;
        public bool ViewAllowed { get; set; } = false;
        public bool Mandatory { get; set; } = false;
    }

    public class EudoAPI_Resultmetadata
    {
        public EudoAPI_Table[]? Tables { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public int NumPage { get; set; }
        public int RowsByPage { get; set; }
    }

    public class EudoAPI_Table
    {
        public bool AddAllowed { get; set; } = false;
        public bool CalendarEnabled { get; set; } = false;
        public int HistoDescId { get; set; } = 0;
        public int DateDescId { get; set; } = 0;
        public int DescId { get; set; } = 0;
        public int EdnType { get; set; } = 0;
        public EudoAPI_Field1[]? Fields { get; set; }
        public string Icon { get; set; } = string.Empty;
        public EudoAPI_Iconinfo IconInfo { get; set; } = new EudoAPI_Iconinfo();
        public EudoAPI_Iconpj IconPJ { get; set; } = new EudoAPI_Iconpj();
        public EudoAPI_Iconnote IconNote { get; set; } = new EudoAPI_Iconnote();
        public EudoAPI_Icondescription IconDescription { get; set; } = new EudoAPI_Icondescription();
        public string Label { get; set; } = string.Empty;
        public int[]? EudoAPI_Links { get; set; }
        public EudoAPI_Linksinfo[]? LinksInfo { get; set; }
    }

    public class EudoAPI_Iconinfo
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class EudoAPI_Iconpj
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class EudoAPI_Iconnote
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class EudoAPI_Icondescription
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class EudoAPI_Field1
    {
        public int DescId { get; set; } = 0;
        public int Disporder { get; set; } = 0;
        public int EdnFormat { get; set; } = 0;
        public string Label { get; set; } = string.Empty;
        public bool Mandatory { get; set; } = false;
        public bool Multiple { get; set; } = false;
        public int PopupDescId { get; set; } = 0;
        public int PopupType { get; set; } = 0;
        public bool UpdateAllowed { get; set; } = false;
        public bool ViewAllowed { get; set; } = false;
        public int ImgStorage { get; set; } = 0;
        public EudoAPI_Iconinfo1 IconInfo { get; set; } = new EudoAPI_Iconinfo1();
        public string SocialNetworkRootUrl { get; set; } = string.Empty;
        public int Length { get; set; } = 0;
        public bool IsInConditionalRule { get; set; } = false;
    }

    public class EudoAPI_Iconinfo1
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class EudoAPI_Linksinfo
    {
        public int DescId { get; set; } = 0;
        public int Disporder { get; set; } = 0;
        public int EdnFormat { get; set; } = 0;
        public string Label { get; set; } = string.Empty;
        public bool Mandatory { get; set; } = false;
        public bool Multiple { get; set; } = false;
        public int PopupDescId { get; set; } = 0;
        public int PopupType { get; set; } = 0;
        public bool UpdateAllowed { get; set; } = false;
        public bool ViewAllowed { get; set; } = false;
        public int ImgStorage { get; set; } = 0;
        public EudoAPI_Iconinfo2 IconInfo { get; set; } = new EudoAPI_Iconinfo2();
        public string SocialNetworkRootUrl { get; set; } = string.Empty;
        public int Length { get; set; } = 0;
        public bool IsInConditionalRule { get; set; } = false;
    }

    public class EudoAPI_Iconinfo2
    {
        public string Address { get; set; } = string.Empty;
        public string Css { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }


    public class EudoAPI_Rootrequest
    {
        public bool ShowMetadata { get; set; } = false;
        public int RowsPerPage { get; set; } = 0;
        public int NumPage { get; set; } = 0;
        public int[]? ListCols { get; set; }
        public int FilterId { get; set; } = 0;
        public EudoAPI_Wherecustom? WhereCustom { get; set; }
        public EudoAPI_Orderby[]? OrderBy { get; set; }
    }

    public class EudoAPI_Wherecustom
    {
        public EudoAPI_Wherecustom[]? WhereCustoms { get; set; }
        public EudoAPI_Criteria? Criteria { get; set; }
        public int InterOperator { get; set; } = 0;
    }

    public class EudoAPI_Criteria
    {
        public int Operator { get; set; } = 0;
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class EudoAPI_Orderby
    {
        public int DescId { get; set; } = 0;
        public int Order { get; set; } = 0;
    }


    #endregion

    public class EudoAPI
    {
        private static readonly string _eudoAPIUrl = "http://sydenet2.eudonet.com/EudoAPI/";
        private static string _token = string.Empty;

        public bool Connect()
        {

            EudoAPI_Auth eudoAuth = new EudoAPI_Auth
            {
                SubscriberLogin = "SYDENET",
                SubscriberPassword = "$sydela!",
                BaseName = "EUDO_05983",
                UserLogin = "SYDELA_API",
                UserPassword = "Sydela$ig!",
                UserLang = "LANG_00",
                ProductName = "SIG_SYDELA",
                ExtendedProperties = true,
                UseRegionalSettings = true
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_eudoAPIUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;

            string credential = System.Text.Json.JsonSerializer.Serialize(eudoAuth);
            StringContent stringContent = new StringContent(credential, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("Authenticate/Token", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                EudoAPI_Root? authResult = JsonConvert.DeserializeObject<EudoAPI_Root>(result);
                if (authResult != null)
                {
                    if (authResult.ResultInfos.Success == true) _token = authResult.ResultData.Token;
                    return true;
                }

            }

            return false;
        }

        public static string QueryFast(int tableDescId, int fieldDescId, int whereFieldDescId, string whereFieldValue)
        {
            EudoAPI_Rootrequest request = new EudoAPI_Rootrequest();
            request.ShowMetadata = true;
            request.RowsPerPage = 10;
            request.ListCols = new int[] { fieldDescId };
            request.WhereCustom = new EudoAPI_Wherecustom();
            request.WhereCustom.Criteria = new EudoAPI_Criteria()
            {
                Operator = 0, // Operator '='
                Field = whereFieldDescId.ToString(),
                Value = whereFieldValue
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_eudoAPIUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-auth", _token);

            string jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
            StringContent stringContent = new StringContent(jsonRequest, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("Search/" + tableDescId.ToString(), stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                EudoAPI_Rootobject? reqResult = JsonConvert.DeserializeObject<EudoAPI_Rootobject>(result);
                if (reqResult != null)
                {
                    if (reqResult.ResultInfos.Success == true)
                    {
#pragma warning disable CS8602
                        return reqResult.ResultData.Rows[0].Fields[0].Value;
#pragma warning restore CS8602
                    }
                }

            }

            return string.Empty;

        }

        public static EudoAPI_Rootobject? QueryByCriteria(int tableDescId, int[] fieldsDescId, int whereFieldDescId, string whereFieldValue)
        {
            EudoAPI_Rootrequest request = new EudoAPI_Rootrequest();
            request.ShowMetadata = true;
            request.RowsPerPage = 10;
            request.ListCols = fieldsDescId;
            request.WhereCustom = new EudoAPI_Wherecustom();
            request.WhereCustom.Criteria = new EudoAPI_Criteria()
            {
                Operator = 0, // Operator '='
                Field = whereFieldDescId.ToString(),
                Value = whereFieldValue
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_eudoAPIUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-auth", _token);

            string jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
            StringContent stringContent = new StringContent(jsonRequest, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("Search/" + tableDescId.ToString(), stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                EudoAPI_Rootobject? reqResult = JsonConvert.DeserializeObject<EudoAPI_Rootobject>(result);
                if (reqResult != null)
                {
                    return reqResult;
                }
            }

            return null;

        }

        public static EudoAPI_Rootobject? QueryByCustoms(int tableDescId, int[] fieldDescId, int[] whereFieldsDescIds, string[] whereFieldsValues, int numPage = 0)
        {
            if (whereFieldsDescIds.Length != whereFieldsValues.Length) return null;
            if (whereFieldsDescIds.Length == 0) return null;

            EudoAPI_Wherecustom[] eudoAPI_Wherecustoms = new EudoAPI_Wherecustom[whereFieldsDescIds.Length];

            EudoAPI_Rootrequest request = new EudoAPI_Rootrequest();
            request.ShowMetadata = true;
            request.RowsPerPage = 50;
            request.ListCols = fieldDescId;
            request.NumPage = numPage;
            request.WhereCustom = new EudoAPI_Wherecustom();
            request.WhereCustom.Criteria = null;
            for (int i = 0; i < whereFieldsDescIds.Length; i++)
            {
                eudoAPI_Wherecustoms[i] = new EudoAPI_Wherecustom();
                eudoAPI_Wherecustoms[i].Criteria = new EudoAPI_Criteria()
                {
                    Operator = 0, // Operator '='
                    Field = whereFieldsDescIds[i].ToString(),
                    Value = whereFieldsValues[i]
                };
                eudoAPI_Wherecustoms[i].WhereCustoms = null;
                if (i == 0) eudoAPI_Wherecustoms[i].InterOperator = 0;
                else eudoAPI_Wherecustoms[i].InterOperator = 1; // Operator 'and'
            }
            request.WhereCustom.WhereCustoms = eudoAPI_Wherecustoms;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_eudoAPIUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-auth", _token);

            string jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
            StringContent stringContent = new StringContent(jsonRequest, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("Search/" + tableDescId.ToString(), stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                EudoAPI_Rootobject? reqResult = JsonConvert.DeserializeObject<EudoAPI_Rootobject>(result);
                if (reqResult != null) return reqResult;
            }
            return null;
        }

        public static EudoAPI_Rootobject? GetFile(int tableDescId, string fileId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_eudoAPIUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-auth", _token);

            HttpResponseMessage response = client.GetAsync("Search/" + tableDescId.ToString() + "/" + fileId).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                EudoAPI_Rootobject? reqResult = JsonConvert.DeserializeObject<EudoAPI_Rootobject>(result);
                if (reqResult != null)
                {
                    return reqResult;
                }

            }

            return null;
        }

        public bool Disconnect()
        {
            string URL = _eudoAPIUrl + "Authenticate/Disconnect";

            if (string.IsNullOrEmpty(_token)) return false;

            // Authenticate/Disconnect is a DELETE api with parameter in the header
            // Let's do it on an old fashioned way ...
#pragma warning disable SYSLIB0014 // remove the "OBSOLET CALL" warning
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
#pragma warning restore SYSLIB0014 
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Headers.Add("x-auth:" + _token);
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);

            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new(webStream);
                string response = responseReader.ReadToEnd();
                responseReader.Close();
                EudoAPI_Root? authResult = JsonConvert.DeserializeObject<EudoAPI_Root>(response);
                if (authResult != null)
                {
                    return authResult.ResultInfos.Success;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

    }
}
