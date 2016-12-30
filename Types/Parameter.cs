using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGenerator.Types
{
    public class Parameter
    {
        private string m_Name = "";
        private string m_Datatype = "";
        private bool m_IsReference = false;
        private bool m_IsPointer = false;
        private bool m_IsConst = false;
        private int m_Position = -1;

        public Parameter()
        {
            /* Intentionally left blank */
        }

        public void SetDatatype(string datatype)
        {
            m_Datatype = datatype;
        }

        public string GetDatatype()
        {
            return m_Datatype;
        }

        public void SetName(string name)
        {
            m_Name = name;
        }

        public string GetName()
        {
            return m_Name;
        }

        public void SetIsReference(bool isReference)
        {
            m_IsReference = isReference;
        }

        public bool IsReference()
        {
            return m_IsReference;
        }

        public void SetIsPointer(bool isPointer)
        {
            m_IsPointer = isPointer;
        }

        public bool IsPointer()
        {
            return m_IsPointer;
        }

        public void SetIsConst(bool isPointer)
        {
            m_IsPointer = isPointer;
        }

        public bool IsConst()
        {
            return m_IsConst;
        }

        public void SetPositionInArgList(int pos)
        {
            m_Position = pos;
        }

        public int GetPositionInArgList()
        {
            return m_Position;
        }
    }
}
