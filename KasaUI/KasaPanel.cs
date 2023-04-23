using KasaLibrary;
using KasaLibrary.DataAccess;
using KasaLibrary.Models;
using Microsoft.SqlServer.Server;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KasaUI
{
    
    public partial class KasaPanel : Form
    {
        readonly string cartDetails = "{0, -15}{0,-5}{0,-8}";
        readonly List<ProductModel> products = GlobalConfig.Connection.CreateProducts();
        readonly CartModel cart = new CartModel();

        public KasaPanel()
        {
            InitializeComponent();

            AddButtons(products);
        }

        private void UpdateListBox()
        {
            // TODO Change print method to using KoszykListBox.DataSource. It help with selected item later on

            KoszykListBox.Items.Clear();

            // Loop through the cart elements and add each item to the ListBox
            foreach (CartElementModel element in cart.ProductsInside)
            {
                string itemName = element.Product.Name;
                int itemQuantity = element.Quantity;

                // Format the item name and quantity as a string and add it to the ListBox
                string itemText = $"{itemName,-20} {itemQuantity} szt. {(element.Product.Price * itemQuantity).ToString("C")}";
                KoszykListBox.Items.Add(itemText);
            }

            KoszykLabel.Text = $"KOSZYK - {(cart.TotatPrice).ToString("C")}";
        }

        private void UpdateListBoxTest()
        {
            // TODO creation solution that no clears listbox.
            // It causes listbox to reset position after update and user need to scroll again to end

            KoszykListBox.Items.Clear();
            foreach (CartElementModel element in cart.ProductsInside)
            {
                string itemName = element.Product.Name;
                int itemQuantity = element.Quantity;

                KoszykListBox.Items.Add(string.Format(cartDetails, itemName, itemQuantity, (element.Product.Price * itemQuantity).ToString("C")));
            }
        }

        private void AddButtons(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                Button btn = new Button();
                btn.Name = $"{product.Id}";
                btn.Text = $"{product.Name +"\n"+ product.Price.ToString("C")}";
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

            if (CheckIfCartIs(cart))
                Console.WriteLine("THERE IS A CART");

            AddToCart(cart, products, numId);

            UpdateListBox();
        }

        private ProductModel SelectProductById(List<ProductModel> p, int id)
        {
            ProductModel product = null;
            product = p.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        private bool CheckIfCartIs(CartModel cart)
        {
            if (cart == null)
                return false;
            else
                return true;
        }

        private CartModel AddToCart(CartModel cart, List<ProductModel> products, int id)
        {
            ProductModel p = SelectProductById(products, id);
            if(!ChceckIfElementInCart(cart,p))
            {
                CartElementModel cartElement = new CartElementModel()
                {
                    Product = p,
                    Quantity = 1
                };
                cart.ProductsInside.Add(cartElement);
            }
            else
            {
                foreach (CartElementModel ce in cart.ProductsInside)
                {
                    if (ce.Product.Id == id)
                    {
                        ce.Quantity += 1;
                    }
                }
            }
            
            return cart;
        }

        private bool ChceckIfElementInCart(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel c in cart.ProductsInside)
            {
                if (c.Product.Id == product.Id)
                    return true;
            }
            return false;
        }

        private void PlusCartButton_Click(object sender, EventArgs e)
        {
            if(KoszykListBox.SelectedItem == null)
            {
                return;
            }

            string productId =  KoszykListBox.SelectedItem.GetType().ToString();
            int numId = int.Parse(productId);

            if (productId == null) 
            {
                MessageBox.Show("Nie można dodać produktu.");
                return;
            }

            foreach (CartElementModel ce in cart.ProductsInside)
            {
                if (ce.Product.Id == numId)
                {
                    ce.Quantity += 1;
                    return;
                }
                
            }

        }
    }
}
