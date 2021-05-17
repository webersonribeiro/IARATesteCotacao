using Flurl.Http;
using IARATesteCotacao.Business.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.Services.Locality
{
    public class LocalityService : ILocalityService
    {
        private IConfiguration _configuration;

        public LocalityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LocalityAddress> GetByCep(string cep)
        {
            var api = _configuration.GetSection("ExternalApis").Get<ExternalApis>();

            var url = $"{ api.ViaCep }{cep}/json";

            return await url.GetJsonAsync<LocalityAddress>();

            //return JsonConvert.DeserializeObject<LocalityAddress>(response);

        }
    }
}
