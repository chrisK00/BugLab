using System.Threading.Tasks;

namespace BugLab.Business.Interfaces
{
    public interface IAuthService
    {
        Task HasAccessToProject(string userId, int projectId);
        Task HasAccessToBug(string userId, int id);
    }
}
