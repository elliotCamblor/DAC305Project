using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {


	public Vector3 origPoint;
	public GameObject endCube;
	private Vector3 endPoint;
	float distance;
	bool reached = false;
	
	public void Start()
	{
		origPoint = transform.position;
		endPoint = endCube.transform.position;
	}
	
	public void Update()
	{
		if(!reached){
			distance = Vector3.Distance(transform.position, endPoint);
			if(distance > .1){
				move (transform.position, endPoint);
			} else {
				reached = true;
			}
		} else {
			distance = Vector3.Distance(transform.position, origPoint);
			if(distance > .1){
				move (transform.position, origPoint);
			} else {
				reached = false;
			}
		}
	}
	
	void move(Vector3 pos, Vector3 towards)
	{
		transform.position = Vector3.MoveTowards(pos, towards, .1f);
	}
}
