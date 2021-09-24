using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEmployees.Domain.Entities;
using WebEmployees.Domain.Interfaces;
using System.Text.Json;

namespace WebEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult ListEmployees()
        {
            try
            {
               
                return View(_employeeRepository.GetAllEmployyes());
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeRepository.AddEmployeeRepository(employee);
                return RedirectToAction("Home");
            }
            catch
            {
                return View("Home");
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _employeeRepository.GetEmployeeById(id);
            return View(data);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                _employeeRepository.EditEmployes(employee);
                return RedirectToAction("ListEmployees");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(Employee employee)
        {
            try
            {
                _employeeRepository.RemoveEmployes(employee);
                return RedirectToAction("ListEmployees");
            }
            catch
            {
                return View("Home");
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            return View("Home");
        }
    }
}
