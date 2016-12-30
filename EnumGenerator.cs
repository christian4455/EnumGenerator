using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using EnumGenerator.Types;

namespace EnumGenerator
{
    public class EnumGenerator : IPlugin
    {
        private string DEFAULT_TARGETPATH = "D:\\";

        IRepositoryHandler m_RepositoryHandler = null;
        IEnumBuilder m_InterfaceBuilder = null;
        IFileWriter m_IFileWriter = null;

        public EnumGenerator()
        {
            /* Intentionally left blank */
        }
        
        void IPlugin.ProcessRepository(EA.Repository repository)
        {
            string targetPath = GetTargetPath();

            List<EnumData> data = m_RepositoryHandler.HandleRepository(repository);

            List<Types.Product> products = new List<Types.Product>();

            foreach (EnumData d in data)
            {
                products.Add(m_InterfaceBuilder.CreateProduct(d, d.GetEnumName() + ".hpp"));
            }

            foreach (Types.Product p in products)
            {
                m_IFileWriter.WriteProduct(targetPath, p);
            }

            MessageBox.Show("Finish");
        }

        public void SetRepositoryHandler(IRepositoryHandler repositoryHandler)
        {
            m_RepositoryHandler = repositoryHandler;
        }

        public void SetInterfaceBuilder(IEnumBuilder interfaceBuilder)
        {
            m_InterfaceBuilder = interfaceBuilder;
        }

        public void SetFileWriter(IFileWriter iFileWriter)
        {
            m_IFileWriter = iFileWriter;
        }

        private string GetTargetPath()
        {
            string result = DEFAULT_TARGETPATH;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                result = folderDialog.SelectedPath + "\\";
            }

            return result;
        }
    }
}
