using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
using Herramientas;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_GrupoEmail_Contenido
    /// </summary>
    public class DALGrupoEmailContenido : AbstractMapper<GrupoEmailContenido>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALGrupoEmailContenido()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALGrupoEmailContenido()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  GrupoEmailc
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public GrupoEmailContenido Load(int idGrupoEmail, string codigoRelacion)
        {
            try
            {
                GrupoEmailContenido oReturn = null;
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, codigoRelacion));

                List<GrupoEmailContenido> grupoEmailContenido = AbstractFindAll(oParameters);
                if (grupoEmailContenido.Count > 0)
                {
                    oReturn = grupoEmailContenido[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        /// <returns></returns>
        public void Delete(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        /// <returns></returns>
        public void Update(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_GrupoEmail
        /// </summary>
        /// <param name="oGrupoEmail"></param>
        /// <returns></returns>
        public void Insert(GrupoEmailContenido oGrupoEmailContenido)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, oGrupoEmailContenido.IdGrupoEmail));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.String, oGrupoEmailContenido.CodigoRelacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// GrupoEmail de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        /// <returns></returns>
        public List<GrupoEmailContenido> GetAllGrupoEmailContenido()
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<GrupoEmailContenido> gruposEmailContenido = AbstractFindAll(oParameters);

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, getGrupoEmailContenido", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// GrupoEmail de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="idGrupoEmail"></param>
        /// <returns></returns>
        public List<GrupoEmailContenido> GetAllGrupoEmailContenidoByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_Contenido_SELECTALL_byIdGrupoEmail";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));

                List<GrupoEmailContenido> gruposEmailContenido = AbstractFindAll(oParameters);

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, GetAllGrupoEmailContenidoByIdGrupoEmail", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        //Agregado por Natalia
        public List<GrupoEmailContenido> GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_SelectALL_ByIdGrupoEmail";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@id_grupoEmail", DbType.Int32, idGrupoEmail));

                List<GrupoEmailContenido> gruposEmailContenido = AbstractFindAll(oParameters);

                return gruposEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, PA_MG_FRONT_GrupoEmail_ContenidoCargoEmpresa_SelectALL_ByIdGrupoEmail", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto GrupoEmailContenido de la tabla dbo.TBL_GrupoEmail_Contenido
        /// </summary>
        /// <param name="oGrupoEmailContenido"></param>
        /// <returns></returns>
        public override GrupoEmailContenido DoLoad(IDataReader registros)
        {
            try
            {
                GrupoEmailContenido grupoEmailContenido = new GrupoEmailContenido();
                grupoEmailContenido.IdGrupoEmail = registros.GetInt32(0);
                grupoEmailContenido.CodigoRelacion = registros.GetString(1);

                return grupoEmailContenido;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmailContenido, DoLoad", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override GrupoEmailContenido DoLoad(IDataReader registros, GrupoEmailContenido ent)
        {
            throw new NotImplementedException();
        }
    }   
    
}
