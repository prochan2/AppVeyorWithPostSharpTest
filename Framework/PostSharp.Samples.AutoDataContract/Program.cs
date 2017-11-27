using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace PostSharp.Samples.AutoDataContract
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var testClass = new TestDerivedClass
      {
        SerializedProperty1 = 1,
        SerializedProperty2 = "2",
        NonSerializedProperty3 = 3,
        SerializedProperty4 = 4,
        SerializedProperty5 = "5",
        NonSerializedProperty6 = 6
      };

      var serializer = new DataContractSerializer(typeof(TestDerivedClass));

      var stringWriter = new StringWriter();
      var xmlWriter = new XmlTextWriter(stringWriter)
      {
        Formatting = Formatting.Indented
      };

      serializer.WriteObject(xmlWriter, testClass);


      Console.WriteLine(stringWriter);
    }
  }
}