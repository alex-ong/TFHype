using UnityEngine;
using System.Collections;

public class LoadImage : MonoBehaviour {
    public string filePath;
    IEnumerator Start() {
        // Start a download of the given URL
        WWW www = new WWW(filePath);
        
        // Wait for download to complete
        yield return www;
        
        // assign texture
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
