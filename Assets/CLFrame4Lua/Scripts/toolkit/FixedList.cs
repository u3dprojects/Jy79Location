using System;
using System.Collections;
using System.Collections.Generic;

public class FixedList<T> : IList<T> {

	protected List<T> list = new List<T>();
	protected T[] values;
	private FixedList()
	{
	}

	public FixedList(IList<T> list)
	{
		values = new T[list.Count];
		int p = 0;

		foreach(T e in list){
			this.list.Add(e);
			values[p++] = e;
		}
	}

	public FixedList(ArrayList list)
	{
		values = new T[list.Count];
		int p = 0;

		foreach(T e in list){
			this.list.Add(e);
			values[p++] = e;
		}
	}

	public FixedList(params T[] list)
	{
		values = new T[list.Length];
		int p = 0;
		
		foreach(T e in list){
			this.list.Add(e);
			values[p++] = e;
		}
	}

	public int IndexOf (T item)
	{
		return list.IndexOf(item);
	}

	public void Insert (int index, T item)
	{
		throw new NotImplementedException ();
	}

	public void RemoveAt (int index)
	{
		throw new NotImplementedException ();
	}

	public void Add (T item)
	{
		throw new NotImplementedException ();
	}

	public void Clear ()
	{
		throw new NotImplementedException ();
	}

	public bool Contains (T item)
	{
		return list.Contains(item);
	}

	public void CopyTo (T[] array, int arrayIndex)
	{
		list.CopyTo(array, arrayIndex);
	}

	public bool Remove (T item)
	{
		throw new NotImplementedException ();
	}

	public IEnumerator<T> GetEnumerator ()
	{
		return list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		return GetEnumerator();
	}

	public T this[int index] {
		get {
			//return list[index];
			return values[index];
		}
		set{
			throw new NotImplementedException ();
		}
	}

	public int Count {
		get {
			return list.Count;
		}
	}

	public bool IsReadOnly {
		get {
			return true;
		}
	}
}
