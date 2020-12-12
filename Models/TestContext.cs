using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHoneyWell.Models
{
    public class TestContext :DbContext
    {
        public TestContext(DbContextOptions<TestContext> dbContextOptions): base(dbContextOptions)  
        {

        }

        public virtual DbSet<Users> USERS { get; set; }

    }
}
