using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MakeQuads : MonoBehaviour {
    public GameObject cloneMe;
    public List<GameObject> allQuads;
        
	// Use this for initialization
    int columns = 25;
	void Start () {
        Random.seed = 0;
        List<int> toLoad = this.numbersToLoad();
        int j = 0;
        foreach (int i in toLoad) {
          GameObject go = GameObject.Instantiate(cloneMe);
          LoadImage li = go.GetComponent<LoadImage>();
          string fp = li.filePath;
          fp = fp.Replace("00",i.ToString());
          li.filePath = fp;
          go.transform.SetParent(this.gameObject.transform);
          Vector3 pos = go.transform.localPosition;
          pos.x = j % columns;
          pos.y = -j / columns;
          go.transform.localPosition = pos;
          go.SetActive(true);
          
          go.GetComponent<QuadID>().id = i;
          j++;  
          allQuads.Add(go);
        }
            
	    
        
        
	}
	
    public List<int> numbersToLoad() {
        List<int> result = new List<int>();
        for (int i = 0; i < 255; i++) {
            result.Add(i);
        }
        Shuffle(result);
        //put "281" in the middle.
        result.Insert(107,281);  
        
        return result;
                
    }

    public static void Shuffle (List<int> array)
    {
      System.Random rng = new System.Random(1555);
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
