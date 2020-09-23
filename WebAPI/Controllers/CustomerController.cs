using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]

        public List<Customer> Get()
        {
            List<Customer> cust = new List<Customer>();
            cust.Add(new Customer()
            {
                CUSTOMERNAME = "Moni",
                MOBILENO = "2776776",
                ADDRESS = "Nagpur"
            });
            
            return cust;
        }
        //public IHttpActionResult GetAllCustomers()
        //{
        //    IList<Customer> customers = null;
        //    using (var ctx = new DataAccess())
        //    {
        //        customers = ctx.Customers.ToList();
        //    }
        //    if (customers.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customers);
        //}
        [HttpGet]
        public IHttpActionResult GetCustomer(int ID)
        {
            Customer customers = null;
            using (var ctx = new DataAccess())
            {
                customers = ctx.Customers.SingleOrDefault(s => s.ID == ID);
            }
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        [HttpPut]
        public IHttpActionResult PutCustomer(Customer Cutomer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            using (var ctx = new DataAccess())
            {
                var existingStudent = ctx.Customers.Where(s => s.ID == Cutomer.ID)
                                                          .FirstOrDefault<Customer>();
                if (existingStudent != null)
                {
                    existingStudent.CUSTOMERNAME = Cutomer.CUSTOMERNAME;
                    existingStudent.MOBILENO = Cutomer.MOBILENO;
                    existingStudent.ADDRESS = Cutomer.ADDRESS;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
        [HttpPost]

        public Customer Post(Customer obj)
        {
            obj.CUSTOMERNAME = obj.CUSTOMERNAME.ToUpper();
            obj.MOBILENO = obj.MOBILENO;
            obj.ADDRESS = obj.ADDRESS.ToUpper();

            return obj;
        }
        //public IHttpActionResult PostNewCustomer(CustomerDetail Cutomer)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid Data");

        //    using (var ctx = new DataAccess())
        //    {
        //        ctx.CustomerDetails.Add(Cutomer);
        //        ctx.SaveChanges();
        //    }
        //    return Ok();
        //}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int ID)
        {
            if (ID <= 0)
                return BadRequest("Invalid Customer ID");

            using (var ctx = new DataAccess())
            {
                var student = ctx.Customers.Where(s => s.ID == ID).FirstOrDefault();
                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
