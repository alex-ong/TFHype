using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour {
    private GameObject targetBracket;
    private float startTimer;
    private float endTimer;
    private AnimationCurve xCurve;
    private AnimationCurve yCurve;
  
    public Vector3 startPos;
    
    void Awake() {
        Vector3 startPos = this.gameObject.transform.position;
    }
	// Use this for initialization
	void Start () {
	    
	}
	public void Setup(float startTimer, float endTimer, GameObject target, AnimationCurve x, AnimationCurve y) 
    {
        this.targetBracket = target;
        this.startTimer = startTimer;
        this.endTimer = endTimer;
        this.xCurve = x;
        this.yCurve = y;
        this.startPos = this.gameObject.transform.position;
    }
    
      public static float Lerp( float a, float b, float t ){
        return t*b + (1-t)*a;
      }
      
    
    
	// Update is called once per frame
	void Update () {
        startTimer = Mathf.MoveTowards(startTimer,endTimer,Time.deltaTime);
        float perc = Mathf.InverseLerp(0.0f,endTimer, startTimer);
        
        Vector3 pos = new Vector3();
        pos.x = Lerp(startPos.x,targetBracket.transform.position.x, xCurve.Evaluate(perc));
        pos.y = Lerp(startPos.y,targetBracket.transform.position.y, yCurve.Evaluate(perc));
        this.transform.position = pos;
        if (perc > 1.0f) {
            
            targetBracket.GetComponent<Bracket>().RegisterContestant(this.gameObject);            
            //destroy this animation.
            Destroy(this);
        }
        
    }
}
