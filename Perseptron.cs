using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perseptron
{
    public static class Perseptron
    {
        public static Function[] GetDecisiveFunctions(int numberClasses, int vectorSize ,Vector[][] teachingVectors)
        {
            Function[] functions = InitializeFunctions(numberClasses, vectorSize);
            bool isError;
            int numberIteration = 0;

            do {
                isError = DoPerseptronIteration(teachingVectors, functions, numberClasses);
                numberIteration++;
            } while (isError && numberIteration != 1000);

            if (isError) ShowErrorMessage();

            return functions;
        }

        private static Function[] InitializeFunctions(int numberClasses, int vectorSize)
        {
            Function[] functions = new Function[numberClasses];
            for (int i = 0; i < numberClasses; i++) {
                functions[i] = new Function(vectorSize);
            }
            return functions;
        }

        private static bool DoPerseptronIteration(Vector[][] teachingVectors, Function[] functions, int numberClasses)
        {
            bool isError = false;
            for (int classNumber = 0; classNumber < numberClasses; classNumber++) {
                for (int vectorNumber = 0; vectorNumber < teachingVectors[classNumber].Length; vectorNumber++) {
                    int currentClassNumber = ClassifyVectorToClass(functions,
                        teachingVectors[classNumber][vectorNumber]);
                    if (currentClassNumber != classNumber) {
                        MakeAdjustment(teachingVectors[classNumber][vectorNumber], functions, classNumber);
                        isError = true;
                    }
                }
            }

            return isError;
        }

        private static void MakeAdjustment(Vector vector, Function[] functions, int classNumber)
        {
            for (int i = 0; i < functions.Length; i++) {
                if (i == classNumber)
                    functions[i] += vector;
                else
                    functions[i] -= vector;
            }
        }

        public static int ClassifyVectorToClass(Function[] functions, Vector vector)
        {
            int maxValue = int.MinValue;
            int classNumber = int.MinValue;
            int countSameResult = 0;
            for (int i = 0; i < functions.Length; i++) {
                int currentValue = functions[i].GetValue(vector);
                if (currentValue > maxValue) {
                    maxValue = currentValue;
                    classNumber = i;
                    countSameResult = 1;
                } else if (currentValue == maxValue) {
                    countSameResult++;
                }
            }
            return countSameResult == 1 ? classNumber : -1;
        }

        private static void ShowErrorMessage()
        {
            MessageBox.Show(@"The iteration cycle does not converge, class definition errors are possible",
                       @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
