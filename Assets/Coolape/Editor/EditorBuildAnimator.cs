using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System;

#if UNITY_4_6
using UnityEditorInternal;
#elif UNITY_5 || UNITY_2019
using UnityEditor.Animations;
#endif

/// <summary>
/// 动态创建人物模型动画控制器
/// Anchor : Canyon
/// Date   : 2016-02-26 16:45
/// UVesion: UNITY_4_6,UNITY_5
/// Desc   : 根据模型FBX的动画类型为Generic，创建一个动画控制器AnimatorControl
///  和美术商量好动作Clip的取名规则，制定代码的状态机子值相对应。
/// </summary>
public class EditorBuildAnimator : Editor
{
    //controller 名称
    private static string nm4Ani = "RoleAni_test.controller";
    
    // 条件名字
    private static string nmParameter = "Action";

    /// <summary>
    /// 为模型FBX的动画类型:Generic创建动画控制器
    /// </summary>
    [MenuItem("Canyon/CreatAni4Generic")]
    static void CreateAnimatorController()
    {
        List<UnityEngine.Object> listFBX = new List<UnityEngine.Object>();
        string _path = "";
        foreach (UnityEngine.Object obj in Selection.objects)
        {
            _path = AssetDatabase.GetAssetPath(obj);
            _path = _path.ToUpper();
            if (_path.LastIndexOf(".FBX") != -1)
            {
                listFBX.Add(obj);
            }
        }

        if (listFBX.Count <= 0)
        {
            Debug.LogError("请选择人物模型文件FBX");
            return;
        }

        foreach (UnityEngine.Object obj in listFBX)
        {
            createOne(obj);
        }
    }
#if UNITY_4_6
    static private void createOne(UnityEngine.Object objFBX)
    {
        if (objFBX == null)
        {
            Debug.LogError("FBX为空");
            return;
        }

        List<AnimationClip> _listClip = new List<AnimationClip>();

        string _path = AssetDatabase.GetAssetPath(objFBX);
        UnityEngine.Object[] objects = AssetDatabase.LoadAllAssetsAtPath(_path);
        for (int i = 0; i < objects.Length; i++)
        {
            UnityEngine.Object _obj = objects[i];

            if (_obj.GetType() == typeof(AnimationClip) && !_obj.name.Contains("Take 001"))
            {
                _listClip.Add((AnimationClip)_obj);
            }
        }

        if (_listClip.Count <= 0)
        {
            Debug.LogError("该FBX中不包含动画!");
            return;
        }

        string _fold = Path.GetDirectoryName(_path);

        string _path4Ani = _fold + Path.DirectorySeparatorChar + nm4Ani;

        if (File.Exists(_path4Ani))
        {
            File.Delete(_path4Ani);
        }


        //创建animationController文件，保存在Assets路径下
        AnimatorController aniController = AnimatorController.CreateAnimatorControllerAtPath(_path4Ani);

        // 创建参数 AnimatorControllerParameter parAction = 
        aniController.AddParameter(nmParameter, AnimatorControllerParameterType.Int);

        //得到它的Layer， 默认layer为base 你可以去拓展
        AnimatorControllerLayer layer = aniController.GetLayer(0);

        StateMachine machine = layer.stateMachine;

        float degVal = 270;
        float degDiff = 25;

        Transition _transition = null;
        State state = createOneState(machine, "None", 270, ref _transition);

        createOrSetCondition(_transition, 0, nmParameter, TransitionConditionMode.NotEqual, 0);

        // 设置默认的状态机
        machine.defaultState = state;

        int index = 0;

        foreach (AnimationClip clip in _listClip)
        {
            degVal = degVal - degDiff;
            state = createOneState(machine, clip.name, degVal, ref _transition, clip);
            createOrSetCondition(_transition, 0, nmParameter, TransitionConditionMode.Equals, ++index);
        }
    }

    // 添加状态机
    static private State createOneState(StateMachine machine, string nm4State, float degVal, ref Transition transition, AnimationClip clip = null)
    {
        Vector3 posAny = machine.anyStatePosition;

        float radius = Mathf.Sqrt(Mathf.Pow(300, 2) + Mathf.Pow(220, 2));
        // 设置位置
		float x = Mathf.Cos(Mathf.Deg2Rad * degVal) * radius;
        float y = Mathf.Sin(Mathf.Deg2Rad * degVal) * radius;
        Vector3 pos = new Vector3(posAny.x + x, posAny.y + y, posAny.z);
		
		// 创建一个默认的None状态机子State
        State state = machine.AddState(nm4State);
        state.position = pos;
        
        // Debug.LogError("== x ==" + x + ",== y ==" + y + "raidus = " + radius);

        if (clip != null)
        {
            state.SetAnimationClip(clip);
        }

        // 添加桥
        transition = machine.AddAnyStateTransition(state);

        transition.duration = 0f;

        return state;
    }

    // 创建设置条件
    static private void createOrSetCondition(Transition transition, int index, string nm4Par, TransitionConditionMode mode, float val)
    {
        int count = transition.conditionCount;
        int dif = count - 1 - index;
        if (dif < 0)
        {
            for (int i = 0; i < dif; i--)
            {
                // 添加 条件
                transition.AddCondition();
            }
        }

        // 取得条件并设置值
        AnimatorCondition codition = transition.GetCondition(index);
        codition.parameter = nm4Par;
        codition.mode = mode;
        codition.threshold = val;
    }
#elif UNITY_2019
  static private void createOne(UnityEngine.Object objFBX)
    {
        if (objFBX == null)
        {
            Debug.LogError("FBX为空");
            return;
        }

        List<AnimationClip> _listClip = new List<AnimationClip>();

        string _path = AssetDatabase.GetAssetPath(objFBX);
        UnityEngine.Object[] objects = AssetDatabase.LoadAllAssetsAtPath(_path);
        for (int i = 0; i < objects.Length; i++)
        {
            UnityEngine.Object _obj = objects[i];

            if (_obj.GetType() == typeof(AnimationClip) && !_obj.name.Contains("Take 001"))
            {
                _listClip.Add((AnimationClip)_obj);
            }
        }

        if (_listClip.Count <= 0)
        {
            Debug.LogError("该FBX中不包含动画!");
            return;
        }

        string _fold = Path.GetDirectoryName(_path);

        string _path4Ani = _fold + Path.DirectorySeparatorChar + nm4Ani;

        if (File.Exists(_path4Ani))
        {
            File.Delete(_path4Ani);
        }


        //创建animationController文件，保存在Assets路径下
        AnimatorController aniController = AnimatorController.CreateAnimatorControllerAtPath(_path4Ani);

        // 创建参数 AnimatorControllerParameter parAction = 
        aniController.AddParameter(nmParameter, AnimatorControllerParameterType.Int);

        //得到它的Layer， 默认layer为base 你可以去拓展
        AnimatorControllerLayer layer = aniController.layers[0];
        AnimatorStateMachine machine = layer.stateMachine;

        float degVal = 270;
        float degDiff = 25;

        AnimatorStateTransition _transition = null;
        AnimatorState state = createOneState(machine, "None", 270, ref _transition);

        createOrSetCondition(_transition, 0, nmParameter, AnimatorConditionMode.NotEqual, 0);

        // 设置默认的状态机
        machine.defaultState = state;

        int index = 0;

        foreach (AnimationClip clip in _listClip)
        {
            degVal = degVal - degDiff;
            state = createOneState(machine, clip.name, degVal, ref _transition, clip);
            createOrSetCondition(_transition, 0, nmParameter, AnimatorConditionMode.Equals, ++index);
        }
    }

  // 添加状态机
  static private AnimatorState createOneState(AnimatorStateMachine machine, string nm4State, float degVal, ref AnimatorStateTransition transition, AnimationClip clip = null)
  {
      Vector3 posAny = machine.anyStatePosition;

      float radius = Mathf.Sqrt(Mathf.Pow(300, 2) + Mathf.Pow(220, 2));
      // 设置位置
      float x = Mathf.Cos(Mathf.Deg2Rad * degVal) * radius;
      float y = Mathf.Sin(Mathf.Deg2Rad * degVal) * radius;
      Vector3 pos = new Vector3(posAny.x + x, posAny.y + y, posAny.z);

      // 创建一个默认的None状态机子State
      AnimatorState state = machine.AddState(nm4State,pos);

      // Debug.LogError("== x ==" + x + ",== y ==" + y + "raidus = " + radius);

      if (clip != null)
      {
          state.motion = clip;
      }

      // 添加桥
      transition = machine.AddAnyStateTransition(state);

      transition.duration = 0f;

      return state;
  }

  // 创建设置条件
  static private void createOrSetCondition(AnimatorStateTransition transition, int index, string nm4Par, AnimatorConditionMode mode, float val)
  {
      int count = transition.conditions.Length;
      int dif = count - 1 - index;
      if (dif < 0)
      {
          // 添加 条件
          transition.AddCondition(mode, val, nm4Par);
      }
      else
      {
          // 取得条件并设置值
          AnimatorCondition codition = transition.conditions[index];
          codition.parameter = nm4Par;
          codition.mode = mode;
          codition.threshold = val;
      }
  }
#endif
}
