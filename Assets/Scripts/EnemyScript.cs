using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField] ParticleSystem deathFX;
	[SerializeField] Transform parent;

	// Use this for initialization
	void Start () {
		AddNonTriggerBoxCollider();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnParticleCollision (GameObject other) {
		Debug.Log("Enemy hit by " + other.name);
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
