using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebEmployees.Domain.Entities;
using Newtonsoft.Json;
using WebEmployees.Domain.Interfaces;
using System.Text;

namespace WebEmployees.Controllers
{
    public class FileController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        public FileController(IEmployeeRepository employeeRepository, IWebHostEnvironment appEnvironment)
        {
            _employeeRepository = employeeRepository;
            _appEnvironment = appEnvironment;
        }
        

        
        public ActionResult Upload()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IFormFile file)
        {
            try
            {
                List<string> logger = new List<string>();
                bool result = false;

                if (file != null)
                {
                    
                    List<Employee> listEmployees = null;
                    using (var fileData = file.OpenReadStream())
                    {
                        string data = new StreamReader(fileData).ReadToEnd();
                        try
                        {
                            listEmployees = JsonConvert.DeserializeObject<List<Employee>>(data);
                        }catch
                        {
                            listEmployees = new List<Employee>();
                            
                            listEmployees.Add(JsonConvert.DeserializeObject<Employee>(data));
                        }
                    }
                    if (listEmployees != null)
                    {
                        foreach (var empl in listEmployees)
                        {
                            
                            try
                            {
                                if (empl.PersonnelNumber != 0 && !empl.StaffMember)
                                {
                                    //todo error
                                    logger.Add("Error: StaffMember is false and Personeel Number not emtry! "+ JsonConvert.SerializeObject(empl));
                                    result = true;
                                    continue;
                                }
                                if (_employeeRepository.GetEmployees(empl) == null)
                                {
                                    _employeeRepository.AddEmployeeRepository(empl);
                                    logger.Add("Epmloyee added to DB: " + JsonConvert.SerializeObject(empl));
                                    result = true;
                                    //todo added
                                }
                                else
                                {
                                    _employeeRepository.EditEmployes(empl);
                                    logger.Add("Epmloyee edited in DB: " + JsonConvert.SerializeObject(empl));
                                    result = true;

                                    //todo edited
                                }
                            }
                            catch (Exception ex)
                            {
                                //todo error
                                if (ex.InnerException != null)
                                    logger.Add("Error: " + ex.Message +" "+ JsonConvert.SerializeObject(empl));
                                else
                                    logger.Add("Error: " + ex.Message + "  " + ex.InnerException.Message+" " + JsonConvert.SerializeObject(empl));
                                result = true;

                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "ERROR Invalid File!";
                        return View();
                    }

                }
                
                if (result)
                {
                    return File(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(logger, Formatting.Indented)), "application/text", "Jurnal.txt");
                }
                ViewBag.ErrorMessage = "ERROR Invalid File!";
                return View();
            }catch(Exception ex)
            {
                ViewBag.ErrorMessage = "ERROR Invalid File!";
                return View();
            }
        }

    }
}
