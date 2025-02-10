//Controllers/CriteriaController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DMS_Audit_MVC.Models;
using DMS_Audit_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS_Audit_MVC.Controllers
{
    public class CriteriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriteriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(short? year, byte? month)
        {
            // Get the current year and month if year and month are not provided
            short currentYear = year ?? (short)DateTime.Now.Year;
            byte currentMonth = month ?? (byte)DateTime.Now.Month;

            // Check if the requested month is in the future
            DateTime requestedDate = new DateTime(currentYear, currentMonth, 1);
            if (requestedDate > DateTime.Now)
            {
                // Redirect to the current month
                return RedirectToAction(nameof(Index));
            }

            // Pass the year and month to the ViewData
            ViewData["year"] = currentYear;
            ViewData["month"] = currentMonth;

            // Fetch all criteria
            var criteriaList = await _context.Criterias.ToListAsync();

            // Create a list to hold the combined data
            var combinedData = new List<CombinedCriteriaData>();

            foreach (var criteria in criteriaList)
            {
                // Find the CriteriaState for the current criteria, year, and month
                var criteriaState = await _context.CriteriaStates
                    .FirstOrDefaultAsync(cs => cs.CriteriaID == criteria.ID &&
                                                 cs.Year == currentYear &&
                                                 cs.Month == currentMonth);

                // If no CriteriaState exists for the current month
                if (criteriaState == null)
                {
                    // Try to copy the previous CriteriaState
                    var previousCriteriaState = await _context.CriteriaStates
                        .Where(cs => cs.CriteriaID == criteria.ID && cs.Year < currentYear || (cs.Year == currentYear && cs.Month < currentMonth))
                        .OrderByDescending(cs => cs.Year)
                        .ThenByDescending(cs => cs.Month)
                        .FirstOrDefaultAsync();

                    if (previousCriteriaState != null)
                    {
                        criteriaState = new CriteriaState
                        {
                            CriteriaID = criteria.ID,
                            Criteria = criteria, // Assign the Criteria object
                            Year = currentYear,
                            Month = currentMonth,
                            CurrentLvl = previousCriteriaState.CurrentLvl,
                            Progress = previousCriteriaState.Progress,
                            Comment = previousCriteriaState.Comment,
                            ClosingComment = previousCriteriaState.ClosingComment,
                            Closed = false,
                            ModifiedDate = null,
                            ModifiedBy = null,
                            ClosedDate = null,
                            ClosedBy = null
                        };
                    }
                    else
                    {
                        // Create a default CriteriaState
                        criteriaState = new CriteriaState
                        {
                            CriteriaID = criteria.ID,
                            Criteria = criteria, // Assign the Criteria object
                            Year = currentYear,
                            Month = currentMonth,
                            CurrentLvl = 0, // Set default value
                            Progress = 0f,   // Set default value
                            // Set other default values as needed
                        };
                    }

                    _context.CriteriaStates.Add(criteriaState); // Add the new entity to the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }

                // Create a combined data object
                var combined = new CombinedCriteriaData
                {
                    Criteria = criteria,
                    CriteriaState = criteriaState
                };

                combinedData.Add(combined);
            }

            // Pass the combined data to the view
            return View(combinedData);
        }

        // GET: CriteriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CriteriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CriteriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Group")] Criteria criteria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criteria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criteria);
        }

        // GET: CriteriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CriteriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CriteriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CriteriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
