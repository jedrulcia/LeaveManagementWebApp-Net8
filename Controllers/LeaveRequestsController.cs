using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementWebApp.Data;
using LeaveManagementWebApp.Models;
using AutoMapper;
using LeaveManagementWebApp.Constants;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementWebApp.Contracts;

namespace LeaveManagementWebApp.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly ILeaveRequestRepository leaveRequestRepository;
		private readonly ILogger<LeaveRequestsController> logger;

		public LeaveRequestsController(ApplicationDbContext context, 
            ILeaveRequestRepository leaveRequestRepository,
            ILogger<LeaveRequestsController> logger)
        {
            _context = context;
			this.leaveRequestRepository = leaveRequestRepository;
			this.logger = logger;
		}

        [Authorize(Roles = Roles.Administrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var model = await leaveRequestRepository.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<ActionResult> MyLeave()
        {
            var model = await leaveRequestRepository.GetMyLeaveDetails();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = await leaveRequestRepository.GetLeaveRequestAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approvalStatus)
        {
            try
            {
                await leaveRequestRepository.ChangeApprovalStatus(id, approvalStatus);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error approving leave request");
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await leaveRequestRepository.CancelLeaveRequest(id);
            }
            catch (Exception ex)
			{
				throw;
            }
            return RedirectToAction(nameof(MyLeave));
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "ID", "Name"),
            };
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            try
			{
				if (ModelState.IsValid)
				{
                    var isValidRequest = await leaveRequestRepository.CreateLeaveRequest(model);
                    if(isValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));
                    }
                    ModelState.AddModelError(string.Empty, "You have exceeded your allocation with this request.");
				}
			}
            catch (Exception ex)
			{
				logger.LogError(ex, "Error creating leave request");
				ModelState.AddModelError(string.Empty, "An error has occurred. Please try again later");
            }

            model.LeaveTypes = new SelectList(_context.LeaveTypes, "ID", "Name", model.LeaveTypeID);
            return View(model);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "ID", "ID", leaveRequest.LeaveTypeID);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeID,DateRequested,RequestComments,Approved,Cancelled,RequestingEmployeeId,ID,DateCreated,DateModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.ID))
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
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "ID", "ID", leaveRequest.LeaveTypeID);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.ID == id);
        }

    }
}
