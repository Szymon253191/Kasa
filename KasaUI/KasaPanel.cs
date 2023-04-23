using KasaLibrary;
using KasaLibrary.DataAccess;
using KasaLibrary.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaUI
{
    public partial class KasaPanel : Form
    {
        readonly List<ProductModel> products = GlobalConfig.Connection.CreateProducts();
        readonly CartModel cart = new CartModel();

        public KasaPanel()
        {
            InitializeComponent();

            AddButtons(products);

            WireUpList();
        }

        private void WireUpList()
        {
            KoszykListBox.DataSource = null;
            KoszykListBox.DataSource = cart.ProductsInside;
        }

        private void AddButtons(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                Button btn = new Button();
                btn.Name = $"{product.Id}";
                btn.Text = product.Name;
                btn.Font = new Font(Button.DefaultFont.FontFamily.Name, 14);
                btn.Size = new Size(200, 100);
                btn.Location = new Point(40, 40);
                ProductsPanel.Controls.Add(btn);
                Console.WriteLine(btn.Name);
                btn.Click += new EventHandler(Btn_Click);
            }
        }      
        
        private void Btn_Click(object sender, EventArgs e)
        {
            // TODO add functionality to buttons
            // sender.Name = product.Id
            // Add product.Where(x => x.Id == sender.Name) to listBox
            // WireUpList() to be Updated after every click

            Button cb = (Button)sender;
            string strName = cb.Name;
            Console.WriteLine(strName);
            int numId = Int16.Parse(strName);
            //cart.Add(products.Where(x => x.Id == numId));
        }
    }
}
