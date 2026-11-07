using CodeFirstApproach.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstApproach.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<CodeFirstApproach.Models.Categorie> Categorie { get; set; }
        public DbSet<CodeFirstApproach.Models.Supplier> Supplier { get; set; }
        public DbSet<CodeFirstApproach.Models.Product> Product { get; set; }
       
        public DbSet<CodeFirstApproach.Models.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<CodeFirstApproach.Models.PurchaseOrderItem> PurchaseOrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تغيير سلوك الحذف المتسلسل لمنع مسارات الحذف المزدوجة
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne( p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict); // أو DeleteBehavior.NoAction
        }
    }
   
    }
