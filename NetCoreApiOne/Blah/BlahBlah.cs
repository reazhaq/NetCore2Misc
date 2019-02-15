using System.Threading.Tasks;

namespace NetCoreApiOne.Blah
{
    public class BlahBlah : IBlahBlah
    {
        public Task<string> SomeBlah()
        {
            var tcs = new TaskCompletionSource<string>();
            tcs.SetResult("blah blah blah");
            return tcs.Task;
        }
    }
}