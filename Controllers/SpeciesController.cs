using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenMaster.Data;
using GreenMaster.Models.Plants;
using GreenMaster.Models.Plants.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GreenMaster.Models
{
    public class SpeciesController : Controller
    {
        private readonly PlantsDbContext _context;

        public SpeciesController(PlantsDbContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
            var plantsContext = _context.Species.Include(s => s.AttractantNavigation).Include(s => s.FruitNavigation).Include(s => s.FruitingPeriodNavigation).Include(s => s.HardinessZoneNavigation).Include(s => s.LifeCycleNavigation).Include(s => s.MaintenanceLevelNavigation).Include(s => s.ShapeNavigation).Include(s => s.ToxicityNavigation).Include(s => s.TypeNavigation);
            return View(await plantsContext.ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species
                .Include(s => s.AttractantNavigation)
                .Include(s => s.FruitNavigation)
                .Include(s => s.FruitingPeriodNavigation)
                .Include(s => s.HardinessZoneNavigation)
                .Include(s => s.LifeCycleNavigation)
                .Include(s => s.MaintenanceLevelNavigation)
                .Include(s => s.ShapeNavigation)
                .Include(s => s.ToxicityNavigation)
                .Include(s => s.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            ViewData["Attractant"] = new SelectList(_context.WildlifeAttractants, "Name", "Name");
            ViewData["Fruit"] = new SelectList(_context.FruitTypes, "Name", "Name");
            ViewData["FruitingPeriod"] = new SelectList(Enum.GetValues(typeof(Period)).Cast<Period>(), "Name", "Name");
            ViewData["HardinessZone"] = new SelectList(_context.HardinessZones, "Id", "Id");
            ViewData["LifeCycle"] = new SelectList(Enum.GetValues(typeof(LifeCycle)).Cast<LifeCycle>(), "Type", "Type");
            ViewData["MaintenanceLevel"] = new SelectList(_context.Ratings, "Score", "Score");
            ViewData["Shape"] = new SelectList(_context.Shapes, "Name", "Name");
            ViewData["Toxicity"] = new SelectList(_context.Toxicities, "Description", "Description");
            ViewData["Type"] = new SelectList(_context.PlantTypes, "Name", "Name");
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScientificName,CommonName,Shape,FruitingPeriod,HardinessZone,Type,LifeCycle,Toxicity,Fruit,Height,Width,Attractant,MaintenanceLevel")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Attractant"] = new SelectList(_context.WildlifeAttractants, "Name", "Name", specie.Attractant);
            ViewData["Fruit"] = new SelectList(_context.FruitTypes, "Name", "Name", specie.Fruit);
            ViewData["FruitingPeriod"] = new SelectList(Enum.GetValues(typeof(Period)).Cast<Period>(), "Name", "Name", specie.FruitingPeriod);
            ViewData["HardinessZone"] = new SelectList(_context.HardinessZones, "Id", "Id", specie.HardinessZone);
            ViewData["LifeCycle"] = new SelectList(Enum.GetValues(typeof(LifeCycle)).Cast<LifeCycle>(), "Type", "Type", specie.LifeCycle);
            ViewData["MaintenanceLevel"] = new SelectList(_context.Ratings, "Score", "Score", specie.MaintenanceLevel);
            ViewData["Shape"] = new SelectList(_context.Shapes, "Name", "Name", specie.Shape);
            ViewData["Toxicity"] = new SelectList(_context.Toxicities, "Description", "Description", specie.Toxicity);
            ViewData["Type"] = new SelectList(_context.PlantTypes, "Name", "Name", specie.Type);
            return View(specie);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }
            ViewData["Attractant"] = new SelectList(_context.WildlifeAttractants, "Name", "Name", specie.Attractant);
            ViewData["Fruit"] = new SelectList(_context.FruitTypes, "Name", "Name", specie.Fruit);
            ViewData["FruitingPeriod"] = new SelectList(Enum.GetValues(typeof(Period)).Cast<Period>(), "Name", "Name", specie.FruitingPeriod);
            ViewData["HardinessZone"] = new SelectList(_context.HardinessZones, "Id", "Id", specie.HardinessZone);
            ViewData["LifeCycle"] = new SelectList(Enum.GetValues(typeof(LifeCycle)).Cast<LifeCycle>(), "Type", "Type", specie.LifeCycle);
            ViewData["MaintenanceLevel"] = new SelectList(_context.Ratings, "Score", "Score", specie.MaintenanceLevel);
            ViewData["Shape"] = new SelectList(_context.Shapes, "Name", "Name", specie.Shape);
            ViewData["Toxicity"] = new SelectList(_context.Toxicities, "Description", "Description", specie.Toxicity);
            ViewData["Type"] = new SelectList(_context.PlantTypes, "Name", "Name", specie.Type);
            return View(specie);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScientificName,CommonName,Shape,FruitingPeriod,HardinessZone,Type,LifeCycle,Toxicity,Fruit,Height,Width,Attractant,MaintenanceLevel")] Specie specie)
        {
            if (id != specie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecieExists(specie.Id))
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
            ViewData["Attractant"] = new SelectList(_context.WildlifeAttractants, "Name", "Name", specie.Attractant);
            ViewData["Fruit"] = new SelectList(_context.FruitTypes, "Name", "Name", specie.Fruit);
            ViewData["FruitingPeriod"] = new SelectList(Enum.GetValues(typeof(Period)).Cast<Period>(), "Name", "Name", specie.FruitingPeriod);
            ViewData["HardinessZone"] = new SelectList(_context.HardinessZones, "Id", "Id", specie.HardinessZone);
            ViewData["LifeCycle"] = new SelectList(Enum.GetValues(typeof(LifeCycle)).Cast<LifeCycle>(), "Type", "Type", specie.LifeCycle);
            ViewData["MaintenanceLevel"] = new SelectList(_context.Ratings, "Score", "Score", specie.MaintenanceLevel);
            ViewData["Shape"] = new SelectList(_context.Shapes, "Name", "Name", specie.Shape);
            ViewData["Toxicity"] = new SelectList(_context.Toxicities, "Description", "Description", specie.Toxicity);
            ViewData["Type"] = new SelectList(_context.PlantTypes, "Name", "Name", specie.Type);
            return View(specie);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Species == null)
            {
                return NotFound();
            }

            var specie = await _context.Species
                .Include(s => s.AttractantNavigation)
                .Include(s => s.FruitNavigation)
                .Include(s => s.FruitingPeriodNavigation)
                .Include(s => s.HardinessZoneNavigation)
                .Include(s => s.LifeCycleNavigation)
                .Include(s => s.MaintenanceLevelNavigation)
                .Include(s => s.ShapeNavigation)
                .Include(s => s.ToxicityNavigation)
                .Include(s => s.TypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Species == null)
            {
                return Problem("Entity set 'plantsContext.Species'  is null.");
            }
            var specie = await _context.Species.FindAsync(id);
            if (specie != null)
            {
                _context.Species.Remove(specie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecieExists(int id)
        {
          return (_context.Species?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
