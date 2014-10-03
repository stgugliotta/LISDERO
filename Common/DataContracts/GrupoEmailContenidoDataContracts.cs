using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.services;
using Common.Interfaces;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2013-10-29
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_grupoemail_contenido
    /// Descripcion	: 
    /// </summary>
    public class GrupoEmailContenidoDataContracts
    {

        private IEmpresaPersonaService empresaPersonaServices = ServiceClient<IEmpresaPersonaService>.GetService("EmpresaPersonaService");
        private IEmpresaService empresaServices = ServiceClient<IEmpresaService>.GetService("EmpresaService");
        private IPersonaService personaServices = ServiceClient<IPersonaService>.GetService("PersonaService");
        private IRelacionService relacionServices = ServiceClient<IRelacionService>.GetService("RelacionService");

        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto GrupoEmailContenido
        /// </summary>
        public GrupoEmailContenidoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idGrupoEmail;

        /// <summary>
        /// 
        /// </summary>
        private string codigoRelacion;

        
        //agregado por Natalia 22/01/2014
        //

        private string cargo;
        private string nombreempresa;

  

        private EmpresaPersonaDataContracts empresaPersona;
        private EmpresaDataContracts empresa;
        private PersonaDataContracts persona;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdGrupoEmail
        {
            get { return this.idGrupoEmail; }
            set { this.idGrupoEmail = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string CodigoRelacion
        {
            get { return this.codigoRelacion; }
            set { this.codigoRelacion = value; }
        }


        public string Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public string NombreEmpresa
        {
            get { return this.nombreempresa; }
            set { this.nombreempresa = value; }
        }	

        public EmpresaDataContracts Empresa
        {
            get { return this.empresa; }
            set { this.empresa = value; }
        }

        public PersonaDataContracts Persona
        {
            get { return this.persona; }
            set { this.persona = value; }
        }

        public void doCustomFill()
        {
            this.empresaPersona = this.EmpresaPersona;

            if (empresaPersona != null)
            {

                if (empresaPersona.Tipo.ToUpper().Equals("EMPRESA"))
                {
                    this.empresa = empresaServices.GetEmpresaByCodigo(int.Parse(empresaPersona.Codigo));
                }
                else if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                {
                    this.persona = personaServices.GetPersonaByCodigo(int.Parse(empresaPersona.Codigo));
                }
            }

        }


        public EmpresaPersonaDataContracts EmpresaPersona
        {
            get
            {
                if (this.codigoRelacion != null && this.codigoRelacion.Length > 0)
                {
                    EmpresaPersonaDataContracts empresaPersona = empresaPersonaServices.Load(int.Parse(this.codigoRelacion));
                    return empresaPersona;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Email
        {
            get
            {
                string email = "No posee email.";

                EmpresaPersonaDataContracts empresaPersona = this.EmpresaPersona;

                if (empresaPersona != null)
                {

                    if (empresaPersona.Tipo.ToUpper().Equals("EMPRESA"))
                    {
                        if (this.empresa != null && empresa.Emails.Count > 0)
                        {
                            email = "";

                            foreach (EmailDataContracts edc in this.empresa.Emails)
                            {
                                email += edc.Emaill;
                            }
                        }

                    }
                    else if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                    {
                        if (this.persona != null && this.persona.Emails.Count > 0)
                        {
                            email = "";

                            foreach (EmailDataContracts edc in this.persona.Emails)
                            {
                                email += edc.Emaill;
                            }
                        }
                    }
                }

                return email;

            }
        }

        public int Codigo
        {
            get
            {
                int codigo = -1;

                EmpresaPersonaDataContracts empresaPersona = this.EmpresaPersona;

                if (empresaPersona != null)
                {

                    if (empresaPersona.Tipo.ToUpper().Equals("EMPRESA"))
                    {
                        if (this.empresa != null)
                        {
                            codigo = this.empresa.Codigo;
                        }

                    }
                    else if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                    {
                        if (this.persona != null)
                        {
                            codigo = this.persona.Codigo;
                        }
                    }
                }

                return codigo;
            }
        }
        public string Nombre
        {
            get
            {
                string nombre = "Sin Nombre.";

                EmpresaPersonaDataContracts empresaPersona = this.EmpresaPersona;

                if (empresaPersona != null)
                {

                    if (empresaPersona.Tipo.ToUpper().Equals("EMPRESA"))
                    {
                        if (this.empresa != null)
                        {
                            nombre = this.empresa.Nombre;
                        }                       
                    }
                    else if (empresaPersona.Tipo.ToUpper().Equals("PERSONA"))
                    {
                        if (this.persona != null)
                        {
                            nombre = this.persona.Nombre;
                        }
                    }
                }

                return nombre;

            }

        }


      
        #endregion
    }
}
