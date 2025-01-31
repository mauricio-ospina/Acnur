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
    
    public partial class GeneralInformationEvent
    {
        public GeneralInformationEvent()
        {
            this.GeneralInformationEventUsers = new HashSet<GeneralInformationEventUsers>();
        }
    
        public int IdGeneralInformationEvent { get; set; }
        public int IdAuthor { get; set; }
        public int IdOffice { get; set; }
        public int IdUnit { get; set; }
        public System.DateTime EventDate { get; set; }
        public int IdCategory { get; set; }
        public int IdSubCategory { get; set; }
        public int IdInformationSource { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int IdCity { get; set; }
        public string AdditionalGeographicLocation { get; set; }
    
        public virtual ParameterDetail ParameterDetail { get; set; }
        public virtual ParameterDetail ParameterDetail1 { get; set; }
        public virtual ParameterDetail ParameterDetail2 { get; set; }
        public virtual ParameterDetail ParameterDetail3 { get; set; }
        public virtual ParameterDetail ParameterDetail4 { get; set; }
        public virtual ParameterDetail ParameterDetail5 { get; set; }
        public virtual ParameterDetail ParameterDetail6 { get; set; }
        public virtual ICollection<GeneralInformationEventUsers> GeneralInformationEventUsers { get; set; }
    }
}
