using MediatR;

namespace BugLab.Business.Commands.Comments
{
    public class DeleteCommentCommand : IRequest
    {
        public DeleteCommentCommand(int commentId, int bugId)
        {
            CommentId = commentId;
            BugId = bugId;
        }

        public int CommentId { get; }
        public int BugId { get; }
    }
}
