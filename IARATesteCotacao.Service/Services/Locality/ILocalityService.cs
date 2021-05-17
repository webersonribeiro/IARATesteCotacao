using System.Threading.Tasks;

namespace IARATesteCotacao.Business.Services.Locality
{
    public interface ILocalityService
    {
        Task<LocalityAddress> GetByCep(string cep);
    }
}
