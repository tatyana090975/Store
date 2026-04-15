using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class LoginForm : Store.ParentCardForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        protected override void OKButton_Click(object sender, EventArgs e)
        {
            string login = nameTextBox.Text;
            string password = passwordTextBox.Text;                
            if (login == "" || password == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                DataTable res = DBQueries.CheckUser(login, password);

                if (res.Rows.Count == 1)
                {
                    StartPageForm startPageForm = new StartPageForm();
                    startPageForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!"); 
                }
            }            
        }
    }
}
