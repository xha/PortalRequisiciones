namespace Datos.Helpers
{
    public class AppSettings
    {
        public string SECRET_KEY { get; set; }
        public string AUDIENCE_TOKEN { get; set; }
        public string ISSUER_TOKEN { get; set; }
        public string EXPIRE_MINUTES { get; set; }
        public string SQLSRVTIMEOUT { get; set; }
    }
}