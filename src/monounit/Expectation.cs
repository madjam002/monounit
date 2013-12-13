using System;

namespace MonoUnit
{
    public class Expectation
    {
        object actual;
        bool inverse;

        public Expectation(object actual)
        {
            this.actual = actual;
            this.inverse = false;
        }

        public Expectation not()
        {
            inverse = true;

            return this;
        }

        public Expectation toEqual(object expected)
        {
            return this;
        }
    }
}

