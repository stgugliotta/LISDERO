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
	/// Accion		: Implementacion de la Interface de la Entidad Profesion
	/// Objeto		: DB_LISDERO.dbo.tbl_profesion
	/// Descripcion	: 
	/// </summary>
	public class ProfesionService: IProfesionService
	{
		#region IProfesionService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto ProfesionDataContracts
		/// </summary>
		/// <value>ProfesionDataContracts</value>
		public ProfesionDataContracts Load(int id)
		 {
			 try
            {
			    ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                return (ProfesionDataContracts)profesionAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(ProfesionDataContracts oProfesion)
		{
            try
            {
                ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                	profesionAdmin.Delete((Profesion)oProfesion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(ProfesionDataContracts oProfesion)
		{
            try
            {
                ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                	profesionAdmin.Update((Profesion)oProfesion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(ProfesionDataContracts oProfesion)
		{
			try
            {
                ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                	profesionAdmin.Insert((Profesion) oProfesion);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		public ProfesionDataContracts GetProfesion(int id)
		 {
			 try
            {
			    ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                return (ProfesionDataContracts)profesionAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetProfesion : ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos ProfesionDataContracts
		/// </summary>
		/// <value>void</value>
		public List<ProfesionDataContracts> GetAllProfesions()
		 {
			 try
            {
                ProfesionAdmin profesionAdmin = new ProfesionAdmin();
                 List<Profesion> resultList = profesionAdmin.GetAllProfesions();

                return resultList.ConvertAll<ProfesionDataContracts>(
                    delegate(Profesion tempProfesion) { return (ProfesionDataContracts)tempProfesion; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllProfesions : ProfesionService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}