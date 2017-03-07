﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseptron
{
    public class Vector
    {
        private int[] Elements { get; set; }

        public Vector(int size)
        {
            Elements = new int[size];
        }

        public static Vector operator *(int number, Vector vector)
        {
            var result = new Vector(vector.Elements.Length);
            for (int i = 0; i < vector.Elements.Length; i++) {
                result.Elements[i] = vector.Elements[i] * number;
            }
            return result;
        }

        public int GetElementsLength()
        {
            return Elements.Length;
        }

        public int GetElement(int position)
        {
            return Elements[position];
        }
    }
}