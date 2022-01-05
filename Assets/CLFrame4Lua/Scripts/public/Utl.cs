using UnityEngine;
using System.Collections;
using Toolkit;
using System.IO;
using LuaInterface;
using System.Net.NetworkInformation;
using System.Text;
using System.Collections.Generic;

//
using System.Security.Cryptography;


public static class Utl
{

	public static Vector3 kXAxis = new Vector3(1.0f, 0.0f, 0.0f); // points in the directon of the positive X axis
	public static Vector3 kZAxis = new Vector3(0.0f, 0.0f, 1.0f);// points in the direction of the positive Y axis
	static string cacheUuid = "";
    public static string uuid()
    {
#if UNITY_EDITOR
        if (!string.IsNullOrEmpty(SCfg.self.UUID))
        {
            return SCfg.self.UUID;
        }
#endif
		if (cacheUuid == "") {
			if (Application.platform == RuntimePlatform.Android ||
			    Application.platform == RuntimePlatform.IPhonePlayer)
			{
				cacheUuid = SystemInfo.deviceUniqueIdentifier;
			}
			else
			{
				cacheUuid = GetMacAddress();
			}
		}
		return cacheUuid;
    }

    public static string GetMacAddress()
    {
        string macAdress = "";
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface adapter in nics)
        {
            PhysicalAddress address = adapter.GetPhysicalAddress();
            if (address.ToString() != "")
            {
                macAdress = address.ToString();
                return macAdress;
            }
        }
        return "00";
    }

	public static string uid {
		get {
			string uid = GLVar.unqid;
			if(string.IsNullOrEmpty(uid)) {
				uid = uuid();
			}
			return PStr.begin().a(SCfg.Channel).a("_").a(uid).end();
		}
	}

    public static Hashtable vector2ToMap(Vector2 v2)
    {
        Hashtable r = new Hashtable();
        r["x"] = (double)(v2.x);
        r["y"] = (double)(v2.y);
        return r;
    }

    public static Hashtable vector3ToMap(Vector3 v3)
    {
        Hashtable r = new Hashtable();
        r["x"] = (double)(v3.x);
        r["y"] = (double)(v3.y);
        r["z"] = (double)(v3.z);
        return r;
    }

    public static Hashtable vector4ToMap(Vector4 v4)
    {
        Hashtable r = new Hashtable();
        r["x"] = (double)(v4.x);
        r["y"] = (double)(v4.y);
        r["z"] = (double)(v4.z);
        r["w"] = (double)(v4.w);
        return r;
    }

    public static Vector2 mapToVector2(Hashtable map)
    {
        if (map == null)
        {
            return Vector2.zero;
        }
        return new Vector2(
            (float)(MapEx.getDouble(map, "x")),
            (float)(MapEx.getDouble(map, "y")));
    }

    public static Vector3 mapToVector3(Hashtable map)
    {
        if (map == null)
        {
            return Vector3.zero;
        }
        return new Vector3(
            (float)(MapEx.getDouble(map, "x")),
            (float)(MapEx.getDouble(map, "y")),
            (float)(MapEx.getDouble(map, "z")));
    }

    /// <summary>
    /// Filters the path.过滤路径
    /// </summary>
    /// <returns>
    /// The path.
    /// </returns>
    /// <param name='path'>
    /// Path.
    /// </param>
    public static string filterPath(string path)
    {
        string r = path;
        if (path.IndexOf("Assets/") == 0)
        {
            r = StrEx.Mid(path, 7);
        }
        r = r.Replace("\\", "/");
		r = r.Replace("/upgradeResMedium", "/upgradeRes");
        r = r.Replace("/upgradeRes4Publish/", "/upgradeRes/");
        return r;
    }

    public static Hashtable colorToMap(Color color)
    {
        Hashtable r = new Hashtable();
        r["r"] = (double)(color.r);
        r["g"] = (double)(color.g);
        r["b"] = (double)(color.b);
        r["a"] = (double)(color.a);
        return r;
    }

    public static Color mapToColor(Hashtable map)
    {
        Color c = new Color(
            (float)(MapEx.getDouble(map, "r")),
            (float)(MapEx.getDouble(map, "g")),
            (float)(MapEx.getDouble(map, "b")),
            (float)(MapEx.getDouble(map, "a"))
        );
        return c;
    }

    /// <summary>
    /// Files to map.取得文件转成map
    /// </summary>
    /// <returns>
    /// The to map.
    /// </returns>
    /// <param name='path'>
    /// Path.
    /// </param>
    public static Hashtable fileToMap(string path)
    {
        byte[] buffer = File.ReadAllBytes(path);
        if (buffer != null)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            object obj = B2InputStream.readObject(ms);
            if (obj != null)
            {
                return (Hashtable)(obj);
            }
        }
        return null;
    }

    public static object fileToObj(string path)
    {
		if(!File.Exists(path)) {
			return null;
		}
        byte[] buffer = File.ReadAllBytes(path);
        if (buffer != null)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            object obj = B2InputStream.readObject(ms);
            if (obj != null)
            {
                return obj;
            }
        }
        return null;
    }

    public static void fileToMapAsyn4Lua(string path, object callback, object orgs1, object orgs2)
    {
        fileToMapAsyn(path, callback, orgs1, orgs2);
    }

    public static void fileToMapAsyn(string path, object callback, params object[] orgs)
    {
        Callback cb = onGetBytes;
        CLVerManager.self.getNewestRes(path, CLAssetType.bytes, cb, callback, orgs);
    }

    static void onGetBytes(params object[] paras)
    {
        bool flag = false;
        if (paras != null && paras.Length >= 3)
        {
            string path = paras[0].ToString();
            byte[] buffer = (byte[])(paras[1]);
            if (buffer != null)
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                ms.Position = 0;

                object obj = B2InputStream.readObject(ms);
                if (obj != null)
                {
                    Hashtable map = (Hashtable)(obj);
                    object[] objs = (object[])(paras[2]);
                    if (objs != null)
                    {
                        object cb = objs[0];
                        object[] para = null;
                        if (objs.Length > 1)
                        {
                            para = (object[])(objs[1]);
                        }
                        if (cb != null)
                        {

                            if (typeof(LuaFunction) == cb.GetType())
                            {
                                ((LuaFunction)cb).Call(path, map, para);
                            }
                            else if (typeof(Callback) == cb.GetType())
                            {
                                ((Callback)cb)(path, map, para);
                            }
                            flag = true;
                        }
                    }
                }
            }
        }
        if (!flag)
        {
            Debug.LogError("Get file failed==" + (paras.Length > 0 ? paras[0] : ""));
        }
    }

    /// <summary>
    /// Gets the audio clip.取得resource目录的音频文件
    /// </summary>
    /// <returns>
    /// The audio clip.
    /// </returns>
    /// <param name='name'>
    /// Name.
    /// </param>
    public static AudioClip getAudioClip(string name)
    {
        Object obj = Resources.Load(name);
        if (obj != null)
        {
            return (AudioClip)obj;
        }
        return null;
    }

    /// <summary>
    /// Gets the animation.取得resource目录的动画文件
    /// </summary>
    /// <returns>
    /// The animation.
    /// </returns>
    /// <param name='name'>
    /// Name.
    /// </param>
    public static Animation getAnimation(string name)
    {
        Object obj = Resources.Load(name);
        if (obj != null)
        {
            return (Animation)obj;
        }
        return null;
    }
    /// <summary>
    /// Gets the animation curve.创建动画曲线
    /// </summary>
    /// <returns>
    /// The animation curve.
    /// </returns>
    /// <param name='list'>
    /// List.
    /// </param>
    /// <param name='postWrapMode'>
    /// Post wrap mode.
    /// </param>
    /// <param name='preWrapMode'>
    /// Pre wrap mode.
    /// </param>
    public static AnimationCurve getAnimationCurve(ArrayList list, WrapMode postWrapMode, WrapMode preWrapMode)
    {
        if (list == null || list.Count <= 0)
        {
            return null;
        }
        int len = list.Count;
        Keyframe[] ks = new Keyframe[len];
        for (int i = 0; i < len; i++)
        {
            Hashtable m = (Hashtable)list[i];
            float inTangent = (float)MapEx.getDouble(m, "inTangent");
            float outTangent = (float)MapEx.getDouble(m, "outTangent");
            float time = (float)MapEx.getDouble(m, "time");
            float value = (float)MapEx.getDouble(m, "value");
            ks[i] = new Keyframe(time, value, inTangent, outTangent);
        }
        AnimationCurve curve = new AnimationCurve(ks);
        curve.preWrapMode = preWrapMode;
        curve.postWrapMode = postWrapMode;
        return curve;
    }

    public static GameObject getMainAsset(AssetBundle asset)
    {
        if (asset == null)
        {
            return null;
        }
        return (GameObject)(asset.mainAsset);
    }

    public static Texture getMainAssetTexture(AssetBundle asset)
    {
        if (asset == null)
        {
            return null;
        }
        return (Texture)(asset.mainAsset);
    }
    /// <summary>
    /// Loads the assets bunlde.异步取得资源
    /// </summary>
    /// <returns>
    /// The assets bunlde.
    /// </returns>
    /// <param name='buff'>
    /// Buff.
    /// </param>
    /// <param name='assetName'>
    /// Asset name.
    /// </param>
    /// <param name='onGetAssetsBundle'>
    /// On get assets bundle.
    /// </param>
    static Hashtable assetsMap = new Hashtable();

    public static IEnumerator loadAssetsBunlde(byte[] buff, string assetName, object onGetAssetsBundle, object original)
    {
        if (!string.IsNullOrEmpty(assetName))
        {
            if (assetsMap[assetName] != null)
            {
                ((AssetBundle)(assetsMap[assetName])).Unload(true);
                assetsMap[assetName] = null;
            }
        }
        AssetBundleCreateRequest abc = AssetBundle.LoadFromMemoryAsync(buff);
        yield return abc;
        if (abc != null)
        {
            if (!string.IsNullOrEmpty(assetName))
            {
                assetsMap[assetName] = abc.assetBundle;
                GameObject go = null;
#if UNITY_2019
                go = abc.assetBundle.LoadAsset(assetName) as GameObject;
#else
                go = abc.assetBundle.Load(assetName) as GameObject;
#endif

                if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
                {
                    ((LuaFunction)onGetAssetsBundle).Call(assetName, go, original);
                }
                else if (typeof(Callback) == onGetAssetsBundle.GetType())
                {
                    ((Callback)onGetAssetsBundle)(assetName, go, original);
                }
            }
            else
            {
                if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
                {
#if UNITY_2019
                ((LuaFunction)onGetAssetsBundle).Call("", abc.assetBundle.LoadAllAssets(), original);
#else
                    ((LuaFunction)onGetAssetsBundle).Call("", abc.assetBundle.LoadAll(), original);
#endif
                    
                }
                else if (typeof(Callback) == onGetAssetsBundle.GetType())
                {
#if UNITY_2019
                ((Callback)onGetAssetsBundle)("", abc.assetBundle.LoadAllAssets(), original);
#else
                    ((Callback)onGetAssetsBundle)("", abc.assetBundle.LoadAll(), original);
#endif
                    
                }
            }
        }
        else
        {
            if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
            {
                ((LuaFunction)onGetAssetsBundle).Call("", null, original);
            }
            else if (typeof(Callback) == onGetAssetsBundle.GetType())
            {
                ((Callback)onGetAssetsBundle)("", null, original);
            }
        }
        abc = null;
    }

    /// <summary>
    /// Loads the assets bunlde only.返回的assetsbundle
    /// </summary>
    /// <returns>
    /// The assets bunlde only.
    /// </returns>
    /// <param name='buff'>
    /// Buff.
    /// </param>
    /// <param name='assetName'>
    /// Asset name.
    /// </param>
    /// <param name='onGetAssetsBundle'>
    /// On get assets bundle.
    /// </param>
    /// <param name='original'>
    /// Original.
    /// </param>
    public static IEnumerator loadAssetsBunldeOnly(byte[] buff, string assetName, object onGetAssetsBundle, object original)
    {
        AssetBundleCreateRequest abc = AssetBundle.LoadFromMemoryAsync(buff);
        yield return abc;
        if (abc != null)
        {
            if (!string.IsNullOrEmpty(assetName))
            {
                if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
                {
                    ((LuaFunction)onGetAssetsBundle).Call(assetName, abc.assetBundle, original);
                }
                else if (typeof(Callback) == onGetAssetsBundle.GetType())
                {
                    ((Callback)onGetAssetsBundle)(assetName, abc.assetBundle, original);
                }
            }
            else
            {
                if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
                {
                    ((LuaFunction)onGetAssetsBundle).Call("", abc.assetBundle, original);
                }
                else if (typeof(Callback) == onGetAssetsBundle.GetType())
                {
                    ((Callback)onGetAssetsBundle)("", abc.assetBundle, original);
                }
            }
        }
        else
        {
            if (typeof(LuaFunction) == onGetAssetsBundle.GetType())
            {
                ((LuaFunction)onGetAssetsBundle).Call("", null, original);
            }
            else if (typeof(Callback) == onGetAssetsBundle.GetType())
            {
                ((Callback)onGetAssetsBundle)("", null, original);
            }
        }
        abc = null;
    }

    public static void getAssetFromPath(string path, string name, object callback)
    {
        Callback cb = onGetBytes4GetGO;
        CLVerManager.self.getNewestRes(path, CLAssetType.bytes, cb, callback, name);
    }

    static void onGetBytes4GetGO(params object[] paras)
    {
        if (paras != null && paras.Length >= 3)
        {
            //			string path = paras [0].ToString ();
            byte[] buffer = (byte[])(paras[1]);

            object[] objs = (object[])(paras[2]);
            if (objs != null)
            {
                object cb = objs[0];
                string name = (string)(objs[1]);
                CLMain.self.StartCoroutine(loadAssetsBunldeOnly(buffer, name, cb, null));
            }
        }
    }

	/// <summary>
	/// Rotates the towards.转向目标方向(支持提前量)
	/// </summary>
	/// <param name='dir'>
	/// Dir.
	/// </param>
	public static void rotateTowardsForecast( Transform trsf, Transform target, float forecastDis = 0 )
	{
		Vector3 dir = Vector3.zero;
		if(forecastDis > 0) {
			dir = target.position + target.forward*forecastDis - trsf.position;
		} else {
			dir = target.position - trsf.position;
		}
		RotateTowards(trsf, dir);
	}

    /// <summary>
    /// Rotates the towards.转向目标方向(立即)
    /// </summary>
    /// <param name='dir'>
    /// Dir.
    /// </param>
	public static void RotateTowards(Transform trsf, Vector3 from, Vector3 to)
    {
		RotateTowards(trsf, to - from);
    }

	public static void RotateTowards(Transform trsf, Vector3 dir)
    {
        if (dir.magnitude < 0.001f)
        {
            return;
        }
        Quaternion rot = trsf.rotation;
        Quaternion toTarget = Quaternion.LookRotation(dir);

//		Vector3 euler = toTarget.eulerAngles;
//		rot = Quaternion.Euler(euler);

		trsf.rotation = toTarget;
    }

    /// <summary>
    /// Rotates the towards.转向目标方向(有转向过程)
    /// </summary>
    /// <param name='dir'>
    /// Dir.
    /// </param>
    public static void RotateTowards(Transform transform, Vector3 dir, float turningSpeed)
    {
        try
        {
            Quaternion rot = transform.rotation;
            if (dir.magnitude < 0.001f)
            {
                return;
            }
            Quaternion toTarget = Quaternion.LookRotation(dir);

            rot = Quaternion.Slerp(rot, toTarget, turningSpeed * Time.fixedDeltaTime);
            Vector3 euler = rot.eulerAngles;
            euler.z = 0;
            euler.x = 0;
            rot = Quaternion.Euler(euler);

            transform.rotation = rot;
        }
        catch (System.Exception e)
        {
            Debug.Log("name==" + transform.name + "   " + e);
        }
    }

    public static Vector3 getAngle(Transform tr, Vector3 pos2)
    {
		return getAngle(tr.position, pos2);
	}
	public static Vector3 getAngle(Vector3 pos1, Vector3 pos2)
	{
		Vector3 dir = pos2 - pos1;
		return getAngle (dir);
	}
	public static Vector3 getAngle(Vector3 dir)
	{
        if (dir.magnitude < 0.001f)
        {
            return Vector3.zero;
        }
        Quaternion toTarget = Quaternion.LookRotation(dir);

        Vector3 euler = toTarget.eulerAngles;
		return euler;
//        return Quaternion.Euler(euler).eulerAngles;
    }

    /// <summary>
    /// Sets the body mat edit.重新设置一次shader，在editor模式下加载assetsbundle才需要调用这个方法
    /// </summary>
    /// <param name='tr'>
    /// Tr.
    /// </param>
	public static void setBodyMatEdit(Transform tr)
	{
		setBodyMatEdit(tr, null);
	}
	public static void setBodyMatEdit(Transform tr, Shader defaultShader)
    {
        if (tr == null)
        {
            return;
        }
        string shName = "";
        if (tr.GetComponent<Renderer>() != null && tr.GetComponent<Renderer>().material != null)
        {
            shName = tr.GetComponent<Renderer>().material.shader.name;
			if(defaultShader != null) {
				tr.GetComponent<Renderer>().material.shader = defaultShader;
			}else {
	            tr.GetComponent<Renderer>().material.shader = Shader.Find(shName);
			}
        }
        SkinnedMeshRenderer smr = tr.GetComponent<SkinnedMeshRenderer>();
        if (smr != null)
        {
            shName = smr.material.shader.name;
			
			if(defaultShader != null) {
				smr.material.shader = defaultShader;
			}else {
				smr.material.shader = Shader.Find(shName);
			}
        }
        MeshRenderer mr = tr.GetComponent<MeshRenderer>();
        if (mr != null)
        {
			shName = mr.material.shader.name;
			if(defaultShader != null) {
				mr.material.shader = defaultShader;
			}else {
				mr.material.shader = Shader.Find(shName);
			}
            foreach (Material m in mr.materials)
            {
				shName = m.shader.name;
				if(defaultShader != null) {
					m.shader = defaultShader;
				}  else {
					m.shader = Shader.Find(shName);
				}
            }
        }
        TrailRenderer tailRender = tr.GetComponent<TrailRenderer>();
        if (tailRender != null)
        {
			shName = tailRender.material.shader.name;
			if(defaultShader != null) {
				tailRender.material.shader = defaultShader;
			}  else {
				tailRender.material.shader = Shader.Find(shName);
			}
        }
        for (int i = 0; i < tr.childCount; i++)
        {
            setBodyMatEdit(tr.GetChild(i));
        }
    }

    public static float distance(Transform tr1, Transform tr2)
    {
        return Vector3.Distance(tr1.position, tr2.position);
    }

    public static float distance4Loc(Transform tr1, Transform tr2)
    {
        return Vector3.Distance(tr1.localPosition, tr2.localPosition);
    }

    public static float distance(Vector2 v1, Vector2 v2)
    {
        return Vector2.Distance(v1, v2);
    }

    public static float distance(Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(v1, v2);
    }

    public static string MapToString(Hashtable map)
    {
        if (map == null)
            return "map is null";
        StringBuilder outstr = new StringBuilder();
        MapToString(map, outstr);
        return outstr.ToString();
    }

    public static void MapToString(Hashtable map, StringBuilder outstr, int spacecount = 0)
    {
        ICollection keslist = map.Keys;
        IEnumerator e = keslist.GetEnumerator();
        StringBuilder space = new StringBuilder();
        for (int i = 0; i < spacecount; i++)
        {
            space.Append(" ");
        }
        outstr.Append("\n" + space.ToString()).Append("{");
        while (e.MoveNext())
        {
            object key = e.Current;
            object val = map[key];
            if (val == null)
            {
                continue;
            }
            outstr.Append(space.ToString()).Append(key).Append("=");
            if (val.GetType().ToString() == "System.Collections.Hashtable" ||
                val.GetType().ToString() == "Toolkit.NewMap")
            {
                MapToString((Hashtable)val, outstr, spacecount++);
            }
            else if (val.GetType().ToString() == "System.Collections.ArrayList" ||
              val.GetType().ToString() == "Toolkit.NewList")
            {
                ArrayListToString((ArrayList)val, outstr, spacecount++);
            }
            else
            {
                outstr.Append(val).Append("(").Append(val.GetType().ToString()).Append(")").Append("\n");
            }
        }
        outstr.Append("}\n");
        //Debug.Log(outstr.ToString());
    }

    public static string ArrayListToString2(ArrayList list)
    {
        StringBuilder outstr = new StringBuilder();
        ArrayListToString(list, outstr);
        return outstr.ToString();
    }

    public static void ArrayListToString(ArrayList list, StringBuilder outstr, int spacecount = 0)
    {
        StringBuilder space = new StringBuilder();
        for (int i = 0; i < spacecount; i++)
        {
            space.Append(" ");
        }
        outstr.Append("\n" + space.ToString()).Append("[");
        foreach (object item in list)
        {
            if (item == null)
            {
                continue;
            }
            if (item.GetType().ToString() == "System.Collections.Hashtable" ||
                item.GetType().ToString() == "Toolkit.NewMap")
            {
                MapToString((Hashtable)item, outstr, spacecount++);
            }
            else if (item.GetType().ToString() == "System.Collections.ArrayList" ||
              item.GetType().ToString() == "Toolkit.NewList")
            {
                ArrayListToString((ArrayList)item, outstr, spacecount++);
            }
            else
            {
                outstr.Append(item).Append(",");
            }
        }
        outstr.Append("]\n");

        //Debug.Log(outstr.ToString());
    }


    /// <summary>
    /// Draws the grid. 画网格
    /// </summary>
    /// <returns>
    /// The grid.
    /// </returns>
    /// <param name='origin'>
    /// Origin.
    /// </param>
    /// <param name='numRows'>
    /// Number rows.
    /// </param>
    /// <param name='numCols'>
    /// Number cols.
    /// </param>
    /// <param name='cellSize'>
    /// Cell size.
    /// </param>
    /// <param name='color'>
    /// Color.
    /// </param>
    public static ArrayList drawGrid(Vector3 origin, int numRows, int numCols, float cellSize, Color color, Transform gridRoot, float h)
    {
        ArrayList list = new ArrayList();
#if UNITY_EDITOR
        if ((Application.platform == RuntimePlatform.OSXEditor ||
            Application.platform == RuntimePlatform.WindowsEditor) &&
           !Application.isPlaying)
        {
//            SimpleAI.Grid.DebugDraw(origin, numRows, numCols, cellSize, ColorEx.getColor(255, 0, 0));
            return list;
        }
#endif

        float width = (numCols * cellSize);
        float height = (numRows * cellSize);

        // Draw the horizontal grid lines
        for (int i = 0; i < numRows + 1; i++)
        {
            Vector3 startPos = origin + i * cellSize * kZAxis + Vector3.up * h;
            Vector3 endPos = startPos + width * kXAxis;
            LineRenderer lr = drawLine(startPos, endPos, color);
            list.Add(lr);
            lr.transform.parent = gridRoot;
        }

        // Draw the vertial grid lines
        for (int i = 0; i < numCols + 1; i++)
        {
            Vector3 startPos = origin + i * cellSize * kXAxis + Vector3.up * h;
            Vector3 endPos = startPos + height * kZAxis;
            LineRenderer lr = drawLine(startPos, endPos, color);
            list.Add(lr);
            lr.transform.parent = gridRoot;
        }
        return list;
    }

    /// <summary>
    /// Draws the line.//画直线
    /// </summary>
    /// <returns>
    /// The line.
    /// </returns>
    /// <param name='startPos'>
    /// Start position.
    /// </param>
    /// <param name='endPos'>
    /// End position.
    /// </param>
    /// <param name='color'>
    /// Color.
    /// </param>
    public static LineRenderer drawLine(Vector3 startPos, Vector3 endPos, Color color)
    {
        LineRenderer line = Object.Instantiate(Resources.Load("prefab/scene/prefLine", typeof(LineRenderer))) as LineRenderer;
        line.SetColors(color, color);
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
        return line;
    }

    /// <summary>
    /// Clones the res. 实例化Resoureces下的资源
    /// </summary>
    /// <returns>
    /// The res.
    /// </returns>
    /// <param name='path'>
    /// Path.
    /// </param>
    public static GameObject cloneRes(string path)
    {
        try
        {
            return Object.Instantiate(Resources.Load(path)) as GameObject;
        }
        catch (System.Exception e)
        {
            Debug.Log(e + "path==" + path);
            return null;
        }
    }

    public static GameObject cloneRes(GameObject prefab)
    {
        try
        {
            return Object.Instantiate(prefab) as GameObject;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }
    /// <summary>
    /// Loads the res.跟路径加载资源
    /// </summary>
    /// <returns>
    /// The res.
    /// </returns>
    /// <param name='path'>
    /// Path.
    /// </param>
    public static object loadRes(string path)
    {
        try
        {
            return Resources.Load(path, typeof(object)) as object;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }

    /// <summary>
    /// Loads the gobj.从指定路径加载gameObject
    /// </summary>
    /// <returns>
    /// The gobj.
    /// </returns>
    /// <param name='path'>
    /// Path.
    /// </param>
    public static GameObject loadGobj(string path)
    {
        try
        {
            return Resources.Load(path, typeof(GameObject)) as GameObject;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return null;
        }
    }

    public static object[] doLua(LuaScriptMgr lua, string path)
    {
        try
        {
            path = path.Replace("\\", "/");
            path = path.Replace("/upgradeRes4Publish/", "/upgradeRes/");
#if UNITY_EDITOR
            if (SCfg.self.isNotEditorMode)
			{
                if (SCfg.self.isUseEncodedLua)
                {
					return lua.lua.DoBytes(FileEx.getBytesFromCache(path));
                }
                else
                {
					return lua.lua.DoString(FileEx.getTextFromCache(path));
                }
            }
            else
            {
                string tmpPath = path.Replace("/upgradeRes/", "/upgradeResMedium/");
				return lua.lua.DoString(FileEx.getTextFromCache(tmpPath));
            }
#else
			if (SCfg.self.isUseEncodedLua) {
				return lua.lua.DoBytes (FileEx.getBytesFromCache (path));
			} else {
				return lua.lua.DoString (FileEx.getTextFromCache (path));
			}
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogError(path + "," + e);
			return null;
        }
    }

    public static Vector2 addVector2(Vector2 v1, Vector2 v2)
    {
        return v1 + v2;
    }

    public static Vector3 addVector3(Vector3 v1, Vector3 v2)
    {
        return v1 + v2;
    }

    public static Vector2 cutVector2(Vector2 v1, Vector2 v2)
    {
        return v1 - v2;
    }

    public static Vector3 cutVector3(Vector3 v1, Vector3 v2)
    {
        return v1 - v2;
    }

    static string preFunctionName = "";
    static int fCount = 0;

    public static string sign(string functionName, string key)
    {
        lock (preFunctionName)
        {
            long nowTime = DateEx.nowMS;
            if (preFunctionName == functionName)
            {		//相同接口时，很可能取出来的时候是一样的
                fCount++;
                nowTime += fCount;
            }
            else
            {
                fCount = 0;
            }
            preFunctionName = functionName;
            return EnAndDecryption.encoder(DateEx.nowServerTime.ToString(), key);
        }
    }

    public static Transform getChild(Transform root, params object[] args)
    {
        Transform tr = root;
        if (root == null || args == null)
            return null;
        int count = args.Length;
        int i = 0;
        while (true)
        {
            if (i >= count)
                break;
            if (tr == null)
            {
                Debug.LogError(args[i]);
                break;
            }
            tr = tr.Find(args[i].ToString());
            i = i + 1;
        }
        return tr;
    }

    public static void saveData(string file, Hashtable map)
    {
        string path = chgToSKCard(file);
        try
        {
            MemoryStream ms = new MemoryStream();
            B2OutputStream.writeObject(ms, map);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllBytes(path, ms.ToArray());
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    public static byte[] getDataByte(string file)
    {
        string path = chgToSKCard(file);
        try
        {
            if (File.Exists(path))
            {
                byte[] buffer = File.ReadAllBytes(path);
                if (buffer.Length <= 0)
                {
                    return new byte[0];
                }
                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                ms.Position = 0;
                return ByteEx.readFully(ms);
            }
            else
            {
                return new byte[0];
            }
        }
        catch (System.Exception e)
        {
            return new byte[0];
        }
    }

    static public byte[] getDataByteByMap(Hashtable map)
    {
        if (MapEx.isNullOrEmpty(map))
            return new byte[0];
        MemoryStream ms = new MemoryStream();
        B2OutputStream.writeMap(ms, map);
        ms.Position = 0;
        return ByteEx.readFully(ms);
    }

    public static Hashtable getData(string file)
    {
        string path = chgToSKCard(file);
        try
        {
            if (File.Exists(path))
            {
                byte[] buffer = File.ReadAllBytes(path);
                return getDataByBts(buffer);
            }
            else
            {
                return new Hashtable();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            return new Hashtable();
        }
    }

    public static Hashtable getDataByBts(byte[] buffer)
    {
        if (buffer == null || buffer.Length == 0)
        {
            return new Hashtable();
        }
        try
        {
            if (buffer.Length <= 0)
            {
                return new Hashtable();
            }
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            object obj = B2InputStream.readObject(ms);
            if (obj != null)
            {
                return ((Hashtable)obj);
            }
            else
            {
                return new Hashtable();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            return new Hashtable();
        }
    }

    public static string chgToSKCard(string path)
    {
#if UNITY_ANDROID
		if(Directory.Exists("/sdcard/")) {
			path = path.Replace(PathCfg.persistentDataPath + "/",  "/sdcard/");
		}
#endif
        return path;
    }

    static public Hashtable getMapFnamesInFolder(string pathFolder, int saveNum)
    {
        if (saveNum < 1)
            saveNum = 1;

        string path = chgToSKCard(pathFolder);
        Hashtable result = new Hashtable();
        if (Directory.Exists(path))
        {
            string[] fnames = Directory.GetFiles(path);
            List<string> delList = new List<string>();

            foreach (string item in fnames)
            {
                string nm = Path.GetFileName(item);
                try
                {
                    int ord = int.Parse(nm);
                    result.Add(ord, item);
                }
                catch (System.Exception)
                {
                    delList.Add(item);
                }
            }

            
            ArrayList list = MapEx.keys2List(result);
            int lens = list.Count;
            list.Sort();
            int diff = lens - saveNum;
            for (int i = 0; i < lens; i++)
            {
                int key = (int)(list[i]);
                if (i < diff)
                {
                    string item = (string)(result[key]);
                    delList.Add(item);
                    result.Remove(key);
                }
            }
            foreach (string item in delList)
            {
                if (File.Exists(item))
                    File.Delete(item);
            }
        }
        else
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        return result;
    }

    /***  序号名字 **/
    static public int getOrderInFolder(string pathFolder,int saveNum)
    {
        Hashtable map = getMapFnamesInFolder(pathFolder, saveNum);
        int result = 0;
        if (MapEx.isNullOrEmpty(map))
            return result;

        ArrayList list = MapEx.keys2List(map);
        foreach (object item in list)
        {
            int v = (int)item;
            if (result < v)
                result = v;
        }
        return result;
    }
	
	///   <summary>
	///   给一个字符串进行MD5加密
	///   </summary>
	///   <param   name="strText">待加密字符串</param>
	///   <returns>加密后的字符串</returns>
	public static string MD5Encrypt (string strText)
	{   
		byte[] bytes = Encoding.UTF8.GetBytes (strText);    //tbPass为输入密码的文本框
		return MD5Encrypt (bytes);
	}
	
	public static string MD5Encrypt (byte[] bytes)
	{
		MD5 md5 = new MD5CryptoServiceProvider ();
		byte[] output = md5.ComputeHash (bytes);
		return System.BitConverter.ToString (output).Replace ("-", "").ToLower ();  //tbMd5pass为输出加密文本
	}

	public static bool netIsActived() {
        bool ret = true;
#if UNITY_ANDROID && !UNITY_EDITOR
		AndroidJavaClass jc = new AndroidJavaClass("com.x3gu.tools.Tools4Net");
        ret =  jc.CallStatic<bool>("isConnectNet");
#endif
        if(Application.internetReachability == NetworkReachability.NotReachable) {
            ret = false;
        }
        return ret;
	}

    /// <summary>
    /// Gets the state of the net.
    /// </summary>
    /// <returns>The net state.
    ///     None 无网络
    ///     WiFi
    ///     2G
    ///     3G
    ///     4G
    ///     Unknown
    /// </returns>
    public static string getNetState() {
        string ret = "Unkown";
        #if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass jc = new AndroidJavaClass("com.x3gu.tools.Tools4Net");
        ret =  jc.CallStatic<string>("getCurrentNetworkType");
        #endif
        return ret;
    }

    public static string urlAddTimes(string url) {
        if(url.StartsWith("http://")) {
            if(url.Contains("?")) {
                url = PStr.b ().a(url).a ("&t_sign_flag___=").a (DateEx.nowMS).e ();
            } else {
                url = PStr.b ().a(url).a ("?t_sign_flag___=").a (DateEx.nowMS).e();
            }
#if CHL_NONE
            Debug.LogWarning(url);
#endif
        }
        return url;
    }

    /// <summary>
    /// Gets the sing in code android.取得签名值
    /// </summary>
    /// <returns>The sing in code android.</returns>
    public static  int getSingInCodeAndroid() {
        try {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaClass jcPackageManager = new AndroidJavaClass("android.content.pm.PackageManager");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject joPackageManager = jo.Call<AndroidJavaObject>("getPackageManager");
        string joPackageName = jo.Call<string>("getPackageName");
        int GET_SIGNATURES = jcPackageManager.GetStatic<int>("GET_SIGNATURES");
        AndroidJavaObject packageInfo = joPackageManager.Call<AndroidJavaObject>("getPackageInfo", joPackageName, GET_SIGNATURES);
        AndroidJavaObject[] signs = packageInfo.Get<AndroidJavaObject[]>("signatures");
        if(signs.Length > 0) {
            AndroidJavaObject sign = signs[0];
            return sign.Call<int>("hashCode");
        }
//        PackageInfo packageInfo = _self.getPackageManager().getPackageInfo(_self.getPackageName(), PackageManager.GET_SIGNATURES);
//        Signature[] signs = packageInfo.signatures;
//        Signature sign = signs[0];
//        Log.d("CommonTool","sign:    " + sign);
//        return sign.hashCode();

#endif
        } catch(System.Exception e) {
            Debug.LogError(e);
        }
        return 0;
    }

	public static LayerMask getLayer(string layerName) {
		string[] list = layerName.Split (',');
		LayerMask ret = 0;
		for(int i=0; i < list.Length; i++) {
			ret |= (1<< LayerMask.NameToLayer(list[i]));
		}
		return ret;
	}

	public static RaycastHit getRaycastHitInfor(Camera camera, Vector3 inPos, LayerMask layer) {
		RaycastHit hitInfor = new RaycastHit();
		if (camera == null)
			return hitInfor;
		Ray ray = camera.ScreenPointToRay (inPos);
		if(Physics.Raycast(ray, out hitInfor, 1000, layer.value)) {
			return hitInfor;
		} else {
			return hitInfor;
		}
	}

	public static void doCallback(object callback, object paras) {
		if(callback == null) return;
		if(callback is LuaFunction) {
			((LuaFunction)callback).Call(paras);
		} else if(callback is Callback) {
			((Callback)callback)(paras);
		}
	}

    public static bool isApplePlatform
    {
        get{
            return Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXEditor ||
                    Application.platform == RuntimePlatform.OSXPlayer;
        }
    }
}
