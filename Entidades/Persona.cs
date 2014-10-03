using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Persona
	/// </summary>
	public class Persona : Entity <Persona, PersonaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Persona
		/// </summary>
		public  Persona()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private int codigo;
		private string nombre;
		private string contacto;
		private int idTipoCalificacion;
		private int idSector;
		private int idSubSector;
		private string vinculo;
		private string origenContacto;
		private int idTratamiento;
		private string documento;
		private int idTipoDocumento;
		private string cuit;
		private int idProfesion;
		private string idCargo;
        private List<Domicilio> domicilios;
        private List<Telefono> telefonos;
        private List<Email> emails;
        private string notas;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public int Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
            public string Notas
            {
                get { return this.notas; }
                set { this.notas = value; }
            }

            public List<Domicilio> Domicilios
            {
                get { return this.domicilios; }
                set { this.domicilios = value; }
            }

            public List<Telefono> Telefonos
            {
                get { return this.telefonos; }
                set { this.telefonos = value; }
            }

            public List<Email> Emails
            {
                get { return this.emails; }
                set { this.emails = value; }
            }


			public string Contacto
				{
					get { return this.contacto; }
					set { this.contacto = value; }
				}
		
			public int IdTipoCalificacion
				{
					get { return this.idTipoCalificacion; }
					set { this.idTipoCalificacion = value; }
				}
		
			public int IdSector
				{
					get { return this.idSector; }
					set { this.idSector = value; }
				}
		
			public int IdSubSector
				{
					get { return this.idSubSector; }
					set { this.idSubSector = value; }
				}
		
			public string Vinculo
				{
					get { return this.vinculo; }
					set { this.vinculo = value; }
				}
		
			public string OrigenContacto
				{
					get { return this.origenContacto; }
					set { this.origenContacto = value; }
				}
		
			public int IdTratamiento
				{
					get { return this.idTratamiento; }
					set { this.idTratamiento = value; }
				}
		
			public string Documento
				{
					get { return this.documento; }
					set { this.documento = value; }
				}
		
			public int IdTipoDocumento
				{
					get { return this.idTipoDocumento; }
					set { this.idTipoDocumento = value; }
				}
		
			public string Cuit
				{
					get { return this.cuit; }
					set { this.cuit = value; }
				}
		
			public int IdProfesion
				{
					get { return this.idProfesion; }
					set { this.idProfesion = value; }
				}
		
			public string IdCargo
				{
					get { return this.idCargo; }
					set { this.idCargo = value; }
				}
		
		
		#endregion
	}
}
