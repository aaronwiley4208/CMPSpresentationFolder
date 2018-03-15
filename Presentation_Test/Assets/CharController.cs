using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
	//tank controls
	//so left and right turns and up and down move forward based on where the character is facing

	public float inputDelay = 0.1f;
	public float runVelocity = 7;
	public float rotateVelocity = 100;

	public ParticleSystem spark;

	//public CameraShake camscript;

	Quaternion targetRotate;
	Rigidbody rigBody;
	float forwardInput;
	float turnInput;

	public Quaternion TargetRotation{
		get{
			return targetRotate;
		}
	}

	void Start(){
		targetRotate = transform.rotation;
		if (GetComponent<Rigidbody>()){
			rigBody = GetComponent<Rigidbody> ();
		}
	}

	void Update(){
		GetInput ();
		Turn ();
	}

	void GetInput(){
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate(){
		Run ();
	}

	void Run(){
		if (Mathf.Abs (forwardInput) > inputDelay) {			
			rigBody.velocity = transform.forward * forwardInput * runVelocity;
		} else {
			rigBody.velocity = Vector3.zero;
		}
	}

	void Turn(){
		targetRotate *= Quaternion.AngleAxis (rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotate;
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "Enemy") {
			var newspark = Instantiate (spark, col.contacts [0].point, Quaternion.identity);
			Destroy (newspark.gameObject, 0.25f);
			//camscript.Shake (0.25f, 0.25f);
		}
	}
}
