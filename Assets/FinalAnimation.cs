using UnityEngine;
using System.Collections;

public class FinalAnimation : MonoBehaviour {
    public GameObject camera;
    public GameObject loserStack;
    public GameObject BracketLines;
    public void HandleFinalDuel(GameObject winner, GameObject loser, AnimationCurve x, AnimationCurve y) {
        //Destroy(BracketLines);
        loserStack.GetComponent<LoserStack>().MakeLoserStack(winner,loser);
        FollowObject fo = this.camera.GetComponent<FollowObject>();
        fo.t = loser.transform;
        AnimationCurve x2 = AnimationCurve.Linear(0f,0f,1f,1f);    
        MoveAnimation ma = loser.GetComponent<MoveAnimation>();
        loser.AddComponent<RotateOverTime>();
        ma.Setup(0.0f,1.0f,loserStack,x2,x2);
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
