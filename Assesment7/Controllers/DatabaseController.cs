using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assesment7.Models;

namespace Assesment7.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            PartyDBEntities ORM = new PartyDBEntities();
            ViewBag.GuestList = ORM.Guests.ToList();
            return View();
            
        }
         public ActionResult AddGuest()
        {
            return View();
        }
        public ActionResult SaveGuest(Guest newGuest)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            
            if (newGuest != null)
            {
                ORM.Guests.Add(newGuest);
                ORM.SaveChanges();
            }


            return RedirectToAction("Summary", newGuest);
        }
        public ActionResult Summary(Guest guest)
        {
           
            return View(guest);
        }
        public ActionResult EditGuest(int GuestID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest found = ORM.Guests.Find(GuestID);

            return View(found);
        }
        public ActionResult SaveGuestChanges(Guest updatedGuest)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest oldGuest = ORM.Guests.Find(updatedGuest.GuestID);
            oldGuest.FirstName = updatedGuest.FirstName;
            oldGuest.LastName = updatedGuest.LastName;
            oldGuest.AttendanceDate = updatedGuest.AttendanceDate;
            oldGuest.EmailAddress = updatedGuest.EmailAddress;
            oldGuest.Guest1 = updatedGuest.Guest1;
           

            ORM.Entry(oldGuest).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteGuest(int GuestID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest found = ORM.Guests.Find(GuestID);

            ORM.Guests.Remove(found);
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DishList()
        {
            PartyDBEntities ORM = new PartyDBEntities();
            ViewBag.DishList = ORM.Dishes.ToList();
            return View();

        }
        public ActionResult AddDish()
        {
            return View();
        }
        public ActionResult SaveDish(Dish newDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();

            if (newDish != null)
            {
                ORM.Dishes.Add(newDish);
                ORM.SaveChanges();
            }


            return RedirectToAction("DishSummary", newDish);
        }







        public ActionResult DishSummary(Dish dish)
        {
            
            return View(dish);
        }
        public ActionResult EditDish(int DishID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish found = ORM.Dishes.Find(DishID);

            return View(found);
        }
        public ActionResult SaveDishChanges(Dish updatedDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish oldDish = ORM.Dishes.Find(updatedDish.DishID);
            oldDish.PersonName = updatedDish.PersonName;
            oldDish.PhoneNumber = updatedDish.PhoneNumber;
            oldDish.DishName = updatedDish.DishName;
            oldDish.DishDescription = updatedDish.DishDescription;
            oldDish.Options = updatedDish.Options;
            


            ORM.Entry(oldDish).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("DishList");
        }
        public ActionResult DeleteDish(int DishID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish found = ORM.Dishes.Find(DishID);

            ORM.Dishes.Remove(found);
            ORM.SaveChanges();

            return RedirectToAction("DishList");
        }
    }
}