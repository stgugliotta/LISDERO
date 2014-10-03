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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Provincia
	/// </summary>
    public class DALProvincia : AbstractMapper<Provincia>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALProvincia()
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
		~DALProvincia()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Provincia
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public Provincia Load(int id)
		{
            try
            {
				Provincia oReturn = null;
				CommandText = "PA_MG_FRONT_Provincia_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Provincia> provincias = AbstractFindAll(oParameters);
				if (provincias.Count > 0)
				{
					oReturn = provincias[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Provincia
		/// </summary>
		/// <param name="oProvincia"></param>
		/// <returns></returns>
		public void Delete(Provincia oProvincia)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Provincia_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oProvincia.Id));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Provincia
		/// </summary>
		/// <param name="oProvincia"></param>
		/// <returns></returns>
		public void Update(Provincia oProvincia)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Provincia_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oProvincia.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oProvincia.Descripcion));
				oParameters.Add(new DBParametro("@idpais", DbType.Int32, oProvincia.IdPais));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Provincia
		/// </summary>
		/// <param name="oProvincia"></param>
		/// <returns></returns>
		public void Insert(Provincia oProvincia)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Provincia_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
	
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oProvincia.Descripcion));
				oParameters.Add(new DBParametro("@idpais", DbType.Int32, oProvincia.IdPais));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Provincia de la tabla dbo.TBL_Provincia
		/// </summary>
		/// <param name="oProvincia"></param>
		/// <returns></returns>
        /// 

        public List<Provincia> GetAllProvinciasPorIdPais(int idPais)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Provincia_SELECTALL_PorIdPais";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@idpais", DbType.Int32, idPais));
				List<Provincia> provincias = AbstractFindAll(oParameters);
				
				return provincias;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, getProvincias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

		public List<Provincia> GetAllProvincias()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Provincia_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Provincia> provincias = AbstractFindAll(oParameters);
				
				return provincias;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, getProvincias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Provincia de la tabla dbo.TBL_Provincia
		/// </summary>
		/// <param name="oProvincia"></param>
		/// <returns></returns>
		public override Provincia DoLoad(IDataReader registros)
        {
            try
            {
				Provincia provincia = new Provincia();
				provincia.Id = registros.GetInt32(0);
				provincia.Descripcion = registros.GetString(1);
				provincia.IdPais = registros.GetInt32(2);
			
				return provincia;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProvincia, getProvincias", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Provincia DoLoad(IDataReader registros, Provincia ent)
        {
            throw new NotImplementedException();
        }
    }
}
