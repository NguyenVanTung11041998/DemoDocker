using System;
using System.Collections.Generic;

namespace ConnectApp.Dto
{
    public class SampleADto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SampleBDto> SampleBs { get; set; }
    }
}
