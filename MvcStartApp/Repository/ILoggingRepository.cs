using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Repository
{
    public interface ILoggingRepository
    {
        Task AddRequest(Request request);

        Task<Request[]> GetRequests();
    }
}
