using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharController : MonoBehaviour {

	float moveSpeed = 10f;

	Vector3 forward, right;

	Animator animator;

	// Use this for initialization
	void Start () {
		forward = Camera.main.transform.forward;

		forward.y = 0;
		forward = Vector3.Normalize (forward);

		right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Move ();
		} else {
			animator.SetBool ("moving", false);
		}
	}

	void Move(){
		animator.SetBool ("moving", true);

		Vector3 rightMovement = right * Input.GetAxis ("HorizontalKey");
		Vector3 upMovement = forward * Input.GetAxis ("VerticalKey");

		Vector3 movement = Vector3.Normalize (upMovement + rightMovement);

		transform.position += movement * Time.deltaTime * moveSpeed;
		Camera.main.transform.position += movement * Time.deltaTime * moveSpeed;

		Debug.Log (movement);

		animator.SetFloat ("xInput", movement.x);
		animator.SetFloat ("zInput", movement.z);
	}
}
