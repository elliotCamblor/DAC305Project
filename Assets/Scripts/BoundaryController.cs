using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	private GameObject Popo;
	private PlayerController controller;
	// Use this for initialization
	void Start () {
		Popo = GameObject.Find ("Popo");
		controller = Popo.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			controller.boundaryCounter++;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player"){
			controller.boundaryCounter--;
		}
	}
}
