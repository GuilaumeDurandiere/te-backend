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

        public MailData(List<string> to,
            string subject,
            string? body = null,
            string? from = null,
            string? displayName = null,
            string? replyTo = null,
            string? replyToName = null,
            List<string>? bcc = null,
            List<string>? cc = null)
        {
            // Receiver
            To = to;
            Bcc = bcc ?? new List<string>();
            Cc = cc ?? new List<string>();

            // Sender
            From = from;
            DisplayName = displayName;
            ReplyTo = replyTo;
            ReplyToName = replyToName;

            // Content
            Subject = subject;
            Body = body;
        }

    }
}

