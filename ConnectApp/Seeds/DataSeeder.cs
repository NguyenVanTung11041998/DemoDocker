using ConnectApp.Entities;
using ConnectApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectApp.Seeds
{
    public class DataSeeder : IDataSeeder
    {
        private ConnectAppDbContext ConnectAppDbContext { get; }

        public DataSeeder(ConnectAppDbContext connectAppDbContext)
        {
            ConnectAppDbContext = connectAppDbContext;
        }

        public void Seed()
        {
            if (!ConnectAppDbContext.SampleAs.Any())
            {
                var sampleA = new SampleA
                {
                    Id = Guid.NewGuid(),
                    Name = "SampleA",
                    SampleBs = new List<SampleB>
                {
                    new SampleB
                    {
                        Id = Guid.NewGuid(),
                        Name = "SampleB1",
                        SampleCs = new List<SampleC>
                        {
                            new SampleC
                            {
                                Id = Guid.NewGuid(),
                                Name = "SampleCB1",
                                SampleDs = new List<SampleD>
                                {
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleDC1B1"
                                    },
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleD2C1B1"
                                    }
                                }
                            },
                            new SampleC
                            {
                                Id = Guid.NewGuid(),
                                Name = "SampleC2B1",
                                SampleDs = new List<SampleD>
                                {
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleDC2B1"
                                    },
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleD2C2B1"
                                    }
                                }
                            }
                        }
                    },
                    new SampleB
                    {
                        Id = Guid.NewGuid(),
                        Name = "SampleB2",
                        SampleCs = new List<SampleC>
                        {
                            new SampleC
                            {
                                Id = Guid.NewGuid(),
                                Name = "SampleCB2",
                                SampleDs = new List<SampleD>
                                {
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleDC1B2"
                                    },
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleD2C1B2"
                                    }
                                }
                            },
                            new SampleC
                            {
                                Id = Guid.NewGuid(),
                                Name = "SampleC2B2",
                                SampleDs = new List<SampleD>
                                {
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleDC2B2"
                                    },
                                    new SampleD
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "SampleD2C2B2"
                                    }
                                }
                            }
                        }
                    },
                }
                };

                ConnectAppDbContext.Add(sampleA);
            }

            ConnectAppDbContext.SaveChanges();
        }
    }
}
