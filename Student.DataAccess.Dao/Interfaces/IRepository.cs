using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Interfaces
{
    public interface IRepository
    {
        int Create(Alumno entity);
        Alumno SelectById(Guid id);
        List<Alumno> GetAll();
        Alumno Update(Guid id, Alumno entity);
        int Delete(Guid id);

    }
}
