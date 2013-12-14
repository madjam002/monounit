using System;

namespace MonoUnit.CLI
{
    public class Test : TestCase
    {
        public Test()
        {
            describe("Hello World", () => {
                for (int i = 0; i < 1000; i++) {

                    it("should work", () => {
                        System.Threading.Thread.Sleep(2);
                    });

                }
            });
        }
    }
}

