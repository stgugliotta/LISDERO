using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_TipoEvento
    /// </summary>
    public class DALTipoEvento : AbstractMapper<TipoEvento>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALTipoEvento()
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


        /// <summary>
        /// M?todo que retorna solo un objeto  TipoEvento
        /// </summary>
        /// <param name="id"></param>      
        /// <returns></returns>
        public TipoEvento Load(int id)
        {
            try
            {
                TipoEvento oReturn = null;
                CommandText = "PA_MG_FRONT_TipoEvento_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<TipoEvento> tiposDeEvento = AbstractFindAll(oParameters);
                if (tiposDeEvento.Count > 0)
                {
                    oReturn = tiposDeEvento[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        /// <returns></returns>
        public void Delete(TipoEvento oTipoEvento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TipoEvento_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoEvento.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        /// <returns></returns>
        public void Update(TipoEvento oTipoEvento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TipoEvento_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoEvento.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oTipoEvento.Descripcion));
                oParameters.Add(new DBParametro("@rgb_color", DbType.String, oTipoEvento.RgbColor));
                oParameters.Add(new DBParametro("@fecha_deshabilitacion", DbType.DateTime, oTipoEvento.FechaDeshabilitacion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que Inserta un registro en la tabla dbo.TBL_TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        /// <returns></returns>
        public long Insert(TipoEvento oTipoEvento)
        {
            try
            {
                CommandText = "PA_MG_FRONT_TipoEvento_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oTipoEvento.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oTipoEvento.Descripcion));
                oParameters.Add(new DBParametro("@rgb_color", DbType.String, oTipoEvento.RgbColor));

                string id = ExecuteReader(oParameters, "id");

                return long.Parse(id);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// TipoEvento de la tabla dbo.TBL_TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        /// <returns></returns>
        public List<TipoEvento> GetAllTiposDeEvento()
        {
            try
            {
                CommandText = "PA_MG_FRONT_TipoEvento_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<TipoEvento> tiposDeEvento = AbstractFindAll(oParameters);

                return tiposDeEvento;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, getTipoEventos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        /// <summary>
        /// M?todo que crea un objeto TipoEvento de la tabla dbo.TBL_TipoEvento
        /// </summary>
        /// <param name="oTipoEvento"></param>
        /// <returns></returns>
        public override TipoEvento DoLoad(IDataReader registros)
        {
            try
            {
                TipoEvento tipoEvento = new TipoEvento();
                tipoEvento.Id = registros.GetInt32(0);
                tipoEvento.Descripcion = registros.GetString(1);
                tipoEvento.RgbColor = registros.GetString(2);
                if (!registros.IsDBNull(3)) tipoEvento.FechaDeshabilitacion =  registros.GetDateTime(3);
                
                return tipoEvento;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTipoEvento, getTipoEventos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override TipoEvento DoLoad(IDataReader registros, TipoEvento ent)
        {
            throw new NotImplementedException();
        }
    }
}
