using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour 
{
	private PlayerController controller;

	public float dropSpeed = 0.01f;

	bool inBeacon = false;
	bool hasPower = false;


	// Use this for initialization
	void Start () {
		Vector3 CapsulePos = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (hasPower == false){
			if (inBeacon){
				if (gameObject.transform.localPosition == new Vector3 (0, -2.2f, 0)) {
					hasPower = true;
				}
				else if (Input.GetKey (KeyCode.Q)) {
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