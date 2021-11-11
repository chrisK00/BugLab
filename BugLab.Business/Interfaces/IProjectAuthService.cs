using System.Threading.Tasks;

namespace BugLab.Business.Interfaces
{
    public interface IProjectAuthService
    {
        Task HasAccess(string userId, int projectId);
    }
}
