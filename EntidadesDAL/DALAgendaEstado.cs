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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Agenda_Estado
    /// </summary>
    public class DALAgendaEstado : AbstractMapper<AgendaEstado>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAgendaEstado()
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
        /// M?todo que retorna solo un objeto  AgendaEstado
        /// </summary>
        /// <param name="id"></param>  
        /// <returns></returns>
        public AgendaEstado Load(int id)
        {
            try
            {
                AgendaEstado oReturn = null;
                CommandText = "PA_MG_FRONT_Agenda_Estado_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<AgendaEstado> agendaEstados = AbstractFindAll(oParameters);
                if (agendaEstados.Count > 0)
                {
                    oReturn = agendaEstados[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        /// <returns></returns>
        public void Delete(AgendaEstado oAgendaEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Estado_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oAgendaEstado.Id));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        /// <returns></returns>
        public void Update(AgendaEstado oAgendaEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Estado_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oAgendaEstado.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oAgendaEstado.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        /// <returns></returns>
        public void Insert(AgendaEstado oAgendaEstado)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Estado_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oAgendaEstado.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oAgendaEstado.Descripcion));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// AgendaEstado de la tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        /// <returns></returns>
        public List<AgendaEstado> GetAllAgendaEstados()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Estado_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<AgendaEstado> agendaEstados = AbstractFindAll(oParameters);

                return agendaEstados;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, getAgendaEstados", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que crea un objeto AgendaEstado de la tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        /// <returns></returns>
        public override AgendaEstado DoLoad(IDataReader registros)
        {
            try
            {
                AgendaEstado agendaEstado = new AgendaEstado();
                agendaEstado.Id = registros.GetInt32(0);
                agendaEstado.Descripcion = registros.GetString(1);

                return agendaEstado;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgendaEstado, getAgendaEstados", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override AgendaEstado DoLoad(IDataReader registros, AgendaEstado ent)
        {
            throw new NotImplementedException();
        }
    }
}
