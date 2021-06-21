using eBiblioteka.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI
{
    public class SetupService
    {
        public static void Seed(eBibliotekaContext context)
        {
            context.Database.Migrate();
        }
    }
}
