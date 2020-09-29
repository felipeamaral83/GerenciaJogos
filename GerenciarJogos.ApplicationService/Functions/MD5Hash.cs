using System.Security.Cryptography;
using System.Text;

namespace GerenciaJogos.ApplicationService.Functions
{
    public static class MD5Hash
    {
        public static string Generate(string value)
        {
            var md5Hasher = MD5.Create();
            var stringBuilder = new StringBuilder();
            byte[] encryptedValue = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));

            for (int i = 0; i < encryptedValue.Length; i++)
                stringBuilder.Append(encryptedValue[i].ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
