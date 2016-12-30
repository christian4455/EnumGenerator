using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGenerator.Types
{
    public class EnumData
    {
        private string m_EnumName;
        private List<Tuple<string, Tuple<int, bool>>> m_Values = new List<Tuple<string, Tuple<int, bool>>>();
        private string m_Namespace = "";
        private List<string> m_Namespaces = new List<string>();

        public EnumData()
        {
            /* Intentionally left blank */
        }

        public void SetEnumName(string enumName)
        {
            m_EnumName = enumName;
        }

        public string GetEnumName()
        {
            return m_EnumName;
        }

        public void AddValue(Tuple<string, Tuple<int, bool>> value)
        {
            m_Values.Add(value);
        }

        public void AddNamespaceElement(string namespaceElement)
        {
            m_Namespaces.Add(namespaceElement);

            if (m_Namespace.Length > 0)
            {
                m_Namespace = namespaceElement + "::" + m_Namespace;
            }
            else
            {
                m_Namespace = namespaceElement;
            }
        }

        public string GetNamespace()
        {
            return m_Namespace;
        }

        public List<string> GetNamespaces()
        {
            return m_Namespaces;
        }

        public List<Tuple<string, Tuple<int, bool>>> GetValues()
        {
            return m_Values;
        }
    }
}
