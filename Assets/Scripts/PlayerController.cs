﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody myRigidbody;
	private SphereCollider myCollider;
	private MeshRenderer myRenderer;
	public PhysicMaterial blueMat;
	public int boundaryCounter;
	public Material whiteTexture;
	public Material blueTexture;
	public Vector3 lastCheck;
	private bool isMovementLocked;


	[SerializeField]
	private float movementspeed;
	private float horizontal;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myCollider = GetComponent<SphereCollider> ();
		myRenderer = GetComponent<MeshRenderer>();
		lastCheck = GameObject.Find("checkpoint_0").transform.position;
		boundaryCounter = 0;
		isMovementLocked = false;
	}

	// Update is called once per frame
	void Update() {
		if (boundaryCounter <= 0) {
			ResetPopo();
		}
	}
	void FixedUpdate () 
	{
	
		if (!isMovementLocked){
			horizontal = Input.GetAxis ("Horizontal");
			HandleMovement (horizontal);
		}
		if (Input.GetKey (KeyCode.Q)) {
			SetBlue ();
		} else if (Input.GetKey(KeyCode.W)){
			SetYellow();
		} else {
			SetNeutral ();
		}
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementspeed, myRigidbody.velocity.y);
	}

	private void SetYellow() {

		myRenderer.material = whiteTexture;
		gameObject.transform.localScale = new Vector3 (1, 1, 1);

	}

	private void SetBlue() {

		myRenderer.material = blueTexture;
		myCollider.material = blueMat;
		gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}

	private void SetNeutral() {

		myRenderer.material = whiteTexture;
		myCollider.material = null;
		gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}

	private void ResetPopo (){
		gameObject.transform.position = lastCheck;
		myRigidbody.velocity = new Vector2 (0, 0);
		isMovementLocked = true;
		StartCoroutine (MovementDelay ());

	}

	private IEnumerator MovementDelay()
	{
		// Wait for 1 second
		yield return new WaitForSeconds(1);
		isMovementLocked = false;
		horizontal = 0.0f;
	}
}
