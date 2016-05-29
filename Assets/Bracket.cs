using UnityEngine;
using System.Collections;

public class Bracket : MonoBehaviour {
    public Bracket next;
    public int number;
    public int level = 0;
    public GameObject contestant1;
    public GameObject contestant2;
    
    public bool canProceed;
    public bool singleContestant = false;
    
    private const int ALWAYS_WIN = 281;
    
    private const float moveTime = 1.0f;
    private const float waitTime = -0.5f;
    
    public void RegisterContestant(GameObject go) 
    {
        if (contestant1 == null) {
            contestant1 = go;
            if (singleContestant) {
                HandleWinner(go);
            }
        } else if (contestant2 == null) {
            contestant2 = go;
            int con1ID = contestant1.GetComponent<QuadID>().id;
            int con2ID = contestant2.GetComponent<QuadID>().id;
            
            GameObject loser;
            GameObject winner;
            
            if (con1ID == ALWAYS_WIN) {
                winner = contestant1;
                loser = contestant2;
                
            } else if (con2ID == ALWAYS_WIN) {
                winner = contestant2;
                loser = contestant1;                                
            } else {
                winner = Random.value > 0.5f ? contestant1 : contestant2;
                loser = winner == contestant1 ? contestant2 : contestant1;                
            }
            HandleWinner(winner);
            HandleLoser(loser);            
        }
    }
    
    public void HandleWinner(GameObject go) {
        if (next != null) {
            float xDistance = Mathf.Abs(go.transform.position.x - next.transform.position.x);
            float yDistance = Mathf.Abs(go.transform.position.y - next.transform.position.y);
            float xPerc = xDistance / (xDistance+yDistance);                
            //horizontal movement followed by vertical movement.            
            AnimationCurve xCurve = AnimationCurve.Linear(0.0f,0.0f,xPerc,1.0f);
            AnimationCurve yCurve = AnimationCurve.Linear(xPerc,0.0f,1.0f,1.0f);
        
            go.GetComponent<MoveAnimation>().Setup(Random.Range(waitTime,0.0f),
                                                   moveTime,
                                                   next.gameObject,
                                                   xCurve,yCurve);
        }
    }
    
    public void HandleLoser(GameObject go) {

    }
    
    public override string ToString()
    {
        return "Bracket";
    }
  
}
