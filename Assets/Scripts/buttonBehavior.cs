using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour {

    public Color highlightColor;
    private Renderer _rend;
    private Color _originalColor;

	// Use this for initialization
	void Start () {
        _rend = GetComponent<Renderer>();
        _originalColor = _rend.material.color;
        Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        _rend.material.color = highlightColor;
        Debug.Log("collision enter");
    }

    void OnTriggerExit(Collider collisionInfo) {
        _rend.material.color = _originalColor;
    }
}
