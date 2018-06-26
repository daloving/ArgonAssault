using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController    : MonoBehaviour {

    [Header("General")]
	[Tooltip("In ms^-1")][SerializeField] float xSpeed = 12f;
	[Tooltip("In m")][SerializeField] float xMovementRange = 8f;
	[Tooltip("In ms^-1")][SerializeField] float ySpeed = 10f;
	[Tooltip("In m")][SerializeField] float yMin = 6f;
	[Tooltip("In m")][SerializeField] float yMax = 6f;
	[SerializeField] GameObject[] guns;

    [Header("Screen-Position Based Parameters")]
	[SerializeField] float positionPitchFactor = -2f;
	[SerializeField] float positionYawFactor = 2f;

    [Header("Control-Throw Based Parameters")]
	[SerializeField] float controlPitchFactor = -10f;
	[SerializeField] float controlRollFactor = -20f;

	float xThrow, yThrow;
	bool controlsDisabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!controlsDisabled) {
			ProcessTranslation();
			ProcessRotation();
			ProcessFiring();
		}
	}

	void ProcessTranslation () {
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * Time.deltaTime * xSpeed;
		float yOffset = yThrow * Time.deltaTime * ySpeed;
		
		float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xMovementRange, xMovementRange);
		float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yMin, yMax);

		transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);

	}

	void ProcessRotation () {

		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControl = yThrow * controlPitchFactor;
		float pitch = pitchDueToControl + pitchDueToPosition;
		
		float yaw = transform.localPosition.x * positionYawFactor;
		
		float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	void ProcessFiring () {
		if (CrossPlatformInputManager.GetButton("Fire")) {
			ActivateGuns();
		} else {
			DeactivateGuns();
		}
	}

	void ActivateGuns () {
		foreach (GameObject gun in guns) {
			gun.SetActive(true);
		}
	}

	void DeactivateGuns () {
		foreach (GameObject gun in guns) {
			gun.SetActive(false);
		}
	}

	void OnPlayerDeath() {
		// Method called by string reference
		print("You died");
		print("Controls frozen");
		controlsDisabled = true;
	}
    
}
