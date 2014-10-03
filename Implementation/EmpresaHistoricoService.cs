using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Common.Interfaces;
using Gobbi.CoreServices.ExceptionHandling;
using EntidadesAdmin;
using Entidades;

namespace Implementation
{
    public class EmpresaHistoricoService : IEmpresaHistoricoService
    {
        #region IEmpresaHistoricoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto EmpresaDataContracts
        /// </summary>
        /// <value>EmpresaDataContracts</value>
        public EmpresaHistoricoDataContracts Load(int id)
        {
            try
            {
                EmpresaHistoricoAdmin empresaAdmin = new EmpresaHistoricoAdmin();
                return (EmpresaHistoricoDataContracts)empresaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(EmpresaHistoricoDataContracts oEmpresa)
        {
            try
            {
                EmpresaHistoricoAdmin empresaAdmin = new EmpresaHistoricoAdmin();
                empresaAdmin.Delete((EmpresaHistorico)oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(EmpresaHistoricoDataContracts oEmpresa)
        {
            try
            {
                EmpresaHistoricoAdmin empresaAdmin = new EmpresaHistoricoAdmin();
                empresaAdmin.Update((EmpresaHistorico)oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(EmpresaHistoricoDataContracts oEmpresa)
        {
            try
            {
                EmpresaHistoricoAdmin empresaAdmin = new EmpresaHistoricoAdmin();
                empresaAdmin.Insert((EmpresaHistorico)oEmpresa);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EmpresaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto EmpresaDataContracts
        /// </summary>
        /// <value>void</value>
        public EmpresaHistoricoDataContracts GetEmpresa(int id)
        {
            try
            {
                EmpresaHistoricoAdmin empresaAdmin = new EmpresaHistoricoAdmin();
                return (EmpresaHistoricoDataContracts)empresaAdmin.Load(id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEmpresa : EmpresaHistoricoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }        

       #endregion
    }
}
