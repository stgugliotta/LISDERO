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
	/// Creado		: 2013-05-16
	/// Accion		: Implementacion de la Interface de la Entidad Relacion
	/// Objeto		: DB_LISDERO.dbo.tbl_relacion
	/// Descripcion	: 
	/// </summary>
    public class RelacionService : IRelacionService
    {
        #region IRelacionService   M E M B E R S
        /// <summary>
        /// Implementacion de la Interfaz para retornar un objeto RelacionDataContracts
		/// </summary>
        /// <value>RelacionDataContracts</value>
        public RelacionDataContracts Load(int codigo1, int codigo2)
		 {
			 try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                return (RelacionDataContracts)relacionAdmin.Load(codigo1, codigo2);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// implementacion de la interfaz para eliminar un RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        public void Delete(RelacionDataContracts oRelacion)
		{
            try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                relacionAdmin.Delete((Relacion)oRelacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
        /// Implemetancion de la Interfaz para actualiza un objeto RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        public void Update(RelacionDataContracts oRelacion)
		{
            try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                relacionAdmin.Update((Relacion)oRelacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
        /// Implemetancion de la Interfaz para Insertar un objeto RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        public void Insert(RelacionDataContracts oRelacion)
		{
			try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                relacionAdmin.Insert((Relacion)oRelacion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
        /// Implemetancion de la Interfaz para returnar un objeto RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        public RelacionDataContracts GetRelacion(int codigo1, int codigo2)
		 {
			 try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                return (RelacionDataContracts)relacionAdmin.Load(codigo1,codigo2);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetRelacion : RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
        /// Implemetancion de la Interfaz para listar todos los objetos RelacionDataContracts
		/// </summary>
		/// <value>void</value>
        public List<RelacionDataContracts> GetAllRelaciones()
		 {
			 try
            {
                RelacionAdmin relacionAdmin = new RelacionAdmin();
                List<Relacion> resultList = relacionAdmin.GetAllRelaciones();

                return resultList.ConvertAll<RelacionDataContracts>(
                    delegate(Relacion tempRelacion) { return (RelacionDataContracts)tempRelacion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllRelaciones : RelacionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}