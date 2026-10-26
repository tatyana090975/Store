using Microsoft.AspNetCore.Identity;
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
        private readonly PasswordHasher<object> passwordHasher = new PasswordHasher<object>();
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
                DataTable res = DBQueries.CheckUser(login);

                if (res.Rows.Count != 1)
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
                
                string currentHash = res.Rows[0]["password"].ToString();
                
                var result = passwordHasher.VerifyHashedPassword(null, currentHash, password);

                if (result == PasswordVerificationResult.Success ||
                    result == PasswordVerificationResult.SuccessRehashNeeded)
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
