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
using TechnicalAssessment.Domain.Models;
using TechnicalAssessment.Domain.ViewModels;

namespace TechnicalAssessment
{
    public partial class Form1 : Form
    {

        private readonly IOrderHeadHandler orderHeadHandler;
        private readonly IOrderDetailHandler orderDetailHandler;
        private readonly ICustomerHandler customerHandler;
        public Form1()
        {
            orderDetailHandler = new OrderDetailHandler();
            orderHeadHandler = new OrderHeadHandler();
            customerHandler = new CustomerHandler();
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

        private void btnOrderHeadSave_ClickAsync(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter a valid Customer Name");
            }
            else
            {

                try
                {
                    customerHandler.CreateCustomer(txtCustomerName.Text);
                    MessageBox.Show("Customer has been creatd");

                }
                catch (AppException ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnOrderHeadClear_Click(object sender, EventArgs e)
        {


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDetail_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtItem.Text))
            {
                MessageBox.Show("Please enter a valid Item");
            }
            else if (txtQuantity.Value <= 0)
            {
                MessageBox.Show("Please enter a valid Quantity");
            }
            else if (txtPrice.Value <= 0)
            {
                MessageBox.Show("Please enter a valid Price");
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewItems);

                row.Cells[0].Value = txtItem.Text;
                row.Cells[1].Value = txtQuantity.Value;
                row.Cells[2].Value = txtPrice.Value;
                dataGridViewItems.Rows.Add(row);
            }
        }

        private void btnClearDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add some items");
            }

            else
            {

                try
                {
                    var ovm = new OrderHeadViewModel()
                    {
                        CustomerId = cmbCustomer.SelectedIndex,
                        CreatedDate = DateTime.Now.ToString("MM/dd/yyyy"),

                    };

                    orderHeadHandler.CreateOrderHead(ovm);

                    foreach (DataRow row in dataGridViewItems.Rows)
                    {
                        var vm = new OrderDetailViewModel()
                        {

                            OrderNum = ovm.OrderNum,
                            Item = row.ItemArray[0].ToString(),
                            Qty = int.Parse(row.ItemArray[1].ToString()),
                            Price = double.Parse(row.ItemArray[2].ToString())
                        };
                        orderDetailHandler.CreateOrderDetail(vm);

                    }

                    MessageBox.Show("Customer has been creatd");

                }
                catch (AppException ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }
    }
}
