using System.Threading.Tasks;
using Ui.Models;

namespace Ui.Services.Interfaces
{
   

    public interface IFlowerService
    {
        Task<PaginatedResponse<TResponse>> GetAllPaginated<TResponse>(int page);
        Task<TResponse> Get<TResponse>(string id);
        Task<CreateResponse> Create<TRequest>(TRequest request);
        Task Update<TRequest>(TRequest request, string id);
        Task Delete(string id);
        Task<CreateResponse> CreateFromForm<TRequest>(TRequest request);
    }

}
