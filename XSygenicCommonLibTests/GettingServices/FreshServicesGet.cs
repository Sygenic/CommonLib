namespace GettingServices;

public class FreshServicesGet
{
	[Fact]
	public void _()
	{
		var ssp = new FreshServiceProvider();
		ssp.AddCommonServices(services =>
		{
			services.AddTransient<TransientThatUsesSingleton>();
			services.AddSingleton<ISingleton, Singleton>();
		});

		var transient1 = ssp.Get<TransientThatUsesSingleton>();
		Assert.Equal(1, transient1.IncrementAndGet());

		var transient2 = ssp.Get<TransientThatUsesSingleton>(); // each Get call gets fresh newly created service provider
		Assert.Equal(1, transient2.IncrementAndGet());

		var commonSingleton = new Singleton();

		var transient3 = ssp.Get<TransientThatUsesSingleton>(commonSingleton);
		Assert.Equal(1, transient3.IncrementAndGet());

		var transient4 = ssp.Get<TransientThatUsesSingleton>(commonSingleton);
		Assert.Equal(2, transient4.IncrementAndGet());
	}

	interface ISingleton
	{
		int Value { get; set; }
	}

	sealed class Singleton : ISingleton
	{
		public int Value { get; set; }
	}

	sealed class TransientThatUsesSingleton(ISingleton singleton)
	{
		public int IncrementAndGet()
		{
			singleton.Value++;
			return singleton.Value;
		}
	}
}
