using System;
using System.Collections.Generic;

namespace ConnectApp.Dto
{
    public class SampleCDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SampleDDto> SampleDs { get; set; }
    }
}
