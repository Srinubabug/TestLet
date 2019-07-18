using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testlet.DAL;

namespace TestletWebApp.Controllers
{
    public class TestLetController : Controller
    {
        private ITestLetItemRepository _testLetItemRepository;

        public TestLetController(ITestLetItemRepository testLetItemRepository)
        {
            _testLetItemRepository = testLetItemRepository;
        }

       

        // GET: TestLet
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestLet/Details/5
        public ActionResult GetTestLetItems()
        {
            
            return View(_testLetItemRepository.GetTestLetItems());
        }

        // GET: TestLet/Details/5
        public ActionResult GetRandomTestLetItems()
        {
            return View(_testLetItemRepository.GetRandomizeItems());
        }


        // GET: TestLet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestLet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestLet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestLet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestLet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestLet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
