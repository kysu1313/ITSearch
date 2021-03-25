using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITSearch.Data;
using ITSearch.Models;
using Microsoft.AspNetCore.Authorization;
using NinjaNye.SearchExtensions;
using ITSearch.Models.ViewModels;

namespace ITSearch.Controllers
{
    [Authorize]
    public class ProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProceduresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procedures
        public async Task<IActionResult> Index()
        {
            GeneralViewModel pvm = new GeneralViewModel();
            pvm.Procedures = await _context.Procedures.ToListAsync();

            return View(pvm);
        }

        [HttpPost]
        public async Task<IActionResult> search([Bind("NewSearch, SearchText")] GeneralViewModel search)
        {

            IEnumerable<Procedure> procedures = _context.Procedures.Search(
                m => m.Name.ToLower(),
                m => m.Action.ToLower())
                .Containing(search.NewSearch.SearchText.ToLower());

            GeneralViewModel pvm = new GeneralViewModel();
            pvm.Procedures = procedures;

            return View("Index", pvm);
        }

        public IActionResult AddTask()
        {
            var newTask = new ToDo();

            return this.PartialView("PartialTask");
        }

        // GET: Procedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // GET: Procedures/Create
        public IActionResult Create()
        {
            ProcedureViewModel pvm = new ProcedureViewModel();
            pvm.ToDos = new DynamicVML.DynamicList<ToDo>();
            return View(pvm);
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Procedures,Procedure,NewSearch,NewToDo,ToDos")] ProcedureViewModel pvm)
        {
            Procedure procedure = new Procedure();

            if (ModelState.IsValid)
            {
                procedure.Id = pvm.Procedure.Id;
                procedure.Name = pvm.Procedure.Name;
                procedure.Notes = pvm.Procedure.Notes;
                procedure.Action = pvm.Procedure.Action;

                //if (pvm.ToDos.Count() > 0)
                //{
                //    foreach(ToDo todo in pvm.ToDos)
                //    {
                //        procedure.ActionList.Append(todo);
                //    }
                //}

                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            return View(procedure);
        }


        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Action,Notes")] Procedure procedure)
        {
            if (id != procedure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedure = await _context.Procedures.FindAsync(id);
            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureExists(int id)
        {
            return _context.Procedures.Any(e => e.Id == id);
        }
    }
}
