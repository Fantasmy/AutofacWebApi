using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;

namespace Student.Business.Logic.BusinessLogic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;

        public StudentBL(ILogger Logger,IRepository dao)
        {
            this.Log = Logger;
            this.repository = dao;
        }

        //public Alumno Create(Alumno entity)
            public int Create(Alumno entity)
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);  // system.reflection para obtenr el nombre del método
                return repository.Create(entity);
                //return id;
            }
            catch (Exception ex)
            {
                Log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Alumno> GetAll()
        {
            throw new NotImplementedException();
        }

        public Alumno SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Alumno Update(int id, Alumno entity)
        {
            throw new NotImplementedException();
        }
    }
}
