namespace NanoIDs;

public class KeyGenerator_
{
	[Fact]
	public void _() => Assert.Equal(KeyGenerator.DEFAULT_ID_LENGTH, KeyGenerator.CreateId().Length);
}
