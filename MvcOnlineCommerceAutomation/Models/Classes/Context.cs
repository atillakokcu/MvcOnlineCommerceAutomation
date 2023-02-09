using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcOnlineCommerceAutomation.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bills> Billss { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenses> Expensess { get; set; }
        public DbSet<InvoiceAdditions> InvoiceAdditionss { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SalesAction> SalesActions { get; set; }

    }
}