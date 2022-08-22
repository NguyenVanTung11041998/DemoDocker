using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectApp.Entities
{
    public class SampleD
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(SampleC))]
        public Guid SampleCId { get; set; }
        public virtual SampleC SampleC { get; set; }
    }
}
