using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLayer.Services;
using CommonLayer;
using System.Linq;
using RepositoryLayer.Services;
using RepositoryLayer.Interface;


namespace EmployeeTest01.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = employeeServices;
        }


        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeServices.GetAllEmployeeService().ToList();

            return View(lstEmployee);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /*        public IActionResult Create()
                {
                    List<Employee> lstEmployee = new List<Employee>();
                    lstEmployee = employeeServices.GetAllEmployeeService().ToList();

                    return View(lstEmployee);
                }

                [HttpPost]
        */


        [HttpPost]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeServices.AddEmployeeService(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        public IActionResult Edit(int id)
        {
            //employeeRepo.GetEmployeeById
            //var employee = employeeServices.GetEmployeeById(id);
            var employee = employeeServices.GetEmployeeByIdService(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //TODO: requires the POST method.... We have a Get method.....

        [HttpPost]
        public IActionResult Edit([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeServices.UpdateEmployeeService(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult GetById(int id)
        {
            var employee = employeeServices.GetEmployeeByIdService(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult DeletePrompt(int id)
        {
            var employee = employeeServices.GetEmployeeByIdService(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
            //return View();
        }

        [HttpPost]
        public IActionResult DeletePrompt([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeServices.DeleteEmployeeService(employee.EmployeeID);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            var employee = employeeServices.GetEmployeeByIdService(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        /*        [HttpPost]
                public IActionResult DeleteById(int id)
                {
                    employeeServices.DeleteEmployeeService(id);
                    return RedirectToAction("Index");
                    //return View();
                }
        */
    }
}
