using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public static CamFollow s; //singleton instance of this class  can be accessed by other scripts by: FollowCam.s.poi;  but only if you have only one instance!!!!!

	//camera following script needs a point of interest, which it can follow
	public GameObject poi; //don't make it public since it might change during runtime(e.g. next projectile)-->change via script

	private float CamZ;
	private float minCamY;
	private float leftCam;
	private Vector2 minXY;

	//awake is always called, even when the attached object is set unactive. start starts as soon as it's set active
	void Awake(){
		s = this;
		CamZ = transform.position.z;
		minCamY = transform.position.y;
		leftCam = transform.position.x;

	}

	void FixedUpdate(){
		//check if poi is empty--- if there is no point of interes yet (in our case it would be the projectile)
		if (poi == null) {return;}

		Vector3 poiTrans = poi.transform.position;
		Vector3 destination = poi.transform.position;



		destination = Vector3.Lerp ( transform.position, poiTrans, 0.15f);
		destination.z = CamZ;

		destination.x = Mathf.Max (minXY.x, destination.x); //prevents camera of jumping under the bottom
		destination.y = Mathf.Max (minXY.y, destination.y);


		transform.position = destination;

	}

}
