using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApp.Entities
{
    public class SampleC
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(SampleB))]
        public Guid SampleBId { get; set; }
        public virtual SampleB SampleB { get; set; }
        public virtual ICollection<SampleD> SampleDs { get; set; }
    }
}
