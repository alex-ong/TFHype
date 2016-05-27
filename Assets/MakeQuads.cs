using UnityEngine;
using System.Collections;

public class MakeQuads : MonoBehaviour {
    public GameObject cloneMe;
	// Use this for initialization
    int columns = 20;
    int rows = 5;
	void Start () {
	    for (int i = 0; i < 280; i++) {
            GameObject go = GameObject.Instantiate(cloneMe);
            LoadImage li = go.GetComponent<LoadImage>();
            string fp = li.filePath;
            fp = fp.Replace("00",i.ToString());
            li.filePath = fp;
            Vector3 pos = go.transform.position;
            pos.x = i % columns;
            pos.y = -i / columns;
            go.transform.position = pos;
            go.SetActive(true);
            go.transform.SetParent(this.gameObject.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
