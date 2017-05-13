using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using Toolkit;
using System.Text;
using System.Diagnostics;

public class CreateBIO
{
//	static string basePath = Application.streamingAssetsPath + "/";

//	[@MenuItem("Coolape/CreateBIO/DBCFActivity")]
//	static void createDBCFActivity ()
//	{
//		DBCFActivityData.init ();
//		int len = DBCFActivityData.datas.Count;
//		DBActivity cell = null;
//		ArrayList list = new ArrayList ();
//		for (int i =0; i < len; i++) {
//			cell = (DBActivity)(DBCFActivityData.datas [i]);
//			list.Add (cell.ToMap ());
//		}
//		
//		MemoryStream os = new MemoryStream ();
//		string fileName = basePath + "cfgActivity";
//		
//		B2OutputStream.writeObject (os, list);
//		os.Position = 0;
//		byte[] data = os.GetBuffer ();
//		os.Close ();
//		File.WriteAllBytes (fileName, data);
//	}

	public static void CreateLua2BIO()
	{
		string path = AssetDatabase.GetAssetPath(Selection.activeObject);//Selection表示你鼠标选择激活的对象
		if (string.IsNullOrEmpty(path) || !File.Exists(path)) {
			UnityEngine.Debug.LogWarning("请选择lua 文件!");
			return;
		}
		string strBuff = File.ReadAllText(path);
		MemoryStream os = new MemoryStream();
		string dir = Path.GetDirectoryName(path);
		string fname = Path.GetFileNameWithoutExtension(path);
		string fext = Path.GetExtension(path);
		string fileName = dir + "/" + fname  + fext + "x";
		UnityEngine.Debug.Log(fileName);
        fileName = fileName.Replace("/upgradeResMedium", "/upgradeRes4Publish");
		Directory.CreateDirectory(Path.GetDirectoryName(fileName));

		B2OutputStream.writeObject(os, Encoding.Default.GetBytes(strBuff));
		os.Position = 0;
		File.WriteAllBytes(fileName, os.ToArray());
		os.Close();

	}

}
