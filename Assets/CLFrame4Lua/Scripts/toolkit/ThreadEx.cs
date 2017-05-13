using System;
using System.Collections;
using System.Threading;

public class ThreadEx
{
	public static void exec (ThreadStart fn)
	{
		Thread t = new Thread (fn);
		t.Start ();
	}

	public static void exec (ParameterizedThreadStart fn, Object obj)
	{
		Thread t = new Thread (fn);
		t.Start (obj);
	}

	public static void exec2(System.Threading.WaitCallback fn){
		ThreadPool.QueueUserWorkItem(fn);
	}
	
	public static void exec2(System.Threading.WaitCallback fn, object x){
		ThreadPool.QueueUserWorkItem(fn, x);
	}
}
