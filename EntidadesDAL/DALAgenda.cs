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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Agenda
    /// </summary>
    public class DALAgenda : AbstractMapper<Agenda>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALAgenda()
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
        /// M?todo que retorna solo un objeto  Agenda
        /// </summary>
        /// <param name="idTarea"></param>      
        /// <returns></returns>
        public Agenda Load(int idTarea)
        {
            try
            {
                Agenda oReturn = null;
                CommandText = "PA_MG_FRONT_Agenda_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idtarea", DbType.Int32, idTarea));

                List<Agenda> agendas = AbstractFindAll(oParameters);
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
        public void Delete(Agenda oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_DELETE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idtarea", DbType.Int32, oAgenda.IdTarea));

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
        public void Update(Agenda oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_UPDATE";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

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
        public long Insert(Agenda oAgenda)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_INSERT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

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
                
                string idtarea = ExecuteReader(oParameters, "idtarea");

                return  long.Parse(idtarea);
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
        /// Agenda de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public List<Agenda> GetAllAgendas()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_SELECTALL";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Agenda> agendas = AbstractFindAll(oParameters);

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
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Agenda de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public List<Agenda> GetAllAgendasByAnalista(string analista)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_SELECTALL_ByAnalista";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@analista", DbType.String, analista));
                List<Agenda> agendas = AbstractFindAll(oParameters);

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
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Agenda de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public List<Agenda> GetAllAgendasByAnalistaYFecha(string analista,DateTime fecha)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_SELECTALL_ByAnalistaYFecha";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@analista", DbType.String, analista));
                oParameters.Add(new DBParametro("@fecha", DbType.DateTime, fecha));
                List<Agenda> agendas = AbstractFindAll(oParameters);

                return agendas;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, getAgendas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public List<Agenda> BuscarAgendaPorFiltros(Boolean IdTarea, string FiltroIdTarea, Boolean Hora, string FiltroHora, Boolean Evento, string FiltroEvento, Boolean TipoEvento, string FiltroTipoEvento, Boolean Usuario, string FiltroUsuario, Boolean FechaAct, string FiltroFechaAct, Boolean Prioridad, string FiltroPrioridad, Boolean Tarea, string FiltroTarea, Boolean Estado, string FiltroEstado, Boolean Contacto, string FiltroContacto)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Agenda_SelectALL_Filtro";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@IdTarea", DbType.Int32, IdTarea));
                oParameters.Add(new DBParametro("@FiltroIdTarea", DbType.String, FiltroIdTarea));
                oParameters.Add(new DBParametro("@Hora", DbType.Int32, Hora));
                oParameters.Add(new DBParametro("@FiltroHora", DbType.String, FiltroHora));
                oParameters.Add(new DBParametro("@Evento", DbType.Int32, Evento));
                oParameters.Add(new DBParametro("@FiltroEvento", DbType.String, FiltroEvento));
                oParameters.Add(new DBParametro("@TipoEvento", DbType.Int32, TipoEvento));
                oParameters.Add(new DBParametro("@FiltroTipoEvento", DbType.String, FiltroTipoEvento));
                oParameters.Add(new DBParametro("@Usuario", DbType.Int32, Usuario));
                oParameters.Add(new DBParametro("@FiltroUsuario", DbType.String, FiltroUsuario));
                oParameters.Add(new DBParametro("@FechaAct", DbType.Int32, FechaAct));
                oParameters.Add(new DBParametro("@FiltroFechaAct", DbType.String, FiltroFechaAct));
                oParameters.Add(new DBParametro("@Prioridad", DbType.Int32, Prioridad));
                oParameters.Add(new DBParametro("@FiltroPrioridad", DbType.String, FiltroPrioridad));
                oParameters.Add(new DBParametro("@Tarea", DbType.Int32, Tarea));
                oParameters.Add(new DBParametro("@FiltroTarea", DbType.String, FiltroTarea));
                oParameters.Add(new DBParametro("@Estado", DbType.Int32, Estado));
                oParameters.Add(new DBParametro("@FiltroEstado", DbType.String, FiltroEstado));
                oParameters.Add(new DBParametro("@Contacto", DbType.Int32, Contacto));
                oParameters.Add(new DBParametro("@FiltroContacto", DbType.String, FiltroContacto));
                List<Agenda> agendas = AbstractFindAll(oParameters);

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
        /// M?todo que crea un objeto Agenda de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        /// <returns></returns>
        public override Agenda DoLoad(IDataReader registros)
        {
            try
            {
                Agenda agenda = new Agenda();
                agenda.IdTarea = registros.GetInt32(0);
                agenda.Usuario = registros.GetString(1);
                agenda.UsuarioAsignado = registros.GetString(2);
                agenda.Tarea = registros.GetString(3);
                agenda.FechaDeAlerta = registros.GetDateTime(4);
                agenda.Estado = registros.GetString(5);
                agenda.Criticidad = registros.GetString(6);
                agenda.CodigoRelacion = registros.GetInt32(7);
                agenda.IdTipoContacto = registros.GetInt32(8);
                //agenda.IdTipoEvento = registros.GetInt32(9);
                agenda.IdTipoEvento = (registros.IsDBNull(9) ? 0 : registros.GetInt32(9));
                agenda.FechaActualizacion = registros.GetDateTime(10);
                try
                {
                    agenda.IdEstado = registros.GetInt32(11);
                }
                catch (Exception)
                {
                    agenda.IdEstado=0;
                    
                }
                
                agenda.ContactoEventual = (registros.IsDBNull(12) ? "" : registros.GetString(12));
                
                return agenda;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALAgenda, getAgendas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public override Agenda DoLoad(IDataReader registros, Agenda ent)
        {
            throw new NotImplementedException();
        }
    }
}
