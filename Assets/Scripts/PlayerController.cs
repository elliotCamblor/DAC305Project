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

	[SerializeField]
	private float movementspeed;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		myCollider = GetComponent<SphereCollider> ();
		myRenderer = GetComponent<MeshRenderer>();
		boundaryCounter = 0;
	}

	// Update is called once per frame
	void Update() {
		if (boundaryCounter <= 0) {
			Debug.Log ("here");
			ResetPopo();
		}
	}
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
		myRigidbody.velocity = new Vector2 (horizontal * movementspeed, myRigidbody.velocity.y);
		Debug.Log (myRigidbody.velocity);
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
		gameObject.transform.position = new Vector3 (0.09f, 1.46f, 0f);
	}
}
