using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMVCApp.BLL;
using CustomerMVCApp.Models;
using System.Text;
using System.Web.UI.WebControls;

namespace CustomerMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerBLL customerBLL = new CustomerBLL();
        public string Add(string Name, string Code, string Address, string Email, string Contact, int Age,
            int LoyalityPoint)
        {
            Customer acustomer = new Customer();
            acustomer.Name = Name;
            acustomer.Code = Code;
            acustomer.Address = Address;
            acustomer.Email = Email;
            acustomer.Contact = Contact;
            acustomer.Age =Convert.ToInt32(Age);
            acustomer.LoyalityPoint = Convert.ToInt32(LoyalityPoint);
            string exist = customerBLL.Exist(acustomer);
            string exmsg;
            if (exist !=null)
            {
                exmsg = "Customer already Exist";
                return exmsg;
            }
            
            bool saved =customerBLL.Add(acustomer);
           
            string msg="UnsuccessFull Operation";
            if (saved)
            {
                msg = "successfuull Operation";
            }
            return msg;
        }

        public string Update(string Name, string Code, string Address, string Email, string Contact, int Age,
            int LoyalityPoint)
        {
            Customer acustomer = new Customer();
            acustomer.Name = Name;
            acustomer.Code = Code;
            acustomer.Address = Address;
            acustomer.Email = Email;
            acustomer.Contact = Contact;
            acustomer.Age = Convert.ToInt32(Age);
            acustomer.LoyalityPoint = Convert.ToInt32(LoyalityPoint);

            string exist = customerBLL.Exist(acustomer);
            
            string  msg = "Customer Not Exist";
            if (exist == null)
            {
                return msg;
            }
               
            bool updated = customerBLL.Update(acustomer);
            
            if (updated)
                {
                    msg = "Customer Updated";
                }
            

            return msg;
        }

        public string Delete(string Code)
        {
            Customer acustomer = new Customer();

            acustomer.Code = Code;

            string exist = customerBLL.Exist(acustomer);

            string msg = "Customer Not Exist";
            if (exist == null)
            {
                return msg;
            }

            bool deleted = customerBLL.Delete(acustomer,exist);

            if (deleted)
            {
                msg = "Deleted Successfully";
            }

            return msg;
        }

        public ActionResult Show()
        {

            DataTable dt = new DataTable();
            dt = customerBLL.Show();

            return View(dt);

        }

        //public ActionResult show(string Name)
        //{
        //    DataTable dt = new DataTable();
        //    dt = customerBLL.Show(Name);
        //    return View(dt);
        //}
        
        //
        // GET: /Customer/
        //public ActionResult Index()
        //{
        //    return View();
        //}
	}
}