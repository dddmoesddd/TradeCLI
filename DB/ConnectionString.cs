using System.Text;

namespace TradeCLI.DB
{
    public static   class ConnectionString
    {
        public static  string Server = string.Empty;
        public static string DataBaseName=string.Empty;
        public static string UserName =string.Empty;
        public static string Password = string.Empty;
        public static StringBuilder sb = new StringBuilder("Server=");
        public static string CreateConnetionString()
        {
         
            sb.Append(Server);
            sb.Append(";");
            sb.Append("User ID=");
            sb.Append(UserName);
            sb.Append(";");
            sb.Append("password =");
            sb.Append(Password);
            sb.Append(";");
            sb.Append("DataBase =");
            sb.Append(DataBaseName);
            sb.Append(";");
            sb.Append("TrustServerCertificate=True");

            return sb.ToString();
        }


  

    }
}
