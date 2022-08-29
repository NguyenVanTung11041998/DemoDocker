using System;
using System.Collections.Generic;

namespace ConnectApp.Dto
{
    public class SampleBDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SampleCDto> SampleCs { get; set; }
    }
}
