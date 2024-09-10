using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LecturerClaims.Controllers
{
    public class ClaimController : Controller
    {
        private const string ApprovedStatus = "Approved";

        // Action to show the list of claims
        public IActionResult Index()
        {
            return View(LecturerClaims.ClaimsList);
        }

        // Action to show the form for creating a new claim
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle claim creation
        [HttpPost]
        public IActionResult Create(Claim claim)
        {
            claim.Id = LecturerClaims.ClaimsList.Count + 1;
            claim.Status = "Pending";
            LecturerClaims.Add(claim);
            return RedirectToAction("Index");
        }

        // Action to approve a claim
        public IActionResult Approve(int id)
        {
            var claim = LecturerClaims.ClaimsList.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = ApprovedStatus;
            }
            return RedirectToAction("Index");
        }
    }

    // Class to handle claim data
    public static class LecturerClaims
    {
        // Simulating the database with an in-memory list
        public static List<Claim> ClaimsList { get; set; } = new List<Claim>();

        // Method to add a claim to the list
        public static void Add(Claim claim)
        {
            ClaimsList.Add(claim);
        }
    }

    // Claim model
    public class Claim
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public string ClaimDescription { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}

