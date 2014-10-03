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
	/// Accion		: Implementacion de la Interface de la Entidad Tratamiento
	/// Objeto		: DB_LISDERO.dbo.tbl_tratamiento
	/// Descripcion	: 
	/// </summary>
	public class TratamientoService: ITratamientoService
	{
		#region ITratamientoService   M E M B E R S 
		/// <summary>
		/// Implementacion de la Interfaz para retornar un objeto TratamientoDataContracts
		/// </summary>
		/// <value>TratamientoDataContracts</value>
		public TratamientoDataContracts Load(int id)
		 {
			 try
            {
			    TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                return (TratamientoDataContracts)tratamientoAdmin.Load( id);
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - Load: TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// implementacion de la interfaz para eliminar un TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Delete(TratamientoDataContracts oTratamiento)
		{
            try
            {
                TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                	tratamientoAdmin.Delete((Tratamiento)oTratamiento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Delete : TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
        
		/// <summary>
		/// Implemetancion de la Interfaz para actualiza un objeto TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Update(TratamientoDataContracts oTratamiento)
		{
            try
            {
                TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                	tratamientoAdmin.Update((Tratamiento)oTratamiento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Update : TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
        }
		
        /// <summary>
		/// Implemetancion de la Interfaz para Insertar un objeto TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		public void Insert(TratamientoDataContracts oTratamiento)
		{
			try
            {
                TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                	tratamientoAdmin.Insert((Tratamiento) oTratamiento);

            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  Insert : TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurripo una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}

		/// <summary>
		/// Implemetancion de la Interfaz para returnar un objeto TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		public TratamientoDataContracts GetTratamiento(int id)
		 {
			 try
            {
			    TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                return (TratamientoDataContracts)tratamientoAdmin.Load( id);
                  }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi  GetTratamiento : TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		
		/// <summary>
		/// Implemetancion de la Interfaz para listar todos los objetos TratamientoDataContracts
		/// </summary>
		/// <value>void</value>
		public List<TratamientoDataContracts> GetAllTratamientos()
		 {
			 try
            {
                TratamientoAdmin tratamientoAdmin = new TratamientoAdmin();
                 List<Tratamiento> resultList = tratamientoAdmin.GetAllTratamientos();

                return resultList.ConvertAll<TratamientoDataContracts>(
                    delegate(Tratamiento tempTratamiento) { return (TratamientoDataContracts)tempTratamiento; });
            }
            catch (GobbiTechnicalException ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteInformation(
                    "Excepci?n T?cnica Gobbi - GetAllTratamientos : TratamientoService", ex.ToString(), "TechnicalException");

                throw new GobbiFunctionalException(
                    string.Format("Ocurri? una Excepci?n en la llamada al servicio {0}", ex.TargetSite));
            }
		}
		#endregion
	}
}