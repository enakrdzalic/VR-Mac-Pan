using UnityEngine;
using System.Collections;

public class BlinkyController : MonoBehaviour {

	public Transform[] wps;
	public float speed;
	public float bounciness;
	int cur;


	void start(){
		cur = 0;
		bounciness = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position != wps[cur].position) {
			transform.position = Vector3.MoveTowards(transform.position, 
			                                                       wps[cur].position, 
			                                                       speed);
		} 
	    else cur = (cur + 1) % wps.Length;
		}

}
