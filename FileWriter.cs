using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EnumGenerator.Types;

namespace EnumGenerator
{
    class FileWriter : IFileWriter
    {
        public FileWriter()
        {
            /* Intentionally left blank */
        }

        public void WriteProduct(string path, Product product)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + product.GetFilename());
                file.WriteLine(product.GetProduct().ToString());
                file.Close();
            }
            catch (Exception e)
            {
            }
            finally
            {
                // nothing
            }
        }
    }
}
