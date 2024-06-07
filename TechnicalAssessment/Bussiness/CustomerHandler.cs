using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Domain.DataContext;
using TechnicalAssessment.Domain.Models;
using TechnicalAssessment.Domain.ViewModels;

namespace TechnicalAssessment.Bussiness
{
    internal interface ICustomerHandler
    {
        Task<bool> CreateCustomer(string name);

        Task<IList<CustomerViewModel>> GetCustomerList();
        Task<CustomerViewModel> GetCustomer(int id);
    }

    internal class CustomerHandler:ICustomerHandler
    {
        private readonly DatabaseContext _context;


        public CustomerHandler()
        {
            _context = new DatabaseContext();
        }

        public async Task<bool> CreateCustomer(string name)
        {
            try
            {

                var model = new Customer()
                {
                    Name = name,
                    IsActive = true

                };

                _context.Customers.Add(model);
                var addedRows = await _context.SaveChangesAsync();
                if (addedRows <= 0)
                {
                    throw new AppException("Customer could not be created");

                }
                return true;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public async Task<IList<CustomerViewModel>> GetCustomerList()
        {

            var query = await (from o in _context.Customers
                               select new CustomerViewModel()
                               {
                                   CustomerName = o.Name,
                                   CustomerId = o.CustomerId,
                                   IsActive = o.IsActive

                               }).ToListAsync();


            return query;

        }

        public async Task<CustomerViewModel> GetCustomer(int id)
        {

            if (id <= 0)
            {
                throw new AppException("Customer could not be found");
            }

            var cust = await _context.Customers.FindAsync(id);

            if (cust == null)
                throw new AppException("Customer could not be found");



            return new CustomerViewModel
            {
                CustomerId = cust.CustomerId,
                CustomerName = cust.Name,
                IsActive = cust.IsActive
            };

        }

    }
}
