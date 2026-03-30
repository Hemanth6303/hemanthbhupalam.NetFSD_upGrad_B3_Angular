using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

public class ContactController : Controller
{
    // In-memory list

    private static List<ContactInfo> contacts = new List<ContactInfo>
    {
       new ContactInfo
      {
        ContactId = 1,
        FirstName = "Hemanth",
        LastName = "Kumar",
        CompanyName = "ABC Infotech",
        EmailId = "hemanth@gmail.com",
        MobileNo = 9876543210,
        Designation = "Software Engineer"
      },
      new ContactInfo
      {
        ContactId = 2,
        FirstName = "Rahul",
        LastName = "Sharma",
        CompanyName = "Tech Solutions",
        EmailId = "rahul@gmail.com",
        MobileNo = 9123456780,
        Designation = "Developer"
      },
      new ContactInfo
      {
        ContactId = 3,
        FirstName = "Priya",
        LastName = "Reddy",
        CompanyName = "Innovate Ltd",
        EmailId = "priya@gmail.com",
        MobileNo = 9988776655,
        Designation = "HR Manager"
       },
       new ContactInfo
       {
        ContactId = 4,
        FirstName = "Arjun",
        LastName = "Verma",
        CompanyName = "Global Tech",
        EmailId = "arjun@gmail.com",
        MobileNo = 9012345678,
        Designation = "Team Lead"
        },
        new ContactInfo
       {
        ContactId = 5,
        FirstName = "Sneha",
        LastName = "Patel",
        CompanyName = "NextGen Solutions",
        EmailId = "sneha@gmail.com",
        MobileNo = 9090909090,
        Designation = "Analyst"
       }
     };

    // ✅ Show all contacts
    [ActionName("Index")]
    public ActionResult showDetails()
    {
        return View(contacts);
    }

    // ✅ Search by ID
    public ActionResult GetContactById(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.ContactId == id);
        return View(contact);
    }

    // ✅ GET: Add Contact
    public ActionResult AddContact()
    {
        return View();
    }

    // ✅ POST: Add Contact
    [HttpPost]
    public ActionResult AddContact(ContactInfo contactInfo)
    {
        contacts.Add(contactInfo);
        return RedirectToAction("Index");
    }
}