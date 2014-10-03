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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Domicilio
	/// </summary>
    public class DALDomicilio : AbstractMapper<Domicilio>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALDomicilio()
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
		
		/// <summary>
        /// M?todo que retorna solo un objeto  Domicilio
		/// </summary>
		/// <param name="id"></param>            
		/// <returns></returns>
		public Domicilio Load(int id)
		{
            try
            {
				Domicilio oReturn = null;
				CommandText = "PA_MG_FRONT_Domicilio_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Domicilio> domicilios = AbstractFindAll(oParameters);
				if (domicilios.Count > 0)
				{
					oReturn = domicilios[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Domicilio
		/// </summary>
		/// <param name="oDomicilio"></param>
		/// <returns></returns>
		public void Delete(Domicilio oDomicilio)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDomicilio.Id));												
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
        public void DeletePorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_Delete_PorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Domicilio
		/// </summary>
		/// <param name="oDomicilio"></param>
		/// <returns></returns>
		public void Update(Domicilio oDomicilio)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDomicilio.Id));
				oParameters.Add(new DBParametro("@pais", DbType.String, oDomicilio.Pais));
				oParameters.Add(new DBParametro("@idpais", DbType.Int32, oDomicilio.IdPais));
				oParameters.Add(new DBParametro("@provincia", DbType.String, oDomicilio.Provincia));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oDomicilio.IdProvincia));
				oParameters.Add(new DBParametro("@ciudad", DbType.String, oDomicilio.Ciudad));
				oParameters.Add(new DBParametro("@idlocalidad", DbType.Int32, oDomicilio.IdLocalidad));
				oParameters.Add(new DBParametro("@domicilio", DbType.String, oDomicilio.Domicilio_));
				oParameters.Add(new DBParametro("@cp", DbType.String, oDomicilio.Cp));
				oParameters.Add(new DBParametro("@piso", DbType.String, oDomicilio.Piso));
				oParameters.Add(new DBParametro("@depto", DbType.String, oDomicilio.Depto));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oDomicilio.Codigo));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Domicilio
		/// </summary>
		/// <param name="oDomicilio"></param>
		/// <returns></returns>
		public void Insert(Domicilio oDomicilio)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Domicilio_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oDomicilio.Id));
				oParameters.Add(new DBParametro("@pais", DbType.String, oDomicilio.Pais));
				oParameters.Add(new DBParametro("@idpais", DbType.Int32, oDomicilio.IdPais));
				oParameters.Add(new DBParametro("@provincia", DbType.String, oDomicilio.Provincia));
				oParameters.Add(new DBParametro("@idprovincia", DbType.Int32, oDomicilio.IdProvincia));
				oParameters.Add(new DBParametro("@ciudad", DbType.String, oDomicilio.Ciudad));
				oParameters.Add(new DBParametro("@idlocalidad", DbType.Int32, oDomicilio.IdLocalidad));
				oParameters.Add(new DBParametro("@domicilio", DbType.String, oDomicilio.Domicilio_));
				oParameters.Add(new DBParametro("@cp", DbType.String, oDomicilio.Cp));
				oParameters.Add(new DBParametro("@piso", DbType.String, oDomicilio.Piso));
				oParameters.Add(new DBParametro("@depto", DbType.String, oDomicilio.Depto));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oDomicilio.Codigo));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Domicilio de la tabla dbo.TBL_Domicilio
		/// </summary>
		/// <param name="oDomicilio"></param>
		/// <returns></returns>
		public List<Domicilio> GetAllDomicilios()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Domicilio_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Domicilio> domicilios = AbstractFindAll(oParameters);
				
				return domicilios;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, getDomicilios", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Domicilio> GetAllDomiciliosPersonasPorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Domicilio_SELECTALL_PersonasPorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
                List<Domicilio> domicilios = AbstractFindAll(oParameters);

                return domicilios;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, getDomicilios", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Domicilio de la tabla dbo.TBL_Domicilio
		/// </summary>
		/// <param name="oDomicilio"></param>
		/// <returns></returns>
		public override Domicilio DoLoad(IDataReader registros)
        {
            try
            {
				Domicilio domicilio = new Domicilio();
				domicilio.Id = registros.GetInt32(0);
				domicilio.Pais = registros.GetString(1);
				domicilio.IdPais = registros.GetInt32(2);
				domicilio.Provincia = registros.GetString(3);
				domicilio.IdProvincia = registros.GetInt32(4);
				domicilio.Ciudad = registros.GetString(5);
				domicilio.IdLocalidad = registros.GetInt32(6);
				domicilio.Domicilio_ = registros.GetString(7);
				//domicilio.Cp = registros.GetString(8);
                domicilio.Cp = registros.IsDBNull(8) != true ? registros.GetString(8) : ""; //registros.GetString(4);
				domicilio.Piso = registros.GetString(9);
				domicilio.Depto = registros.GetString(10);
				domicilio.Codigo = registros.GetString(11);
			
				return domicilio;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALDomicilio, getDomicilios", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Domicilio DoLoad(IDataReader registros, Domicilio ent)
        {
            throw new NotImplementedException();
        }
    }
}
