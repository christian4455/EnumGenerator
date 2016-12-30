using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnumGenerator.Types;

namespace EnumGenerator
{
    class EnumBuilder : IEnumBuilder
    {
        private string ELSE = "else";
        private string NONE = "";

        public Product CreateProduct(EnumData data, string filename)
        {
            Product product = new Product();

            product.SetFilename(filename);

            product.Append(CreateHeader(data.GetNamespaces(), filename));
            product.Append(CreateBody(data.GetValues(), filename));
            product.Append(CreateFooter(data.GetNamespaces(), filename));

            return product;
        }

        private string CreateHeader(List<string> namespaces, string filename)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("#ifndef " + ConvertToClassname(filename).ToUpper() +"_HPP");
            result.AppendLine("#define " + ConvertToClassname(filename).ToUpper() + "_HPP");
            result.AppendLine("");

            namespaces.Reverse();

            foreach (string nSpace in namespaces)
            {
                result.AppendLine("namespace " + nSpace + " {");
            }

            if (namespaces.Count > 0)
            {
                result.AppendLine("");
            }

            result.AppendLine("class " + ConvertToClassname(filename));
            result.AppendLine("{");
            result.AppendLine("");
            result.AppendLine("public:");
            result.AppendLine("");

            return result.ToString();
        }

        private string CreateBody(List<Tuple<string, Tuple<int, bool>>> values, string filename)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("    enum " + ConvertToClassname(filename));
            result.AppendLine("    {");

            foreach (Tuple<string, Tuple<int, bool>> v in values)
            {
                if (values.IndexOf(v) != values.Count - 1)
                {
                    if (v.Item2.Item2)
                    {
                        result.AppendLine("        " + v.Item1 + " = " + v.Item2.Item1.ToString() + ",");
                    }
                    else
                    {
                        result.AppendLine("        " + v.Item1 + ",");
                    }
                }
                else
                {
                    if (v.Item2.Item2)
                    {
                        result.AppendLine("        " + v.Item1 + " = " + v.Item2.Item1.ToString());
                    }
                    else
                    {
                        result.AppendLine("        " + v.Item1);
                    }
                }
            }

            result.AppendLine("    };");
            result.AppendLine("");
            result.AppendLine("    static ::std::string ToString(const Enum e)");
            result.AppendLine("    {");
            result.AppendLine("        ::std::string ret;");
            result.AppendLine("        switch (e)");
            result.AppendLine("        {");
            
            foreach (Tuple<string, Tuple<int, bool>> v in values)
            {
                result.AppendLine("            case " + v.Item1 + ": ret = \"" + v.Item1 + "\"; break;");
            }

            result.AppendLine("        // no default case since we want to get a compiler warning in case enum value is added");
            result.AppendLine("        }");
            result.AppendLine("        return ret;");
            result.AppendLine("    }");


            return result.ToString();
        }

        private string CreateFooter(List<string> namespaces, string filename)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("private:");
            result.AppendLine("");
            result.AppendLine("    " + ConvertToClassname(filename) + "();");
            result.AppendLine("    " + ConvertToClassname(filename) + "(const " + ConvertToClassname(filename) + "&);");
            result.AppendLine("    " + ConvertToClassname(filename) + "& operator =(const " + ConvertToClassname(filename) + "&);");
            result.AppendLine("};");
            result.AppendLine("");

            namespaces.Reverse();
            foreach (string nSpace in namespaces)
            {
                result.AppendLine("} // namespace - " + nSpace);
            }

            if (namespaces.Count > 0)
            {
                result.AppendLine("");
            }

            result.AppendLine("#endif // !" + ConvertToClassname(filename).ToUpper() + "_HPP");

            return result.ToString();
        }

        private string ConvertToClassname(string filename)
        {
            string result = "";

            result = filename.Remove(filename.IndexOf("."));

            return result;
        }

        private bool IsLegalFunctionName(string functionName)
        {
            bool result = false;

            if (functionName != ELSE && functionName != NONE)
            {
                result = true;
            }

            return result;
        }
    }
}
