using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class BracketMaker : MonoBehaviour {
    public float xDistance = 1;
    public float yDistance = 1;
    
    bool LeftRightSplit = true;
    
    private float startTimer = 1.0f;
    private float timer = 0.0f;
    public MakeQuads mk;
    public List<GameObject> allBaseBrackets = new List<GameObject>();
    public BracketAnimatorMaster bam;
    
  // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    timer += Time.deltaTime;
        if (timer > startTimer && allBaseBrackets.Count == 0) {
            this.MakeBracket(mk.allQuads);
        }
    }
    
    
    
    
    public void MakeBracket(List<GameObject> nodes)
    {        
        Debug.Log(nodes.Count);
        if (LeftRightSplit) {           
            List<GameObject> left = new List<GameObject>();
            for (int i = 0; i < nodes.Count/2; i++) {
                left.Add(nodes[i]);
            }
            List<GameObject> right = new List<GameObject>();
            for (int i = nodes.Count/2; i < nodes.Count; i++) {
                right.Add(nodes[i]);
            }
            MakeBracket(left,xDistance,yDistance, 0, 0);
            MakeBracket(right,-xDistance,yDistance, Mathf.Log(nodes.Count/2,2) * xDistance * 2, nodes.Count/2);
        } else {
            
        }
        bam.StartChain(nodes,this.allBaseBrackets);
    }
    
    
    //make a one sided bracket.
    public void MakeBracket(List<GameObject> nodes, float xDist, float yDist, float startX, int nodeStart)     
    {
        for (int i = 0; i < nodes.Count; i++) {
            GameObject go = new GameObject();
            
            go.transform.SetParent(this.gameObject.transform);
            
            Bracket b = go.AddComponent<Bracket>();
            b.number = nodeStart + i;
            Vector3 pos = new Vector3(startX,-yDist * i,0);
            go.transform.localPosition = pos;
            this.allBaseBrackets.Add(go);
        }
    }
        
    
    
    
}
