namespace votClient.HttpMessageHandler
{
    public class AddHeadersDelegatingHandler: DelegatingHandler
    {
        public AddHeadersDelegatingHandler() : base(new HttpClientHandler())
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-MyTestHeader", "MyValue");  // Add whatever headers you want here
            Console.WriteLine("X-MyTestHeader");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
