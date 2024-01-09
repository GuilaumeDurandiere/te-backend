namespace PortailTE44.Common.Utils
{
    public class ConvertHelper
    {
        public static string? BytesToBase64(byte[]? bytesArray)
        {
            return bytesArray != null ? Convert.ToBase64String(bytesArray) : default;
        }

        public static byte[]? Base64ToBytes(string? base64)
        {
            return !string.IsNullOrEmpty(base64) ? Convert.FromBase64String(base64) : default;
        }
    }
}
