﻿using BugLab.Shared.Responses;
using MediatR;

namespace BugLab.Shared.Queries
{
    public class GetBugQuery : IRequest<BugResponse>
    {
        public GetBugQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
