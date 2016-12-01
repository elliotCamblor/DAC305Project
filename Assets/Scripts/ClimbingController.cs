using UnityEngine;
using System.Collections;

public class ClimbingController : MonoBehaviour {

	private GameObject Popo;
	private PlayerController controller;
	// Use this for initialization
	void Start () {
		Popo = GameObject.Find ("Popo");
		controller = Popo.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player") {
			if (Input.GetAxis ("Horizontal") > 0) {
				controller.isMovingRight = true; 
			} else {
				controller.isMovingRight = false;
			}
		}
	}

	void OnCollisionStay(Collision collisionInfo){
		if ((Input.GetKey (KeyCode.Q)) && (Input.GetKey (KeyCode.W)) && collisionInfo.gameObject.tag == "Player") {
			controller.isClimbing = true;
		}
	}
	void OnCollisionExit(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player"){
			controller.isClimbing = false;
		}
	}
	
}
