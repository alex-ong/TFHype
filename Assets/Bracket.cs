using UnityEngine;
using System.Collections;

public class Bracket : MonoBehaviour {
    public Bracket next;
    public Bracket wait;
    
    public int number;
    public int level = 0;
    public GameObject contestant1;
    public GameObject contestant2;
    
    public bool singleContestant = false;
    
    private const int ALWAYS_WIN = 281;
    
    private const float moveTime = 1.0f;
    private const float waitTime = -0.5f;
    
    public bool handledWinner = false;
    public bool canWin = false;
    private GameObject winner;
    public AnimationCurve loseCurveX;
    public AnimationCurve loseCurveY;
    public void RegisterContestant(GameObject go) 
    {
        if (contestant1 == null) {
            contestant1 = go;
            if (singleContestant) {
                HandleWinner(go, false);
            }
        } else if (contestant2 == null && go != contestant1) {
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
                winner = con1ID > con2ID ? contestant1 : contestant2;
                loser = winner == contestant1 ? contestant2 : contestant1;                
            }
            if (wait == null) {
                HandleWinner(winner, con1ID == ALWAYS_WIN || con2ID == ALWAYS_WIN ||con1ID == 254 || con2ID == 254 );
                HandleLoser(loser);            
            } else {
                HandleLoser(loser);
                this.winner = winner;
                this.canWin = true;
            }
        }
    }
    public void Update() {
        if (wait != null && !this.handledWinner && canWin && wait.canWin) {
            this.HandleWinner(this.winner,true);
        }
    }
    public void HandleWinner(GameObject go, bool god) {
            handledWinner = true;
            if (next != null) {
            
            float xDistance = Mathf.Abs(go.transform.position.x - next.transform.position.x);
            float yDistance = Mathf.Abs(go.transform.position.y - next.transform.position.y);
            float xPerc = xDistance / (xDistance+yDistance);                
            //horizontal movement followed by vertical movement.            
            AnimationCurve xCurve = AnimationCurve.Linear(0.0f,0.0f,xPerc,1.0f);
            AnimationCurve yCurve = AnimationCurve.Linear(xPerc,0.0f,1.0f,1.0f);
            float toWait = god ? 0.0f : Random.Range(waitTime,0.0f);
            go.GetComponent<MoveAnimation>().Setup(toWait,
                                                   moveTime,
                                                   next.gameObject,
                                                   xCurve,yCurve);
        }
    }
    
    public void HandleLoser(GameObject go) {
        GameObject newTarget = new GameObject();
        newTarget.transform.SetParent(this.gameObject.transform);
        newTarget.transform.position = go.transform.position + new Vector3(Random.Range(-3f,3f),-5f,0.0f);
        go.GetComponent<MoveAnimation>().Setup(0.0f,moveTime,newTarget,this.loseCurveX,this.loseCurveY);
        FadeAlpha fa = go.GetComponent<FadeAlpha>();
        Destroy(fa);
        fa = go.AddComponent<FadeAlpha>();   
        fa.Setup(0.0f,0.0f,0.25f);
        go.AddComponent<RotateOverTime>();
    }
    
    public override string ToString()
    {
        return "Bracket";
    }
  
}
