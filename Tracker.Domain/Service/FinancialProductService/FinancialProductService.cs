using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Context;
using Tracker.Data.Entities;

namespace Tracker.Domain.Service.FinancialProductService
{
    public class FinancialProductService : IFinancialProductService
    {
        private readonly TrackerContext _dbContext;
        private readonly IMapper _mapper;

        public FinancialProductService(TrackerContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public FinancialProduct AddFinancialProduct(FinancialProduct financialProduct)
        {
            try
            {
                _dbContext.FinancialProducts.Add(financialProduct);
                _dbContext.SaveChanges();

                return financialProduct;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public FinancialProduct DeleteFinancialProduct()
        {
            throw new NotImplementedException();
        }

        public FinancialProduct GetFinancialProductById(Guid id)
        {
            FinancialProduct? financialProduct = _dbContext.FinancialProducts.SingleOrDefault(f => f.FinancialProductID == id);

            return financialProduct ?? throw new KeyNotFoundException($"Invalid Financial Product ID: {id}");
        }

        public List<FinancialProduct> GetFinancialProductList()
        {
            List<FinancialProduct> data = _dbContext.FinancialProducts.ToList();

            return data;
        }

        public FinancialProduct UpdateFinancialProduct(Guid id, UpdateFinancialProductDto financialProduct)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be empty.");
            }

            if (financialProduct == null)
            {
                throw new ArgumentNullException(nameof(financialProduct), "Request cannot be null.");
            }

            var existingProduct = _dbContext.FinancialProducts.Find(id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Could not find the Financial Product for the ID: {id}");
            }

            // Update the existing entity with the values from the parameter
            _mapper.Map(financialProduct, existingProduct);


            _dbContext.SaveChanges();

            return existingProduct;
        }

    }
}
