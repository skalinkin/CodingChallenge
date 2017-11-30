using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using CodingChallengeApplication;
using CodingChallengeApplication.BusinessCases;
using WebHost.Models;

namespace WebHost.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILifetimeScope _scope;

        public EmployeesController(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ActionResult Index()
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var shoeEmployeesBusnessCase = scope.Resolve<IShowEmployees>();
                var employees = shoeEmployeesBusnessCase.GetAll();
                var model = new List<EmployeeWithDeduction>();

                foreach (var employee in employees)
                {
                    var item = new EmployeeWithDeduction();
                    var calculation = scope.Resolve<ICalculatePreviewStrategy>();
                    var yearDeduction = calculation.Calculate(employee);
                    item.Employee = employee;
                    item.YearDeduction = yearDeduction.ToString("C");
                    var paycheckDeduction = yearDeduction / 26;
                    item.PaycheckDeduction = paycheckDeduction.ToString("C");
                    var employeeRecieves = 2000 - paycheckDeduction;
                    item.EmplyeeRecieves = employeeRecieves.ToString("C");
                    model.Add(item);
                }
                return View(model);
            }
        }

        public ActionResult Details(Guid id)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var _showEmployeeBusinessCase = scope.Resolve<IShowEmployee>();
                return View(_showEmployeeBusinessCase.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (var scope = _scope.BeginLifetimeScope())
                {
                    var _addNewEmployeeBusinessCase = scope.Resolve<IAddNewEmployee>();
                    var employee = new Employee();

                    employee.Id = Guid.NewGuid();
                    employee.Name = collection["Name"];
                    _addNewEmployeeBusinessCase.Insert(employee);

                    return RedirectToAction("Details", new {id = employee.Id});
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showEmployeeBusinessCase = scope.Resolve<IShowEmployee>();
                return View(showEmployeeBusinessCase.Find(id));
            }
        }

        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                using (var scope = _scope.BeginLifetimeScope())
                {
                    var updateEmployeeBusinessCase = scope.Resolve<IUpdateEmployee>();
                    var showEmployeeBusinessCase = scope.Resolve<IShowEmployee>();
                    var employee = showEmployeeBusinessCase.Find(id);
                    employee.Name = collection["Name"];
                    updateEmployeeBusinessCase.Update(employee);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showEmployeeBusinessCase = scope.Resolve<IShowEmployee>();
                return View(showEmployeeBusinessCase.Find(id));
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                using (var scope = _scope.BeginLifetimeScope())
                {
                    var showEmployeeBusinessCase = scope.Resolve<IDeleteEmployee>();
                    showEmployeeBusinessCase.Delete(id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                using (var scope = _scope.BeginLifetimeScope())
                {
                    var deleteEmployeeBusinessCase = scope.Resolve<IDeleteEmployee>();
                    deleteEmployeeBusinessCase.Delete(id);
                }
                return View();
            }
        }

        public ActionResult EditDependent(Guid employeeid, Guid id)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showEmployee = scope.Resolve<IShowEmployee>();

                var employee = showEmployee.Find(employeeid);
                var dependent = employee.Dependents.Single(d => d.Id == id);
                return View(dependent);
            }
        }

        [HttpPost]
        public ActionResult EditDependent(Guid employeeid, Guid id, FormCollection collection)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showEmployee = scope.Resolve<IShowEmployee>();
                var updateEmployee = scope.Resolve<IUpdateEmployee>();
                var employee = showEmployee.Find(employeeid);
                var dependent = employee.Dependents.Single(d => d.Id == id);
                dependent.Name = collection["Name"];
                updateEmployee.Update(employee);
                return RedirectToAction("Details", new {id = employeeid});
            }
        }

        public ActionResult DetailsDependent(Guid employeeid, Guid id)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showEmployee = scope.Resolve<IShowEmployee>();
                var employee = showEmployee.Find(employeeid);
                var dependent = employee.Dependents.Single(d => d.Id == id);
                return View(dependent);
            }
        }

        public ActionResult DeleteDependent(Guid employeeId, Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateDependent(Guid employeeId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDependent(Guid employeeId, FormCollection collection)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                var showemployee = scope.Resolve<IShowEmployee>();
                var updateEmployee = scope.Resolve<IUpdateEmployee>();
                var employee = showemployee.Find(employeeId);
                var dependent = new Dependent();
                dependent.Id = Guid.NewGuid();
                dependent.Name = collection["Name"];
                dependent.DependentType = DependentType.Child;
                employee.Dependents.Add(dependent);
                updateEmployee.Update(employee);
            }
            return RedirectToAction("Details", new { id = employeeId });
        }
    }
}