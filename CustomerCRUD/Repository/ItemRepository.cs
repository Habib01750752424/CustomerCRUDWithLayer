using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerCRUD.Repository
{
    public class ItemRepository
    {
        string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";

        public bool Add(string name, string address, string contact)
        {
            bool isAdd = false;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "INSERT INTO Customer(CustomerName, Address,Contact)" +
                "VALUES('" + name + "', '" + address + "','" + contact + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isAdd = true;
            }
            sqlConnection.Close();
            return isAdd;
        }

        public bool isNameExist(string name)
        {
            bool isExisName = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT CustomerName FROM Customer WHERE CustomerName = '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);


            if (isFill > 0)
            {
                isExisName = true;
            }
            return isExisName;
        }

        public bool CheckIfNumeric(string input)
        {
            return input.IsNumeric();
        }

        public DataTable Display()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Customer ORDER BY ID ASC";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;

        }

        public bool UpdateCustomer(int id, string name, string address, string contact)
        {
            bool isUpdate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "UPDATE Customer SET CustomerName = '" + name + "', Address = '" + address + "',Contact = '" + contact + "'" +
                "WHERE ID = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isUpdate = true;
            }

            sqlConnection.Close();
            return isUpdate;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = "DELETE FROM Customer WHERE ID = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isDelete = true;
            }
            sqlConnection.Close();

            return isDelete;
        }

        public DataTable Search(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Customer WHERE CustomerName = '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }




    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}
