using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	public GameObject Popo;
	private PlayerController controller;
	private CircleCollider2D popoCollider;
	// Use this for initialization
	void Start () {
		Popo = GameObject.Find ("Popo");
		controller = Popo.GetComponent<PlayerController>();
		popoCollider = Popo.GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D popoCollider){
		controller.boundaryCounter++;
		Debug.Log("enter");
	}

	void OnTriggerExit2D(Collider2D popoCollider){
		controller.boundaryCounter++;
		Debug.Log("exit");
	}
}
