using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject particle;




	void OnCollisionEnter(Collision other){
		if (Slingshot.aimingMode) {
			return;
		}
		Debug.Log ("Projectile has hit obstacle");
		if (particle != null) {
			GameObject GO = GameObject.Instantiate (particle, transform.position, new Quaternion ()) as GameObject;
			if(CamFollow.s.poi != CamFollow.empty){
			CamFollow.s.poi = GO;
			}
			Destroy (GO, 2.0f);
		}
		Destroy (this.gameObject);

	}
}
