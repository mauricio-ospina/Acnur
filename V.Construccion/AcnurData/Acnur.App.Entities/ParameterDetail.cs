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
    public partial class ParameterDetail
    {
    	/// <summary>
        /// Constructor ParameterDetail
        /// </summary>
        public ParameterDetail()
        {
            this.GeneralInformationAction = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction1 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction2 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction3 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction4 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction5 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction6 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction7 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction8 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction9 = new HashSet<GeneralInformationAction>();
            this.GeneralInformationAction10 = new HashSet<GeneralInformationAction>();
            this.AnnexC = new HashSet<AnnexC>();
            this.AnnexC1 = new HashSet<AnnexC>();
            this.AnnexC2 = new HashSet<AnnexC>();
            this.AnnexC3 = new HashSet<AnnexC>();
            this.AnnexC4 = new HashSet<AnnexC>();
            this.AnnexC5 = new HashSet<AnnexC>();
            this.AnnexC6 = new HashSet<AnnexC>();
            this.AnnexC7 = new HashSet<AnnexC>();
            this.AnnexC8 = new HashSet<AnnexC>();
            this.AnnexC9 = new HashSet<AnnexC>();
            this.AnnexC10 = new HashSet<AnnexC>();
            this.AnnexC11 = new HashSet<AnnexC>();
            this.AnnexC12 = new HashSet<AnnexC>();
            this.AnnexC13 = new HashSet<AnnexC>();
            this.AnnexC14 = new HashSet<AnnexC>();
            this.AnnexC15 = new HashSet<AnnexC>();
            this.AnnexC16 = new HashSet<AnnexC>();
            this.AnnexC17 = new HashSet<AnnexC>();
            this.CostApproval = new HashSet<CostApproval>();
            this.CostApproval1 = new HashSet<CostApproval>();
            this.CostApproval2 = new HashSet<CostApproval>();
            this.CostApproval3 = new HashSet<CostApproval>();
            this.DataProject = new HashSet<DataProject>();
            this.DataProject1 = new HashSet<DataProject>();
            this.DataProject2 = new HashSet<DataProject>();
            this.DataProject3 = new HashSet<DataProject>();
            this.DataProject4 = new HashSet<DataProject>();
            this.DataProject5 = new HashSet<DataProject>();
            this.Events = new HashSet<Events>();
            this.GeneralInformationRiskProfile = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile1 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile2 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile3 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile4 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile5 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile6 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile7 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile8 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile9 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile10 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile11 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile12 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile13 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile14 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile15 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile16 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationRiskProfile17 = new HashSet<GeneralInformationRiskProfile>();
            this.GeneralInformationEmergency = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency1 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency2 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency3 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency4 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency5 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency6 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency7 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency8 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEmergency9 = new HashSet<GeneralInformationEmergency>();
            this.GeneralInformationEvent = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent1 = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent2 = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent3 = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent4 = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent5 = new HashSet<GeneralInformationEvent>();
            this.GeneralInformationEvent6 = new HashSet<GeneralInformationEvent>();
            this.Goods = new HashSet<Goods>();
            this.ItineraryInformation = new HashSet<ItineraryInformation>();
            this.ItineraryInformation1 = new HashSet<ItineraryInformation>();
            this.ParameterDetail1 = new HashSet<ParameterDetail>();
            this.PressData = new HashSet<PressData>();
            this.PressData1 = new HashSet<PressData>();
            this.PressData2 = new HashSet<PressData>();
            this.PressData3 = new HashSet<PressData>();
            this.PressData4 = new HashSet<PressData>();
            this.PressData5 = new HashSet<PressData>();
            this.PressData6 = new HashSet<PressData>();
            this.PT8 = new HashSet<PT8>();
            this.PT81 = new HashSet<PT8>();
            this.PT82 = new HashSet<PT8>();
            this.Request = new HashSet<Request>();
            this.SatffInformation = new HashSet<SatffInformation>();
            this.SatffInformation1 = new HashSet<SatffInformation>();
            this.Services = new HashSet<Services>();
            this.Sessions = new HashSet<Sessions>();
            this.Weekly = new HashSet<Weekly>();
            this.Weekly1 = new HashSet<Weekly>();
            this.Weekly2 = new HashSet<Weekly>();
            this.Weekly3 = new HashSet<Weekly>();
            this.Attachments = new HashSet<Attachments>();
            this.Attachments1 = new HashSet<Attachments>();
        }
    
    
    	/// <summary>
        /// Atributo IdParameterDetail
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public int IdParameterDetail { get; set; }
    
    	/// <summary>
        /// Atributo IdParameter
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public int IdParameter { get; set; }
    
    	/// <summary>
        /// Atributo IdParameterDetailFather
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public Nullable<int> IdParameterDetailFather { get; set; }
    
    	/// <summary>
        /// Atributo Name
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public string Name { get; set; }
    
    	/// <summary>
        /// Atributo Definition
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public string Definition { get; set; }
    
    	/// <summary>
        /// Atributo Value1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public string Value1 { get; set; }
    
    	/// <summary>
        /// Atributo Value2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public string Value2 { get; set; }
    
    	/// <summary>
        /// Atributo Ordinal
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public byte Ordinal { get; set; }
    
    	/// <summary>
        /// Atributo Active
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public bool Active { get; set; }
    
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction7
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction7 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction8
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction8 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction9
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction9 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationAction10
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationAction> GeneralInformationAction10 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Parameter
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual Parameter Parameter { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC7
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC7 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC8
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC8 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC9
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC9 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC10
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC10 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC11
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC11 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC12
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC12 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC13
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC13 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC14
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC14 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC15
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC15 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC16
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC16 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion AnnexC17
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<AnnexC> AnnexC17 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion CostApproval
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<CostApproval> CostApproval { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion CostApproval1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<CostApproval> CostApproval1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion CostApproval2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<CostApproval> CostApproval2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion CostApproval3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<CostApproval> CostApproval3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion DataProject5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<DataProject> DataProject5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Events
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Events> Events { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile7
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile7 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile8
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile8 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile9
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile9 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile10
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile10 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile11
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile11 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile12
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile12 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile13
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile13 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile14
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile14 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile15
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile15 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile16
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile16 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationRiskProfile17
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationRiskProfile> GeneralInformationRiskProfile17 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency7
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency7 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency8
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency8 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEmergency9
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEmergency> GeneralInformationEmergency9 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion GeneralInformationEvent6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<GeneralInformationEvent> GeneralInformationEvent6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Goods
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Goods> Goods { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion ItineraryInformation
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<ItineraryInformation> ItineraryInformation { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion ItineraryInformation1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<ItineraryInformation> ItineraryInformation1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion ParameterDetail1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<ParameterDetail> ParameterDetail1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion ParameterDetail2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ParameterDetail ParameterDetail2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData4
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData4 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData5
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData5 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PressData6
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PressData> PressData6 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PT8
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PT8> PT8 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PT81
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PT8> PT81 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion PT82
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<PT8> PT82 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Request
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Request> Request { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion SatffInformation
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<SatffInformation> SatffInformation { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion SatffInformation1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<SatffInformation> SatffInformation1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Services
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Services> Services { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Sessions
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Sessions> Sessions { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Weekly
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Weekly> Weekly { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Weekly1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Weekly> Weekly1 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Weekly2
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Weekly> Weekly2 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Weekly3
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Weekly> Weekly3 { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Attachments
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Attachments> Attachments { get; set; }
    
    	/// <summary>
        /// Atributo de agregacion Attachments1
        /// </summary>
    	[System.Runtime.Serialization.DataMember]
        public virtual ICollection<Attachments> Attachments1 { get; set; }
    }
}
