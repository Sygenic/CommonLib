namespace Sygenic.CommonLib;

/// <summary>
/// Dictionary based on ConcurrentDictionary which calls defined action during getting value if key is missing
/// Default action is to create new default instance of value type
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
[NotTested]
public class LambdaDictionaryDefault<TKey, TValue>
	: ICollection<KeyValuePair<TKey, TValue>>,
		IEnumerable<KeyValuePair<TKey, TValue>>,
		IEnumerable,
		IDictionary<TKey, TValue>,
		IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
		IReadOnlyDictionary<TKey, TValue>,
		ICollection,
		IDictionary,
		IDeserializationCallback,
		ISerializable
	where TValue : notnull // this version does not need new() here
	where TKey : notnull
{
	/// <summary>
	/// Method called when no key/value is found. Method is called with key and returned value is saved as value for given key.
	/// Default for defaultLambda is to create new instance of TValue
	/// </summary>
	public Func<TKey, TValue> DefaultLambda { get; set; } = key => default!; // this version passes default insted of new TValue

	/// <summary>
	/// Real Dictionary used to store data
	/// </summary>
	protected readonly ConcurrentDictionary<TKey, TValue> BackstageDictionary = new();

	public ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary() => new(BackstageDictionary);

	/// <summary>
	/// Access to BackstageDictionary with "contains key" checking (and defaultLambda calling if key is not contained)
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public TValue this[TKey key]
	{
		get
		{
			lock (BackstageDictionary)
			{
				if (!BackstageDictionary.ContainsKey(key)) BackstageDictionary[key] = DefaultLambda(key);
				return BackstageDictionary[key];
			}
		}
		set => BackstageDictionary[key] = value;
	}

	public ImmutableDictionary<TKey, TValue> ToImmutableDictionary()
		=> BackstageDictionary.ToImmutableDictionary();

	#region Bridge to BackstageDictionary
	public ICollection<TKey> Keys => BackstageDictionary.Keys;
	public ICollection<TValue> Values => BackstageDictionary.Values;
	public int Count => BackstageDictionary.Count;
	public bool IsReadOnly => ((IDictionary<TKey, TValue>)BackstageDictionary).IsReadOnly;
	IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => ((IReadOnlyDictionary<TKey, TValue>)BackstageDictionary).Keys;
	IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => ((IReadOnlyDictionary<TKey, TValue>)BackstageDictionary).Values;
	public bool IsSynchronized => true;
	public object SyncRoot => ((ICollection)BackstageDictionary).SyncRoot;
	public bool IsFixedSize => ((IDictionary)BackstageDictionary).IsFixedSize;
	ICollection IDictionary.Keys => ((IDictionary)BackstageDictionary).Keys;
	ICollection IDictionary.Values => ((IDictionary)BackstageDictionary).Values;
	public object? this[object key]
	{
		get => ((IDictionary)BackstageDictionary)[key];
		set => ((IDictionary)BackstageDictionary)[key] = value;
	}
	public void Add(TKey key, TValue value) => throw new NotSupportedException();
	public bool ContainsKey(TKey key) => BackstageDictionary.ContainsKey(key);
	public bool Remove(TKey key) => throw new NotSupportedException();
	public bool TryGetValue(TKey key, out TValue value) => BackstageDictionary.TryGetValue(key, out value!);
	public void Clear() => BackstageDictionary.Clear();
	public void Add(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)BackstageDictionary).Add(item);
	public bool Contains(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)BackstageDictionary).Contains(item);
	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((IDictionary<TKey, TValue>)BackstageDictionary).CopyTo(array, arrayIndex);
	public bool Remove(KeyValuePair<TKey, TValue> item) => ((IDictionary<TKey, TValue>)BackstageDictionary).Remove(item);
	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ((IDictionary<TKey, TValue>)BackstageDictionary).GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => ((IDictionary<TKey, TValue>)BackstageDictionary).GetEnumerator();
	public void CopyTo(Array array, int index) => ((ICollection)BackstageDictionary).CopyTo(array, index);
	public void Add(object key, object? value) => ((IDictionary)BackstageDictionary).Add(key, value);
	public bool Contains(object key) => ((IDictionary)BackstageDictionary).Contains(key);
	IDictionaryEnumerator IDictionary.GetEnumerator() => ((IDictionary)BackstageDictionary).GetEnumerator();
	public void Remove(object key) => ((IDictionary)BackstageDictionary).Remove(key);
	public void OnDeserialization(object? sender) => throw new NotSupportedException();
	public void GetObjectData(SerializationInfo info, StreamingContext context) => throw new NotSupportedException();
	#endregion
}