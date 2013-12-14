using System;
using System.Reflection;
using System.IO;

namespace MonoUnit.CLI
{
    public class AssemblyLoader
    {
        Runner runner;

        public AssemblyLoader(Runner runner)
        {
            this.runner = runner;
        }

        public void Load(string path)
        {
            // Check if given path is a directory
            if (Directory.Exists(path))
            {
                // Get assemblies in directory
                var files = Directory.GetFiles(path, "*.dll");
                foreach (string file in files)
                {
                    Load(file);
                }

                return;
            }

            // Load assembly
            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFile(path);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Assembly {0} could not be found", path);
                return;
            }
            catch (BadImageFormatException)
            {
                Console.WriteLine("Assembly {0} is not a valid assembly", path);
                return;
            }

            Type testCaseType = typeof(TestCase);

            // Find classes in assembly which are test classes
            Type[] classes = assembly.GetTypes();
            foreach (Type assemblyClass in classes)
            {
                if (assemblyClass.IsSubclassOf(testCaseType))
                {
                    runner.AddTestCase((TestCase) Activator.CreateInstance(assemblyClass));
                }
            }
        }
    }
}

