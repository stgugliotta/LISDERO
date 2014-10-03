using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto AgendaEstado 
    /// </summary>
    public class AgendaEstadoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto AgendaEstado 
        /// </summary>
        /// <param name="idTarea"></param>		
        /// <returns></returns>
        public AgendaEstado Load(int idTarea)
        {
            AgendaEstado oReturn = new AgendaEstado();
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {

                    oReturn = dalAgendaEstado.Load(idTarea);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto AgendaEstado
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        public void Delete(AgendaEstado oAgendaEstado)
        {
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {
                    dalAgendaEstado.Delete(oAgendaEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto AgendaEstado 
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        public void Update(AgendaEstado oAgendaEstado)
        {
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {
                    dalAgendaEstado.Update(oAgendaEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto AgendaEstado 
        /// </summary>
        /// <param name="oAgendaEstado"></param>
        public void Insert(AgendaEstado oAgendaEstado)
        {
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {
                    dalAgendaEstado.Insert(oAgendaEstado);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto AgendaEstado 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idTarea"></param>      
        /// <returns></returns>
        public AgendaEstado GetAgendaEstado(int idTarea)
        {
            AgendaEstado oReturn = new AgendaEstado();
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {
                    oReturn = dalAgendaEstado.Load(idTarea);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos AgendaEstado
        /// de la tabla dbo.TBL_Agenda_Estado
        /// </summary>
        /// <returns></returns>
        public List<AgendaEstado> GetAllAgendaEstados()
        {
            List<AgendaEstado> lstAgendaEstado = new List<AgendaEstado>();
            try
            {
                using (DALAgendaEstado dalAgendaEstado = new DALAgendaEstado())
                {
                    lstAgendaEstado = dalAgendaEstado.GetAllAgendaEstados();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAgendaEstado;

        }
    }
}
