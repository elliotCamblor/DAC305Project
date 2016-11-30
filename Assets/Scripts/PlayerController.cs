using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D myRigidbody;
	private SpriteRenderer mySprite;
	private CircleCollider2D myCollider;
	public PhysicsMaterial2D blueMat;
	public int boundaryCounter;

	[SerializeField]
	private float movementspeed;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		mySprite = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<CircleCollider2D> ();
		boundaryCounter = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis ("Horizontal");

		HandleMovement (horizontal);
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
		myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, horizontal * movementspeed);
	}

	private void SetYellow() {
		
		mySprite.color = Color.yellow;
		myCollider.enabled = false;
		myCollider.enabled = true;

	gameObject.transform.localScale = new Vector2 (3, 3);

	}

	private void SetBlue() {

		mySprite.color = Color.blue;
		myCollider.sharedMaterial = blueMat;
		myCollider.enabled = false;
		myCollider.enabled = true;
		gameObject.transform.localScale = new Vector2 (10, 10);
	}

	private void SetNeutral() {
		mySprite.color = Color.white;
		myCollider.sharedMaterial = null;
		myCollider.enabled = false;
		myCollider.enabled = true;
		gameObject.transform.localScale = new Vector2 (10, 10);
	}
}
