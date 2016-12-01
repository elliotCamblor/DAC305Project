using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	public GameObject start;
	public GameObject title;
	public GameObject cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			start.SetActive(false);
			title.SetActive(false);
		}

		if (!start.active) {
			cam.camera.orthographicSize += 0.0095f;
			Debug.Log ("Increase Size");
		}
		if (cam.camera.orthographicSize >= 7f) {
			cam.SetActive (false);
		}
	}
}
