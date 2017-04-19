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
    public partial class MainForm : Form
    {
        private Product _product;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadProduct()
        {
            String ApiResourcePath = Statics.Statics.ApiPath + "Product";
            String ProductId = "1";

            IRESTService<Product> RESTProductService = new BasicRESTService<Product>();
            RESTProductService.SetPath(ApiResourcePath);

            this._product = RESTProductService.GetEntityById(ProductId);
        }

        private void SetError(String Message)
        {
            this.ProductDescription.Text = String.Empty;
            this.ProductId.Text = String.Empty;
            this.ErrorMessage.Text = Message;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadProduct();
                this.ProductDescription.Text = this._product.ProductDescription;
                 this.ProductId.Text = this._product.ProductId;
            }
            catch (NotResourceFoundException)
            {
                this.SetError("No se encotró ningún usuario/contraseña");
            }
            catch (InternalErrorException)
            {
                this.SetError("Error al intentar logear");
            }
        }
    }
}
