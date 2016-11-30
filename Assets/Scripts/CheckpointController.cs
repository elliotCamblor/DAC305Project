using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {


	public GameObject Popo;
	private PlayerController controller;
	private bool isReached = false;

	// Use this for initialization
	void Start () {
		Popo = GameObject.Find ("Popo");
		controller = Popo.GetComponent<PlayerController>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && isReached == false){
			controller.lastCheck = gameObject.transform.position;
			isReached = true;
			Debug.Log("checkpoint reached");
		}
	}
}
