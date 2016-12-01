using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject track1_loop;
	public GameObject track2_loop;
	public GameObject blueToggle;


	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position + new Vector3(0,-2,-1);
	}

	void Update () {
		
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
