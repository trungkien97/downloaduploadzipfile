using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Village
    {
        public int VillageId { get; set; }
        public string VillageCode { get; set; }
        public string WardCode { get; set; }
        public string VillageName { get; set; }
        public ulong Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string VillageHeadsCode { get; set; }
        public string VillageHeadsName { get; set; }
        public string PhoneNumber { get; set; }
        public int? Id { get; set; }
    }
}
