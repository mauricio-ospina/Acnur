//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acnur.App.Repository.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class OperationsModuleUser
    {
        public int IdOperationModuleUser { get; set; }
        public int IdOperationModule { get; set; }
        public int IdUser { get; set; }
    
        public virtual OperationsModule OperationsModule { get; set; }
        public virtual Users Users { get; set; }
    }
}
