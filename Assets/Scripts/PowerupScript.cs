using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour 
{
//	public GameObject Popo;
	private PlayerController controller;
//	private GameObject BBeacon = GameObject.Find ("BlueBeacon");
//	private BoxCollider BCollider;

	public float dropSpeed = 0.01f;

	bool inBeacon = false;
	bool bluePower = false;


	// Use this for initialization
	void Start () {
		Vector3 CapsulePos = gameObject.transform.position;
//		BCollider = BBeacon.GetComponent<BoxCollider> ();
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (gameObject.transform.localPosition);
		if (bluePower == false){
			if (inBeacon){
				if (gameObject.transform.localPosition == new Vector3 (0, -2.2f, 0)) {
					bluePower = true;
					Debug.Log ("BluePower Gained");
				}
				else if (Input.GetKey (KeyCode.Q)) {
					Vector3 down = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position -= down; 
					Debug.Log ("Q is press");
				}
				else if (gameObject.transform.localPosition != new Vector3 (0, 0, 0)) {
					Vector3 up = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position += up; 
					Debug.Log("Must move up");
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other){	
		if (other.gameObject.tag == "Player"){
			inBeacon = true;
			Debug.Log("enter");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player"){
			inBeacon = false;
			Debug.Log("exit");
		}
	}
}