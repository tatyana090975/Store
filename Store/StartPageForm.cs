using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class StartPageForm : Form
    {
        public StartPageForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void employeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EmployeForm form = new EmployeForm();
            form.ShowDialog();
        }

        private void personLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonForm form = new PersonForm();
            form.ShowDialog();
        }

        private void usersLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UsersForm form = new UsersForm();
            form.ShowDialog();
        }

        private void positionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PositionForm form = new PositionForm();
            form.ShowDialog();
        }

        private void ownershipLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OwnershipForm form = new OwnershipForm();
            form.ShowDialog();
        }

        private void saleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaleForm form = new SaleForm();
            form.ShowDialog();
        }

        private void sevicesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ServicesForm form = new ServicesForm();
            form.ShowDialog();
        }

        private void deliveryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeliveryForm form = new DeliveryForm();
            form.ShowDialog();
        }

        private void counteragentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CounteragentForm form = new CounteragentForm();
            form.ShowDialog();
        }

        private void supplierLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SupplierProductsForm form = new SupplierProductsForm();
            form.ShowDialog();
        }

        private void tradeMarginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TradeMarginForm form = new TradeMarginForm();
            form.ShowDialog();
        }

        private void productLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();
        }

        private void counteragentLinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CounteragentForm counteragentForm = new CounteragentForm();
            counteragentForm.ShowDialog();
        }

        private void colorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorForm form = new ColorForm();
            form.ShowDialog();
        }

        private void elementLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ElementForm form = new ElementForm();
            form.ShowDialog();
        }

        private void materialLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaterialForm form = new MaterialForm();
            form.ShowDialog();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductMaterialForm form = new ProductMaterialForm();
            form.ShowDialog();
        }
    }
}
