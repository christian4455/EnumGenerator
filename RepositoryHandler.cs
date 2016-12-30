using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EnumGenerator.Types;
using EnumGenerator.Utils;

namespace EnumGenerator
{
    public class RepositoryHandler : IRepositoryHandler
    {
        private Types.EnumData m_Data = new Types.EnumData();
        private EA.Repository m_PackageOfInterest = null;

        public RepositoryHandler()
        {
            /* Intentionally left blank */
        }

        List<Types.EnumData> IRepositoryHandler.HandleRepository(EA.Repository packageElement)
        {
            List<Types.EnumData> list = new List<Types.EnumData>();

            m_PackageOfInterest = packageElement;

            foreach (EA.Element e in packageElement.GetTreeSelectedPackage().Elements)
            {
                if ((EnumUtil.ParseEnum<ElementType>(e.Type, ElementType.Unknown) == ElementType.Enumeration) || (e.Stereotype.Contains("enum") || (e.Stereotype.Contains("Enum"))))
                {
                    m_Data = new Types.EnumData();

                    FetchNamespace(packageElement);

                    m_Data.SetEnumName(e.Name);

                    HandleEnumeration(e);

                    list.Add(m_Data);
                }
            }

            return list;
        }

        private void FetchNamespace(EA.Repository element)
        {
            EA.Package package = element.GetTreeSelectedPackage();

            while (!package.IsNamespace)
            {
                m_Data.AddNamespaceElement(package.Name);
                package = element.GetPackageByID(package.ParentID);
            }
        }

        private void HandleEnumeration(EA.Element enumerationElement)
        {
            foreach (EA.Attribute a in enumerationElement.Attributes)
            {
                int value;
                bool valueIsValid = Int32.TryParse(a.Default, out value);
                m_Data.AddValue(new Tuple<string, Tuple<int, bool>>(a.Name, new Tuple<int, bool>(value, valueIsValid)));
            }
        }
    }
}
