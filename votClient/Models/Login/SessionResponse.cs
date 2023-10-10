namespace votClient.Models.Login
{
    public class SessionResponse
    {
        public string userName { get; set; }
        public string token { get; set; }
        public string status { get; set; }
        public string errorMessage { get; set; }
    }
}
