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
    /// <summary>
    /// Creado		: 2010-02-26
    /// EmpresaPersona		: Implementacion de la Interface de la Entidad EmpresaPersona
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_empresaPersona
    /// Descripcion	: 
    /// </summary>
    public class EmpresaPersonaService : IEmpresaPersonaService
    {
        #region IEmpresaPersonaService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>EmpresaPersonaDataContracts</value>
        public EmpresaPersonaDataContracts Load(int idEmpresaPersona)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                return (EmpresaPersonaDataContracts)empresaPersonaAdmin.Load(idEmpresaPersona);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(EmpresaPersonaDataContracts oEmpresaPersona)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                empresaPersonaAdmin.Delete((EmpresaPersona)oEmpresaPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(EmpresaPersonaDataContracts oEmpresaPersona)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                empresaPersonaAdmin.Update((EmpresaPersona)oEmpresaPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(EmpresaPersonaDataContracts oEmpresaPersona)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                empresaPersonaAdmin.Insert((EmpresaPersona)oEmpresaPersona);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public EmpresaPersonaDataContracts GetEmpresaPersona(int idEmpresaPersona)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                return (EmpresaPersonaDataContracts)empresaPersonaAdmin.Load(idEmpresaPersona);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetEmpresaPersona : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos EmpresaPersonaDataContracts
        /// </summary>
        /// <value>void</value>
        public List<EmpresaPersonaDataContracts> GetAllEmpresaPersonas()
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                List<EmpresaPersona> resultList = empresaPersonaAdmin.GetAllEmpresaPersonas();

                return resultList.ConvertAll<EmpresaPersonaDataContracts>(
                    delegate(EmpresaPersona tempEmpresaPersona) { return (EmpresaPersonaDataContracts)tempEmpresaPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaPersonas : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<EmpresaPersonaDataContracts> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(int idFactura, decimal idCliente, DateTime fechaVenc)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                List<EmpresaPersona> resultList = empresaPersonaAdmin.GetAllEmpresaPersonasByIdFacturaIdClienteFechaVenc(idFactura, idCliente, fechaVenc);

                return resultList.ConvertAll<EmpresaPersonaDataContracts>(
                    delegate(EmpresaPersona tempEmpresaPersona) { return (EmpresaPersonaDataContracts)tempEmpresaPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaPersonas : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }



        public List<EmpresaPersonaDataContracts> GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(int idFactura, decimal idCliente, DateTime fechaVenc, int idEstado)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                List<EmpresaPersona> resultList = empresaPersonaAdmin.GetAllEmpresaPersonasByIdFacturaIdClienteFechaVencIdEstado(idFactura, idCliente, fechaVenc, idEstado);

                return resultList.ConvertAll<EmpresaPersonaDataContracts>(
                    delegate(EmpresaPersona tempEmpresaPersona) { return (EmpresaPersonaDataContracts)tempEmpresaPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaPersonas : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        #endregion

        #region IEmpresaPersonaService Members


        public EmpresaPersonaDataContracts GetLastActionByIdFactura(int idFactura)
        {
            EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
            return (EmpresaPersonaDataContracts)empresaPersonaAdmin.GetLastActionByIdFactura(idFactura);
        }

        #endregion




     

        #region IEmpresaPersonaService Members


        #endregion

        #region IEmpresaPersonaService Members


        public List<EmpresaPersonaDataContracts> GetAllEmpresaPersonaPorCantidad(int cantidadDeRegistros,string cadena)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                List<EmpresaPersona> resultList = empresaPersonaAdmin.GetAllEmpresaPersonaPorCantidad(cantidadDeRegistros, cadena);

                return resultList.ConvertAll<EmpresaPersonaDataContracts>(
                    delegate(EmpresaPersona tempEmpresaPersona) { return (EmpresaPersonaDataContracts)tempEmpresaPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaPersonas : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion

        #region IEmpresaPersonaService Members


        public List<EmpresaPersonaDataContracts> GetAllEmpresaPersonaRelaciones(string codigo)
        {
            try
            {
                EmpresaPersonaAdmin empresaPersonaAdmin = new EmpresaPersonaAdmin();
                List<EmpresaPersona> resultList = empresaPersonaAdmin.GetAllEmpresaPersonaRelaciones(codigo);

                return resultList.ConvertAll<EmpresaPersonaDataContracts>(
                    delegate(EmpresaPersona tempEmpresaPersona) { return (EmpresaPersonaDataContracts)tempEmpresaPersona; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllEmpresaPersonas : EmpresaPersonaService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}