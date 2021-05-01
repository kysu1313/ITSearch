using System;
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
using ITSearch.Models.ProductInfo;
using Microsoft.AspNetCore.Authorization;
using ITSearch.Models.SNLookup;

namespace ITSearch.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _context.Services.ToListAsync();
            List<Product> products = await _context.Products.ToListAsync();
            List<Procedure> procedures = await _context.Procedures.ToListAsync();
            List<Computer> computers = await _context.Computers.ToListAsync();
            List<IOSDevice> iOSDevices = await _context.IOSDevices.ToListAsync();

            GeneralViewModel svm = new GeneralViewModel();
            svm.Services = services;
            svm.Products = products;
            svm.Procedures = procedures;
            svm.Computers = computers;
            svm.IOSDevices = iOSDevices;

            return View(svm);
        }

        /// <summary>
        /// This runs a search in each table shown below.
        /// It looks for similar keywords in various fields in the object.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> search(GeneralViewModel search)
        {
            string[] tokens = search.NewSearch.SearchText.ToLower().Split(new char[] { ' ', ',', '.', ';' });

            GeneralViewModel gvm = new GeneralViewModel();

            if (search.ViewServices)
            {
                IEnumerable<Service> services = _context.Services.Search(
                    m => m.ServiceName.ToLower(), 
                    m => m.AdditionalInfo.ToLower())
                    .ContainingAll(tokens);
                gvm.Services = services;
            }

            if (search.ViewProcedures)
            {
                IEnumerable<Procedure> procedures = _context.Procedures.Search(
                    m => m.Name.ToLower(),
                    m => m.Action.ToLower(),
                    m => m.Notes.ToLower())
                    .ContainingAll(tokens);
                gvm.Procedures = procedures;
            }

            if (search.ViewComputers)
            {
                IEnumerable<Computer> computers = _context.Computers.Search(
                    m => m.Description.ToLower(),
                    m => m.Model.ToLower(),
                    m => m.ModelIdentifier.ToLower(),
                    m => m.AdditionalInfo.ToLower())
                    .ContainingAll(tokens);
                gvm.Computers = computers;
            }

            if (search.ViewIOSDevices)
            {
                IEnumerable<IOSDevice> iOSDevices = _context.IOSDevices.Search(
                    m => m.DeviceName.ToLower(),
                    m => m.DeviceModel.ToLower(),
                    m => m.DeviceConfiguration.Configuration.ToLower(),
                    m => m.DeviceModelNumber.Model.ToLower())
                    .ContainingAll(tokens);
                gvm.IOSDevices = iOSDevices;
            }

            if (search.ViewProducts)
            {
                IEnumerable<Product> products = _context.Products.Search(
                    m => m.sku.ToLower(),
                    m => m.Description.ToLower(),
                    m => m.ProductPrice.ToString())
                    .ContainingAll(tokens);
                gvm.Products = products;
            }

            gvm.ViewServices = search.ViewServices;
            gvm.ViewComputers = search.ViewComputers;
            gvm.ViewIOSDevices = search.ViewIOSDevices;
            gvm.ViewProcedures = search.ViewProcedures;
            gvm.ViewProducts = search.ViewProducts;
            

            return View("Index", gvm);
        }

        /// <summary>
        /// Takes a serial number in and first checks the stored list of 
        /// known serial numbers from the database. If it is not found,
        /// it makes a call to apples web api using the DeviceID class.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IActionResult GetSN(GeneralViewModel search)
        {
            string str = search.NewSearch.SearchText.ToString();
            string lastFour = search.NewSearch.SearchText.ToString().Substring(str.Length - 4);
            LastFourSN lfsn = _context.LastFourSNs.FirstOrDefault(m => m.last4 == lastFour);

            GeneralViewModel gvm = new GeneralViewModel();

            if (lfsn == null)
            {
                DeviceID dId = new DeviceID();
                string itemName = dId.AppleSNLookup(str);
                gvm.DeviceName = itemName;
            } 
            else
            {
                gvm.DeviceName = lfsn.name;
            }

            

            Computer computer = _context.Computers.Search(
                m => m.Model.ToLower(),
                m => m.Description.ToLower(),
                m => m.ModelIdentifier.ToLower())
                .Containing(gvm.DeviceName.ToLower()).FirstOrDefault();

            IOSDevice iOSDevice = _context.IOSDevices.Search(
                m => m.DeviceName.ToLower(),
                m => m.DeviceModel.ToLower(),
                m => m.DeviceConfiguration.Configuration.ToLower(),
                m => m.DeviceModelNumber.Model.ToLower())
                .Containing(gvm.DeviceName.ToLower()).FirstOrDefault();


            if (computer != null)
            {
                gvm.Computer = computer;
                return RedirectToAction("details", "Computers", new { id = computer.Id });
            }
            if (iOSDevice != null)
            {
                gvm.IOSDevice = iOSDevice;
                return RedirectToAction("details", "IOSDevices", new { id = iOSDevice.Id});
            }
            else
            {
                return View("Index", gvm);
            }

        }

        public void AddProducts()
        {
            DataParser dpar = new DataParser(_context);
            dpar.ParseProductCSV();
        }

        /// <summary>
        /// 
        /// *** Still in progress ***
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
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
