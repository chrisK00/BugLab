using MediatR;

namespace BugLab.API.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
    }
}
