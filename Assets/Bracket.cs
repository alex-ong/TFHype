using UnityEngine;
using System.Collections;

public class Bracket : MonoBehaviour {
    public Bracket next;
    public int number;
    
    public GameObject contestant1;
    public GameObject contestant2;
    
    public bool canProceed;
    
    private const int ALWAYS_WIN = 281;
    public void RegisterContestant(GameObject go) 
    {
    
    }
    
    public override string ToString()
    {
        return "Bracket";
    }
  
}
