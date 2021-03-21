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

namespace ITSearch.Controllers
{
    public class IOSDevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IOSDevicesController(ApplicationDbContext context)
        {
            _context = context;

            //DataParser dparse = new DataParser(context);
            //dparse.ParseIOSJson();
        }

        // GET: IOSDevices
        public async Task<IActionResult> Index()
        {
            GeneralViewModel gvm = new GeneralViewModel();
            gvm.IOSDevices = await _context.IOSDevices.ToListAsync();
            return View(gvm);
        }

        [HttpPost]
        public async Task<IActionResult> search(Search search)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return 
            //}

            GeneralViewModel gvm = new GeneralViewModel();


            IEnumerable<IOSDevice> devices = _context.IOSDevices.Search(
                m => m.DeviceName.ToLower(),
                m => m.DeviceIdentifier.ToLower(),
                m => m.DeviceModel.ToLower(),
                m => m.DeviceConfiguration.Configuration.ToLower(),
                m => m.StringYear.ToLower())
                .Containing(search.SearchText.ToLower());

            gvm.IOSDevices = devices;

            return View("Index", gvm);
        }

        // GET: IOSDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iOSDevice = await _context.IOSDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iOSDevice == null)
            {
                return NotFound();
            }

            return View(iOSDevice);
        }

        // GET: IOSDevices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IOSDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceName,DeviceIdentifier,DeviceModel,StringDeviceConfiguration,StringYear,Year")] IOSDevice iOSDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iOSDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iOSDevice);
        }

        // GET: IOSDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iOSDevice = await _context.IOSDevices.FindAsync(id);
            if (iOSDevice == null)
            {
                return NotFound();
            }
            return View(iOSDevice);
        }

        // POST: IOSDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceName,DeviceIdentifier,DeviceModel,StringDeviceConfiguration,StringYear,Year")] IOSDevice iOSDevice)
        {
            if (id != iOSDevice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iOSDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IOSDeviceExists(iOSDevice.Id))
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
            return View(iOSDevice);
        }

        // GET: IOSDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iOSDevice = await _context.IOSDevices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iOSDevice == null)
            {
                return NotFound();
            }

            return View(iOSDevice);
        }

        // POST: IOSDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iOSDevice = await _context.IOSDevices.FindAsync(id);
            _context.IOSDevices.Remove(iOSDevice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IOSDeviceExists(int id)
        {
            return _context.IOSDevices.Any(e => e.Id == id);
        }
    }
}
