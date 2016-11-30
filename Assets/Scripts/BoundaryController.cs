using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	public GameObject Popo;
	private PlayerController controller;
	private SphereCollider popoCollider;
	// Use this for initialization
	void Start () {
		Popo = GameObject.Find ("Popo");
		controller = Popo.GetComponent<PlayerController>();
		popoCollider = Popo.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			controller.boundaryCounter++;
			Debug.Log("enter");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player"){
			controller.boundaryCounter--;
			Debug.Log("exit");
		}
	}
}
