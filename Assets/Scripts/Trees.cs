using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class Trees : MonoBehaviour {

	public delegate void TreeTurnedPink();
	public static event TreeTurnedPink onTreeTurnPink;

	public GameObject matchingPrefab;
	public Texture pink;

	public bool isPink;

	private Renderer ren;
	private Rigidbody rb;
	private AudioSource audio;

	void Awake(){
		isPink = false;
		ren = GetComponent<Renderer> ();
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Projectile") {
			rb.AddExplosionForce (300.0f, other.gameObject.transform.position, 30.0f);
			audio.Play ();
		} else if(other.gameObject.tag == "Tree" && other.gameObject.GetComponent<Trees>().isPink ) {
			audio.Play ();
			turnPink ();
		}

		if (other.gameObject.name.Contains (matchingPrefab.name)) {
			Debug.Log ("tree turns pink");
			turnPink ();
		
		} 
	}

	private void turnPink(){
		isPink = true;
//		Debug.Log ("isPink: " + isPink);
		onTreeTurnPink ();
		for (int i = 0; i<ren.materials.Length; i++) { //why can't I change the material??
			ren.materials [i].shader = Shader.Find ("Unlit/Texture");
			ren.materials [i].mainTexture = pink;
		}
	}
}


