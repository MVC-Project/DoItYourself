namespace DoItYourself.Web.ViewModels.Projects
{
    using System;
    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class AllProjectsViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Project, AllProjectsViewModel>()
               .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content.Substring(0, 150) + "..."));

            configuration.CreateMap<Project, AllProjectsViewModel>()
               .ForMember(x => x.ImagePath, opt => opt.MapFrom(x => x.Image.Path));
        }
    }
}
