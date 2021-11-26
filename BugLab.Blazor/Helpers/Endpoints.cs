namespace BugLab.Blazor.Helpers
{
    public static class Endpoints
    {
        public const string Projects = "/api/projects";
        public const string Bugs = "/api/bugs";
        public const string Auth = "/api/auth";
        public const string Users = "/api/users";

        public static string Comments(int bugId)
        {
            return $"{Bugs}/{bugId}/comments";
        }

        public static string BugTypes(int projectId)
        {
            return $"{Projects}/{projectId}/bugTypes";
        }

        public static string ProjectUsers(int projectId)
        {
            return $"{Projects}/{projectId}/projectUsers";
        }
    }
}
