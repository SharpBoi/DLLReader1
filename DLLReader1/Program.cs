using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DLLReader1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // prepare fields
                AssemblyVisualizer asmVisual = new AssemblyVisualizer();
                AssemblyReader dllReader = new AssemblyReader();
                string asmDir = "";
                List<Exception> exceptions = new List<Exception>();

                // reading user input
                Console.WriteLine("Input assemblies directory. You can drag and drop folder name: ");
                asmDir = Console.ReadLine();

                // read assemblies
                var dlls = dllReader.ReadAssemblies(asmDir, exceptions);

                // print asms content
                if (dlls.Count > 0)
                {
                    Console.WriteLine("\nAssemblies content. Classes with public and protected methods: \n");
                    asmVisual.VisualizeAsmTree(dlls, exceptions);
                }
                else Console.WriteLine("\nNo content :(");

                // log about exceptions in reading process
                Console.WriteLine();
                if (exceptions.Count == 0)
                    Console.WriteLine("Readed without exceptions !");
                else
                {
                    Console.WriteLine("Exceptions log: ");
                    for (int i = 0; i < exceptions.Count; i++)
                        Console.WriteLine(exceptions[i].Message);
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
