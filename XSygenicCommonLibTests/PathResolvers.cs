namespace PathResolver_;

public class PathResolvers
{
	[Fact]
	public void _()
	{
		var resolver = new PathResolver();
		var a = new A();

		Assert.Throws<PathResolverException>(() => resolver.GetOwnerAndProperty(a, "there is no such property"));
		Assert.Throws<PathResolverException>(() => resolver.GetOwnerAndProperty(a, "b.there is no such property"));

		var actual = resolver.GetOwnerAndProperty(a, nameof(A.bNull));
		Assert.Same(a, actual.Item1);
		Assert.Equal(typeof(A).GetProperty(nameof(A.bNull)), actual.Item2);

		var act = resolver.GetOwnerAndPropertySafe(a, "there is no such property");
		Assert.Null(act.Item1);
		Assert.Null(act.Item2);

		Assert.Equal(1.ToString(), resolver.GetValue(a, "b.c.d").ToString());
		Assert.Equal(1, resolver.GetValue<int>(a, "b.c.d"));
		Assert.Throws<PathResolverException>(() => resolver.GetValue<int>(a, "b.c.no such property"));
		Assert.Null(resolver.GetValueSafe(a, "no such prop"));

		resolver.SetValue(a, "b.c.d", 2);
		Assert.Equal(2, a.b.c.d);
	}

	public class A
	{
		public B b { get; set; } = new();
		public B? bNull { get; set; } = null;
	}

	public class B
	{
		public C c { get; set; } = new();
		public C? cNull { get; set; } = null;
	}

	public class C
	{
		public int d { get; set; } = 1;
	}
}