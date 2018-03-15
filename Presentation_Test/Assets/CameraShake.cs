using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;
	public Vector3 basePos;

	void Start () {
		
	}

	void Update () {
		if (shakeTimer >= 0) {
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;

		} 
		else {
			transform.position = basePos;
		}
	}

	public void Shake(float shakePower, float shakeDur){
		shakeTimer = shakeDur;
		shakeAmount = shakePower;
	}
}
