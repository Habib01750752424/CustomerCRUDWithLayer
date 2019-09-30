using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerCRUD.BLL;

namespace CustomerCRUD
{
    public partial class CustomerUI : Form
    {
        ItemManager _itemManager = new ItemManager();
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            contactTextBox.Clear();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string contact = contactTextBox.Text;

            if (name == "" || address == "" || contact == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (_itemManager.CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Item name, not numeric value.");
                nameTextBox.Clear();
                return;
            }
            if (_itemManager.isNameExist(name))
            {
                MessageBox.Show("Customer is Already exist..");
                return;
            }

            if (_itemManager.Add(name, address, contact))
            {
                MessageBox.Show("Saved Successfully");
                Clear();
                showDataGridView.DataSource = _itemManager.Display();
                return;
            }
            else
            {
                MessageBox.Show("Not Saved Data, Check Inserting Details");
            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _itemManager.Display();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Text);
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string contact = contactTextBox.Text;

            if (name == "" || address == "" || contact == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }
            else if (_itemManager.CheckIfNumeric(name))
            {
                MessageBox.Show("Please enter Customer name, not numeric value.");
                nameTextBox.Text = "";
                return;
            }

            if (_itemManager.UpdateCustomer(id, name, address, contact))
            {
                MessageBox.Show("Customer Updated Successfully");
                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated,,Please Check Updating Details..");
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextBox.Text);
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please Select Id Field..");
                return;
            }

            if (_itemManager.Delete(id))
            {
                showDataGridView.DataSource = _itemManager.Display();
                MessageBox.Show("Customer Deleted Successfully..");
                return;
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            idTextBox.Text = showDataGridView[0, e.RowIndex].Value.ToString();
            nameTextBox.Text = showDataGridView[1, e.RowIndex].Value.ToString();
            addressTextBox.Text = showDataGridView[2, e.RowIndex].Value.ToString();
            contactTextBox.Text = showDataGridView[3, e.RowIndex].Value.ToString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            if (name == "")
            {
                MessageBox.Show("Field must not be empty..");
                return;
            }

            showDataGridView.DataSource = "";
            showDataGridView.DataSource = _itemManager.Search(name);
            return;
        }
    }
}
