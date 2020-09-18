using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class AdministrativeArea
    {
        public int AdministrativeAreaId { get; set; }
        public string AdministrativeAreaCode { get; set; }
        public string ParentCode { get; set; }
        public string Name { get; set; }
        public ulong Status { get; set; }
    }
}
