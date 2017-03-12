namespace Perseptron
{
    public static class Writer
    {
        public static string PrintVectors(Vector[][] vectors)
        {
            string result = "";

            for (int i = 0; i < vectors.Length; i++)
            {
                result += @"Vectors " + (i + 1) + @" class :" + "\r\n";
                for (int j = 0; j < vectors[i].Length; j++)
                {
                    result += (j + 1) + @" vectors : (";
                    for (int k = 0; k < vectors[i][j].GetElementsLength() - 2; k++)
                    {
                        result += vectors[i][j].GetElement(k) + @", ";
                    }
                    result += vectors[i][j].GetElement(vectors[i][j].GetElementsLength() - 2) + @");" + "\r\n";
                }
                result += "\r\n";
            }
            result = result.Remove(result.Length - 4, 4);

            return result;
        }

        public static string PrintFunctions(Function[] functions)
        {
            string result = "";

            for (int i = 0; i < functions.Length; i++)
            {
                result += @"d(" + (i + 1) + @") = ";
                for (int j = 0; j < functions[i].GetElementsLength() - 1; j++)
                {
                    if (j != 0 && functions[i].GetElement(j) >= 0)
                        result += @"+";
                    result += functions[i].GetElement(j) + "*x" + (j + 1);
                }
                if (functions[i].GetElement(functions[i].GetElementsLength() - 1) >= 0)
                    result += "+";
                result += functions[i].GetElement(functions[i].GetElementsLength() - 1) + ";" + "\r\n";
            }
            result = result.Remove(result.Length - 2, 2);

            return result;
        }
    }
}
