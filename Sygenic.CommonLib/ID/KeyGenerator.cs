namespace Sygenic.CommonLib;

[NotTested]
public static class KeyGenerator
{
	public const byte DEFAULT_ID_LENGTH = 21;

	/// <summary>
	/// LENGHT OF DEFAULT ALPHABET MUST BE 1..255 !!!
	/// </summary>
	public const string DEFAULT_ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	private static readonly RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

	public static string CreateId(byte size) => CreateId(DEFAULT_ALPHABET, size);

	public static string CreateId(string alphabet = DEFAULT_ALPHABET, byte size = DEFAULT_ID_LENGTH)
	{
		// See https://github.com/ai/nanoid/blob/master/format.js for explanation why masking is use (`randomNumberGenerator % alphabet` is a common mistake security-wise).
		var mask = (2 << 31 - Clz32((alphabet.Length - 1) | 1)) - 1;
		var step = (int)Math.Ceiling(1.6 * mask * size / alphabet.Length);

		Span<char> idBuilder = stackalloc char[size];
		Span<byte> bytes = stackalloc byte[step];

		int cnt = 0;

		while (true)
		{
			randomNumberGenerator.GetBytes(bytes);
			for (var index = 0; index < step; index++)
			{
				var alphabetIndex = bytes[index] & mask;
				if (alphabetIndex >= alphabet.Length) continue;
				idBuilder[cnt] = alphabet[alphabetIndex];
				if (++cnt == size)
				{
					return new string(idBuilder);
				}
			}
		}
	}

	/// <summary>
	/// Counts leading zeros of <paramref name="x"/>.
	/// </summary>
	/// <param name="x">Input number.</param>
	/// <returns>Number of leading zeros.</returns>
	/// <remarks>
	/// Courtesy of spender/Sunsetquest see https://stackoverflow.com/a/10439333/623392.
	/// </remarks>
	internal static int Clz32(int x)
	{
		const int numIntBits = sizeof(int) * 8; //compile time constant
																						//do the smearing
		x |= x >> 1;
		x |= x >> 2;
		x |= x >> 4;
		x |= x >> 8;
		x |= x >> 16;
		//count the ones
		x -= x >> 1 & 0x55555555;
		x = (x >> 2 & 0x33333333) + (x & 0x33333333);
		x = (x >> 4) + x & 0x0f0f0f0f;
		x += x >> 8;
		x += x >> 16;
		return numIntBits - (x & 0x0000003f); //subtract # of 1s from 32
	}
}