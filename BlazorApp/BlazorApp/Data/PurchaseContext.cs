using Microsoft.EntityFrameworkCore;
namespace BlazorApp.Data
{
    public class PurchaseContext : DbContext
    { 
        public DbSet<Request> Request { get; set; }
        
        public DbSet<RequestMaterial> Material { get; set; }
        
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options) { }
    }

    public class Request
    {
        public int Id { get; set; }
        public List<RequestMaterial> Materials { get; set; }
        public string Text { get; set; } = "";
    }

    public class RequestMaterial
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public int RequestId { get; set; } 
        public Request Request { get; set; }
    }
}
