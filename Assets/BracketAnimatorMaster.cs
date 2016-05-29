using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BracketAnimatorMaster : MonoBehaviour {
    public static BracketAnimatorMaster instance;
    public AnimationCurve[] initialMove;
    public AnimationCurve xBracket;
    public AnimationCurve yBracket;
    
    public float initialTimeToMove;
    public float initialMinTimer;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void StartChain(List<GameObject> quads, List<GameObject> bracketNodes) {
        System.Random rnd = new System.Random(1555);
        for (int i = 0 ; i < quads.Count; i++) {
            GameObject quad = quads[i];
            GameObject bracketNode = bracketNodes[i];
            
            MoveAnimation ma = quads[i].AddComponent<MoveAnimation>();
            
            ma.Setup(Random.Range(this.initialMinTimer,0.0f),
                    this.initialTimeToMove,
                    bracketNode,
                    initialMove[rnd.Next(initialMove.Length)],
                    initialMove[rnd.Next(initialMove.Length)]);               
            
        }
   }
}
