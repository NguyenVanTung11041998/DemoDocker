using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApp.Entities
{
    public class SampleB
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(SampleA))]
        public Guid SampleAId { get; set; }
        public virtual SampleA SampleA { get; set; }
        public virtual ICollection<SampleC> SampleCs { get; set; }
    }
}
