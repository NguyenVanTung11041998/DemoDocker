using System;
using System.Collections.Generic;

namespace ConnectApp.Entities
{
    public class SampleA
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SampleB> SampleBs { get; set; }
    }
}
