using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using StudentsAndTeacherWebApp.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentsAndTeacherWebApp.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly UniversityDbContext _dbContext;

        public TeacherService(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Teacher teacher)
        {
            _dbContext.Teacher.Add(teacher);

            _dbContext.SaveChanges();
        }

        public Teacher Get(int id)
        {
            var teacher = _dbContext.Teacher.FirstOrDefault(x => x.Id == id);

            return teacher;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _dbContext.Teacher.ToListAsync();
        }
    }

    public interface ITeacherService
    {
        void Add(Teacher teacher);

        Teacher Get(int id);

        Task<List<Teacher>> GetAllAsync();
    }
}
