namespace SpyMasterApi.Pact.Middleware.SpyMasterProviderState
{
    using HttpExtensions;
    using Microsoft.AspNetCore.Http;
    using Services;
    using Pact;

    public class SpyMasterProviderStateMiddleware : ProviderStateMiddleWare<IAgentsService>
    {
        private readonly SpyMasterInMemoryProviderStateSeeder _providerStateSeeder;

        public SpyMasterProviderStateMiddleware(RequestDelegate next) : base(next)
        {
            _providerStateSeeder = new SpyMasterProviderStateBuilder()
                .Build();
        }

        protected override void MatchProviderState(IAgentsService agentsService, HttpRequest request)
        {
            if (!request.HasBody()) return;
            var providerState = request.GetBodyAsync<ProviderState>();
             _providerStateSeeder.MatchSeedingAction(providerState, agentsService as InMemoryAgentsService);
        }
    }
}