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
    public partial class Form1 : Form
    {
        private static IDataService _service;
        public Form1()
        {
            InitializeComponent();
            _service = new DataService();
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _service.GetAllProducts();
                grdDetails.DataSource = data;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Event handler: Its a instance of delegate EventHandler
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog(this);//displays as modal dialog, now allowing users to move back to the parent window.
        }
    }
}
