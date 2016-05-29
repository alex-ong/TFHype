using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LoserStack : MonoBehaviour {
    public MakeQuads makeQuads;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void MakeLoserStack(GameObject winner, GameObject loser) 
    {
        List<GameObject> allQuads = makeQuads.allQuads;
        allQuads.Remove(winner);
        allQuads.Remove(loser);
        
        foreach(GameObject go in allQuads) 
        {
            Destroy(go.GetComponent<FadeAlpha>());
            go.GetComponent<Renderer>().material.color = Color.white;
            go.transform.SetParent(this.gameObject.transform);
            float y = Random.Range(-8f,0f);
            float x = Random.Range(-y*2,y*2);
            go.transform.localPosition = new Vector3(x,y,Random.Range(0,0.3f));
            go.transform.Rotate(Vector3.forward,Random.Range(0f,360f));
            Destroy(go.GetComponent<MoveAnimation>());
            Destroy(go.GetComponent<ScaleOverTime>());
            Destroy(go.GetComponent<RotateOverTime>());
        }
  }
}
