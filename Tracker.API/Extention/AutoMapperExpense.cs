using AutoMapper;
using Tracker.API.RequestModels;
using Tracker.API.ResponseModels;
using Tracker.Data.Entities;

namespace Tracker.API.Extention
{
    public class AutoMapperExpense : Profile
    {
        public AutoMapperExpense()
        {
            CreateMap<Expense, ExpenseResponseDto>();
            CreateMap<ExpenseResponseDto, Expense>();
            
            CreateMap<Expense, ExpenseRequestDto>();
            CreateMap<ExpenseRequestDto, Expense>();

            CreateMap<CategoryRequest, Category>().ReverseMap();

            CreateMap<Due, Due>().ReverseMap();
            CreateMap<AddDueRequest, Due>().ReverseMap();

            CreateMap<EmailDto, ExpenseMail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ThreadId, opt => opt.MapFrom(src => src.ThreadId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Snippet))
                .ForMember(dest => dest.Gmail, opt => opt.MapFrom(src => "alerts@axisbank.com"))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

        }
    }
}
