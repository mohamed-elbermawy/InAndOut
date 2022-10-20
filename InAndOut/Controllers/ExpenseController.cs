using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expensesList = _context.Expenses;
            return View(expensesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(expense);
            }
        }

        public IActionResult Update(int? Id)
        {
            var obj = _context.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(expense);
            }
        }

        public IActionResult Delete(int? Id)
        {
            var obj = _context.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _context.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.Expenses.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

