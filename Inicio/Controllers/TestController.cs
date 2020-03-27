using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Datos.Models;

namespace Inicio.Controllers
{
    public class TestController : Controller
    {
        private readonly BDCOMUN _context;

        public TestController(BDCOMUN context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            return View(await _context.REQUISC_PORTAL.ToListAsync());
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEQUISC_PORTALModel = await _context.REQUISC_PORTAL
                .FirstOrDefaultAsync(m => m.NROREQUI == id);
            if (rEQUISC_PORTALModel == null)
            {
                return NotFound();
            }

            return View(rEQUISC_PORTALModel);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento")] REQUISC_PORTALModel rEQUISC_PORTALModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEQUISC_PORTALModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rEQUISC_PORTALModel);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEQUISC_PORTALModel = await _context.REQUISC_PORTAL.FindAsync(id);
            if (rEQUISC_PORTALModel == null)
            {
                return NotFound();
            }
            return View(rEQUISC_PORTALModel);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento")] REQUISC_PORTALModel rEQUISC_PORTALModel)
        {
            if (id != rEQUISC_PORTALModel.NROREQUI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEQUISC_PORTALModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REQUISC_PORTALModelExists(rEQUISC_PORTALModel.NROREQUI))
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
            return View(rEQUISC_PORTALModel);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEQUISC_PORTALModel = await _context.REQUISC_PORTAL
                .FirstOrDefaultAsync(m => m.NROREQUI == id);
            if (rEQUISC_PORTALModel == null)
            {
                return NotFound();
            }

            return View(rEQUISC_PORTALModel);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rEQUISC_PORTALModel = await _context.REQUISC_PORTAL.FindAsync(id);
            _context.REQUISC_PORTAL.Remove(rEQUISC_PORTALModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REQUISC_PORTALModelExists(string id)
        {
            return _context.REQUISC_PORTAL.Any(e => e.NROREQUI == id);
        }
    }
}
