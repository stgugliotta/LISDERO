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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Agenda_Historia
    /// </summary>
    public class DALAgendaHistoria : AbstractMapper<AgendaHistoria>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAgendaHistoria()
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
        /// M?todo que retorna solo un objeto  AgendaHistoria
        /// </summary>
        /// <param name="idTareaHistoria"></param>      
        /// <returns></returns>
        public AgendaHistoria Load(int idTareaHistoria)
        {
            try
            {
                AgendaHistoria oReturn = null;
                CommandText = "PA_MG_FRONT_Agenda_Historia_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idTareaHistoria", DbType.Int32, idTareaHistoria));

                List<AgendaHistoria> agendas = AbstractFindAll(oParameters);
                if (agendas.Count > 0)
                {
                    oReturn = agendas[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public void Delete(AgendaHistoria oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Historia_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idtareaHistoria", DbType.Int32, oAgenda.IdTareaHistoria));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public void Update(AgendaHistoria oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Historia_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idtareaHistoria", DbType.Int32, oAgenda.IdTareaHistoria));
                oParameters.Add(new DBParametro("@idtarea", DbType.Int32, oAgenda.IdTarea));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oAgenda.Usuario));
                oParameters.Add(new DBParametro("@usuarioAsignado", DbType.String, oAgenda.UsuarioAsignado));
                oParameters.Add(new DBParametro("@tarea", DbType.String, oAgenda.Tarea));
                oParameters.Add(new DBParametro("@fechadealerta", DbType.DateTime, oAgenda.FechaDeAlerta));
                oParameters.Add(new DBParametro("@estado", DbType.String, oAgenda.Estado));
                oParameters.Add(new DBParametro("@criticidad", DbType.String, oAgenda.Criticidad));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.Int32, oAgenda.CodigoRelacion));
                oParameters.Add(new DBParametro("@id_tipo_contacto", DbType.Int32, oAgenda.IdTipoContacto));
                oParameters.Add(new DBParametro("@id_tipo_evento", DbType.Int32, oAgenda.IdTipoEvento));
                oParameters.Add(new DBParametro("@fechaactualizacion", DbType.DateTime, DateTime.Now));
                oParameters.Add(new DBParametro("@id_estado", DbType.Int32, oAgenda.IdEstado));
                oParameters.Add(new DBParametro("@contactoeventual", DbType.String, oAgenda.ContactoEventual));
                
                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que Inserta un registro en la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public long Insert(AgendaHistoria oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Historia_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idtareaHistoria", DbType.Int32, oAgenda.IdTareaHistoria));
                oParameters.Add(new DBParametro("@idtarea", DbType.Int32, oAgenda.IdTarea));
                oParameters.Add(new DBParametro("@usuario", DbType.String, oAgenda.Usuario));
                oParameters.Add(new DBParametro("@usuarioAsignado", DbType.String, oAgenda.UsuarioAsignado));
                oParameters.Add(new DBParametro("@tarea", DbType.String, oAgenda.Tarea));
                oParameters.Add(new DBParametro("@fechadealerta", DbType.DateTime, oAgenda.FechaDeAlerta));
                oParameters.Add(new DBParametro("@estado", DbType.String, oAgenda.Estado));
                oParameters.Add(new DBParametro("@criticidad", DbType.String, oAgenda.Criticidad));
                oParameters.Add(new DBParametro("@codigo_relacion", DbType.Int32, oAgenda.CodigoRelacion));
                oParameters.Add(new DBParametro("@id_tipo_contacto", DbType.Int32, oAgenda.IdTipoContacto));
                oParameters.Add(new DBParametro("@id_tipo_evento", DbType.Int32, oAgenda.IdTipoEvento));
                oParameters.Add(new DBParametro("@fechaactualizacion", DbType.DateTime, DateTime.Now));
                oParameters.Add(new DBParametro("@id_estado", DbType.Int32, oAgenda.IdEstado));
                oParameters.Add(new DBParametro("@contactoeventual", DbType.String, oAgenda.ContactoEventual));
                
                string idtareahistoria = ExecuteReader(oParameters, "idtareahistoria");

                return  long.Parse(idtareahistoria);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// AgendaHistoria de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public List<AgendaHistoria> GetAllAgendas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_Historia_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<AgendaHistoria> agendas = AbstractFindAll(oParameters);

                return agendas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, getAgendas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


       
        /// <summary>
        /// Método que retorna  todos los registro convertido en una lista de Objetos
        /// Agenda de la tabla dbo.TBL_Agenda_Historia para un determinado idTarea.
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public List<AgendaHistoria> GetAllAgendasHistoriaByIdTarea(int idTarea)
        {
            try
            {
                CommandText = "PA_MG_FRONT_AgendaHistoria_SelectALL_ByIdTarea";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idTarea", DbType.Int32, idTarea));
                List<AgendaHistoria> agendas = AbstractFindAll(oParameters);

                return agendas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, GetAllAgendasHistoriaByIdTarea", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

  
        


        /// <summary>
        /// M?todo que crea un objeto AgendaHistoria de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public override AgendaHistoria DoLoad(IDataReader registros)
        {
            try
            {
                AgendaHistoria agenda = new AgendaHistoria();
                agenda.IdTareaHistoria = registros.GetInt32(0);
                agenda.IdTarea = registros.GetInt32(1);
                agenda.Usuario = registros.GetString(2);
                agenda.UsuarioAsignado = registros.GetString(3);
                agenda.Tarea = registros.GetString(4);
                agenda.FechaDeAlerta = registros.GetDateTime(5);
                agenda.Estado = registros.GetString(6);
                agenda.Criticidad = registros.GetString(7);
                agenda.CodigoRelacion = registros.GetInt32(8);
                agenda.IdTipoContacto = registros.GetInt32(9);
                //agenda.IdTipoEvento = registros.GetInt32(9);
                agenda.IdTipoEvento = (registros.IsDBNull(10) ? 0 : registros.GetInt32(10));
                agenda.FechaActualizacion = registros.GetDateTime(11);
                agenda.IdEstado = registros.GetInt32(12);
                agenda.ContactoEventual = (registros.IsDBNull(13) ? "" : registros.GetString(13));
                
                return agenda;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, getAgendas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override AgendaHistoria DoLoad(IDataReader registros, AgendaHistoria ent)
        {
            throw new NotImplementedException();
        }
    }
}
