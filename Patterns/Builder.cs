using System;

namespace Patterns
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

        private Flower() { }

        public class Builder
        {
            private Flower current = new Flower();

            private (bool isColor, bool isLength) setted = (false, false);

            public Builder SetColor(ConsoleColor color)
            {
                current.Color = color;
                setted.isColor = true;
                return this;
            }

            public Builder SetLength(float length)
            {
                current.Length = length;
                setted.isLength = true;
                return this;
            }

            public Flower Build()
            {
                if (setted.isColor && setted.isLength)
                    return current;
                else
                    throw new Exception(setted.ToString());
            }
        }
    }
}
