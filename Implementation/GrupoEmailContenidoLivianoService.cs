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
    public class GrupoEmailContenidoLivianoService : IGrupoEmailContenidoLivianoService
    {
        #region IGrupoEmailContenidoLivianoService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>GrupoEmailContenidoDataContracts</value>
        public GrupoEmailContenidoLivianoDataContracts Load(int idGrupoEmail, string codigoRelacion)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                return (GrupoEmailContenidoLivianoDataContracts)grupoEmailContenidoAdmin.Load(idGrupoEmail, codigoRelacion);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: GrupoEmailService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// implementacion de la interfaz para eliminar un GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Delete(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                grupoEmailContenidoAdmin.Delete((GrupoEmailContenidoLiviano)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Update(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                grupoEmailContenidoAdmin.Update((GrupoEmailContenidoLiviano)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto GrupoEmailContenidoDataContracts
        /// </summary>
        /// <value>void</value>
        public void Insert(GrupoEmailContenidoLivianoDataContracts oGrupoEmailContenido)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                grupoEmailContenidoAdmin.Insert((GrupoEmailContenidoLiviano)oGrupoEmailContenido);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }   


        public List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                List<GrupoEmailContenidoLiviano> resultList = grupoEmailContenidoAdmin.GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail(idGrupoEmail);

                return resultList.ConvertAll<GrupoEmailContenidoLivianoDataContracts>(
                    delegate(GrupoEmailContenidoLiviano tempGrupoEmailContenido) { return (GrupoEmailContenidoLivianoDataContracts)tempGrupoEmailContenido; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmailContenidoCargoEmpresaByIdGrupoEmail : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }


        public List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(int idGrupoEmail)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                List<GrupoEmailContenidoLiviano> resultList = grupoEmailContenidoAdmin.GetAllGrupoEmailContenidoLivianoByIdGrupoEmail(idGrupoEmail);

                return resultList.ConvertAll<GrupoEmailContenidoLivianoDataContracts>(
                    delegate(GrupoEmailContenidoLiviano tempGrupoEmailContenido) { return (GrupoEmailContenidoLivianoDataContracts)tempGrupoEmailContenido; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmailContenidoLivianoByIdGrupoEmail : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public List<GrupoEmailContenidoLivianoDataContracts> GetAllGrupoEmailContenidoLivianoByEmail(int idGrupoEmail, string idCodigoRelacion)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                List<GrupoEmailContenidoLiviano> resultList = grupoEmailContenidoAdmin.GetAllGrupoEmailContenidoLivianoByEmail(idGrupoEmail,idCodigoRelacion);

                return resultList.ConvertAll<GrupoEmailContenidoLivianoDataContracts>(
                    delegate(GrupoEmailContenidoLiviano tempGrupoEmailContenido) { return (GrupoEmailContenidoLivianoDataContracts)tempGrupoEmailContenido; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllGrupoEmailContenidoLivianoByIdGrupoEmail : GrupoEmailContenidoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        public void Combinar(int id_GrupoEmailNuevo, int id_GrupoEmailViejo, string id_CodigoRelacion)
        {
            try
            {
                GrupoEmailContenidoLivianoAdmin grupoEmailContenidoAdmin = new GrupoEmailContenidoLivianoAdmin();
                grupoEmailContenidoAdmin.Combinar(id_GrupoEmailNuevo,id_GrupoEmailViejo, id_CodigoRelacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : GrupoEmailContenidoLivianoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }   


        #endregion


    }
}
