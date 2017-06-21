using System;
using System.Reflection;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace TestingAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            
            constraints
            .   no Assembly.LoadFrom() 


            bits
            .   load an assembly from a file
            .   load a .dll from a file

            can try
            .    load assemblies by specifying the name (either full or short)

            terminology
            .   assembly
            .   dependency (this project referenced libraries)

            current
            +   need to create some library class or another .dll that can be reffered via path


            */

            var ff = Assembly.CreateQualifiedName("", "");
            var bhhuihui = Assembly.GetEntryAssembly();


            var qq = new AssemblyLoader();
            var assembly = qq.LoadFromAssemblyPath(@"C:\DONT REMOVE\AzureStone.dll");

            var qwqwqwqw = assembly.GetTypes();

            var type = assembly.GetType("AzureStone.BasicClass");

            dynamic obj = Activator.CreateInstance(type);
            //var obj = new BasicClass("hello world");
            var result1 = obj.ReturnHashed();
                                                                                           


            if (result1 == "5EB63BBBE01EEED093CB22BB8F5ACDC3")
                Debug.WriteLine("it works");




            Console.WriteLine("hello world!");
        }
    }

    public class AssemblyLoader : AssemblyLoadContext
    {
        // Not exactly sure about this
        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
            //throw new NotImplementedException();
            var deps = DependencyContext.Default;
            var res1 = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
            var res2 = deps.RuntimeLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
            var assembly = Assembly.Load(new AssemblyName(res2.First().Name));
            return assembly;
        }
    }
}