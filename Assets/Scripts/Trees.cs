using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour {

	public GameObject matchingPrefab;

	private Renderer ren;

	void Awake(){
		ren = GetComponent<Renderer> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Projectile") {
			Debug.Log ("was not a projectile");
			return;
		}
		if (other.gameObject.name.Contains (matchingPrefab.name)) {
			Debug.Log (this.gameObject + "destroys nearby objects");
			ren.material.mainTexture = null;
		} 
	}
}
