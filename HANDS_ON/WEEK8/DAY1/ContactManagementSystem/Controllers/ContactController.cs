using ContactManagementSystem.Models;
using ContactManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Pkcs;

[Route("contact")]
public class ContactController : Controller
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet("list")]
    public IActionResult ShowContacts()
    {
        return View(_service.GetAllContacts());
    }

    [HttpGet("add")]
    public IActionResult AddContact()
    {
        LoadDropdowns();
        return View();
    }

    [HttpPost("add")]
    public IActionResult AddContact(ContactInfo contact)
    {
        _service.AddContact(contact);
        return RedirectToAction("ShowContacts");
    }

    [HttpGet("edit/{id}")]
    public IActionResult EditContact(int id)
    {
        LoadDropdowns();
        return View(_service.GetContactById(id));
    }

    [HttpPost("edit")]

    public IActionResult EditContact(ContactInfo contact)
    {
        

        _service.UpdateContact(contact);
        return RedirectToAction("ShowContacts");
    }
   

    [HttpGet("delete/{id}")]
    public IActionResult DeleteContact(int id)
    {
        _service.DeleteContact(id);
        return RedirectToAction("ShowContacts");
    }

    private void LoadDropdowns()
    {
        ViewBag.Companies = new SelectList(_service.GetCompanies(), "CompanyId", "CompanyName");
        ViewBag.Departments = new SelectList(_service.GetDepartments(), "DepartmentId", "DepartmentName");
    }
}