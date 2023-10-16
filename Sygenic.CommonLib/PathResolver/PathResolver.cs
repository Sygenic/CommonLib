namespace Sygenic.CommonLib;

[Tested]
public class PathResolver : IPathResolver
{
	private const BindingFlags FLAGS = BindingFlags.Public
		| BindingFlags.NonPublic
		| BindingFlags.FlattenHierarchy
		| BindingFlags.Instance;

	public (object, PropertyInfo) GetOwnerAndProperty(object root, string path)
	{
		if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

		var tokens = path.Split('.');
		object? cursor = root;
		PropertyInfo? lastPropertyInfo = null;
		for (int index = 0; index < tokens.Length; index++)
		{
			if (cursor is null) throw new PathResolverException($"Null property owner for path {path} index {index - 1}");
			Type? type = cursor.GetType();
			var propertyName = tokens[index];
			lastPropertyInfo = type.GetProperty(propertyName, FLAGS);

			if (index < tokens.Length - 1)
			{
				if (lastPropertyInfo is null) throw new PathResolverException($"Property info is null for path {path} index {index}");
				cursor = lastPropertyInfo.GetValue(cursor);
			}
		}
		if (cursor is null) throw new PathResolverException($"Null property owner for path {path} index one before end");
		if (lastPropertyInfo is null) throw new PathResolverException($"Last property info is null for path {path}");
		return (cursor, lastPropertyInfo);
	}

	public (object?, PropertyInfo?) GetOwnerAndPropertySafe(object root, string path)
	{
		try
		{
			return GetOwnerAndProperty(root, path);
		}
		catch
		{
			return (null, null);
		}
	}

	public T GetValue<T>(object root, string path) => (T)GetValue(root, path);

	public object GetValue(object root, string path)
	{
		(var owner, var propertyInfo) = GetOwnerAndProperty(root, path);
		var ret = propertyInfo.GetValue(owner) ?? throw new PathResolverException($"Null value on owner {owner} last path element of {path}");
		return ret;
	}
	public T? GetValueSafe<T>(object root, string path) => (T?)GetValueSafe(root, path);

	public object? GetValueSafe(object root, string path)
	{
		try
		{
			return GetValue(root, path);
		}
		catch
		{
			return null;
		}
	}

	public void SetValue(object root, string path, object value)
	{
		(var owner, var property) = GetOwnerAndProperty(root, path);
		property.SetValue(owner, value);
	}
}
