using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Repository
{
    public class StudentDaoSql : IRepository
    {
        private readonly ILogger Log;
        private readonly string connectionString;

        public StudentDaoSql(ILogger log)
        {
            this.Log = log;
            connectionString = "Data Source=.; Initial Catalog = VuelingApi; integrated Secutiry=true;"; //DataSource es el nombre del servidor, localhost o ., ip si es remoto. Initial Catalog = base de datos
        }

        public int Create(Alumno entity)
        {
            try
            {
                var sql = "insert into dbo.Alumnos (UUID,Nombre,Apellido,Dni,DataRegistry,DateBorn,Edad )" +
                    "values (@UUID,@Nombre,@Apellido,@Dni,@Registro,@Nacimiento,@Edad);";
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))

                    {
                        _conn.Open();  // ANtes de lanzar hay que abrir la conexion 

                        _cmd.Parameters.AddWithValue("@UUID", entity.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                        _cmd.Parameters.AddWithValue("@Dni", entity.Dni);
                        _cmd.Parameters.AddWithValue("@Nacimiento", entity.Nacimiento);
                        _cmd.Parameters.AddWithValue("@Registro", entity.Registro);
                        _cmd.Parameters.AddWithValue("@Edad", entity.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtain here last inserted identified
                        var id = Convert.ToInt32(_cmd.ExecuteScalar());
                        //return SelectById(id);
                        return id;
                    }
                }
            }

            catch (SqlException ex)
            {
                //log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

        }
        //public int Delete(int id)

    }
}

