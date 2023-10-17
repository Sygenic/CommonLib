namespace ImplementationProvider;

public class FindInterfacesInheritedFrom_
{
	[Fact]
	public void _()
	{
		var impProvider = TestHost.Services.Get<IImplementationProvider>();
		var types = impProvider.GetInterfacesInheritedFrom(typeof(IGenericInterface<>));
		Assert.Equal(2, types.Count());
		Assert.Contains(typeof(ISomeInterfaceA), types);
		Assert.Contains(typeof(ISomeInterfaceB), types);
	}
}
