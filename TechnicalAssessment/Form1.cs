using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnicalAssessment.Bussiness;
using TechnicalAssessment.Domain.ViewModels;

namespace TechnicalAssessment
{
    public partial class Form1 : Form
    {

        private readonly IOrderHeadHandler orderHeadHandler;
        private readonly IOrderDetailHandler orderDetailHandler;
        public Form1()
        {
            orderDetailHandler = new OrderDetailHandler();
            orderHeadHandler = new OrderHeadHandler();
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderHeadSave_Click(object sender, EventArgs e)
        {
            var vm = new OrderHeadViewModel()
            {
                CustomerName = txtCustomerName.Text,
            };
            orderHeadHandler.CreateOrderHead(vm);
        }

        private void btnOrderHeadClear_Click(object sender, EventArgs e)
        {

            var vm = new OrderDetailViewModel(){ 
                
                OrderNum =int.Parse(cmbOrderNum.Text),
                Item = txtItem.Text, 
                Qty = (int)txtQuantity.Value,
                Price = (double)txtPrice.Value
                };
            orderDetailHandler.CreateOrderDetail(vm);

        }
    }
}
