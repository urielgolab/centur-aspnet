namespace Datos
{
    using System.Configuration;
    using System.Security.Cryptography;
    using System.IO;

    partial class DC
    {
        public DC() :
            base((ConfigurationManager.ConnectionStrings["Moebius"].ConnectionString.Contains("Data Source") ? ConfigurationManager.ConnectionStrings["Moebius"].ConnectionString : desencriptarConexion(ConfigurationManager.ConnectionStrings["Moebius"].ConnectionString, ConfigurationManager.ConnectionStrings["clavePublica"].ConnectionString)), mappingSource)
            {
            //Este constructor es para que tome la conexion del App.Config o Web.Config
            OnCreated();
            }

        public static string desencriptarConexion(string cryptedString, string clavePublica)
        {
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(clavePublica);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }


    }
           
}
