using UnityEngine;
using System.Collections;

public class StartTime : MonoBehaviour {
    public float finalTimeScale = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = finalTimeScale;
        }
	}
}
