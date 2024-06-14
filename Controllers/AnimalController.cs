namespace ZooApplicationV2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using ZooApplicationV2.Data;
    using ZooApplicationV2.Models;

    public class AnimalController : Controller
    {
        private readonly ZooContext _context;

        public AnimalController(ZooContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var animals = await _context.Animals.Include(a => a.Category).Include(a => a.Enclosure).ToListAsync();
            return View(animals);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,Category,Size,DietaryClass,ActivityPattern,SpaceRequirement,SecurityRequirement")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View(animal);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,Category,Size,DietaryClass,ActivityPattern,SpaceRequirement,SecurityRequirement")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
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
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.Category)
                .Include(a => a.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }

        // Custom Actions
        public async Task<IActionResult> Sunrise()
        {
            var animals = await _context.Animals.ToListAsync();
            foreach (var animal in animals)
            {
                if (animal.ActivityPattern == ActivityPattern.Diurnal || animal.ActivityPattern == ActivityPattern.Cathemeral)
                {
                    // Wake up the animal
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Sunset()
        {
            var animals = await _context.Animals.ToListAsync();
            foreach (var animal in animals)
            {
                if (animal.ActivityPattern == ActivityPattern.Nocturnal || animal.ActivityPattern == ActivityPattern.Cathemeral)
                {
                    // Wake up the animal
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

    [Serializable]
    internal class DbUpdateConcurrencyException : Exception
    {
        public DbUpdateConcurrencyException()
        {
        }

        public DbUpdateConcurrencyException(string? message) : base(message)
        {
        }

        public DbUpdateConcurrencyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DbUpdateConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
