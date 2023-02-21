using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prog122_lecture9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Preload();
        }
        void Preload()
        {
            rbSmallP.IsChecked = true;
            rbSmallD.IsChecked = true;
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            runReciept.Text = txtCustomer.Text + "\n";
            double amount = 0;

            bool hasPepperoni = cbPepperoni.IsChecked.Value;
            bool hasExtraCheese = cbCheese.IsChecked.Value;
            bool hasMushrooms = cbMushrooms.IsChecked.Value;
            bool hasPineapple = cbPineapple.IsChecked.Value;

            bool sizeSmall = rbSmallP.IsChecked.Value;
            bool sizeMedium = rbMediumP.IsChecked.Value;
            bool sizeLarge = rbLargeP.IsChecked.Value;
            bool sizeExtraLarge = rbEXP.IsChecked.Value;

            bool drinkSmall = rbSmallD.IsChecked.Value;
            bool drinkMedium = rbMediumD.IsChecked.Value;
            bool drinkLarge = rbLargeD.IsChecked.Value;
            bool drinkXL = rbEXD.IsChecked.Value;

            double price = 0;
            // Check for pizza size
            if (sizeSmall)
            {
                price = 13;
                runReciept.Text += "Small";
            }
            else if (sizeMedium)
            {
                price = 15;
                runReciept.Text += "Medium";

            }
            else if (sizeLarge)
            {
                price = 18;
                runReciept.Text += "Large";

            }
            else if (sizeExtraLarge)
            {
                runReciept.Text += "Extra Large";
                price = 20;

            }


            runReciept.Text += " - " + price.ToString("c");
            amount += price;

            runReciept.Text += "\nToppings: \n";

            if (hasPepperoni == true)
            {
                double toppingPrice = 4;
                runReciept.Text += $"Pepperoni - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if (hasExtraCheese)
            {
                double toppingPrice = 5;
                runReciept.Text += $"Extra Cheese - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }

            if (hasMushrooms)
            {
                double toppingPrice = 2;
                runReciept.Text += $"Mushrooms - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;

            }

            if (hasPineapple)
            {
                double toppingPrice = 20;
                runReciept.Text += $"Pineapple - {toppingPrice.ToString("c")}\n";
                amount += toppingPrice;
            }


            // CHeck for drink size'
            runReciept.Text += "\nDrink Size: ";

            if (drinkSmall)
            {
                double drinkPrice = 2;
                runReciept.Text += $"Small Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkMedium)
            {
                double drinkPrice = 2.69;
                runReciept.Text += $"Medium Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkLarge)
            {
                double drinkPrice = 3.25;
                runReciept.Text += $"Large Drink - {drinkPrice.ToString("c")}\n";
                amount += drinkPrice;
            }
            else if (drinkXL)
            {
                double drinkPrice = 7.50;
                //runReciept.Text += $"XL Drink - {drinkPrice.ToString("c")}\n";
                FormatItem("XL Drink", drinkPrice);
                amount += drinkPrice;
            }

            double taxAmount = .1;
            double calculatedTax = amount * taxAmount;
            double totalAmount = amount + calculatedTax;



            runReciept.Text += $"\n\n" +
                $"Subtotal: {amount.ToString("c")}\n" +
                $"Tax Amount: {calculatedTax.ToString("c")}\n" +
                $"Total Price: {totalAmount.ToString("c")} ";
        }
        public string FormatItem(string item, double amount)
        {

            return $"{item} - {amount.ToString("c")}\n";

        }

    }
}
