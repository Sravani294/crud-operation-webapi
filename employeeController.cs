using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDoperations.Models;

namespace CRUDoperations.Controllers
{
    public class employeeController : ApiController
    {
        Entities db = new Entities();
        public string POST(Employe employ)
        {
            db.Employes.Add(employ);
            db.SaveChanges();
            return "Product added";
        }
        //Get All Records
        
        public IEnumerable<Employe> Get()
        {
            return db.Employes.ToList();
        }
        //Get single record
        public Employe Get(int id)
        {
            Employe employee = db.Employes.Find(id);
            return employee;
        }
        //updating the record
        public string PUT(int id, Employe employess)
        {
            var employess_ = db.Employes.Find(id);
            employess_.Name = employess.Name;
            employess_.Price = employess.Price;
            employess_.Quantity = employess.Quantity;
            employess_. Active = employess.Active;



            db.Entry(employess_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "employee details are updated";



        }
        //deleting the record
        public string DELETE(int id)
        {
            Employe employee = db.Employes.Find(id);
            db.Employes.Remove(employee);
            db.SaveChanges();
            return "record deleted successfully";
        }
    }
}
    

