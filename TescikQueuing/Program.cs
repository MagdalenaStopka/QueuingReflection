using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TescikQueuing
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFileFromLibs();
            Console.ReadKey();
        }
        public static void GetFileFromLibs()
        {
             var files = Directory.GetFiles(@"C:\Users\Admin\Desktop\QueuingLibrary\TescikQueuing\Libs", "*.dll");
            foreach (var file in files)
            {
                Type[] types;
                ////https://www.codeproject.com/Articles/19911/Dynamically-Invoke-A-Method-Given-Strings-with-Met
                ////https://stackoverflow.com/questions/20240092/use-reflection-to-search-in-dlls-c-sharp

                types = Assembly.LoadFrom(file).GetTypes();

                foreach (var type in types)
                {
                    MethodInfo m = type.GetMethod("Run", new Type[] { typeof(string), typeof(string) });
  
                    if (m != null)

                        Console.WriteLine("Found method: {0}", m);
                    m.Invoke(null, new object[] {null, null });
                    //MethodInfo[] methods = type.GetMethods();
                    //foreach(var method in methods)
                    //{ Console.WriteLine(method); }
                }

            }

        }
    }
}

