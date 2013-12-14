using System;
using System.Reflection;

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
            Assembly assembly = Assembly.LoadFile(path);
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

