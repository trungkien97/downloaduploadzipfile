using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ParticipationForm
    {
        public Guid ParticipationFormId { get; set; }
        public string ParticipationFormCode { get; set; }
        public string ParticipationFormName { get; set; }
        public decimal Rate { get; set; }
    }
}
