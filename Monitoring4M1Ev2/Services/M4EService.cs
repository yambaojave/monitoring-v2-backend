using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class M4EService : IM4EService
    {
        private readonly ApplicationDbContext _db;

        public M4EService(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
