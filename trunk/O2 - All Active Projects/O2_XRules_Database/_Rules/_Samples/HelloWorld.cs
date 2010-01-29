using O2.Kernel;
//O2Tag_AddReferenceFile:nunit.framework.dll
using NUnit.Framework;

namespace O2.XRules.Database._Rules._Samples
{
    [TestFixture]
    public class HelloWorld
    {
        [Test]
        public void sayHello()
        {
            PublicDI.log.showMessageBox("Hello O2 World!");
        }
        
        public void sayHello3()
        {
            PublicDI.log.info("Hello O2 World!");
        }
        
    }
}