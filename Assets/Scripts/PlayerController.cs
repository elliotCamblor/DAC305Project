using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D myRigidbody;
	private SpriteRenderer mySprite;
	private CircleCollider2D myCollider;
	public PhysicsMaterial2D blueMat;

	[SerializeField]
	private float movementspeed;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		mySprite = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis ("Horizontal");

		HandleMovement (horizontal);
		if (Input.GetKey(KeyCode.Q)){
			SetBlue();
		} else {
			SetNeutral ();
		}
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementspeed, myRigidbody.velocity.y);
	}

	private void SetBlue() {

		mySprite.color = Color.blue;
		myCollider.sharedMaterial = blueMat;
		myCollider.enabled = false;
		myCollider.enabled = true;
	}

	private void SetNeutral() {
		mySprite.color = Color.white;
		myCollider.sharedMaterial = null;
		myCollider.enabled = false;
		myCollider.enabled = true;
	}
}
