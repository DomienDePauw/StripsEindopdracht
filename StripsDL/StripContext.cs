using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripsBL.Models;

namespace StripsDL;

public class StripContext : DbContext
{
    public DbSet<Strip> Strips { get; set; }
    public DbSet<Auteur> Auteurs { get; set; }
    public DbSet<Reeks> Reeksen { get; set; }
    public DbSet<Uitgeverij> Uitgeverijen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=Strips;Integrated Security=True;Trust Server Certificate=True");
    }

}
