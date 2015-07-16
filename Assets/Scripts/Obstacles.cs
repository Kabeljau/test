using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SphereCollider))]
public class Obstacles : MonoBehaviour {

	public GameObject matchingPrefab; //the one that will cause extra damage

	private float detectionArea;

	private GameObject[] nearbyObjects;

	private AudioSource audio_effects;

	public AudioClip sound_explosion;
	public AudioClip sound_doing;


	void Awake(){

		detectionArea = GetComponent<SphereCollider> ().radius;
		audio_effects = GameObject.Find ("Audio_Effects").GetComponent<AudioSource> ();
		


	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Projectile") {
			//Debug.Log ("was not a projectile");
			return;
		}
		if (other.gameObject.name.Contains (matchingPrefab.name)) {
			//Debug.Log (this.gameObject + "destroys nearby objects");
			destroyNearby ();
		} else {
			Debug.Log ("is destroyed");
			GameManager.score += 2;
			audio_effects.clip = sound_doing;
			audio_effects.Play ();
			Destroy (this.gameObject);
		}
	}

	void destroyNearby(){
		Collider[] hitColliders = Physics.OverlapSphere (gameObject.transform.position, detectionArea);
		nearbyObjects = new GameObject[hitColliders.Length];
		/*foreach (GameObject obj in nearbyObjects) {
			foreach(Collider col in hitColliders){
				obj = col.gameObject;
			}
		}*/
		
		for (int i = 0; i < hitColliders.Length; i++) {
			nearbyObjects[i] = hitColliders[i].gameObject;
//			Debug.Log (nearbyObjects[i]);
		}
		GameManager.score += nearbyObjects.Length;

		foreach (GameObject obj in nearbyObjects) {
			if(obj.tag == "Obstacle"){
				Debug.Log (obj);
				Destroy (obj);
			}
		}
		audio_effects.clip = sound_explosion;
		audio_effects.Play ();
		Destroy (this.gameObject);
	}
}
