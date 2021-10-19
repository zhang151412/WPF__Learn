using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraSQLite.Repository
{
    public class StudentRepository : RepositoryBase<Student, int>
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
