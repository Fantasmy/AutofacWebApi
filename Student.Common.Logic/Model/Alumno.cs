using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Model
{
    public class Alumno
    {

        #region Propierties
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Registro { get; set; }
        #endregion

        #region Constructors 
        public Alumno()
        {
            this.Guid = Guid.NewGuid();
        }


        #region
        public Alumno(Guid guid, int id, string dni, string nombre, string apellido, int edad, DateTime nacimiento, DateTime registro)
        {
            Guid = guid;
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Nacimiento = nacimiento;
            Registro = registro;
        }

        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Guid.Equals(alumno.Guid) &&
                   Id == alumno.Id &&
                   Dni == alumno.Dni &&
                   Nombre == alumno.Nombre &&
                   Apellido == alumno.Apellido &&
                   Edad == alumno.Edad &&
                   Nacimiento == alumno.Nacimiento &&
                   Registro == alumno.Registro;
        }

        #endregion

        #region
        public override int GetHashCode()
        {
            var hashCode = -377388725;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Guid);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + Nacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Registro.GetHashCode();
            return hashCode;
        }
        #endregion







    }
}

#endregion