namespace PortailTE44.Common.Models
{
	public class MailData
	{
        public List<string> To { get; set; } = default!;
        public List<string> Bcc { get; set; } = default!;

        public List<string> Cc { get; set; } = default!;

        public string? From { get; set; }

        public string? DisplayName { get; set; }

        public string? ReplyTo { get; set; }

        public string? ReplyToName { get; set; }

        public string Subject { get; set; } = default!;

        public string? Body { get; set; }

	}
}

