using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls;
using System.Diagnostics;
using System.Globalization;

namespace WPFDataGrid
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {        
        public Window1()
        {
            InitializeComponent();
        }
     
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {            
                LoadCustomers();                        
        }

        private void LoadCustomers()
        {
            
            CustomersDataContext cd = new CustomersDataContext();
            var customers = (from p in cd.Customers
                             select p).Take(10);
            MyDataGrid.ItemsSource = customers;
            LoadButton.Content = "Customers Loaded";
        }
       
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomersDataContext dataContext = new CustomersDataContext();
                Customer customerRow = MyDataGrid.SelectedItem as Customer;
                string m = customerRow.CustomerID;
                Customer customer = (from p in dataContext.Customers
                                     where p.CustomerID == customerRow.CustomerID
                                     select p).Single();
                customer.CompanyName = customerRow.CompanyName;
                customer.ContactName = customerRow.ContactName;
                customer.Country = customerRow.Country;
                customer.City = customerRow.City;
                customer.Phone = customerRow.Phone;
                dataContext.SubmitChanges();
                MessageBox.Show("Row Updated Successfully.");
                LoadCustomers();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {           
            CustomersDataContext cd = new CustomersDataContext();
            Customer customerRow = MyDataGrid.SelectedItem as Customer;
            var customer = (from p in cd.Customers
                            where p.CustomerID == customerRow.CustomerID
                            select p).Single();
            cd.Customers.DeleteOnSubmit(customer);
            cd.SubmitChanges();
            MessageBox.Show("Row Deleted Successfully.");
            LoadCustomers();
        }      
       
    }
}
