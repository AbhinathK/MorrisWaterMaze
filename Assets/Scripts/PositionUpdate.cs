using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextMesh position = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        var headPosition = Camera.main.transform.position;
        position.text = headPosition.x.ToString();


    }
	
	// Update is called once per frame
	void Update () {
        TextMesh position = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        var headPosition = Camera.main.transform.position;
        position.text = headPosition.x.ToString();
    }
}
