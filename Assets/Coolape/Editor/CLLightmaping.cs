using UnityEngine;
using UnityEditor;
using System.Collections;

public class CLLightmaping : MonoBehaviour
{
	public static void bake()
	{
		LightmapEditorSettings.maxAtlasHeight = 512;
		LightmapEditorSettings.maxAtlasWidth = 512;
		Lightmapping.Clear();
		Lightmapping.BakeSelected();
	}
}
