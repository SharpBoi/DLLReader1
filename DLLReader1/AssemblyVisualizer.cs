using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DLLReader1
{
    public class AssemblyVisualizer
    {
        private StringBuilder output = new StringBuilder();

        public void VisualizeAsmTree(List<Assembly> asms, List<Exception> exceptions = null)
        {
            output.Clear();

            try
            {
                for (int i = 0; i < asms.Count; i++)
                {
                    Type[] types = asms[i].GetTypes();
                    for (int j = 0; j < types.Length; j++)
                    {
                        if (types[j].BaseType != null)
                            if (types[j].BaseType.Name == "Object")
                            {
                                Type typeClass = types[j];
                                output.AppendLine(typeClass.Name);

                                MethodInfo[] methods = typeClass.GetTypeInfo().DeclaredMethods.Cast<MethodInfo>() as MethodInfo[];
                                for (int k = 0; k < methods.Length; k++)
                                {
                                    MethodInfo method = methods[k];

                                    if (method.Attributes.HasFlag(MethodAttributes.Public) ||
                                        method.Attributes.HasFlag(MethodAttributes.Family))
                                        output.AppendLine("    " + method.Name);
                                }
                            }
                    }
                }
            }
            catch(Exception ex)
            {
                if (exceptions != null) exceptions.Add(ex);
            }

            Console.WriteLine(output);
        }
    }
}
