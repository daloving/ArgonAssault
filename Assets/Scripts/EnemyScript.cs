using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField] ParticleSystem deathFX;
	[SerializeField] Transform parent;

	[SerializeField] int scorePerHit = 10;
	[SerializeField] int scorePerKill = 100;
	[SerializeField] int damagePerHit = 25;
	[SerializeField] int healthPoints = 100;

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
		TakeDamage();
		if (healthPoints <= 0) {
			KillEnemy();
		}
	}

	void TakeDamage () {
		scoreBoard.ScoreHit(scorePerHit);
		healthPoints -= damagePerHit;
		//todo consider particle effect
	}

	void KillEnemy () {
		scoreBoard.ScoreHit(scorePerKill);
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
