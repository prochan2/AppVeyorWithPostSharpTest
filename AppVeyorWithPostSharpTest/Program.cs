using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace AppVeyorWithPostSharpTest
{
    class Program
    {
        [SayHello]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PostSharp!");
        }
    }

    [PSerializable]
    class SayHelloAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Hello C#!");
        }
    }
}
