using UnityEngine;
using System.Collections;

public class FadeAlpha : MonoBehaviour {
    private float _timer;
    private float animLength = 0.2f;
	// Use this for initialization
    private float targetAlpha = 1.0f;
    private float startAlpha = 0.0f;
    
	void Start () {
	    _timer = Random.Range(-0.74f,0.0f);
	}
	public void Setup(float startTimer, float alphaTarget, float animLength) 
    {
        this.startAlpha = this.GetComponent<Renderer>().material.color.a;
        this.targetAlpha = alphaTarget;
        this.animLength = animLength;
    }
    
	// Update is called once per frame
	void Update () {
	    _timer += Time.deltaTime;
        float perc = _timer / animLength;
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = Mathf.Lerp(startAlpha, targetAlpha, perc);
        
        this.GetComponent<Renderer>().material.color = c;
	}
}
