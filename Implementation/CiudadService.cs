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
	/// Creado		: 2013-06-02
	/// Accion		: Implementacion de la Interface de la Entidad Ciudad
	/// Objeto		: DB_LISDERO.dbo.tbl_ciudad
	/// Descripcion	: 
	/// </summary>
	public class CiudadService: ICiudadService
	{
		#region ICiudadService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto CiudadDataContracts
		/// </summary>
		/// <value>CiudadDataContracts</value>
		public CiudadDataContracts Load(int id)
		 {
			 try
            {
			    CiudadAdmin ciudadAdmin = new CiudadAdmin();
                return (CiudadDataContracts)ciudadAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(CiudadDataContracts oCiudad)
		{
            try
            {
                CiudadAdmin ciudadAdmin = new CiudadAdmin();
                	ciudadAdmin.Delete((Ciudad)oCiudad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(CiudadDataContracts oCiudad)
		{
            try
            {
                CiudadAdmin ciudadAdmin = new CiudadAdmin();
                	ciudadAdmin.Update((Ciudad)oCiudad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(CiudadDataContracts oCiudad)
		{
			try
            {
                CiudadAdmin ciudadAdmin = new CiudadAdmin();
                	ciudadAdmin.Insert((Ciudad) oCiudad);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		public CiudadDataContracts GetCiudad(int id)
		 {
			 try
            {
			    CiudadAdmin ciudadAdmin = new CiudadAdmin();
                return (CiudadDataContracts)ciudadAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetCiudad : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos CiudadDataContracts
		/// </summary>
		/// <value>void</value>
		public List<CiudadDataContracts> GetAllCiudads()
		 {
			 try
            {
                CiudadAdmin ciudadAdmin = new CiudadAdmin();
                 List<Ciudad> resultList = ciudadAdmin.GetAllCiudads();

                return resultList.ConvertAll<CiudadDataContracts>(
                    delegate(Ciudad tempCiudad) { return (CiudadDataContracts)tempCiudad; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCiudads : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion

        #region ICiudadService Members


        public List<CiudadDataContracts> GetAllCiudadesPorIdProvincia(int idProvincia)
        {
            try
            {
                CiudadAdmin ciudadAdmin = new CiudadAdmin();
                List<Ciudad> resultList = ciudadAdmin.GetAllCiudadesPorIdProvincia(idProvincia);

                return resultList.ConvertAll<CiudadDataContracts>(
                    delegate(Ciudad tempCiudad) { return (CiudadDataContracts)tempCiudad; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllCiudads : CiudadService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }

        #endregion
    }
}