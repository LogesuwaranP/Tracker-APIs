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

        }
    }
}
