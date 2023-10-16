namespace _Helpers;

public interface IData : IHasId
{

}

public class SomeDataA : IData
{
	public string Id { get; } = KeyGenerator.CreateId();
	public string StringValue { get; internal set; } = "x";
}

public interface ISomeInterfaceA : IGenericInterface<SomeDataA>
{

}

public class SomeDataB : IData
{
	public string Id { get; } = KeyGenerator.CreateId();
}

public interface ISomeInterfaceB : IGenericInterface<SomeDataB>
{

}

public interface IGenericInterface<DATA> where DATA : IData
{

}