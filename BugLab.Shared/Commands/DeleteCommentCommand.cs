using MediatR;

namespace BugLab.Shared.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public DeleteCommentCommand(int bugId, int commentId)
        {
            BugId = bugId;
            CommentId = commentId;
        }

        public int BugId { get; }
        public int CommentId { get; }
    }
}
