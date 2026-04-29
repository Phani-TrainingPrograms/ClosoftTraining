using DataApplication.Models;
using DataApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataApplication.WinApp
{
    public partial class AddProduct : Form
    {
        private IDataService _service = new DataService();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //write the code to store to db
            try
            {
                var product = new Product();
                product.ProductId = Convert.ToInt32(txtID.Text);
                product.ProductName = txtName.Text;
                product.ProductPrice = Convert.ToDouble(txtCost.Text);
                product.ProductStock = Convert.ToInt32(txtStock.Text);
                _service.AddNewProduct(product);
                MessageBox.Show("Product added successfully");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
