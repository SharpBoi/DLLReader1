using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLLReader1
{
    public class AssemblyReader
    {
        #region Fields

        #endregion

        #region Funcs

        public List<Assembly> ReadAssemblies(string assembliesDirectory, List<Exception> exceptions = null)
        {
            List<Assembly> dlls = new List<Assembly>();

            try
            {
                string[] filesNames = Directory.GetFiles(assembliesDirectory);
                for (int i = 0; i < filesNames.Length; i++)
                {
                    FileInfo fi = new FileInfo(filesNames[i]);
                    if (fi.Extension.ToLower() == ".dll")
                    {
                        try
                        {
                            dlls.Add(Assembly.LoadFile(filesNames[i]));
                        }
                        catch (Exception ex)
                        {
                            if (exceptions != null) exceptions.Add(ex);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if (exceptions != null) exceptions.Add(ex);
            }

            return dlls;
        }
        #endregion

        #region Props
        #endregion
    }
}
