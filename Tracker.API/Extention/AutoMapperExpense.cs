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

            CreateMap<GetFinancialProduct, FinancialProduct>().ReverseMap();
            CreateMap<FinancialProductResponse, FinancialProduct>().ReverseMap();
            CreateMap<UpdateFinancialProductDto, FinancialProduct>().ReverseMap();

            CreateMap<GroupRequest, Group>().ReverseMap();

            CreateMap<CategoryRequest, Category>().ReverseMap();

        }
    }
}
