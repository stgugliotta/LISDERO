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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Telefono
	/// </summary>
    public class DALTelefono : AbstractMapper<Telefono>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALTelefono()
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
        /// M?todo que retorna solo un objeto  Telefono
		/// </summary>
		/// <param name="id"></param>    
		/// <returns></returns>
		public Telefono Load(int id)
		{
            try
            {
				Telefono oReturn = null;
				CommandText = "PA_MG_FRONT_Telefono_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Telefono> telefonos = AbstractFindAll(oParameters);
				if (telefonos.Count > 0)
				{
					oReturn = telefonos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Telefono
		/// </summary>
		/// <param name="oTelefono"></param>
		/// <returns></returns>
		public void Delete(Telefono oTelefono)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Telefono_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTelefono.Id));				
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public void DeletePorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Telefono_Delete_PorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Telefono
		/// </summary>
		/// <param name="oTelefono"></param>
		/// <returns></returns>
		public void Update(Telefono oTelefono)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Telefono_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTelefono.Id));
				oParameters.Add(new DBParametro("@numero", DbType.String, oTelefono.Numero));
				oParameters.Add(new DBParametro("@idtipo", DbType.Int32, oTelefono.IdTipo));
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oTelefono.Codigo));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Telefono> GetAllTelefonosPersonasPorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Telefono_SELECTALL_PersonasPorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
                List<Telefono> telefonos = AbstractFindAll(oParameters);

                return telefonos;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, getTelefonos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		

	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Telefono
		/// </summary>
		/// <param name="oTelefono"></param>
		/// <returns></returns>
		public void Insert(Telefono oTelefono)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Telefono_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTelefono.Id));
				oParameters.Add(new DBParametro("@numero", DbType.String, oTelefono.Numero));
				oParameters.Add(new DBParametro("@idtipo", DbType.Int32, oTelefono.IdTipo));
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oTelefono.Codigo));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Telefono de la tabla dbo.TBL_Telefono
		/// </summary>
		/// <param name="oTelefono"></param>
		/// <returns></returns>
		public List<Telefono> GetAllTelefonos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Telefono_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Telefono> telefonos = AbstractFindAll(oParameters);
				
				return telefonos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, getTelefonos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Telefono de la tabla dbo.TBL_Telefono
		/// </summary>
		/// <param name="oTelefono"></param>
		/// <returns></returns>
		public override Telefono DoLoad(IDataReader registros)
        {
            try
            {
				Telefono telefono = new Telefono();
				telefono.Id = registros.GetInt32(0);
				telefono.Numero = registros.GetString(1);
				telefono.IdTipo = registros.GetInt32(2);
				telefono.Codigo = registros.GetInt32(3);
			
				return telefono;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTelefono, getTelefonos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Telefono DoLoad(IDataReader registros, Telefono ent)
        {
            throw new NotImplementedException();
        }
    }
}
