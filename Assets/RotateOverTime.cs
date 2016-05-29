using UnityEngine;
using System.Collections;

public class RotateOverTime : MonoBehaviour {
    public float speed = 180f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    this.transform.Rotate(Vector3.forward,speed * Time.deltaTime);
	}
}
