using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarShopGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();

        BindingSource carListBinding = new BindingSource();
        BindingSource ShoppingListBinding = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            SetBindings();
        }

        private void SetBindings()
        {
            carListBinding.DataSource = store.CarList;
            listBox1.DataSource = carListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            ShoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = ShoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car newCar = new Car();
            newCar.Make = textBox1.Text;
            newCar.Model = textBox2.Text;
            try
            {
                newCar.Price = Decimal.Parse(textBox3.Text);
            }
            catch (FormatException InvalidInput)
            {
                MessageBox.Show("Invalid input in Car Price. Please enter a number for price.");
            }
            try
            {
                newCar.Year = int.Parse(textBox4.Text);
            }
            catch (FormatException InvalidInput)
            {

                MessageBox.Show("Invalid input in Car Year. Please enter a number for year.");
            }
            newCar.Color = textBox5.Text;

            store.CarList.Add(newCar);

            carListBinding.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);

            ShoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label5.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}