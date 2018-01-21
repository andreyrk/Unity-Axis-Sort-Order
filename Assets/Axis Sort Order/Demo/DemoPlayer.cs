using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayer : MonoBehaviour {

	[HideInInspector]
	Rigidbody2D myRigidbody2D;

	public float speed;

	void Start() {
		myRigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		myRigidbody2D.velocity = new Vector2 (horizontal, vertical) * speed * Time.deltaTime;
	}
}
