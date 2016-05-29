using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeQuads : MonoBehaviour {
    public GameObject cloneMe;
    public List<GameObject> allQuads;
        
	// Use this for initialization
    int columns = 32;
	void Start () {
        List<int> toLoad = this.numbersToLoad();
        int j = 0;
        foreach (int i in toLoad) {
          GameObject go = GameObject.Instantiate(cloneMe);
          LoadImage li = go.GetComponent<LoadImage>();
          string fp = li.filePath;
          fp = fp.Replace("00",i.ToString());
          li.filePath = fp;
          Vector3 pos = go.transform.position;
          pos.x = j % columns;
          pos.y = -j / columns;
          go.transform.position = pos;
          go.SetActive(true);
          go.transform.SetParent(this.gameObject.transform);
          j++;  
        }
            
	    
        
        
	}
	
    public List<int> numbersToLoad() {
        List<int> result = new List<int>();
        for (int i = 0; i < 280; i++) {
            result.Add(i);
        }
        Shuffle(result);
        result.Insert(0,281);  
        result.Add(281);  
        
        return result;
                
    }

    public static void Shuffle (List<int> array)
    {
      System.Random rng = new System.Random();
      int n = array.Count;
      while (n > 1) 
      {
        int k = rng.Next(n--);
        int temp = array[n];
        array[n] = array[k];
        array[k] = temp;
      }
    }

    
    
	// Update is called once per frame
	void Update () {
	
	}
}
