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
        readonly List<ProductModel> products = GlobalConfig.Connection.CreateProducts();
        CartModel cart = new CartModel();

        public KasaPanel()
        {
            InitializeComponent();

            AddButtons(products);
        }

        private void UpdateListBox()
        {
            KoszykListBox.DataSource = cart.ProductsInside.ToList();
            KoszykListBox.DisplayMember = "NameQuantityPrice";

            KoszykLabel.Text = $"KOSZYK - {(cart.TotatPrice).ToString("C")}";
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
                btn.Click += new EventHandler(Btn_Click);
            }
        }      
        
        private void Btn_Click(object sender, EventArgs e)
        {
            Button cb = (Button)sender;
            string strName = cb.Name;
            Console.WriteLine(strName);
            int numId = Int16.Parse(strName);

            AddToCart(cart, products, numId);

            UpdateListBox();
        }

        private ProductModel SelectProductById(List<ProductModel> p, int id)
        {
            ProductModel product = null;
            product = p.Where(x => x.Id == id).FirstOrDefault();
            return product;
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

        private void IncrementItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel ce in cart.ProductsInside)
            {
                if (ce.Product.Id == product.Id)
                {
                    ce.Quantity += 1;
                    UpdateListBox();
                    return;
                }
            }
        } 
        
        private void DecrementItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel ce in cart.ProductsInside)
            {
                if (ce.Product.Id == product.Id)
                {
                    ce.Quantity -= 1;
                    UpdateListBox();
                    return;
                }
            }
        }

        private void RemoveItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel ce in cart.ProductsInside)
            {
                if (ce.Product.Id == product.Id)
                {
                    cart.ProductsInside.Remove(ce);
                    UpdateListBox();
                    return;
                }
            }
        }

        private void SetSelectedListBox(CartElementModel element)
        {
            int index = KoszykListBox.Items.IndexOf(element);
            if (index >= 0)
                KoszykListBox.SetSelected(index, true);
        }

        private void PlusCartButton_Click(object sender, EventArgs e)
        {
            if (KoszykListBox.SelectedItem == null)
            {
                return;
            }

            CartElementModel selectedCartItem = (CartElementModel)KoszykListBox.SelectedItem;
            ProductModel selectedProduct = selectedCartItem.Product;

            IncrementItem(cart, selectedProduct);
            SetSelectedListBox(selectedCartItem);

        }

        private void MinusCartButton_Click(object sender, EventArgs e)
        {
            if (KoszykListBox.SelectedItem == null)
            {
                return;
            }

            CartElementModel selectedCartItem = (CartElementModel)KoszykListBox.SelectedItem;
            ProductModel selectedProduct = selectedCartItem.Product;

            if (selectedCartItem.Quantity <= 1)
            {
                DialogResult result = MessageBox.Show("Czy chcesz usunąć przedmiot?", "Koszyk", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                else if (result == DialogResult.Yes)
                {
                    RemoveItem(cart, selectedProduct);
                }
            }
            DecrementItem(cart, selectedProduct);
            SetSelectedListBox(selectedCartItem);
        }

        private void DeleteCartButton_Click(object sender, EventArgs e)
        {
            if (KoszykListBox.SelectedItem == null)
            {
                return;
            }

            CartElementModel selectedCartItem = (CartElementModel)KoszykListBox.SelectedItem;
            ProductModel selectedProduct = selectedCartItem.Product;

            RemoveItem(cart, selectedProduct);
        }

        private void CompleteCartButton_Click(object sender, EventArgs e)
        {
            if (KoszykListBox.Items.Count == 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Czy chcesz potwierdzić zakup?", "Koszyk", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            else if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Dziękuję za zakup! Koszt: { cart.TotatPrice.ToString("C") }.", "Koszyk");
                string output = CartSummary(cart);
                Console.WriteLine(output);
                cart = new CartModel();
                UpdateListBox();
            }
        }

        private string CartSummary(CartModel cart)
        {
            string output = string.Empty;
            foreach (CartElementModel element in cart.ProductsInside)
            {
                output += "Id: " + element.Product.Id + ", quantity:" + element.Quantity + ";";
            }
            return output;
        }
    }
}
