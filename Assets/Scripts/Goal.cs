using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public static bool goalHit =false;


	//check whether goal has been hit
	void OnTriggerEnter(Collider other){
		if (other.tag == "Projectile") {
			Debug.Log ("goal has been hit");

			//set the static field to true
			goalHit = true;

			//give some visual feedback(in this case: make it transparent)
			Color c = this.gameObject.GetComponent<Renderer>().material.color;
			c.a = 0.5f;
			gameObject.GetComponent<Renderer>().material.color = c;


		}
	}
}
