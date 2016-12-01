using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	public GameObject track1_intro;
	public GameObject track1_loop;
	public GameObject track2_loop;
	public GameObject track3_loop;
	public GameObject track4_loop;
	
	private GameObject blueBeacon;
	private GameObject yellowBeacon;
	private GameObject greenBeacon;
	
	private PowerupScript blueController;
	private PowerupScript yellowController;
	private PowerupScript greenController;
	
	private AudioSource tr1_intro;
	private AudioSource tr1_loop;
	
	//	public float sec = 3f;
	
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		blueBeacon = GameObject.Find ("BlueCap");
		yellowBeacon = GameObject.Find ("YellowCap");
		greenBeacon = GameObject.Find ("GreenCap");
		
		blueController = blueBeacon.GetComponent<PowerupScript> ();
		yellowController = yellowBeacon.GetComponent<PowerupScript> ();
		greenController = greenBeacon.GetComponent<PowerupScript> ();
		
		offset = new Vector3(0,2,10);

		tr1_intro = track1_intro.GetComponent<AudioSource> ();
		tr1_loop = track1_loop.GetComponent<AudioSource> ();
		
		//		tr1_loop.audio.PlayDelayed (3f);
		
		//		StartCoroutine(LateCall());
	}
	
	//	IEnumerator LateCall()
	//	{
	
	//		yield return new WaitForSeconds(sec);
	
	//		tr1_loop.audio.PlayDelayed (3f);
	//		track1_loop.SetActive (true);
	//		track1_intro.SetActive (false);
	//	}
	
	void Update () {
		//		if (!track1_intro.active) {
		//			track1_loop.SetActive(true);
		//		}
		if (Input.GetKey (KeyCode.Space) && tr1_intro.volume == 1){
			tr1_intro.volume = 0.95f;
		}
		
		if (tr1_intro.volume < 0.99f){
			tr1_intro.volume -= 0.005f;
		}
		
		if (Input.GetKey (KeyCode.Space) && tr1_loop.volume == 0){
			tr1_loop.volume = 0.05f;
		}
		
		if (tr1_loop.volume > 0.01f){
			tr1_loop.volume += 0.005f;
		}
		
		if (track1_loop.active){
			if (blueController.hasPower) {
				track1_loop.SetActive(false);
				Debug.Log ("Turn off loop 1");
				track2_loop.SetActive(true);
			}
		}
		
		if (track2_loop.active){
			if (yellowController.hasPower) {
				track2_loop.SetActive(false);
				Debug.Log ("Turn off loop 1");
				track3_loop.SetActive(true);
			}
		}
		
		if (track3_loop.active){
			if (greenController.hasPower) {
				track3_loop.SetActive(false);
				Debug.Log ("Turn off loop 1");
				track4_loop.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position - offset;
	}
}
