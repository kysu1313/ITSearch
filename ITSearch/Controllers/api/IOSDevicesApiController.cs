using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSearch.Data;
using ITSearch.Models;
using ITSearch.Models.ViewModels;

namespace ITSearch.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOSDevicesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IOSDevicesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IOSDevicesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IOSDevice>>> GetIOSDevices()
        {
            ProcedureViewModel pvm = new ProcedureViewModel();
            //pvm.Procedures = await _context.IOSDevices.ToListAsync();
            return await _context.IOSDevices.ToListAsync();
        }

        // GET: api/IOSDevicesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IOSDevice>> GetIOSDevice(int id)
        {
            var iOSDevice = await _context.IOSDevices.FindAsync(id);

            if (iOSDevice == null)
            {
                return NotFound();
            }

            return iOSDevice;
        }

        // PUT: api/IOSDevicesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIOSDevice(int id, IOSDevice iOSDevice)
        {
            if (id != iOSDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(iOSDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IOSDeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IOSDevicesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IOSDevice>> PostIOSDevice(IOSDevice iOSDevice)
        {
            _context.IOSDevices.Add(iOSDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIOSDevice", new { id = iOSDevice.Id }, iOSDevice);
        }

        // DELETE: api/IOSDevicesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIOSDevice(int id)
        {
            var iOSDevice = await _context.IOSDevices.FindAsync(id);
            if (iOSDevice == null)
            {
                return NotFound();
            }

            _context.IOSDevices.Remove(iOSDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IOSDeviceExists(int id)
        {
            return _context.IOSDevices.Any(e => e.Id == id);
        }
    }
}
