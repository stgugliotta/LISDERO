using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto Agenda 
    /// </summary>
    public class AgendaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Agenda 
        /// </summary>
        /// <param name="idTarea"></param>		
        /// <returns></returns>
        public Agenda Load(int idTarea)
        {
            Agenda oReturn = new Agenda();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {

                    oReturn = dalAgenda.Load(idTarea);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Agenda
        /// </summary>
        /// <param name="oAgenda"></param>
        public void Delete(Agenda oAgenda)
        {
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    dalAgenda.Delete(oAgenda);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Agenda 
        /// </summary>
        /// <param name="oAgenda"></param>
        public void Update(Agenda oAgenda)
        {
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    dalAgenda.Update(oAgenda);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Agenda 
        /// </summary>
        /// <param name="oAgenda"></param>
        public long Insert(Agenda oAgenda)
        {
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    long idagenda = dalAgenda.Insert(oAgenda);

                    return idagenda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto Agenda 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idTarea"></param>      
        /// <returns></returns>
        public Agenda GetAgenda(int idTarea)
        {
            Agenda oReturn = new Agenda();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    oReturn = dalAgenda.Load(idTarea);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Agenda
        /// de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetAllAgendas()
        {
            List<Agenda> lstAgenda = new List<Agenda>();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    lstAgenda = dalAgenda.GetAllAgendas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAgenda;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Agenda
        /// de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetAllAgendasByAnalista(string analista)
        {
            List<Agenda> lstAgenda = new List<Agenda>();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    lstAgenda = dalAgenda.GetAllAgendasByAnalista(analista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAgenda;

        }

        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos Agenda
        /// de la tabla dbo.TBL_Agenda
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetAllAgendasByAnalistaYFecha(string analista,DateTime fecha)
        {
            List<Agenda> lstAgenda = new List<Agenda>();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    lstAgenda = dalAgenda.GetAllAgendasByAnalistaYFecha(analista,fecha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAgenda;

        }

        public List<Agenda> BuscarAgendaPorFiltros(Boolean IdTarea, string FiltroIdTarea, Boolean Hora, string FiltroHora, Boolean Evento, string FiltroEvento, Boolean TipoEvento, string FiltroTipoEvento, Boolean Usuario, string FiltroUsuario, Boolean FechaAct, string FiltroFechaAct, Boolean Prioridad, string FiltroPrioridad, Boolean Tarea, string FiltroTarea, Boolean Estado, string FiltroEstado, Boolean Contacto, string FiltroContacto)
        {
            List<Agenda> lstAgenda = new List<Agenda>();
            try
            {
                using (DALAgenda dalAgenda = new DALAgenda())
                {
                    lstAgenda = dalAgenda.BuscarAgendaPorFiltros(IdTarea, FiltroIdTarea, Hora, FiltroHora, Evento, FiltroEvento, TipoEvento, FiltroTipoEvento, Usuario, FiltroUsuario, FechaAct, FiltroFechaAct, Prioridad, FiltroPrioridad, Tarea, FiltroTarea, Estado, FiltroEstado, Contacto,FiltroContacto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAgenda;

        }

        public List<AgendaHistoria> GetAllAgendasHistoriaByIdTarea(int idTarea)
        {
            List<AgendaHistoria> lstAgenda = new List<AgendaHistoria>();
            try
            {

                using (DALAgendaHistoria dalAgenda = new DALAgendaHistoria())
                {
                    lstAgenda = dalAgenda.GetAllAgendasHistoriaByIdTarea(idTarea);
                }
            
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstAgenda;

        }


      

        /// <summary>
        /// M?todo de lectura de objeto AgendaHistoria 
        /// </summary>
        /// <param name="idTareaHistoria"></param>		
        /// <returns></returns>
        public AgendaHistoria LoadHistorica(int idTareaHistoria)
        {
            AgendaHistoria oReturn = new AgendaHistoria();
            try
            {
                using (DALAgendaHistoria dalAgenda = new DALAgendaHistoria())
                {

                    oReturn = dalAgenda.Load(idTareaHistoria);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }



    }
}
