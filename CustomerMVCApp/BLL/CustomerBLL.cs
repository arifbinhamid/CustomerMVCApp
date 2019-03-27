using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CustomerMVCApp.Models;
using CustomerMVCApp.Repository;

namespace CustomerMVCApp.BLL
{
    public class CustomerBLL
    {
        CustomerRepository customerRepo = new CustomerRepository();

        public bool Add(Customer customer)
        {
            bool add = customerRepo.Add(customer);

            return add;


        }

        public string Exist(Customer acustomer)
        {
            string exist = customerRepo.Exist(acustomer);
            return exist;
        }

        public bool Update(Customer customer)
        {
            bool updated = customerRepo.Update(customer);

            return updated;
        }

        public bool Delete(Customer acustomer, string exist)
        {
            bool deleted = customerRepo.Delete(acustomer, exist);

            return deleted;
        }

        public DataTable Show()
        {
            DataTable dataTable = new DataTable();
            dataTable = customerRepo.Show();
            return dataTable;
        }

        public DataTable Show(string name)
        {
            DataTable dataTable = new DataTable();
            dataTable = customerRepo.Show(name);
            return dataTable;
        }
    }
}