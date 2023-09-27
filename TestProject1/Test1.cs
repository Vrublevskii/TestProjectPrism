using System.Reflection;

namespace TestProject1
{

    [TestClass]
    public class Test1
    {
        
        ClassWithSet classWithSet = new ClassWithSet();

        [TestMethod]
        public void GetProps()
        {
            //get properties
            PropertyInfo[] propertyInfos = classWithSet.GetType().GetProperties();
            int length = propertyInfos.Length;
            Assert.AreEqual(2, length);
            //get first propety type
            object type = propertyInfos.First().PropertyType;
            Assert.AreEqual(typeof(List<string>), type);
            //get first property Generic type
            Type typeGeneric = propertyInfos.First().PropertyType.GetGenericArguments().First();
            Assert.AreEqual(typeof(string), typeGeneric);


        }

        [TestMethod]
        public void ReflGetProp()
        {                
            Type type = classWithSet.GetType().GetProperties().First().GetType();
            Assert.AreEqual(typeof(string), type);
        }

        [TestMethod]
        public void GetList()
        {
            PropertyInfo propertyInfo = classWithSet.GetType().GetProperties().First();
            object? v = propertyInfo.GetValue(classWithSet);
            Assert.AreEqual(new List<string>(), v);
        }

        [TestMethod]
        public void SetList()
        {
            Type? type = classWithSet.GetType().GetProperties()?.First()?.GetValue(classWithSet)?.GetType().GetGenericArguments().First().GetType();
            List<Type> list = new List<Type>();
            Assert.Equals(new List<string>(), list);

        }


        public class ClassWithSet
        {            
            public List<string>? list {  get; set; }
            public List<int>? listInt { get; set; }
        }







    }
}
