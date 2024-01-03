using System;
namespace PortailTE44.Common.Models
{
	public class MailData
	{
        public List<string> To { get; }
        public List<string> Bcc { get; }

        public List<string> Cc { get; }

        public string? From { get; }

        public string? DisplayName { get; }

        public string? ReplyTo { get; }

        public string? ReplyToName { get; }

        public string Subject { get; }

        public string? Body { get; }

        public MailData()
		{
		}
	}
}

