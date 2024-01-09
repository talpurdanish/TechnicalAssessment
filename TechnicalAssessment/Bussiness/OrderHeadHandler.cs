using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Domain;
using TechnicalAssessment.Domain.DataContext;
using TechnicalAssessment.Domain.Models;
using TechnicalAssessment.Domain.ViewModels;

namespace TechnicalAssessment.Bussiness
{

    internal interface IOrderHeadHandler
    {
        Task<bool> CreateOrderHead(OrderHeadViewModel viewModel);

        Task<IList<OrderHeadViewModel>> GetOrderHeadList();
    }

    internal class OrderHeadHandler : IOrderHeadHandler
    {
        private readonly DatabaseContext _context;


        public OrderHeadHandler()
        {
            _context = new DatabaseContext();
        }

        public async Task<bool> CreateOrderHead(OrderHeadViewModel viewModel)
        {
            try
            {

                var model = new OrderHead()
                {
                    CustomerName = viewModel.CustomerName,
                    CreatedDate = DateTime.Now
                };

                _context.OrderHeads.Add(model);
                var addedRows = await _context.SaveChangesAsync();
                if (addedRows <= 0)
                {
                    throw new AppException("Todo could not be created");

                }
                return true;
            }
            catch (Exception e)
            {
                throw new AppException(e.Message);
            }
        }

        public async Task<IList<OrderHeadViewModel>> GetOrderHeadList()
        {
            var query = (from o in _context.OrderHeads

                         select new OrderHeadViewModel()
                         {
                             OrderNum = o.OrderNum,
                             CustomerName = o.CustomerName,
                             CreatedDate = o.CreatedDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                         });
            return await query.ToListAsync();
        }


    }
}
