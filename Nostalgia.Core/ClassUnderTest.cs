using System;
using MoonSharp.Interpreter;
using Sandbox;

namespace Nostalgia.Core
{
    public class ClassUnderTest
    {
        public static int FunctionUnderTest()
        {
            Sandbox.Assert.True(true);
            var result = Script.RunString("return 1");
            return (int)result.Number;
        }
    }
}
