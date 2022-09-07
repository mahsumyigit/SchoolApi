using System;
using SchoolApi.Context;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Base;
using SchoolApi.Repositories.Interface;

namespace SchoolApi.Repositories.Concretes
{
    public class SchoolRepository : EfEntityRepositoryBase<School, DbContextBase>, ISchoolRepository
    {
    }
}

