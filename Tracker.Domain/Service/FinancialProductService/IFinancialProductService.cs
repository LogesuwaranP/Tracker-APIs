using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Entities;

namespace Tracker.Domain.Service.FinancialProductService
{
    public interface IFinancialProductService
    {
        public List<FinancialProduct> GetFinancialProductList();
        public FinancialProduct AddFinancialProduct(FinancialProduct financialProduct);
        public FinancialProduct GetFinancialProductById(Guid id);
        public FinancialProduct UpdateFinancialProduct(Guid id, UpdateFinancialProductDto financialProduct);
        public FinancialProduct DeleteFinancialProduct();
    }
}
