using System;

namespace BugLab.Shared.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public UserResponse CreatedBy { get; set; }
        public UserResponse ModifiedBy { get; set; }
    }
}