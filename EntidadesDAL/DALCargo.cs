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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Cargo
	/// </summary>
    public class DALCargo : AbstractMapper<Cargo>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALCargo()
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
        /// M?todo que retorna solo un objeto  Cargo
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
		public Cargo Load(int id)
		{
            try
            {
				Cargo oReturn = null;
				CommandText = "PA_MG_FRONT_Cargo_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Cargo> calificacions = AbstractFindAll(oParameters);
				if (calificacions.Count > 0)
				{
					oReturn = calificacions[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Cargo
		/// </summary>
		/// <param name="oCargo"></param>
		/// <returns></returns>
		public void Delete(Cargo oCargo)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Cargo_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCargo.Id));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Cargo
		/// </summary>
		/// <param name="oCargo"></param>
		/// <returns></returns>
		public void Update(Cargo oCargo)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Cargo_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCargo.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCargo.Descripcion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Cargo
		/// </summary>
		/// <param name="oCargo"></param>
		/// <returns></returns>
		public void Insert(Cargo oCargo)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Cargo_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCargo.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCargo.Descripcion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Cargo de la tabla dbo.TBL_Cargo
		/// </summary>
		/// <param name="oCargo"></param>
		/// <returns></returns>
		public List<Cargo> GetAllCargos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Cargo_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Cargo> calificacions = AbstractFindAll(oParameters);
				
				return calificacions;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, getCargos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Cargo de la tabla dbo.TBL_Cargo
		/// </summary>
		/// <param name="oCargo"></param>
		/// <returns></returns>
		public override Cargo DoLoad(IDataReader registros)
        {
            try
            {
				Cargo calificacion = new Cargo();
				calificacion.Id = registros.GetInt32(0);
				calificacion.Descripcion = registros.GetString(1);
			
				return calificacion;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCargo, getCargos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Cargo DoLoad(IDataReader registros, Cargo ent)
        {
            throw new NotImplementedException();
        }
    }
}
