using ContactForm.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactForm.Api.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController
    {
        private readonly Data.DbContext _context;

        public DataController(Data.DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Lead>>> Get()
        {
            return await _context.Leads.ToListAsync();
        }

        [HttpPost]
        public async Task Post([FromBody]Lead lead)
        {
            _context.Leads.Add(lead);

            _context.SaveChanges();
        }
    }
}
