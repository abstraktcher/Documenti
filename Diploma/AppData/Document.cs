//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diploma.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Document()
        {
            this.IfDocumentIsExternal = new HashSet<IfDocumentIsExternal>();
        }
    
        public int IdDocument { get; set; }
        public int IdDocumentType { get; set; }
        public bool IsInternal { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int IdImportance { get; set; }
        public int IdCreator { get; set; }
        public Nullable<int> WhereIsItDirected_IdDepartment { get; set; }
        public Nullable<int> ResponsiblePerson { get; set; }
        public string PeriodOfExecution { get; set; }
        public string Comments { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        public virtual TypeOfDocument TypeOfDocument { get; set; }
        public virtual TypeOfImportance TypeOfImportance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IfDocumentIsExternal> IfDocumentIsExternal { get; set; }
    }
}
