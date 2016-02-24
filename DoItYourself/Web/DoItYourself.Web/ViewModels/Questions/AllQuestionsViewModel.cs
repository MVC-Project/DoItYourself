namespace DoItYourself.Web.ViewModels.Questions
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AllQuestionsViewModel : IMapFrom<Question>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string CreatedOn { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Question, AllQuestionsViewModel>()
               .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content.Substring(0, 100) + "..."));

            configuration.CreateMap<Question, AllQuestionsViewModel>()
               .ForMember(x => x.Author, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));

            configuration.CreateMap<Question, AllQuestionsViewModel>()
               .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));

            configuration.CreateMap<Question, AllQuestionsViewModel>()
               .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn.Day.ToString() + "/" + x.CreatedOn.Month.ToString() + "/" + x.CreatedOn.Year.ToString()));
        }
    }
}
