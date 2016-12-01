using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour 
{
	private PlayerController controller;

	public float dropSpeed = 0.01f;

	bool inBeacon = false;
	public bool hasPower = false;

	private GameObject blueBeacon;
	private GameObject yellowBeacon;
	private GameObject greenBeacon;
	
	private PowerupScript blueController;
	private PowerupScript yellowController;
	private PowerupScript greenController;


	// Use this for initialization
	void Start () {
		blueBeacon = GameObject.Find ("BlueCap");
		yellowBeacon = GameObject.Find ("YellowCap");
		greenBeacon = GameObject.Find ("GreenCap");
		
		blueController = blueBeacon.GetComponent<PowerupScript> ();
		yellowController = yellowBeacon.GetComponent<PowerupScript> ();
		greenController = greenBeacon.GetComponent<PowerupScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (hasPower == false){
			if (inBeacon){
				if (gameObject.transform.localPosition.y <= -2.2f) {
					hasPower = true;
				}
				else if (Input.GetKey (KeyCode.Q) && !blueController.hasPower) {
					Vector3 down = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position -= down;
				}
				else if (Input.GetKey (KeyCode.W) && !yellowController.hasPower) {
					Vector3 down = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position -= down;
				}
				else if ((Input.GetKey (KeyCode.Q))  && (Input.GetKey (KeyCode.W)) && !greenController.hasPower) {
					Vector3 down = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position -= down;
				}
				else if (gameObject.transform.localPosition != new Vector3 (0, 0, 0)) {
					Vector3 up = new Vector3 (0, dropSpeed, 0);
					gameObject.transform.position += up;
				}
			} else if (gameObject.transform.localPosition != new Vector3 (0, 0, 0)){
				Vector3 up = new Vector3 (0, dropSpeed, 0);
				gameObject.transform.position += up; 
			}
		}
	}
	
	void OnTriggerEnter(Collider other){	
		if (other.gameObject.tag == "Player"){
			inBeacon = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player"){
			inBeacon = false;
			Debug.Log("exit");
		}
	}
}