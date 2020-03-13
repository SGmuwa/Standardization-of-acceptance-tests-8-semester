using System;

namespace Standardization_of_acceptance_tests_8_semester
{
    public class Flower
    {
        public ConsoleColor Color { get; private set; }
        public float Length { get; private set; }

        public Flower(ConsoleColor color, float length)
        {
            Color = color;
            Length = length;
        }

        private Flower() {}

        public class Builder
        {
            private Flower current = new Flower();

            private dynamic seted = new {isColor = false, isLength = false};

            public Builder SetColor(ConsoleColor color)
            {
                current.Color = color;
                seted.isColor = true;
                return this;
            }

            public Builder SetLength(int length)
            {
                current.Length = length;
                seted.isLength = true;
                return this;
            }

            public Flower Build()
            {
                if(seted.isColor && seted.isLength)
                    return current;
                else
                    throw new Exception(seted);
            }
        }
    }
}
