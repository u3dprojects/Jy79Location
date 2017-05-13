using UnityEngine;
using System.Collections;

public class CLMainSplash : MonoBehaviour
{
    public Renderer progressBar;
    public int maxProgress = 12;
    AsyncOperation ao = null;
    Vector3 pos = Vector3.zero;
    Vector3 scale = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        scale = new Vector3 (0, 1, 0.12f);
        pos = progressBar.transform.localPosition;
        progressBar.transform.localScale = scale;
        ao = Application.LoadLevelAsync ("Main");

    }
    
    // Update is called once per frame
    void Update ()
    {
        if (ao != null) {
            scale.x = ao.progress * maxProgress;

            pos.x = (-(maxProgress - scale.x) / 2.0f) * 10.0f;
            progressBar.transform.localScale = scale;
            progressBar.transform.localPosition = pos;
        }
    }
}
