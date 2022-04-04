using MediatR;
using System;

namespace BugLab.Business.Commands.Sprints
{
    public class AddSprintCommand : IRequest<int>
    {
        public AddSprintCommand(int projectId, string title, DateTime startDate, DateTime endDate)
        {
            ProjectId = projectId;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int ProjectId { get; }
        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
