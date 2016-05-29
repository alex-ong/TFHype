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
    
    public GameObject line;
    public float lineThickness = 0.1f;
    public Transform bracketLinesParent;
    
    public AnimationCurve xDie;
    public AnimationCurve yDie;
    public FinalAnimation fa;
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
        if (LeftRightSplit) {           
            List<GameObject> left = new List<GameObject>();
            for (int i = 0; i < nodes.Count/2; i++) {
                left.Add(nodes[i]);
            }
            List<GameObject> right = new List<GameObject>();
            for (int i = nodes.Count/2; i < nodes.Count; i++) {
                right.Add(nodes[i]);
            }
            GameObject LeftWinner = MakeBracket(left,xDistance,yDistance, 0, 0);
            GameObject RightWinner = MakeBracket(right,-xDistance,yDistance, (Mathf.Log(nodes.Count/2,2)+1) * xDistance * 2, nodes.Count/2);
            
            List<GameObject> finalBranch = new List<GameObject>();
            finalBranch.Add(LeftWinner);
            finalBranch.Add(RightWinner);
            Bracket leftb = LeftWinner.GetComponent<Bracket>();
            Bracket rightb = RightWinner.GetComponent<Bracket>();
            leftb.wait = rightb;
            rightb.wait = leftb;
            List<GameObject> final = ExpandBracket(finalBranch,xDistance);
            final[0].GetComponent<Bracket>().fa = this.fa;
    } else {
            
        }
        bam.StartChain(nodes,this.allBaseBrackets);
    }
    
    
    //make a one sided bracket. Returns winner
    public GameObject MakeBracket(List<GameObject> nodes, float xDist, float yDist, float startX, int nodeStart)     
    {        
        List<GameObject> currentBracket = new List<GameObject>();
        for (int i = 0; i < nodes.Count; i++) {
            GameObject go = new GameObject();
            
            go.transform.SetParent(this.gameObject.transform);
            
            Bracket b = go.AddComponent<Bracket>();
            b.loseCurveX = this.xDie;
            b.loseCurveY = this.yDie;
            b.number = nodeStart + i;
            b.singleContestant = true;
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
        return expanded[0];
        
    }
    
    public List<GameObject> ExpandBracket(List<GameObject> gos, float xDist) {
        List<GameObject> result = new List<GameObject>();
        for (int i = 0; i < gos.Count; i += 2) {
            int j = i+1;
            //GameObject newNode = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject newNode = new GameObject();
            Bracket b = newNode.AddComponent<Bracket>();
            b.loseCurveX = this.xDie;
            b.loseCurveY = this.yDie;
            Vector3 pos = new Vector3();
            pos.x = gos[i].transform.localPosition.x + xDist;
            pos.y = (gos[i].transform.localPosition.y + gos[j].transform.localPosition.y) / 2;
            newNode.transform.localPosition = pos;
            gos[i].GetComponent<Bracket>().next = b;
            gos[j].GetComponent<Bracket>().next = b;
            b.level = gos[i].GetComponent<Bracket>().level + 1;
            
            newNode.transform.SetParent(this.gameObject.transform);
            //:TODO: draw bracket in. 
            GameObject horLine1 = GameObject.Instantiate(this.line); horLine1.SetActive(true);
            GameObject horLine2 = GameObject.Instantiate(this.line); horLine2.SetActive(true);
            Vector3 horPos1 =  new Vector3((gos[i].transform.position.x + newNode.transform.position.x) / 2.0f,
                                           gos[i].transform.position.y, 0.01f);
            Vector3 horPos2 = new Vector3((gos[j].transform.position.x + newNode.transform.position.x) / 2.0f,
                                           gos[j].transform.position.y, 0.01f);
            Vector3 horScale = new Vector3(Mathf.Abs(gos[i].transform.position.x - newNode.transform.position.x),
                                            lineThickness, 1.0f);
                       
            horLine1.transform.position = horPos1;                                             
            horLine2.transform.position = horPos2;
            horLine1.transform.localScale = horScale;
            horLine2.transform.localScale = horScale;
            horLine1.transform.SetParent(this.bracketLinesParent);
            horLine2.transform.SetParent(this.bracketLinesParent);
            
            GameObject vertLine = GameObject.Instantiate(this.line); vertLine.SetActive(true);
            Vector3 vertPos =  newNode.transform.position + new Vector3(0.0f,0f,0.01f);
            Vector3 vertScale = new Vector3(lineThickness, Mathf.Abs(gos[i].transform.position.y - gos[j].transform.position.y)+lineThickness, 1.0f);
            vertLine.transform.position = vertPos;
            vertLine.transform.localScale = vertScale;
            vertLine.transform.SetParent(this.bracketLinesParent);
            
            result.Add(newNode);
        }
        return result;
    }
        
    
    
    
}
