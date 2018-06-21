using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DestroyObject();		
	}

	void DestroyObject () {
		print("Destroying game object");
		Destroy(gameObject, 5f);
	}
}
