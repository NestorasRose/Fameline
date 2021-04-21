using System;
using Fameline.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fameline.Lib.DAL
{
    public class FamelineGenerator
    {
        private readonly FamelineContext ctx;
        public FamelineGenerator(FamelineContext dbContext)
        {
            ctx = dbContext;
        }

        public void FamelineDataSeed()
        {
            if (ctx.Fleets.Any())
            {
                return;
            }

            ctx.Fleets.Add(new Fleet()
            {
                Name = "Seeded Fleet",
                Vessels = new List<Vessel>()
                {
                    new Vessel()
                    {
                        Name = "Seeded Vessel",
                        MaxWeight = 1000.05M,
                        Containers = new List<Container>()
                        {
                            new Container()
                            {
                                Name = "Seeded Container 1",
                                Weight = 500
                            },
                            new Container()
                            {
                                Name = "Seeded Container 2",
                                Weight = 500
                            }
                        }
                    }
                }
            });

            ctx.Fleets.Add(new Fleet()
            {
                Name = "Seeded Fleet 2",
                Vessels = new List<Vessel>()
                {
                    new Vessel()
                    {
                        Name = "Seeded Vessel 2",
                        MaxWeight = 1000.05M,
                        Containers = new List<Container>()
                        {
                            new Container()
                            {
                                Name = "Seeded Container 3",
                                Weight = 400
                            },
                            new Container()
                            {
                                Name = "Seeded Container 4",
                                Weight = 250
                            }
                        }
                    }
                }
            });

            ctx.SaveChanges();
        }
    }
}
