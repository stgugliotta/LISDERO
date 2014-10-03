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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Persona
	/// </summary>
    public class DALPersona : AbstractMapper<Persona>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALPersona()
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
        /// M?todo que retorna solo un objeto  Persona
		/// </summary>
		/// <param name="id"></param>               
		/// <returns></returns>
		public Persona Load(int id)
		{
            try
            {
				Persona oReturn = null;
				CommandText = "PA_MG_FRONT_Persona_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Persona> personas = AbstractFindAll(oParameters);
				if (personas.Count > 0)
				{
					oReturn = personas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public Persona GetPersonaByCodigo(int codigo)
		{
            try
            {
				Persona oReturn = null;
				CommandText = "PA_MG_FRONT_Persona_SELECT_PorCodigo";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
				
				List<Persona> personas = AbstractFindAll(oParameters);
				if (personas.Count > 0)
				{
					oReturn = personas[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}

		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		public void Delete(Persona oPersona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Persona_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));															
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		public void Update(Persona oPersona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Persona_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.Int32, oPersona.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPersona.Nombre));
				oParameters.Add(new DBParametro("@contacto", DbType.String, oPersona.Contacto));
				oParameters.Add(new DBParametro("@idtipocalificacion", DbType.Int32, oPersona.IdTipoCalificacion));
				oParameters.Add(new DBParametro("@idsector", DbType.Int32, oPersona.IdSector));
				oParameters.Add(new DBParametro("@idsubsector", DbType.Int32, oPersona.IdSubSector));
				oParameters.Add(new DBParametro("@vinculo", DbType.String, oPersona.Vinculo));
				oParameters.Add(new DBParametro("@origencontacto", DbType.String, oPersona.OrigenContacto));
				oParameters.Add(new DBParametro("@idtratamiento", DbType.Int32, oPersona.IdTratamiento));
				oParameters.Add(new DBParametro("@documento", DbType.String, oPersona.Documento));
				oParameters.Add(new DBParametro("@idtipodocumento", DbType.Int32, oPersona.IdTipoDocumento));
				oParameters.Add(new DBParametro("@cuit", DbType.String, oPersona.Cuit));
				oParameters.Add(new DBParametro("@idprofesion", DbType.Int32, oPersona.IdProfesion));
				oParameters.Add(new DBParametro("@idcargo", DbType.String, oPersona.IdCargo));
				
				ExecuteNonQuery(oParameters);


                if (oPersona.Domicilios.Count > 0)
                {
                    DALDomicilio dalDomicilio = new DALDomicilio();
                    dalDomicilio.DeletePorCodigo(oPersona.Codigo);
                    foreach (var item in oPersona.Domicilios)
                    {
                        item.Codigo = oPersona.Codigo.ToString();
                        dalDomicilio.Insert(item);
                    }
                }

                if (oPersona.Telefonos.Count > 0)
                {
                    DALTelefono dalTelefono = new DALTelefono();
                    dalTelefono.DeletePorCodigo(oPersona.Codigo);
                    foreach (var item in oPersona.Telefonos)
                    {
                        item.Codigo = oPersona.Codigo;
                        dalTelefono.Insert(item);
                    }
                }
                if (oPersona.Emails.Count > 0)
                {
                    DALEmail dalEmail = new DALEmail();
                    dalEmail.DeletePorCodigo(oPersona.Codigo);
                    foreach (var item in oPersona.Emails)
                    {
                        item.IdRelacion = oPersona.Codigo;
                        dalEmail.Insert(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		public void Insert(Persona oPersona)
		{
			 try
            {
                DALContacto dalContacto = new DALContacto();
                string codigo = dalContacto.GenerarCodigo().ToString();
                Contacto contacto = new Contacto();
                contacto.Codigo = int.Parse(codigo);
                contacto.IdTipoContacto = 1;
                dalContacto.Insert(contacto);

                CommandText = "PA_MG_FRONT_Persona_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPersona.Nombre));
				oParameters.Add(new DBParametro("@contacto", DbType.String, oPersona.Contacto));
				oParameters.Add(new DBParametro("@idtipocalificacion", DbType.Int32, oPersona.IdTipoCalificacion));
				oParameters.Add(new DBParametro("@idsector", DbType.Int32, oPersona.IdSector));
				oParameters.Add(new DBParametro("@idsubsector", DbType.Int32, oPersona.IdSubSector));
				oParameters.Add(new DBParametro("@vinculo", DbType.String, oPersona.Vinculo));
				oParameters.Add(new DBParametro("@origencontacto", DbType.String, oPersona.OrigenContacto));
				oParameters.Add(new DBParametro("@idtratamiento", DbType.Int32, oPersona.IdTratamiento));
				oParameters.Add(new DBParametro("@documento", DbType.String, oPersona.Documento));
				oParameters.Add(new DBParametro("@idtipodocumento", DbType.Int32, oPersona.IdTipoDocumento));
				oParameters.Add(new DBParametro("@cuit", DbType.String, oPersona.Cuit));
				oParameters.Add(new DBParametro("@idprofesion", DbType.Int32, oPersona.IdProfesion));
                oParameters.Add(new DBParametro("@idcargo", DbType.String, codigo));
                
                object idPersona=ExecuteScalar(oParameters);
                contacto.IdContacto = int.Parse(idPersona.ToString());
                dalContacto.Update(contacto);

                if (oPersona.Domicilios.Count > 0)
                {
                    foreach (var item in oPersona.Domicilios)
                    {
                        DALDomicilio dalDomicilio = new DALDomicilio();
                        item.Codigo = codigo;
                        dalDomicilio.Insert(item);
                    }
                }

                if (oPersona.Telefonos.Count > 0)
                {
                    foreach (var item in oPersona.Telefonos)
                    {
                        DALTelefono dalTelefono = new DALTelefono();
                        item.Codigo = int.Parse(codigo);
                        dalTelefono.Insert(item);
                    }
                }
                if (oPersona.Emails.Count > 0)
                {
                    foreach (var item in oPersona.Emails)
                    {
                        DALEmail dalEmail = new DALEmail();
                        item.IdRelacion = int.Parse(codigo);
                        dalEmail.Insert(item);
                    }
                }
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Persona de la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		public List<Persona> GetAllPersonas()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Persona_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Persona> personas = AbstractFindAll(oParameters);
				
				return personas;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, getPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Persona de la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		public override Persona DoLoad(IDataReader registros)
        {
            try
            {
				Persona persona = new Persona();
				persona.Id = registros.GetInt32(0);
				persona.Codigo = registros.GetInt32(1);
				persona.Nombre = registros.GetString(2);
                try
                {
                    persona.Contacto = registros.GetString(3);
                }
                catch (Exception)
                {

                    persona.Contacto = string.Empty;
                }
                try
                {
                    persona.IdTipoCalificacion = registros.GetInt32(4);
                }
                catch (Exception)
                {

                    persona.IdTipoCalificacion = 0;
                }

                try
                {
                    persona.IdSector = registros.GetInt32(5);
                }
                catch (Exception)
                {

                    persona.IdSector = 0;
                }

                try
                {
                    persona.IdSubSector = registros.GetInt32(6);
                }
                catch (Exception)
                {

                    persona.IdSubSector = 0;
                }
				
                try
                {
                    persona.Vinculo = registros.GetString(7);
                }
                catch (Exception)
                {

                    persona.Vinculo = string.Empty;
                }

                try
                {
                    persona.OrigenContacto = registros.GetString(8);
                }
                catch (Exception)
                {

                    persona.OrigenContacto = string.Empty;
                }

                try
                {
                    persona.IdTratamiento = registros.GetInt32(9);
                }
                catch (Exception)
                {

                    persona.IdTratamiento = 0;
                }
				
                try
                {
                    persona.Documento = registros.GetString(10);
                }
                catch (Exception)
                {

                    persona.Documento = string.Empty;
                }

                try
                {
                    persona.IdTipoDocumento = registros.GetInt32(11);
                }
                catch (Exception)
                {

                    persona.IdTipoDocumento = 0;
                }
                try
                {
                    persona.Cuit = registros.GetString(12);
                }
                catch (Exception)
                {

                    persona.Cuit = string.Empty;
                }
                try
                {
                    persona.IdProfesion = registros.GetInt32(13);
                }
                catch (Exception)
                {

                    persona.IdProfesion = 0;
                }
                try
                {
                    persona.IdCargo = registros.GetString(14);
                }
                catch (Exception)
                {

                    persona.IdCargo = string.Empty;
                }
				
			
				return persona;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersona, getPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Persona DoLoad(IDataReader registros, Persona ent)
        {
            throw new NotImplementedException();
        }
    }
}
