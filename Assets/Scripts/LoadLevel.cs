using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization

	private void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		Invoke("LoadNextLevel", 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadNextLevel () {
		SceneManager.LoadScene(1);
	}
}
