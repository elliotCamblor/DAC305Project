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

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myCollider = GetComponent<SphereCollider> ();
		myRenderer = GetComponent<MeshRenderer>();
		lastCheck = GameObject.Find("checkpoint_0").transform.position;
		boundaryCounter = 0;
		isMovementLocked = false;
		isClimbing = false;
	}

	// Update is called once per frame
	void Update() {
		if (boundaryCounter <= 0) {
			ResetPopo();

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
		gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}

	private void SetYellow() {
		isClimbing = false;
		myRenderer.material = yellowTexture;
		gameObject.transform.localScale = new Vector3 (1, 1, 1);

	}

	private void SetBlue() {
		isClimbing = false;
		myRenderer.material = blueTexture;
		myCollider.material = blueMat;
		gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}

	private void SetNeutral() {
		isClimbing = false;
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
