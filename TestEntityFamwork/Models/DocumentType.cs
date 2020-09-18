using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Employee = new HashSet<Employee>();
        }

        public string DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
