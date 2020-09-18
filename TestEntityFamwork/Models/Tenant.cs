using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Employee = new HashSet<Employee>();
            Organization = new HashSet<Organization>();
            OrganizationUnit = new HashSet<OrganizationUnit>();
            Possition = new HashSet<Possition>();
        }

        public Guid TenantId { get; set; }
        public string TenantCode { get; set; }
        public string TenantName { get; set; }
        public string TransactionName { get; set; }
        public string Tax { get; set; }
        public DateTime? DateOfEstablishment { get; set; }
        public string BusinessRegistrationCode { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<OrganizationUnit> OrganizationUnit { get; set; }
        public virtual ICollection<Possition> Possition { get; set; }
    }
}
