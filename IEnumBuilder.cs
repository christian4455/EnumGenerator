using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnumGenerator.Types;

namespace EnumGenerator
{
    public interface IEnumBuilder
    {
        Product CreateProduct(EnumData data, string filename);
    }
}
