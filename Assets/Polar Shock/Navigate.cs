using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal")*25*Time.deltaTime,0,Input.GetAxis("Vertical")*25*Time.deltaTime));
		transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"),0,0));
		transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0),Space.World);
	}
}
