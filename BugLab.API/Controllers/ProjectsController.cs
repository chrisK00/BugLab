using BugLab.Shared.Queries;
using BugLab.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        public ProjectsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> Get(int id, CancellationToken cancellationToken)
        {
            var project = await _mediator.Send(new GetProjectQuery(id), cancellationToken);
            return project;
        }
    }
}
