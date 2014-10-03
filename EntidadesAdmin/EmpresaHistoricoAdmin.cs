using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    public class EmpresaHistoricoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Empresa 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public EmpresaHistorico Load(int id)
        {
            EmpresaHistorico oReturn = new EmpresaHistorico();
            try
            {
                using (DALEmpresaHistorico dalEmpresa = new DALEmpresaHistorico())
                {
                    oReturn = dalEmpresa.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Empresa
        /// </summary>
        /// <param name="oEmpresa"></param>
        public void Delete(EmpresaHistorico oEmpresa)
        {
            try
            {
                using (DALEmpresaHistorico dalEmpresa = new DALEmpresaHistorico())
                {
                    dalEmpresa.Delete(oEmpresa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Empresa 
        /// </summary>
        /// <param name="oEmpresa"></param>
        public void Update(EmpresaHistorico oEmpresa)
        {
            try
            {
                using (DALEmpresaHistorico dalEmpresa = new DALEmpresaHistorico())
                {
                    dalEmpresa.Update(oEmpresa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Empresa 
        /// </summary>
        /// <param name="oEmpresa"></param>
        public void Insert(EmpresaHistorico oEmpresa)
        {
            try
            {
                using (DALEmpresaHistorico dalEmpresa = new DALEmpresaHistorico())
                {
                    dalEmpresa.Insert(oEmpresa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo de lectura de objeto Empresa 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>                
        /// <returns></returns>
        public EmpresaHistorico GetEmpresa(int id)
        {
            EmpresaHistorico oReturn = new EmpresaHistorico();
            try
            {
                using (DALEmpresaHistorico dalEmpresa = new DALEmpresaHistorico())
                {
                    oReturn = dalEmpresa.Load(id);
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
