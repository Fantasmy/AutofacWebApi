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
        private readonly ILogger log;
        private readonly string connectionString;

        public StudentDaoSql(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=.; Initial Catalog = VuelingApi; integrated Secutiry=true;"; //DataSource es el nombre del servidor, localhost o ., ip si es remoto. Initial Catalog = base de datos
        }

        #region Create
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
                        _conn.Open();  // Antes de lanzar hay que abrir la conexion 

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
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Delete
        public int Delete(Guid id)
        {
            try
            {
                // var sql = "DELETE FROM dbo.Alumnos WHERE Guid='@GUID'";
                var sql = "DELETE FROM dbo.Alumnos WHERE id=@GUID";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@GUID", id);

                        _cmd.ExecuteNonQuery();

                        return 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw;
            }
        }
        #endregion

        #region GetAll
        public List<Alumno> GetAll()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {
                var sql = "SELECT * FROM dbo.Alumnos";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    // Importante abrir la conexion antes de lanzar ningun comando
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno entity = new Alumno(Guid.Parse(reader["guid"].ToString()), Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellidos"].ToString(), reader["dni"].ToString(), Convert.ToInt32(reader["edad"]), DateTime.Parse(reader["nacimiento"].ToString()), DateTime.Parse(reader["registro"].ToString()));
                                listaAlumnos.Add(entity);
                            }
                        }
                    }
                }

                return listaAlumnos;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region SelectById
        public Alumno SelectById(Guid id)
        {
            Alumno alumno = null;

            try
            {
                var sql = "SELECT * FROM dbo.Alumnos WHERE id=@GUID";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@GUID", id);

                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumno = new Alumno(Guid.Parse(reader["guid"].ToString()), Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellidos"].ToString(), reader["dni"].ToString(), Convert.ToInt32(reader["edad"]), DateTime.Parse(reader["nacimiento"].ToString()), DateTime.Parse(reader["registro"].ToString()));
                            }
                        }
                    }
                }

                return alumno;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public Alumno Update(Guid id, Alumno entity)
        {
            try
            {
                var sql = "UPDATE dbo.Alumnos SET id=@Guid, Nombre=@Nombre, Apellidos=@Apellidos, Dni=@Dni, Registro=@Registro, Nacimiento=@Nacimiento, Edad=@Edad WHERE id=@Guid";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", id);
                        _cmd.Parameters.AddWithValue("@Nombre", entity.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", entity.Apellido.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", entity.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", entity.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", entity.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", entity.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        return SelectById(id);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion
    }
}

