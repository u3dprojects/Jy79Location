using System;
using System.Collections;

/// <summary>
/// B2 int.为了解决lua中map的key为int时传给服务器无法取值的问题
/// </summary>
public class B2Int  {
	public int value = 0;
//	public B2Int() {
//		value = 0;
//	}
	public B2Int(int v) {
		value = v;
	}
}
