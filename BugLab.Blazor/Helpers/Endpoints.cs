namespace BugLab.Blazor.Helpers
{
    public static class Endpoints
    {
        public const string Auth = "/api/auth";
        public const string Bugs = "/api/bugs";
        public const string Projects = "/api/projects";
        public const string Token = "/api/token";
        public const string Users = "/api/users";

        public static string BugTypes(int projectId) => $"{Projects}/{projectId}/bugTypes";
        public static string Sprints(int projectId) => $"{Projects}/{projectId}/sprints";
        public static string Comments(int bugId) => $"{Bugs}/{bugId}/comments";
        public static string ProjectUsers(int projectId) => $"{Projects}/{projectId}/projectUsers";
    }
}