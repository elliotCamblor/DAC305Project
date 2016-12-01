using UnityEngine;
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
	public Material yellowTexture;
	public Material greenTexture;
	public bool isClimbing;
	public bool isMovingRight;
	[SerializeField]
	private float movementspeed;
	private float horizontal;

	private Vector3 reduce;

	private GameObject blueBeacon;
	private GameObject yellowBeacon;
	private GameObject greenBeacon;
	
	private PowerupScript blueController;
	private PowerupScript yellowController;
	private PowerupScript greenController;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myCollider = GetComponent<SphereCollider> ();
		myRenderer = GetComponent<MeshRenderer>();
		lastCheck = GameObject.Find("checkpoint_0").transform.position;
		boundaryCounter = 0;
		isMovementLocked = false;
		isClimbing = false;

		reduce = new Vector3 (0.02f, 0.02f, 0.02f);

		blueBeacon = GameObject.Find ("BlueCap");
		yellowBeacon = GameObject.Find ("YellowCap");
		greenBeacon = GameObject.Find ("GreenCap");
		
		blueController = blueBeacon.GetComponent<PowerupScript> ();
		yellowController = yellowBeacon.GetComponent<PowerupScript> ();
		greenController = greenBeacon.GetComponent<PowerupScript> ();
	}

	// Update is called once per frame
	void Update() {

		if (boundaryCounter <= 0) {
			ResetPopo();
		}

		if ((Input.GetKey (KeyCode.Q)) && (Input.GetKey (KeyCode.W))) {
			SetGreen ();
		}else if (Input.GetKey (KeyCode.Q)) {
			SetBlue ();
		} else if (Input.GetKey(KeyCode.W)){
			SetYellow();
		} else {
			SetNeutral ();
		}
	}
	void FixedUpdate () 
	{
		if (isMovementLocked)
			return;
		horizontal = Input.GetAxis ("Horizontal");
		if (!isClimbing) {
			HandleMovement (horizontal);
		}else{
			HandleVertMovement(horizontal);
		}
		if ((Input.GetKey (KeyCode.Q)) && (Input.GetKey (KeyCode.W)) && (greenController.hasPower)) {
			SetGreen ();
		} else if (Input.GetKey (KeyCode.Q) && (blueController.hasPower)) {
			SetBlue ();
		} else if (Input.GetKey (KeyCode.W)&& (yellowController.hasPower)) {
			SetYellow ();
		} else {
			SetNeutral ();
		}
	}


	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementspeed, myRigidbody.velocity.y);
	}

	private void HandleVertMovement(float horizontal)
	{
		if (isMovingRight) {
			myRigidbody.velocity = new Vector2 (0, horizontal * movementspeed);
		} else {
			myRigidbody.velocity = new Vector2 (0, -horizontal * movementspeed);
		}
	}
	private void SetGreen() {
		myRenderer.material = greenTexture;
		myCollider.material = null;
		if (gameObject.transform.localScale != new Vector3 (2, 2, 2)) {
			gameObject.transform.localScale += reduce;
		}
	}

	private void SetYellow() {
		isClimbing = false;
		myRenderer.material = yellowTexture;
		if (gameObject.transform.localScale != new Vector3 (1, 1, 1)) {
			gameObject.transform.localScale -= reduce;
		}
//		gameObject.transform.localScale = new Vector3 (1, 1, 1);

	}

	private void SetBlue() {
		isClimbing = false;
		myRenderer.material = blueTexture;
		myCollider.material = blueMat;
		if (gameObject.transform.localScale != new Vector3 (2, 2, 2)) {
			gameObject.transform.localScale += reduce;
		}
	}

	private void SetNeutral() {
		isClimbing = false;
		myRenderer.material = whiteTexture;
		myCollider.material = null;
		if (gameObject.transform.localScale != new Vector3 (2, 2, 2)) {
			gameObject.transform.localScale += reduce;
		}
//		gameObject.transform.localScale = new Vector3 (2, 2, 2);
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
