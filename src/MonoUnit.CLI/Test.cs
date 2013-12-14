using System;

namespace MonoUnit.CLI
{
    public class Test : TestCase
    {
        public Test()
        {
            describe("Hello World", () => {

                Random rand = new Random();

                it("should work");
                it("should work");
                it("should work");
                it("should work");
                it("should work");

                for (int i = 0; i < 2000; i++) {

                    it("should work", () => {
                        if (rand.Next(0, 5) == 3) {
                            expect(false).toEqual(true);
                        } else {
                            expect(true).toEqual(true);
                        }
                        System.Threading.Thread.Sleep(2);
                    });

                }

                it("should work");
                it("should work");
            });
        }
    }
}

