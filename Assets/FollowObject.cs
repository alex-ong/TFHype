using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {
    public Transform t;
    public Vector3 offset = new Vector3(7.5f,-4f,-7.77f);
  public AnimationCurve xDistance;
  public AnimationCurve zDistance;
    
  float timer = 0.0f;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	    if (t != null) {
            timer += Time.deltaTime;            
            this.offset.z = zDistance.Evaluate(timer);
            this.offset.x = xDistance.Evaluate(timer);
            this.transform.position = offset + t.position;
        }
	}
}
