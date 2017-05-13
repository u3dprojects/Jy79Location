using System.Collections;

public class FixedMap : IDictionary {

	protected Hashtable map = new Hashtable();

	private FixedMap()
	{}

	public FixedMap(IDictionary dic){
		ICollection keys = dic.Keys;
		foreach(object key in keys)
		{
			this.map[key] = dic[key];
		}
	}

	public FixedMap(Hashtable dic){
		ICollection keys = dic.Keys;
		foreach(object key in keys)
		{
			this.map[key] = dic[key];
		}
	}

	public void Add (object key, object value)
	{
		throw new System.NotImplementedException ();
	}

	public void Clear ()
	{
		throw new System.NotImplementedException ();
	}

	public bool Contains (object key)
	{
		return map.Contains(key);
	}

	public IDictionaryEnumerator GetEnumerator ()
	{
		return map.GetEnumerator();
	}

	public void Remove (object key)
	{
		throw new System.NotImplementedException ();
	}

	public void CopyTo (System.Array array, int index)
	{
		map.CopyTo(array, index);
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		return GetEnumerator();
	}

	public bool IsFixedSize {
		get {
			return true;
		}
	}

	public bool IsReadOnly {
		get {
			return true;
		}
	}

	public object this[object key] {
		get {
			return map[key];
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public ICollection Keys {
		get {
			return map.Keys;
		}
	}

	public ICollection Values {
		get {
			return map.Values;
		}
	}

	public int Count {
		get {
			return map.Count;
		}
	}

	public bool IsSynchronized {
		get {
			return map.IsSynchronized;
		}
	}

	public object SyncRoot {
		get {
			return map.SyncRoot;
		}
	}
}
