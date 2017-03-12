using System;

namespace Perseptron
{
    public class Function
    {
        private int[] Elements { get; }

        public Function(int size)
        {
            Elements = new int[size];
            for (int i = 0; i < size; i++) {
                Elements[i] = 0;
            }
        }

        public int GetElementsLength()
        {
            return Elements.Length;
        }

        public int GetElement(int index)
        {
            return Elements[index];
        }

        public static Function operator +(Function function, Vector vector)
        {
            if (function.GetElementsLength() != vector.GetElementsLength()) throw new ArgumentException();

            Function result = new Function(function.Elements.Length);
            for (int i = 0; i < function.GetElementsLength(); i++) {
                result.Elements[i] = function.Elements[i] + vector.GetElement(i);
            }
            return result;
        }

        public static Function operator -(Function function, Vector vector)
        {
            if (function.GetElementsLength() != vector.GetElementsLength()) throw new ArgumentException();

            Function result = new Function(function.Elements.Length);
            for (int i = 0; i < function.GetElementsLength(); i++)
            {
                result.Elements[i] = function.Elements[i] - vector.GetElement(i);
            }
            return result;
        }

        public int GetValue(Vector vector)
        {
            if (Elements.Length != vector.GetElementsLength()) throw new ArgumentException();

            int result = 0;
            for (int i = 0; i < Elements.Length; i++) {
                result += vector.GetElement(i) * Elements[i];
            }
            return result;
        }
    }
}
