using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErrorLog.Models;

namespace ErrorLog.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new ErrorLogContext();
            var errors = db.Errors.ToList();
            return View(errors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var error = new Error();
            return View(error);
        }

        [HttpPost]
        public ActionResult Create(Error model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var db = new ErrorLogContext();
            db.Errors.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == id);
            if (error == null)
                throw new Exception("Error not found");

            db.Errors.Remove(error);
            db.SaveChanges();


            return RedirectPermanent("/Errors/Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == id);
            if (error == null)
                return RedirectPermanent("/Errors/Index");

            return View(error);


           

        }

        [HttpPost]
        public ActionResult Edit(Error model)
        {
            var db = new ErrorLogContext();
            var error = db.Errors.FirstOrDefault(x => x.Id == model.Id);
            if (error == null)
            {
                ModelState.AddModelError("Id", "Ошибка не найдена");
            }

            if (!ModelState.IsValid)
                return View(model);

            MappingError(model, error);

            db.Entry(error).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Errors/Index");
        }


        private void MappingError(Error sourse, Error destination)
        {
            destination.ErrorCode = sourse.ErrorCode;
            destination.Type = sourse.Type;
            destination.Description = sourse.Description;
            destination.Solution = sourse.Solution;
            
        }
    }
}