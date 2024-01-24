namespace PortailTE44.Exchange.CustomMiddleware
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = default!;
        public string? Message { get; set; }
    }
}
