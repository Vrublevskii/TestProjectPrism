using TestProject1.Classes;
using TestProjectPrism.Utils;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Class1 class1 = new Class1()
        {
            Id = 1,
            Name = "Foo",
            Class2 = new Class2()
            {
                Id = 2,
                Name = "Bar"
            }
        };
                
        [TestMethod]
        public void ObjectClonerTest()
        {
            Class1 class11 = new Class1();
            class11.ObjectCloner(class1);

            Assert.AreEqual(class11.Id, 1);
            Assert.AreEqual(class11.Name, "Foo");
            Assert.AreEqual(class11?.Class2?.Id, 2);
            Assert.AreEqual(class11?.Class2?.Name, "Bar");
        }

        [TestMethod]
        public void ObjectClonerWithoutIdTest()
        {
            Class1 class11 = new Class1();
            class11.ObjectClonerWithoutId(class1);

            Assert.IsNull(class11.Id);
            Assert.AreEqual(class11.Name, "Foo");
            Assert.AreEqual(class11?.Class2?.Id, 2);
            Assert.AreEqual(class11?.Class2?.Name, "Bar");
        }

        [TestMethod]
        public void ObjectClonerWithout1()
        {
            Class1 class11 = new Class1();
            class11.ObjectClonerWithout(class1, "Name");            

            Assert.AreEqual(1, class11.Id); 
            Assert.IsNull(class11.Name);
            Assert.AreEqual(2, class11?.Class2?.Id);
            Assert.AreEqual("Bar", class11?.Class2?.Name);
        }

        [TestMethod]
        public void ObjectClonerWithout2()
        {
            Class1 class11 = new Class1();
            class11.ObjectClonerWithout(class1, "Class2");

            Assert.AreEqual(1, class11.Id);
            Assert.AreEqual("Foo", class11.Name);
            Assert.IsNull(class11.Class2);

        }
    }
}