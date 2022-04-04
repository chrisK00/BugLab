using BugLab.Data.Entities;
using BugLab.Shared.Responses;
using Mapster;

namespace BugLab.Business.Helpers
{
    public class Mappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Bug, BugResponse>()
               .Map(dest => dest.ProjectTitle, src => src.Project.Title);

            config.Default.MapToConstructor(true);
        }
    }
}
