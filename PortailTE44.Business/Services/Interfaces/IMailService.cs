using PortailTE44.Common.Models;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IMailService
	{

        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    }
}

