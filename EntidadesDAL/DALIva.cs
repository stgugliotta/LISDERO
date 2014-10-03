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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_IVA
	/// </summary>
    public class DALIva : AbstractMapper<Iva>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALIva()
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
		~DALIva()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Iva
		/// </summary>
		/// <param name="id"></param>    
		/// <returns></returns>
		public Iva Load(int id)
		{
            try
            {
				Iva oReturn = null;
				CommandText = "PA_MG_FRONT_Iva_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Iva> ivas = AbstractFindAll(oParameters);
				if (ivas.Count > 0)
				{
					oReturn = ivas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_IVA
		/// </summary>
		/// <param name="oIva"></param>
		/// <returns></returns>
		public void Delete(Iva oIva)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Iva_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIva.Id));				
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_IVA
		/// </summary>
		/// <param name="oIva"></param>
		/// <returns></returns>
		public void Update(Iva oIva)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Iva_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIva.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oIva.Descripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oIva.Activo));
				oParameters.Add(new DBParametro("@porcentaje", DbType.String, oIva.Porcentaje));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_IVA
		/// </summary>
		/// <param name="oIva"></param>
		/// <returns></returns>
		public void Insert(Iva oIva)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Iva_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oIva.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oIva.Descripcion));
				oParameters.Add(new DBParametro("@activo", DbType.Boolean, oIva.Activo));
				oParameters.Add(new DBParametro("@porcentaje", DbType.String, oIva.Porcentaje));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Iva de la tabla dbo.TBL_IVA
		/// </summary>
		/// <param name="oIva"></param>
		/// <returns></returns>
		public List<Iva> GetAllIvas()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Iva_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Iva> ivas = AbstractFindAll(oParameters);
				
				return ivas;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, getIvas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Iva de la tabla dbo.TBL_IVA
		/// </summary>
		/// <param name="oIva"></param>
		/// <returns></returns>
		public override Iva DoLoad(IDataReader registros)
        {
            try
            {
				Iva iva = new Iva();
				iva.Id = registros.GetInt32(0);
				iva.Descripcion = registros.GetString(1);
				iva.Activo = registros.GetBoolean(2);
				iva.Porcentaje = registros.IsDBNull(3) != true ? registros.GetString(3) : ""; //registros.GetString(4);
				
			
				return iva;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALIva, getIvas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Iva DoLoad(IDataReader registros, Iva ent)
        {
            throw new NotImplementedException();
        }
    }
}
