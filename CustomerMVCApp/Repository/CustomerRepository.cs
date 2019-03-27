using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using CustomerMVCApp.Models;

namespace CustomerMVCApp.Repository
{
    public class CustomerRepository
    {
        private static string _conStr = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        private static SqlConnection _con = new SqlConnection(_conStr);
        private SqlCommand _cmd = new SqlCommand("", _con);
        DataTable dt = new DataTable();

        public bool Add(Customer customer)
        {

            bool inserted = false;
            try
            {
                string query = @"INSERT INTO Customers(Name,Code,Address,Email,Contact,Age,LoyalityPoint) VALUES('" +
                               customer.Name + "','" + customer.Code + "','" + customer.Address + "','" + customer.Email +
                               "','" + customer.Contact + "','"+customer.Age+"','"+customer.LoyalityPoint+"')";

                _cmd.CommandText = query;
                _con.Open();
                int saved = _cmd.ExecuteNonQuery();
                if (saved>0)
                {
                    inserted = true;
                }
                _con.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
           
            
            return inserted;
        }

        public string Exist(Customer acustomer)
        {
            string msg = "";
           // bool exist = false;
            try
            {
                string query = @"SELECT Id FROM Customers WHERE Code='" + acustomer.Code + "'";

                _cmd.CommandText = query;
                _con.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_cmd);

                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    msg = dt.Rows[0].ItemArray[0].ToString();
                }
                _con.Close();
            }
            catch (Exception e)
            {
                
                throw e;
            }

            return msg;
        }

        public bool Update(Customer customer)
        {
            
            bool updated = false; 
            try
            {
                string query = @"UPDATE Customers SET Name='" + customer.Name + "', Address ='" + customer.Address +
                               "',Email ='" + customer.Email + "',Contact ='" + customer.Contact + "',Age='" +
                               customer.Age + "',LoyalityPoint ='" + customer.LoyalityPoint + "' WHERE Code ='"+customer.Code+"'";

                _cmd.CommandText = query;
                _con.Open();

                int update = _cmd.ExecuteNonQuery();

                if (update > 0)
                {
                    updated = true;
                }


                _con.Close();

            }
            catch (Exception e)
            {
                
                throw e;
            }

            return updated;
        }

        public bool Delete(Customer acustomer, string exist)
        {
            bool deleted = false;
            int id = Convert.ToInt32(exist);
            try
            {
                string query = @"DELETE FROM Customers WHERE ID ='" + id + "'";

                _cmd.CommandText = query;
                _con.Open();

                int del = _cmd.ExecuteNonQuery();
                if (del > 0)
                {
                    deleted = true;
                }

                _con.Close();
            }
            catch (Exception e)
            {
               
                throw e;
            }

            return deleted;
        }

        public DataTable  Show()
        {
            try
            {
              string query = @"SELECT * FROM Customers";

              _cmd.CommandText = query;
              _con.Open();
              SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_cmd);
              DataTable dat = new DataTable();
              sqlDataAdapter.Fill(dat);


              _con.Close();
              
              return dat;
            }
            catch (Exception e)
            {
                
                throw e;
            }
           
        }

        public DataTable Show(string name)
        {
            try
            {
                string query = @"SELECT * FROM Customers WHERE Name ='"+name+"'";

                _cmd.CommandText = query;
                _con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_cmd);
                DataTable dat = new DataTable();
                sqlDataAdapter.Fill(dat);


                _con.Close();

                return dat;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}