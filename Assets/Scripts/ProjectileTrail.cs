using UnityEngine;
using System.Collections;

public class ProjectileTrail : MonoBehaviour {
	/*
	//Singleton instance
	public static ProjectileTrail s;  //Singleton

	//public inspector fields
	//public float minDist = 0.1f;  //is not needed if you use the trail renderer-this seems to have it already built in 



	//private fields
	private TrailRenderer trailRen;
	//private LineRenderer lineRen;
	//private int points;
	//private Vector3 lastPoint;

	private GameObject _poi;


	//property: like a field to the outside but calls get/set internally!! some safety thing- so nobody can directly access the private field _poi
	public GameObject poi {
		get{
			return _poi;
		}
		set{
			// use "value" to access the new value of the property
			//set the new value of _poi
			_poi = value;
			//Check if the poi was set so something (and now to something new)
			if(_poi != null){
				trailRen.enabled = false;
				//reset everything (the line renderer)
				/*lineRen.enabled = false;
				points = 0;
				lineRen.SetVertexCount(0);
			}
		}
	}


	void Awake(){
		s = this;
		trailRen = GetComponent<TrailRenderer> ();
		//lineRen = GetComponent<LineRenderer> ();

		//initialize fileds
		//points = 0;

		//lineRen.enabled = false;
		trailRen.enabled = false;
	}

	void FixedUpdate(){
		//trailRen.probeAnchor = CamFollow.s.poi.GetComponent<Transform> ();


		//if no poi has been set, use the camera's poi if it follows a projectile--> so we could trail everything

		//identify if the poi has a value that is a projectile

		//add a point
		//addPoint ();
	}

	void addPoint(){
		Vector3 pt = _poi.transform.position;
		//if the point isn't far enouh from thelast one do nothing
		//if we are dealing with the first(launch) point
		//else, not the first point



		//lastPoint = pt;
	}*/
}
