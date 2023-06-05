using ClothingStoreGolubkovUrmancheeva.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStoreGolubkovUrmancheeva.ClassHelper
{
    public class CartClass
    {
        public static ObservableCollection<Product> products = new ObservableCollection<Product>();
    }
}
