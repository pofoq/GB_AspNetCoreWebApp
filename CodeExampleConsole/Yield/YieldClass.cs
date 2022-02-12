using System.Collections.Generic;

namespace CodeExampleConsole.Yield
{
    public static class YieldClass
    {
        public static IEnumerable<int> GetNewArray(IEnumerable<int> array)
        {
            foreach (int i in array)
            {
                yield return i * 10;
            }
        }
    }
}
