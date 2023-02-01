using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStoreGolubkovUrmancheeva.DB;

namespace ClothingStoreGolubkovUrmancheeva.ClassHelper
{
    public class EFClass
    {
        public static Entities Context { get; } = new Entities();
    }
}
