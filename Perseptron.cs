using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseptron
{
    public class Perseptron
    {
        private readonly int _numberClasses;
        private readonly int _vectorSize;

        public Perseptron(int numberClasses, int vectorSize)
        {
            _numberClasses = numberClasses;
            _vectorSize = vectorSize;
        }
    }
}
