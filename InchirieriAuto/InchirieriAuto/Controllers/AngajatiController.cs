using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InchirieriAuto.Controllers
{
    public class AngajatiController : Controller
    {
        private readonly IAngajatiRepository _repository;

        public AngajatiController(ApplicationDbContext dbContext)
        {
            _repository = new AngajatiRepository(dbContext);
        }

        // Constructor suplimentar pentru teste
        public AngajatiController(IAngajatiRepository repository)
        {
            _repository = repository;
        }

        // GET: AngajatiController
        public ActionResult Index()
        {
            var angajatis = _repository.GetAllAngajatis();
            return View("Index", angajatis);
        }

        // Restul codului...
    }
}
