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

    internal interface IOrderDetailHandler
    {
        Task<bool> CreateOrderDetail(OrderDetailViewModel viewModel);

        Task<IList<OrderDetailViewModel>> GetOrderDetailList(int id = -1);
    }

    internal class OrderDetailHandler : IOrderDetailHandler
    {
        private readonly DatabaseContext _context;


        public OrderDetailHandler()
        {
            _context = new DatabaseContext();
        }

        public async Task<bool> CreateOrderDetail(OrderDetailViewModel viewModel)
        {
            try
            {

                var model = new OrderDtl()
                {
                    OrderNum = viewModel.OrderNum,
                    Item = viewModel.Item,
                    Price = viewModel.Price,
                    Qty = viewModel.Qty,

                };

                _context.OrderDetails.Add(model);
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

        public async Task<IList<OrderDetailViewModel>> GetOrderDetailList(int id = -1)
        {

            var query = (from o in _context.OrderDetails

                         select new OrderDetailViewModel()
                         {
                             OrderNum = o.OrderNum,
                             Item = o.Item,
                             Price = o.Price,
                             Qty = o.Qty,

                         });

            if (id > -1)
            {
                return await query.Where(o => o.OrderNum == id).ToListAsync();

            }
            else
            {
                return await query.ToListAsync();
            }
        }


    }
}
