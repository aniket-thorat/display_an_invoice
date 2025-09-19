using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuggyApp.Data;
using BuggyApp.Models;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoiceController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoice()
        {
            var invoice = await _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync();

            if (invoice == null)
            {
                return NotFound("No invoice found");
            }

            var items = invoice.Items.Select(item => new Item
            {
                name = item.Name,
                price = (double)item.Price
            }).ToList();

            return Ok(new { items });
        }

        public class Item
        {
            public string name { get; set; } = string.Empty;
            public double price { get; set; }
        }
    }
}
