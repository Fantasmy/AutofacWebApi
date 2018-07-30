using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class AlumnoController : ApiController
    {

        //constructor publico, pasa 2 propiedades IBusiness y ILogger

        private readonly ILogger Log;
        private readonly IBusiness studentBl;
        public AlumnoController(ILogger Log, IBusiness business)
        {
            this.Log = Log;
            this.studentBl = business;
        }

        // GET: api/Alumno
        //http://localhost:57960/api/alumno/GetAll
        //[ConnectionFilter]
        [HttpGet()]
        public IHttpActionResult GetAll()
        {
            // HACER TRY CATCH
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(studentBl.GetAll());
        }

        // GET: api/Alumno/5
        [HttpGet()]
        [Route("api/Alumno/GetById/{guid}")]
        public IHttpActionResult GetById(Guid id)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.SelectById(id));
        }

        // POST: api/Alumno
        [HttpPost()]
        [Route("api/Alumno/Post")]
        public IHttpActionResult Post(Alumno entity)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Create(entity));
        }

        // PUT: api/Alumno/5
        [HttpPut()]
        [Route("api/Alumno/Update/{guid}")]
        public IHttpActionResult Put(Guid id, Alumno entity)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Update(id, entity));
        }

        // DELETE: api/Alumno/5
        [HttpDelete()]
        [Route("api/Alumno/Remove/{guid}")]
        public IHttpActionResult Remove(Guid id)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Delete(id));
        }
    }
}
