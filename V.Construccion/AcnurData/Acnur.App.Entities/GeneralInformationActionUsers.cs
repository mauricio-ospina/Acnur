//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acnur.App.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// DTO TabCuenta
    /// </summary>
    [System.Runtime.Serialization.DataContract(IsReference=true)]
    [Serializable]
    public partial class GeneralInformationActionUsers
    {
    
    	/// <summary>
        /// Atributo IdGeneralInformationActionUser
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public int IdGeneralInformationActionUser { get; set; }
    
    	/// <summary>
        /// Atributo IdGeneralInformationAction
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public int IdGeneralInformationAction { get; set; }
    
    	/// <summary>
        /// Atributo IdUser
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public int IdUser { get; set; }
    
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual GeneralInformationAction GeneralInformationAction { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Users
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual Users Users { get; set; }
    }
}
