﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITSearch.Data;
using ITSearch.Models;
using NinjaNye.SearchExtensions;
using ITSearch.Models.ViewModels;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using Newtonsoft.Json.Linq;

namespace ITSearch.Controllers
{

    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;

            ParseJson();
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _context.Services.ToListAsync();

            ServiceViewModel svm = new ServiceViewModel();
            svm.Services = services;

            return View(svm);
        }

        [HttpPost]
        public async Task<IActionResult> search(Search search)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return 
            //}

            IEnumerable<Service> services = _context.Services.Search(
                m => m.ServiceName.ToLower(), 
                m => m.AdditionalInfo.ToLower())
                .Containing(search.SearchText.ToLower());

            ServiceViewModel svm = new ServiceViewModel();
            svm.Services = services;

            return View("Index", svm);
        }

        [HttpPost]
        public async Task<IActionResult> InnerSearch(ServiceViewModel search)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return 
            //}

            IEnumerable<Service> services = _context.Services.Search(
                m => m.ServiceName.ToLower(),
                m => m.AdditionalInfo.ToLower())
                .Containing(search.NewSearch.SearchText.ToLower());

            ServiceViewModel svm = new ServiceViewModel();
            svm.Services = services;

            return View("Index", svm);
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var services = (from service in this._context.Services
                             where service.ServiceName.StartsWith(prefix)
                             select new
                             {
                                 label = service.ServiceName,
                                 val = service.ServicePrice,
                                 info = service.AdditionalInfo
                             }).ToList();

            return Json(services);
        }

        public void ParseJson()
        {

            Computer comp = JObject.Parse(System.IO.File.ReadAllText(@"Data/mbpModels.json")).ToObject<Computer>();
            Console.WriteLine(comp);


        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ServiceName,ServicePrice,AdditionalInfo")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,ServiceName,ServicePrice,AdditionalInfo")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
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
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}
