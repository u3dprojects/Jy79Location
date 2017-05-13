using UnityEngine;
using System.Collections;
using Toolkit;

/// <summary>
/// S role avata.纸娃娃
/// </summary>
using System.Collections.Generic;


[RequireComponent(typeof(Animator))]
public class SRoleAvata : MonoBehaviour
{
	// 需要用到的骨骼关节点

	[SerializeField]
	public List<string> bonesNames = new List<string> ();
	[SerializeField]
	public List<Transform> bonesList = new List<Transform> ();
	Hashtable _bonesMap;
	public Hashtable bonesMap {
		get {
			if(_bonesMap == null) {
				_bonesMap = new Hashtable();
				for(int i = 0; i < bonesNames.Count; i++) {
					_bonesMap[bonesNames[i]] = bonesList[i];
				}
			}
			return _bonesMap;
		}
	}

	public Transform getBoneByName(string bname) {
		return (Transform)(bonesMap [bname]);
	}

	Animator _animator;
	public Animator animator{
		get {
			if(_animator == null) {
				_animator = GetComponent<Animator>();
			}
			return _animator;
		}
	}

	[SerializeField]
	public List<string> bodyPartNames = new List<string>();
	[SerializeField]
	public List<CLBodyPart> bodyParts = new List<CLBodyPart>();
	Hashtable mapIndex = new Hashtable();
	bool isInited = false;

	public void setMapindex() {
		for (int i=0; i<bodyPartNames.Count; i++) {
			mapIndex [bodyPartNames [i]] = i;
		}
	}

	/// <summary>
	/// Switch2xx the specified partName and cellName.变装
	/// </summary>
	/// <param name="partName">Part name.</param>身体部位
	/// <param name="cellName">Cell name.</param>服装、表情、装备等的名称
	public void switch2xx (string partName, string cellName)
	{
		if (!isInited) {
			isInited = true;
			setMapindex();
		}
		try {
			int index = MapEx.getInt (mapIndex, partName);
			CLBodyPart part = bodyParts [index];
			if (part == null)
				return;
			part.switchByName (cellName, animator);
		} catch (System.Exception e) {
			Debug.LogError (e);
		}
	}
}

[System.Serializable]
public class CLBodyPart
{
	public string partName = ""; //身体部位
	public CLSwitchType switchType = CLSwitchType.showOrHide;
	public List<string> cellNames = new List<string>();	//身体部位中各个部件的名字
	public Renderer render;
//    [System.NonSerialized]
//    public List<Material> materials = null;
    public List<string> materialNames = new List<string>();
	public List<GameObject> partObjs = new List<GameObject>();
	public bool needSwitchController = false;
	public List<RuntimeAnimatorController> animatorControllers = new List<RuntimeAnimatorController>();
	public Hashtable mapIndex = new Hashtable();
	[System.NonSerialized]
	bool isInited = false;

	public void init ()
	{
		if (!isInited) {
			isInited = true;
			for (int i=0; i<cellNames.Count; i++) {
				mapIndex [cellNames [i]] = i;
			}
		}
	}

	public void switchByName (string cellName, Animator animator)
	{
		if (!isInited) {
			init();
		}
		int index = MapEx.getInt(mapIndex, cellName);
		if(switchType == CLSwitchType.showOrHide) {
			for(int i=0; i < partObjs.Count; i++) {
				if(i == index) {
					NGUITools.SetActive(partObjs[i], true);
				} else {
					NGUITools.SetActive(partObjs[i], false);
				}
			}
		} else if(switchType == CLSwitchType.switchShader) {
//			render.material = materials[index];
            if(render.material != null) {
                string mName = render.material.name;
                mName = mName.Replace(" (Instance)", "");
                CLMaterialPool.returnMat(mName);
                render.material = null;
            }
            setMat(render, materialNames[index]);
		}

		if(needSwitchController) {
			animator.runtimeAnimatorController =  animatorControllers[index];
		}
	}

    public void setMat(Renderer render, string name) {
		if(!CLMaterialPool.havePrefab(name)) {
            ArrayList list = new ArrayList();
            list.Add(render);
            list.Add(name);
			CLMaterialPool.setPrefab(name, (Callback)onSetPrefab, list);
            return;
        }

		Material mat = CLMaterialPool.borrowMat(name);
        render.material = mat;
    }

    void onSetPrefab(params object[] args) {
        Material mat = (Material)(args[0]);
        if(mat != null) {
            ArrayList list = (ArrayList)(args[1]);
            Renderer render = (Renderer)(list[0]);
            string name = list[1].ToString();
            setMat(render, name);
        }
    }
}

public enum CLSwitchType
{
	showOrHide,
	switchShader,
}
