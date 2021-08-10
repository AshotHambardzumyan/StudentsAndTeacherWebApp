using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentsAndTeacherWebApp.Models.Model;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
    {
    }

    public DbSet<StudentsAndTeacherWebApp.Models.Model.Student> Student { get; set; }

    public DbSet<StudentsAndTeacherWebApp.Models.Model.Teacher> Teacher { get; set; }
}
