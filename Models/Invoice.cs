using System.ComponentModel.DataAnnotations;

namespace BuggyApp.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Invoice Invoice { get; set; } = null!;
    }
}
