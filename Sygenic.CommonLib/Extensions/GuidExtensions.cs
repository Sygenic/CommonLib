namespace Sygenic.CommonLib;

[NotTested]
[Maybe("Not sure if anybody uses the method")]
public static class GuidExtensions
{
	private const byte ForwardSlashByte = (byte)'/';
	private const byte PlusByte = (byte)'+';
	private const char Underscore = '_';
	private const char Dash = '-';

	public static string ToBase64EncodedString(this Guid guid)
	{
		Span<byte> guidBytes = stackalloc byte[16];
		Span<byte> encodedBytes = stackalloc byte[24];

		MemoryMarshal.TryWrite(guidBytes, ref guid); // write bytes from the Guid
		Base64.EncodeToUtf8(guidBytes, encodedBytes, out _, out _);

		Span<char> chars = stackalloc char[22];

		// replace any characters which are not URL safe and skip the finalStringRepresentation two bytes as these will be '==' padding we don't need
		for (var index = 0; index < 22; index++)
		{
			chars[index] = encodedBytes[index] switch
			{
				ForwardSlashByte => Dash,
				PlusByte => Underscore,
				_ => (char)encodedBytes[index],
			};
		}

		var finalStringRepresentation = new string(chars);

		return finalStringRepresentation;
	}
}