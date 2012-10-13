using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Servicios
{
    public class Seguridad
    {
        public static Usuarios Usuario;
        public static int idZona = 0;

        public static Usuarios Login(string login, string password)
        {
            DC dc = new DC();
            return (from u in dc.Usuarios
                    where u.Login == login && u.Password == password
                    select u).FirstOrDefault();
        }

        public static bool PuedeOperarZona(int idDivision)
        {
            DC dc = new DC();
            var usz=from uz in dc.Usuarios_Zonas
                    join div in dc.Divisiones on uz.idZonas equals div.idZona
                    where uz.idZonas==idZona && uz.idUsuario==Usuario.idUsuario
                    && div.idDivision==idDivision
                    select uz;
            if (usz.Count()>0)
                return true;
            else
                return false;
        }

        public static void AgregarPuertasRec(int idPuerta, int idPerfil)
        {
            DC dc = new DC();

            //tiene acceso la puerta padre?
            if (dc.Accesos.SingleOrDefault(j => j.idPuerta == idPuerta && j.idGrupo == idPerfil) == null)
            {
                Accesos oAcceso = new Accesos();
                oAcceso.idGrupo = idPerfil;
                oAcceso.idPuerta = idPuerta;
                dc.Accesos.InsertOnSubmit(oAcceso);
                dc.SubmitChanges();
            }

            int idPuertaPadre = dc.Puertas.Single(k => k.idPuerta == idPuerta).idPuertaPadre;
            if (idPuertaPadre == 0)
                return;

            //tiene acceso la puerta padre? NO LO ASUMO!, "valido la base"
            if (dc.Accesos.SingleOrDefault(j => j.idPuerta == idPuertaPadre && j.idGrupo == idPerfil) == null)
            {
                Accesos oAccesoPadre = new Accesos();
                oAccesoPadre.idGrupo = idPerfil;
                oAccesoPadre.idPuerta = idPuertaPadre;
                dc.Accesos.InsertOnSubmit(oAccesoPadre);
                dc.SubmitChanges();
                Seguridad.AgregarPuertasRec(idPuertaPadre, idPerfil);
            }
        }

        public static Boolean VerificarAcceso(int intUsuario, int idPuerta)
        {
            DC dc = new DC();
            if (null ==
                    (from a in dc.Accesos
                     join ug in dc.Usuarios_Grupos on a.idGrupo equals ug.idGrupo
                     where a.idPuerta == idPuerta && ug.idUsuario == intUsuario
                     select a).FirstOrDefault())
                return false;
            else
                return true;
        }

        public static Boolean VerificarAcceso(int intUsuario, string strCodigoPuerta)
        {
            DC dc = new DC();
            if (null ==
                    (from a in dc.Accesos
                     join ug in dc.Usuarios_Grupos on a.idGrupo equals ug.idGrupo
                     where ug.idUsuario == intUsuario && a.Puertas.Codigo==strCodigoPuerta
                     select a).FirstOrDefault())
                return false;
            else
                return true;
        }

        public static IQueryable<Puertas> ListarAccesos(int idUsuario)
        {
            DC dc = new DC();
            return ( from p in dc.Puertas
                     join a in dc.Accesos on p.idPuerta equals a.idPuerta
                     join g in dc.Grupos on a.idGrupo equals g.idGrupo
                     join ug in dc.Usuarios_Grupos on g.idGrupo equals ug.idGrupo
                     where ug.idUsuario==idUsuario
                     select p);
        }
    }
}
