using DropDown4rmViewbag.Models;
using Microsoft.EntityFrameworkCore;

namespace DropDown4rmViewbag.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public DbSet<tblStudent> tblStudent { get; set; }
        public DbSet<tbl_Subject> tbl_Subject{ get; set; }
        public DbSet<DropDown4rmViewbag.Models.StudentClass>? StudentClass { get; set; }
        public DbSet<DropDown4rmViewbag.Models.AllClass>? AllClass { get; set; }
    }
}
