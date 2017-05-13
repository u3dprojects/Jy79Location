using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
/*
 * 有个简单粗暴的办法, 直接在Editor\Data\Resources\ScriptTemplates文件夹下
 * 建一个文件,文件名类似即可...如89-LuaScript-NewLuaScript.lua.txt 
 * 文件名的意义=>优先级为:89;右键Create名为:Lua Sprite;
 * 创建初始名为:NewLuaScript.lua 文件里的#SCRIPTNAME# 也会自动替换
 */
public class CLCreateLuaFile
{
	[MenuItem("Assets/Create/Lua Script/New Lua Panel", false, 81)]
	public static void CreatNewLuaPanel ()
	{
		ProjectWindowUtil.StartNameEditingIfProjectWindowExists (0,
		                                                         ScriptableObject.CreateInstance<MyDoCreateScriptAsset> (),
		                                                         GetSelectedPathOrFallback () + "/NewLuaPanel.lua",
		                                                         null,
		                                                         "Assets/CLFrame4Lua/Templates/Lua/NewLuaPanel.lua");
	}
	[MenuItem("Assets/Create/Lua Script/New Lua Cell", false, 81)]
	public static void CreatNewLuaCell ()
	{
		ProjectWindowUtil.StartNameEditingIfProjectWindowExists (0,
		                                                         ScriptableObject.CreateInstance<MyDoCreateScriptAsset> (),
		                                                         GetSelectedPathOrFallback () + "/NewLuaCell.lua",
		                                                         null,
		                                                         "Assets/CLFrame4Lua/Templates/Lua/NewLuaCell.lua");
	}
	
	public static string GetSelectedPathOrFallback ()
	{
		string path = "Assets";
		foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets)) {
			path = AssetDatabase.GetAssetPath (obj);
			if (!string.IsNullOrEmpty (path) && File.Exists (path)) {
				path = Path.GetDirectoryName (path);
				break;
			}
		}
		return path;
	}
}

class MyDoCreateScriptAsset : EndNameEditAction
{
	public override void Action (int instanceId, string pathName, string resourceFile)
	{
		UnityEngine.Object o = CreateScriptAssetFromTemplate (pathName, resourceFile);
		ProjectWindowUtil.ShowCreatedAsset (o);
	}
	
	internal static UnityEngine.Object CreateScriptAssetFromTemplate (string pathName, string resourceFile)
	{
		string fullPath = Path.GetFullPath (pathName);
		StreamReader streamReader = new StreamReader (resourceFile);
		string text = streamReader.ReadToEnd ();
		streamReader.Close ();
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension (pathName);
		text = Regex.Replace (text, "#SCRIPTNAME#", fileNameWithoutExtension);
		//string text2 = Regex.Replace(fileNameWithoutExtension, " ", string.Empty);
		//text = Regex.Replace(text, "#SCRIPTNAME#", text2);
		//if (char.IsUpper(text2, 0))
		//{
		//    text2 = char.ToLower(text2[0]) + text2.Substring(1);
		//    text = Regex.Replace(text, "#SCRIPTNAME_LOWER#", text2);
		//}
		//else
		//{
		//    text2 = "my" + char.ToUpper(text2[0]) + text2.Substring(1);
		//    text = Regex.Replace(text, "#SCRIPTNAME_LOWER#", text2);
		//}
		bool encoderShouldEmitUTF8Identifier = true;
		bool throwOnInvalidBytes = false;
		UTF8Encoding encoding = new UTF8Encoding (encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
		bool append = false;
		StreamWriter streamWriter = new StreamWriter (fullPath, append, encoding);
		streamWriter.Write (text);
		streamWriter.Close ();
		AssetDatabase.ImportAsset (pathName);
		return AssetDatabase.LoadAssetAtPath (pathName, typeof(UnityEngine.Object));
	}
	
}