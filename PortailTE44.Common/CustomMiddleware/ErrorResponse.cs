namespace PortailTE44.Common.CustomMiddleware
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = default!;
        public string? Message { get; set; }
    }
}
