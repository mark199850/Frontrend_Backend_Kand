using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargyiEszkozNyilvantarto.Models;
using TargyiEszkozNyilvantarto.Services;

namespace TargyiEszkozNyilvantarto.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CoworkerController : Controller
    {
        private readonly CoworkerService service;
        public CoworkerController(CoworkerService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("/Get/CoworkerByEmail/{email}")]
        public Coworker GetCoworkerByEmail(string email)
        {
            return service.GetAllCoworkerByEmail(email);
        }

        [HttpGet]
        [Route("/Get/CoworkerNumber")]

        public int GetCoworkerNumber()
        {
            return service.GetCoworkerNumber();
        }
    }

}
