namespace SpyMasterApi.Pact
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using PactNet;
    using PactNet.Infrastructure.Outputters;
    using Xunit;
    using Xunit.Abstractions;
    using Middleware.SpyMasterProviderState;
    using XUnit;

    public class SpyMasterApiShould
    {
        private readonly ITestOutputHelper _output;

        public SpyMasterApiShould(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public async Task HonourPactWithSpyLens()
        {
            var baseAddress = $"http://localhost:8088";
            var webHost = WebHost
                .CreateDefaultBuilder()
                .UseKestrel()
                .UseStartup<TestStartup>()
                .UseUrls(baseAddress)
                .Build();

            await webHost.StartAsync();

            var pactVerifierConfig = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                }  ,
                ProviderVersion = "1.0.0",
                PublishVerificationResults = !string.IsNullOrEmpty("1.0.0")
            };
            IPactVerifier pactVerifier = new PactVerifier(pactVerifierConfig);
            
            pactVerifier                    
                .ProviderState($"{baseAddress}/{SpyMasterProviderStateMiddleware.ProviderStatePath}")
                .ServiceProvider("SpyMasterApi", baseAddress)
                .HonoursPactWith("SpyLens JS Frontend")
                .PactUri(@"http://localhost:8082/pacts/provider/SpyMaster%20Api/consumer/SpyLens%20JS%20Frontend/latest")
                .Verify();
            await webHost.StopAsync();

        }
    }
}
