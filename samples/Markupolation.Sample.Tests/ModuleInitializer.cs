using System.Runtime.CompilerServices;

namespace Markupolation.Sample.Tests
{
    public static class ModuleInitializer
    {
        [ModuleInitializer]
        public static void Init() => VerifyAngleSharpDiffing.Initialize();
    }
}
