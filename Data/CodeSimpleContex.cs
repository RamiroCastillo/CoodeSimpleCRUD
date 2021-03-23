using CoodeSimpleCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoodeSimpleCRUD.Data
{
    public class CodeSimpleContex:DbContext
    {
        public CodeSimpleContex(DbContextOptions<CodeSimpleContex> options): base(options) { }

        public virtual DbSet<Product> Products { get; set; }
    }
}
