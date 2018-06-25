using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField] ParticleSystem deathFX;
	[SerializeField] Transform parent;

	[SerializeField] int scorePerHit = 10;

	ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
		AddNonTriggerBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnParticleCollision (GameObject other) {
		Debug.Log("Enemy hit by " + other.name);
		scoreBoard.ScoreHit(scorePerHit);
		ParticleSystem fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		fx.Play();
		Destroy(gameObject);
	}

	void AddNonTriggerBoxCollider () {
		Collider nonTriggerBoxCollier = gameObject.AddComponent<BoxCollider>();
		nonTriggerBoxCollier.isTrigger = false;
	}
}
