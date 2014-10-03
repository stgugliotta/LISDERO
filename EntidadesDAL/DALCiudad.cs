using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
	/// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Ciudad
	/// </summary>
    public class DALCiudad : AbstractMapper<Ciudad>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALCiudad()
        {
            DBConnection oDbConnection  = DBConnection.Instancia;
            Db = oDbConnection.Db;
			ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		~DALCiudad()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Ciudad
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public Ciudad Load(int id)
		{
            try
            {
				Ciudad oReturn = null;
				CommandText = "PA_MG_FRONT_Ciudad_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Ciudad> ciudads = AbstractFindAll(oParameters);
				if (ciudads.Count > 0)
				{
					oReturn = ciudads[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Ciudad
		/// </summary>
		/// <param name="oCiudad"></param>
		/// <returns></returns>
		public void Delete(Ciudad oCiudad)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Ciudad_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCiudad.Id));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Ciudad
		/// </summary>
		/// <param name="oCiudad"></param>
		/// <returns></returns>
		public void Update(Ciudad oCiudad)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Ciudad_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCiudad.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCiudad.Descripcion));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oCiudad.IdProvincia));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Ciudad
		/// </summary>
		/// <param name="oCiudad"></param>
		/// <returns></returns>
		public void Insert(Ciudad oCiudad)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Ciudad_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCiudad.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCiudad.Descripcion));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oCiudad.IdProvincia));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Ciudad de la tabla dbo.TBL_Ciudad
		/// </summary>
		/// <param name="oCiudad"></param>
		/// <returns></returns>
        /// 

        public List<Ciudad> GetAllCiudadesPorIdProvincia(int idProvincia)
		{
            try
            {
				CommandText = "PA_MG_FRONT_Ciudad_SELECTALL_PorIdProvincia";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, idProvincia));
				List<Ciudad> ciudads = AbstractFindAll(oParameters);
				
				return ciudads;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, getCiudads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

		public List<Ciudad> GetAllCiudads()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Ciudad_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Ciudad> ciudads = AbstractFindAll(oParameters);
				
				return ciudads;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, getCiudads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Ciudad de la tabla dbo.TBL_Ciudad
		/// </summary>
		/// <param name="oCiudad"></param>
		/// <returns></returns>
		public override Ciudad DoLoad(IDataReader registros)
        {
            try
            {
				Ciudad ciudad = new Ciudad();
				ciudad.Id = registros.GetInt32(0);
				ciudad.Descripcion = registros.GetString(1);
				ciudad.IdProvincia = registros.GetInt32(2);
			
				return ciudad;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCiudad, getCiudads", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Ciudad DoLoad(IDataReader registros, Ciudad ent)
        {
            throw new NotImplementedException();
        }
    }
}
