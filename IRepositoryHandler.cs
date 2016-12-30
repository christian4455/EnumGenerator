using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnumGenerator.Types;

namespace EnumGenerator
{
    public interface IRepositoryHandler
    {
        List<EnumData> HandleRepository(EA.Repository packageElement);
    }
}
