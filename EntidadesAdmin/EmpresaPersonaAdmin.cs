using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    /// <summary>
    /// Manejador del objeto EmpresaPersona 
    /// </summary>
    public class EmpresaPersonaAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto EmpresaPersona 
        /// </summary>
        /// <param name="idEmpresaPersona"></param>		
        /// <returns></returns>
        public EmpresaPersona Load(int idEmpresaPersona)
        {
            EmpresaPersona oReturn = new EmpresaPersona();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    oReturn = dalEmpresaPersona.Load(idEmpresaPersona);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        public EmpresaPersona GetLastActionByIdFactura(int idFactura)
        {
            EmpresaPersona oReturn = new EmpresaPersona();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    oReturn = dalEmpresaPersona.GetLastActionByIdFactura(idFactura);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
        /// <summary>
        /// M?todo para eliminar un objeto EmpresaPersona
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        public void Delete(EmpresaPersona oEmpresaPersona)
        {
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    dalEmpresaPersona.Delete(oEmpresaPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto EmpresaPersona 
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        public void Update(EmpresaPersona oEmpresaPersona)
        {
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    dalEmpresaPersona.Update(oEmpresaPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto EmpresaPersona 
        /// </summary>
        /// <param name="oEmpresaPersona"></param>
        public void Insert(EmpresaPersona oEmpresaPersona)
        {
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    dalEmpresaPersona.Insert(oEmpresaPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto EmpresaPersona 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="idEmpresaPersona"></param>        
        /// <returns></returns>
        public EmpresaPersona GetEmpresaPersona(int idEmpresaPersona)
        {
            EmpresaPersona oReturn = new EmpresaPersona();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    oReturn = dalEmpresaPersona.Load(idEmpresaPersona);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }


        /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos EmpresaPersona
        /// de la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <returns></returns>
        public List<EmpresaPersona> GetAllEmpresaPersonas()
        {
            List<EmpresaPersona> lstEmpresaPersona = new List<EmpresaPersona>();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    lstEmpresaPersona = dalEmpresaPersona.GetAllEmpresaPersonas();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaPersona;

        }
                /// <summary>
        /// M?todo para traer una lista de la totalidad de los objetos EmpresaPersona
        /// de la tabla dbo.TBL_EmpresaPersona
        /// </summary>
        /// <returns></returns>
        /// 


        public List<EmpresaPersona> GetAllEmpresaPersonaPorCantidad(int cantidadDeRegistros,string cadena)
        {
            List<EmpresaPersona> lstEmpresaPersona = new List<EmpresaPersona>();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    lstEmpresaPersona = dalEmpresaPersona.GetAllEmpresaPersonaPorCantidad(cantidadDeRegistros, cadena);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaPersona;

        }




        public List<EmpresaPersona> GetAllEmpresaPersonaRelaciones(string codigo)
        {
            List<EmpresaPersona> lstEmpresaPersona = new List<EmpresaPersona>();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    lstEmpresaPersona = dalEmpresaPersona.GetAllEmpresaPersonaRelaciones(codigo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaPersona;

        }

        public List<EmpresaPersona> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            List<EmpresaPersona> lstEmpresaPersona = new List<EmpresaPersona>();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    lstEmpresaPersona = dalEmpresaPersona.GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(idFactura, idCliente, fechaVenc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaPersona;

        }


        public List<EmpresaPersona> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            List<EmpresaPersona> lstEmpresaPersona = new List<EmpresaPersona>();
            try
            {
                using (DALEmpresaPersona dalEmpresaPersona = new DALEmpresaPersona())
                {
                    lstEmpresaPersona = dalEmpresaPersona.GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(idFactura, idCliente, fechaVenc, idEstado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpresaPersona;

        }

        
    }
}
