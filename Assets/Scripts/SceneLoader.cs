using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	void Start () {
		Invoke("LoadNextLevel", 5.0f);
	}
	
	void LoadNextLevel () {
		SceneManager.LoadScene(1);
	}
}
