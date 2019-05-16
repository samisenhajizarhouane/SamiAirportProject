using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportLogicTier;

namespace WebAirport.Controllers
{
    public class HomeController : Controller
    {
        private db_AirportEntities db = new db_AirportEntities();

        // GET: Home
        public ActionResult IndexD()
        {
           tbl_Flight a = new tbl_Flight();
            return View(a.getDepartures().ToList());
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListVols()
        {
            tbl_Flight a = new tbl_Flight();
            return View(a.getAll().ToList());
        }
        public ActionResult IndexA()
        {
            tbl_Flight a = new tbl_Flight();
            return View(a.getArrives().ToList());
        }


        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Flight tbl_Flight = db.tbl_Flight.Find(id);
            if (tbl_Flight == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Flight);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.idtbl_Airplane = new SelectList(db.tbl_Airplane, "idtbl_Airplane", "Name");
            ViewBag.FromCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name");
            ViewBag.ToCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name");
            ViewBag.idtbl_Company = new SelectList(db.tbl_Company, "idtbl_Company", "Name");
            ViewBag.idRoute = new SelectList(db.tbl_Route, "idRoute", "idRoute");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtbl_Flight,FlightNumber,FromCity,ToCity,DepartureDate,ArrivalDate,idtbl_Airplane,idtbl_Company,StopOver,Status,idRoute")] tbl_Flight tbl_Flight)
        {


            if (ModelState.IsValid)
            {
                db.tbl_Flight.Add(tbl_Flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idtbl_Airplane = new SelectList(db.tbl_Airplane, "idtbl_Airplane", "Name", tbl_Flight.idtbl_Airplane);
            ViewBag.FromCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.FromCity);
            ViewBag.ToCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.ToCity);
            ViewBag.idtbl_Company = new SelectList(db.tbl_Company, "idtbl_Company", "Name", tbl_Flight.idtbl_Company);
            ViewBag.idRoute = new SelectList(db.tbl_Route, "idRoute", "idRoute", tbl_Flight.idRoute);
            return View(tbl_Flight);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Flight tbl_Flight = db.tbl_Flight.Find(id);
            if (tbl_Flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.idtbl_Airplane = new SelectList(db.tbl_Airplane, "idtbl_Airplane", "Name", tbl_Flight.idtbl_Airplane);
            ViewBag.FromCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.FromCity);
            ViewBag.ToCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.ToCity);
            ViewBag.idtbl_Company = new SelectList(db.tbl_Company, "idtbl_Company", "Name", tbl_Flight.idtbl_Company);
            ViewBag.DepartureDate = new SelectList(db.tbl_Flight, "DepartureDate", "DepartureDate", tbl_Flight.DepartureDate);
            ViewBag.ArrivalDate = new SelectList(db.tbl_Flight, "ArrivalDate", "ArrivalDate", tbl_Flight.ArrivalDate);

            ViewBag.idRoute = new SelectList(db.tbl_Route, "idRoute", "idRoute", tbl_Flight.idRoute);
            return View(tbl_Flight);
        }



        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtbl_Flight,FlightNumber,FromCity,ToCity,DepartureDate,ArrivalDate,idtbl_Airplane,idtbl_Company,StopOver,Status,idRoute")] tbl_Flight tbl_Flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idtbl_Airplane = new SelectList(db.tbl_Airplane, "idtbl_Airplane", "Name", tbl_Flight.idtbl_Airplane);
            ViewBag.FromCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.FromCity);
            ViewBag.ToCity = new SelectList(db.tbl_Airport, "idtbl_Airport", "Name", tbl_Flight.ToCity);
            ViewBag.idtbl_Company = new SelectList(db.tbl_Company, "idtbl_Company", "Name", tbl_Flight.idtbl_Company);
            ViewBag.idRoute = new SelectList(db.tbl_Route, "idRoute", "idRoute", tbl_Flight.idRoute);
            ViewBag.Flight = new SelectList(db.tbl_Flight, "DepartureDate", "DepartureDate", tbl_Flight.DepartureDate);

            return View(tbl_Flight);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Flight tbl_Flight = db.tbl_Flight.Find(id);
            if (tbl_Flight == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Flight);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Flight tbl_Flight = db.tbl_Flight.Find(id);
            db.tbl_Flight.Remove(tbl_Flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
