using KasaLibrary;
using KasaLibrary.DataAccess;
using KasaLibrary.Models;
using Microsoft.Build.Framework;
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
        private readonly ILogger _logger;
        readonly List<ProductModel> products = GlobalConfig.Connection.CreateProducts();
        CartModel cart = new CartModel();

        public KasaPanel(ILogger<KasaPanel> logger)
        {
            _logger = logger;
            InitializeComponent();
            AddButtons(products);
        }

        private void UpdateListBox()
        {
            KoszykListBox.DataSource = cart.ProductsInside.ToList();
            KoszykListBox.DisplayMember = "NameQuantityPrice";

            KoszykLabel.Text = $"KOSZYK - {cart.TotatPrice:C}";
        }

        private void AddButtons(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                Button button = new Button
                {
                    Name = $"{product.Id}",
                    Text = $"{product.Name + "\n" + product.Price.ToString("C")}",
                    Font = new Font(Button.DefaultFont.FontFamily.Name, 14),
                    Size = new Size(200, 100),
                    Location = new Point(40, 40)
                };

                ProductsPanel.Controls.Add(button);
                button.Click += new EventHandler(Btn_Click);
            }
        }      
        
        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string strName = button.Name;
            int numId = Int16.Parse(strName);

            AddToCart(cart, products, numId);

            UpdateListBox();
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
                string output = CartSummary(cart);
                Console.WriteLine(output);
                MessageBox.Show($"Dziękuję za zakup! Koszt: {cart.TotatPrice:C}.", "Koszyk");
                cart = new CartModel();
                UpdateListBox();
            }
        }

        private ProductModel SelectProductById(List<ProductModel> products, int id)
        {
            ProductModel outputProduct = null;
            outputProduct = products.Where(x => x.Id == id).FirstOrDefault();
            return outputProduct;
        }

        private CartModel AddToCart(CartModel cart, List<ProductModel> products, int id)
        {
            ProductModel proudct = SelectProductById(products, id);
            if(!ChceckIfElementInCart(cart, proudct))
            {
                CartElementModel cartElement = new CartElementModel()
                {
                    Product = proudct,
                    Quantity = 1
                };
                cart.ProductsInside.Add(cartElement);
            }
            else
            {
                foreach (CartElementModel cartElement in cart.ProductsInside)
                {
                    if (cartElement.Product.Id == id)
                    {
                        cartElement.Quantity += 1;
                    }
                }
            }
            
            return cart;
        }

        private bool ChceckIfElementInCart(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel cartElement in cart.ProductsInside)
            {
                if (cartElement.Product.Id == product.Id)
                    return true;
            }
            return false;
        }

        private void IncrementItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel cartElement in cart.ProductsInside)
            {
                if (cartElement.Product.Id == product.Id)
                {
                    cartElement.Quantity += 1;
                    UpdateListBox();
                    return;
                }
            }
        } 
        
        private void DecrementItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel cartElement in cart.ProductsInside)
            {
                if (cartElement.Product.Id == product.Id)
                {
                    cartElement.Quantity -= 1;
                    UpdateListBox();
                    return;
                }
            }
        }

        private void RemoveItem(CartModel cart, ProductModel product)
        {
            foreach (CartElementModel cartElement in cart.ProductsInside)
            {
                if (cartElement.Product.Id == product.Id)
                {
                    cart.ProductsInside.Remove(cartElement);
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


        private string CartSummary(CartModel cart)
        {
            string output = string.Empty;
            foreach (CartElementModel cartElement in cart.ProductsInside)
            {
                output += "Id: " + cartElement.Product.Id + ", quantity:" + cartElement.Quantity + ";";
            }
            return output;
        }
    }
}
