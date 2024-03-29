﻿using BugLab.Shared.Responses;
using MediatR;
using System.Collections.Generic;

namespace BugLab.Business.Queries.Sprints
{
    public class GetSprintsQuery : IRequest<IEnumerable<SprintForListResponse>>
    {
        public GetSprintsQuery(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; }
    }
}
