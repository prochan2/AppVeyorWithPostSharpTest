namespace PostSharp.Samples.AutoDataContract
{
  [AutoDataContract]
  internal class TestBaseClass
  {
    public int SerializedProperty1 { get; set; }

    public string SerializedProperty2 { get; set; }

    [NotDataMember]
    public int NonSerializedProperty3 { get; set; }
  }
}