using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace Servicios
{
    public class srvUsuarios
    {
        public static IQueryable<Usuarios> ListarUsuarios()
        {
            DC dc = new DC();
            return dc.Usuarios;
        }
        public static Usuarios TraerUsuarioPorLogin(string login)
        {
            DC dc = new DC();
            return (from u in dc.Usuarios
                    where u.Login == login
                    select u).FirstOrDefault();
        }

        public static Boolean AgregarAGrupo(int idUsuario, int idGrupo)
        {
            // Se verifica por Clave Unica
            DC dc = new DC();
            try
            {
                Usuarios_Grupos x = new Usuarios_Grupos();
                x.idUsuario = idUsuario;
                x.idGrupo = idGrupo;

                dc.Usuarios_Grupos.InsertOnSubmit(x);
                dc.SubmitChanges();
                return true;
            }
            catch(System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }

        public static Boolean AgregarAZona(int idUsuario, int idZona)
        {
            DC dc = new DC();
            if (dc.Usuarios_Zonas.SingleOrDefault(j => j.idZonas == idZona && j.idUsuario == idUsuario) != null)
                return false;

            Usuarios_Zonas x = new Usuarios_Zonas();
            x.idUsuario = idUsuario;
            x.idZonas = idZona;

            dc.Usuarios_Zonas.InsertOnSubmit(x);
            dc.SubmitChanges();
            return true;
        }

        public static Boolean AgregarASector(int idUsuario, int idSector)
        {
            DC dc = new DC();
            if (dc.Usuarios_Sectores.SingleOrDefault(j => j.idSectorResponsable == idSector && j.idUsuario == idUsuario) != null)
                return false;

            Usuarios_Sectores x = new Usuarios_Sectores();
            x.idUsuario = idUsuario;
            x.idSectorResponsable = idSector;

            dc.Usuarios_Sectores.InsertOnSubmit(x);
            dc.SubmitChanges();
            return true;
        }

        public static int? obtenerSectorPorDefecto(int idUsuario)
        {
            DC dc = new DC();

            var usuarioSector = from us in dc.Usuarios_Sectores
                                where us.idUsuario == idUsuario
                                select us;
            Usuarios_Sectores x = usuarioSector.Take(1).SingleOrDefault();

            if (x != null)
                return x.idSectorResponsable;
            return null;
        }
    }

}