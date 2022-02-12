using System.Threading.Tasks;

namespace CodeExampleConsole.AsyncApp
{
    internal static class WorkEmulation
    {
        internal static Task Get(int milliseconds)
        {
            //return new Task(() => Thread.Sleep(milliseconds));
            return Task.Delay(milliseconds);
        }
    }
}
