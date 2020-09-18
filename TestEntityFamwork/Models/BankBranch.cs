using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class BankBranch
    {
        public Guid BankBranchId { get; set; }
        public string BankBranchCode { get; set; }
        public string BankBranchName { get; set; }
        public string ParentCode { get; set; }
        public string ProvincialCode { get; set; }
    }
}
