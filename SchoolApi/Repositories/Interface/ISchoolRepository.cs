using System;
using SchoolApi.Models.Entities;
using SchoolApi.Repositories.Base;

namespace SchoolApi.Repositories.Interface
{
    public interface ISchoolRepository:IEntityRepository<School>
    {
    }
}

