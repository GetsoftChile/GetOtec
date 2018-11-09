using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using ENT;

namespace DAL
{
    public class Datos
    {
        Database db = DatabaseFactory.CreateDatabase();


        public DataSet GetBuscarUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            if (user.Rut == string.Empty)
            {
                db.AddInParameter(cmd, "@rut", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@rut", DbType.String, user.Rut);
            }

            db.AddInParameter(cmd, "@nombre", DbType.String, user.Nombre);
            db.AddInParameter(cmd, "@idPerfil", DbType.String, user.IdPerfil);
            db.AddInParameter(cmd, "@login", DbType.String, user.Login);
            db.AddInParameter(cmd, "@clave", DbType.String, user.Clave);
            db.AddInParameter(cmd, "@areaCargo", DbType.String, user.AreaCargo);
            db.AddInParameter(cmd, "@activo", DbType.String, user.Activo);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarUsuarioPorPerfil(string idPerfil, int activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioPorPerfil");

            db.AddInParameter(cmd, "@idPerfil", DbType.String, idPerfil);
            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }







        public DataSet GetBuscarValUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_ValUsuario");


            db.AddInParameter(cmd, "@login", DbType.String, user.Login);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarUsuarioMandante(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarUsuarioAsignadoMandante(int idMandante)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioAsignadoPorMandante");

            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }


        public string SetInUpUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@Rut", DbType.String, user.Rut);
            db.AddInParameter(cmd, "@Nombre", DbType.String, user.Nombre);
            db.AddInParameter(cmd, "@Email", DbType.String, user.Email);
            if (user.IdPerfil == 0)
            {
                db.AddInParameter(cmd, "@IdPerfil", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdPerfil", DbType.String, user.IdPerfil);
            }
            db.AddInParameter(cmd, "@Login", DbType.String, user.Login);
            db.AddInParameter(cmd, "@Clave", DbType.String, user.Clave);
            db.AddInParameter(cmd, "@AreaCargo", DbType.String, user.AreaCargo);
            db.AddInParameter(cmd, "@Foto", DbType.String, user.Foto);
            db.AddInParameter(cmd, "@Activo", DbType.String, user.Activo);

            if (user.IdUsuarioDiscador == 0)
            {
                db.AddInParameter(cmd, "@idUsuarioDiscador", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idUsuarioDiscador", DbType.String, user.IdUsuarioDiscador);
            }




            try
            {
                string val = db.ExecuteScalar(cmd).ToString();
                return val;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
        }

        public void SetInUsuarioMandante(UsuarioMandante user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@IdMandante", DbType.String, user.IdMandante);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario mandante, " + ex.Message, ex);
            }
        }

        public void SetDelUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
        }


        public void SetDelMensajes(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMensaje");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar los mensajes , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar los mensajes , " + ex.Message, ex);
            }
        }

        public void SetUpFotoUsuario(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpFotoUsuario");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@foto", DbType.String, user.Foto);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar la fotografia del usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar la fotografia del usuario, " + ex.Message, ex);
            }
        }


        public void SetDelUsuarioMandante(UsuarioMandante user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelUsuarioMandante");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario , " + ex.Message, ex);
            }
        }

        //PERFIL




        public DataSet GetBuscarPerfil(Perfil per)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarPerfil");
            //@idMandante int, @nomMandante varchar(30), @razonSocial varchar(100), @giro varchar(50), @rut varchar(12), @activo int
            db.AddInParameter(cmd, "@idPerfil", DbType.String, per.IdPerfil);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el perfil, " + ex.Message, ex);
            }
        }


        //MANDANTE

        public DataSet GetBuscarMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandante");
            //@idMandante int, @nomMandante varchar(30), @razonSocial varchar(100), @giro varchar(50), @rut varchar(12), @activo int
            db.AddInParameter(cmd, "@idMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@nomMandante", DbType.String, man.NomMandante);
            db.AddInParameter(cmd, "@razonSocial", DbType.String, man.RazonSocial);
            db.AddInParameter(cmd, "@giro", DbType.String, man.Giro);
            db.AddInParameter(cmd, "@rut", DbType.String, man.Rut);
            db.AddInParameter(cmd, "@activo", DbType.String, man.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mandante, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarMandanteArchivo(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandanteArchivo");
            //@idMandante int
            db.AddInParameter(cmd, "@idMandante", DbType.String, man.IdMandante);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mandante archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mandante archivo, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarMoneda(Moneda mo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMoneda");

            db.AddInParameter(cmd, "@activo", DbType.String, mo.Activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la moneda, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la moneda, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarComuna(Comuna co)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarComuna");

            db.AddInParameter(cmd, "@idComuna", DbType.String, co.IdComuna);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la comuna, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la comuna, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarMensajePorId(int idMensaje)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMensajePorId");
            db.AddInParameter(cmd, "@idMensaje", DbType.String, idMensaje);


            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar información, " + ex.Message, ex);
            }
        }

        public void SetInMensaje(Mensaje msj)
        {
            //@asunto varchar(10),@mensaje varchar(300),@idUsuarioPara int, @idUsuarioDe int
            DbCommand cmd = db.GetStoredProcCommand("stp_InMensaje");

            db.AddInParameter(cmd, "@asunto", DbType.String, msj.Asunto);
            db.AddInParameter(cmd, "@mensaje", DbType.String, msj.MensajeObs);
            db.AddInParameter(cmd, "@idUsuarioPara", DbType.String, msj.IdUsuarioPara);
            db.AddInParameter(cmd, "@idUsuarioDe", DbType.String, msj.IdUsuarioDe);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el mensaje, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el mensaje, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarMensajes(Usuario usuario, int? leido)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMensajes");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, usuario.IdUsuario);
            db.AddInParameter(cmd, "@leido", DbType.String, leido);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el mensaje, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el mensaje, " + ex.Message, ex);
            }
        }


        public void SetInUpMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InUpMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@NomMandante", DbType.String, man.NomMandante);
            db.AddInParameter(cmd, "@RazonSocial", DbType.String, man.RazonSocial);
            db.AddInParameter(cmd, "@Giro", DbType.String, man.Giro);
            db.AddInParameter(cmd, "@Rut", DbType.String, man.Rut);
            db.AddInParameter(cmd, "@Direccion", DbType.String, man.Direccion);
            if (man.IdComuna == "0")
            {
                db.AddInParameter(cmd, "@idComuna", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idComuna", DbType.String, man.IdComuna);
            }

            db.AddInParameter(cmd, "@Telefono", DbType.String, man.Telefono);
            db.AddInParameter(cmd, "@RepLegalNombre", DbType.String, man.RepLegalNombre);
            db.AddInParameter(cmd, "@RepLegalRut", DbType.String, man.RepLegalRut);
            db.AddInParameter(cmd, "@ContactoNombre", DbType.String, man.ContactoNombre);
            db.AddInParameter(cmd, "@ContactoEmail", DbType.String, man.ContactoEmail);
            db.AddInParameter(cmd, "@DeudaNomAdic1", DbType.String, man.DeudaNomAdic1);
            db.AddInParameter(cmd, "@DeudaNomAdic2", DbType.String, man.DeudaNomAdic2);
            db.AddInParameter(cmd, "@DeudaNomAdic3", DbType.String, man.DeudaNomAdic3);
            db.AddInParameter(cmd, "@DeudaNomAdic4", DbType.String, man.DeudaNomAdic4);
            db.AddInParameter(cmd, "@DeudaNomAdic5", DbType.String, man.DeudaNomAdic5);
            db.AddInParameter(cmd, "@DeudaNomAdic6", DbType.String, man.DeudaNomAdic6);
            db.AddInParameter(cmd, "@DeudaNomAdic7", DbType.String, man.DeudaNomAdic7);
            db.AddInParameter(cmd, "@DeudaNomAdic8", DbType.String, man.DeudaNomAdic8);
            db.AddInParameter(cmd, "@DeudaNomAdic9", DbType.String, man.DeudaNomAdic9);
            db.AddInParameter(cmd, "@DeudaNomAdic10", DbType.String, man.DeudaNomAdic10);
            db.AddInParameter(cmd, "@DeudorNomAdic1", DbType.String, man.DeudorNomAdic1);
            db.AddInParameter(cmd, "@DeudorNomAdic2", DbType.String, man.DeudorNomAdic2);
            db.AddInParameter(cmd, "@DeudorNomAdic3", DbType.String, man.DeudorNomAdic3);
            db.AddInParameter(cmd, "@DeudorNomAdic4", DbType.String, man.DeudorNomAdic4);
            db.AddInParameter(cmd, "@DeudorNomAdic5", DbType.String, man.DeudorNomAdic5);
            db.AddInParameter(cmd, "@TasaMaxConv", DbType.String, man.TasaMaxConv);
            if (man.IdTipoInteres == 0)
            {
                db.AddInParameter(cmd, "@IdTipoInteres", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdTipoInteres", DbType.String, man.IdTipoInteres);
            }

            if (man.IdTipoCliente == 0)
            {
                db.AddInParameter(cmd, "@IdTipoCliente", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdTipoCliente", DbType.String, man.IdTipoCliente);
            }

            db.AddInParameter(cmd, "@InteresMora", DbType.String, man.InteresMora);

            if (man.IdMoneda == 0)
            {
                db.AddInParameter(cmd, "@IdMoneda", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@IdMoneda", DbType.String, man.IdMoneda);
            }
            db.AddInParameter(cmd, "@Activo", DbType.String, man.Activo);
            db.AddInParameter(cmd, "@RutaLogo", DbType.String, man.RutaLogo);
            db.AddInParameter(cmd, "@Skin", DbType.String, man.Skin);
            db.AddInParameter(cmd, "@IdTipoTipificacion", DbType.String, man.IdTipoTipificacion);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el mandante, " + ex.Message, ex);
            }
        }



        public void SetDelMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el mandante, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el mandante, " + ex.Message, ex);
            }
        }

        public void SetUpContrasena(Usuario user)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpPassword");
            db.AddInParameter(cmd, "@idUsuario", DbType.String, user.IdUsuario);
            db.AddInParameter(cmd, "@clave", DbType.String, user.Clave);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el usuario, " + ex.Message, ex);
            }
        }

        public void SetDelMandanteArchivo(Mandante man, string idArchivo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_DelMandanteArchivo");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@IdArchivo", DbType.String, idArchivo);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
        }


        public void SetInMandanteArchivo(Mandante man, string nombre, string desc, string ruta, string idUsuarioIngreso)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_InMandanteArchivo");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            db.AddInParameter(cmd, "@descripcion", DbType.String, desc);
            db.AddInParameter(cmd, "@rutaArchivo", DbType.String, ruta);
            db.AddInParameter(cmd, "@idUsuarioIngreso", DbType.String, idUsuarioIngreso);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
        }

        public void SetUpLogoMandante(Mandante man)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_UpLogoMandante");
            db.AddInParameter(cmd, "@IdMandante", DbType.String, man.IdMandante);
            db.AddInParameter(cmd, "@logo", DbType.String, man.RutaLogo);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo editar el logo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo editar el logo, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarMandantesGeneral(int activo, int idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarMandantesGeneral");
            db.AddInParameter(cmd, "@activo", DbType.String, activo);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los mandantes, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los mandantes, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarUsuarioAsignacion(int idMandante, int idUsuarioAsignado)
        {
            //@idMandante int, @idUsuarioAsignado int
            DbCommand cmd = db.GetStoredProcCommand("stp_BuscarUsuarioAsignacion");
            db.AddInParameter(cmd, "@idMandante", DbType.String, idMandante);
            db.AddInParameter(cmd, "@idUsuarioAsignado", DbType.String, idUsuarioAsignado);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar los usuarios, " + ex.Message, ex);
            }
        }






    }
}
