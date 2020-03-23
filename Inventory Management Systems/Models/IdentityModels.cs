using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Inventory_Management_Systems.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblAccount> tblAccounts { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblAccountHead> tblAccountHeads { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblItem> tblItems { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblItemcategory> tblItemcategories { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblItemUnit> tblItemUnits { get; set; }

       

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblInvoice> tblInvoices { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblInvoiceDetail> tblInvoiceDetails { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblVoucher> tblVouchers { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblVoucherDetail> tblVoucherDetails { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblOrder> tblOrders { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblCustomer> Customers { get; set; }

        public System.Data.Entity.DbSet<Inventory_Management_Systems.Models.tblCompany> Companies { get; set; }
    }
}