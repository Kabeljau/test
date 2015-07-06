using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

	public static bool goalHit =false;
	public GameObject ProjectileOfDeath;
	public RawImage gameOverScreen;

	void Awake(){
		if (gameOverScreen != null) {
			gameOverScreen.enabled = false;
		}
	}

	//check whether goal has been hit
	void OnTriggerEnter(Collider other){
		if (other.name.Contains (ProjectileOfDeath.name)) {
			Debug.Log ("goal has been hit");

			CamFollow.s.poi = this.gameObject;

			//set the static field to true
			goalHit = true;

			if (gameOverScreen != null) {
				gameOverScreen.enabled = true;
			}

		}
	}
}
