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
    
    public partial class Operations
    {
        public Operations()
        {
            this.OperationsModule = new HashSet<OperationsModule>();
        }
    
        public int IdOperation { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<OperationsModule> OperationsModule { get; set; }
    }
}
