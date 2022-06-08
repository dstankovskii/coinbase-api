using Coinbase.Commerce;
using Coinbase.Commerce.Models;
using Microsoft.Extensions.DependencyInjection;

namespace COINBASE.API
{
    public class Program
    {
        public const string _apiKey = "***";

        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped(_ => new CommerceApi(_apiKey));

            var container = services.BuildServiceProvider();

            var _coinbaseApi = container.GetRequiredService<CommerceApi>();

            var charge = new CreateCharge
            {
                Name = "Test Name",
                Description = "Test Description",
                PricingType = PricingType.FixedPrice,
                LocalPrice = new Money { Amount = 5.5m, Currency = "USD" },
                Metadata =
                {
                    { "id", "2AIQZ3VHPuPBpJ1ByoUkwlqTcYD" }
                }
            };

            var response = await _coinbaseApi.CreateChargeAsync(charge);
        }
    }
}