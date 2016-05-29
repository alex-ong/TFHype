﻿using UnityEngine;
using System.Collections;

public class FadeAlpha : MonoBehaviour {
    private float _timer;
	// Use this for initialization
	void Start () {
	    _timer = Random.Range(-1.25f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	    _timer += Time.deltaTime;
        float perc = _timer / 0.25f;
        Color c = this.GetComponent<Renderer>().material.color;
        c.a = perc;
        this.GetComponent<Renderer>().material.color = c;
	}
}