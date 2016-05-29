﻿using UnityEngine;
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
        List<GameObject> currentBracket = new List<GameObject>();
        for (int i = 0; i < nodes.Count; i++) {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            go.transform.SetParent(this.gameObject.transform);
            
            Bracket b = go.AddComponent<Bracket>();
            b.number = nodeStart + i;
            Vector3 pos = new Vector3(startX,-yDist * i,0);
            go.transform.localPosition = pos;
            go.name = b.ToString();
            this.allBaseBrackets.Add(go);
            currentBracket.Add(go);
        }
        
        List<GameObject> expanded = currentBracket;
        int counter = 0;
        while (expanded.Count > 1) 
        {
          expanded = ExpandBracket(expanded,xDist);
          counter++;
        }
        
    }
    
    public List<GameObject> ExpandBracket(List<GameObject> gos, float xDist) {
        List<GameObject> result = new List<GameObject>();
        for (int i = 0; i < gos.Count; i += 2) {
            int j = i+1;
            GameObject newNode = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Bracket b = newNode.AddComponent<Bracket>();
            Vector3 pos = new Vector3();
            pos.x = gos[i].transform.localPosition.x + xDist;
            pos.y = (gos[i].transform.localPosition.y + gos[j].transform.localPosition.y) / 2;
            newNode.transform.localPosition = pos;
            gos[i].GetComponent<Bracket>().next = b;
            gos[j].GetComponent<Bracket>().next = b;
            
            newNode.transform.SetParent(this.gameObject.transform);
            //:TODO: draw bracket in.            
            result.Add(newNode);
        }
        return result;
    }
        
    
    
    
}
