using UnityEngine;
using System.Collections;

public class ScaleOverTime : MonoBehaviour {
    public AnimationCurve ac;
    public float timer;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.timer += Time.deltaTime;
        Vector3 s = Vector3.one * ac.Evaluate(timer);
        this.transform.localScale = s;
	}
}
