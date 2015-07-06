﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject particle;



	void OnCollisionEnter(Collision other){
		Debug.Log ("Projectile has hit obstacle");
		if (particle != null) {
			GameObject GO = GameObject.Instantiate (particle, transform.position, new Quaternion ()) as GameObject;
			CamFollow.s.poi = GO;
			Destroy (GO, 2.0f);
		}
		Destroy (this.gameObject);

	}
}
