using UnityEngine;
using System.Collections.Generic;

public static class CLMaterialCache
{
	static Dictionary<string, Material> materialCache = new Dictionary<string, Material> ();
	static List<Material> addedMaterials = new List<Material> ();

	public static void setMaterial (Material mat)
	{
		if (mat == null)
			return;
		string key = mat.mainTexture.name + "_" + mat.shader.name;
		materialCache [key] = mat;
	}

	public static Material getMaterial (Texture mainTexture, string shaderName)
	{
		if (mainTexture == null)
			return null;
		string key = mainTexture.name + "_" + shaderName;
		Material ret = null;
		if(materialCache.ContainsKey(key)) {
			ret = materialCache [key];
		}
		if (ret == null) {
			ret = new Material (Shader.Find (shaderName));
			ret.mainTexture = mainTexture;
			materialCache [key] = ret;
			addedMaterials.Add (ret);
		}
		return ret;
	}

	public static void clean ()
	{
		int count = addedMaterials.Count;
		Material mat = null;
		for (int i=0; i < count; i++) {
			mat = addedMaterials [i];
			GameObject.DestroyImmediate (mat);
		}
		addedMaterials.Clear ();
		materialCache.Clear ();
	}
}
