using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	[Tooltip("Level load delay in seconds")][SerializeField] float levelLoadDelay = 3.0f;
	[Tooltip("Drag in the game object for explosion or other death effects")][SerializeField] GameObject deathFX;

	void OnTriggerEnter (Collider other) {
		
		StartDeathSequence();
	}

	private void StartDeathSequence () {
		gameObject.SendMessage("OnPlayerDeath");
		deathFX.SetActive(true);
		Invoke("ReloadLevel", levelLoadDelay);
	}

	private void ReloadLevel() {
		SceneManager.LoadScene(1);
	}

}
