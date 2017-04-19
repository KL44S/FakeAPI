using ExampleDesktop.Exceptions;
using ExampleDesktop.Services;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void SetLoginError(String Message)
        {
            this.UsernameTxt.Text = String.Empty;
            this.PasswordTxt.Text = String.Empty;
            this.ErrorMessage.Text = Message;
        }

        private void LaunchMainForm()
        {
            this.Hide();
            var MainForm = new MainForm();
            MainForm.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                User User = new User();
                User.UserId = this.UsernameTxt.Text;
                User.Password = this.PasswordTxt.Text;

                String ApiResourcePath = Statics.Statics.ApiPath + "User";

                IRESTService<User> RESTService = new BasicRESTService<User>();
                RESTService.SetPath(ApiResourcePath);

                User = RESTService.PostEntity(User);
                Statics.Statics.Token = User.Token;

                this.LaunchMainForm();
            }
            catch(NotResourceFoundException)
            {
                this.SetLoginError("No se encotró ningún usuario/contraseña");
            }
            catch(InternalErrorException)
            {
                this.SetLoginError("Error al intentar logear");
            }
        }
    }
}
