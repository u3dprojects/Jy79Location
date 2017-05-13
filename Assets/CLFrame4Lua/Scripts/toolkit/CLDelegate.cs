using UnityEngine;
using System.Collections;
using Toolkit;

public class CLDelegate
{
	public Hashtable delegateInfro = new Hashtable();
	public void add(string key, object callback, object orgs) {
		ArrayList list = MapEx.getList(delegateInfro, key);
		if(list == null ) {
			list = new ArrayList();
		}
		ArrayList infor = new ArrayList();
		infor.Add(callback);
		infor.Add(orgs);
		list.Add(infor);
		delegateInfro[key] = list;
	}
	
	public void removeDelegates(string key) {
		if(delegateInfro[key] != null) {
			ArrayList list = MapEx.getList(delegateInfro, key);
			list.Clear();
			list = null;
		}
		delegateInfro.Remove(key);
	}
	
	public ArrayList getDelegates(string key) {
		return MapEx.getList(delegateInfro, key);
	}
}
