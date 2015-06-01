using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	//Fields in the Inspector panel
	public int numClouds;

	public GameObject[] cloudPrefabs;

	public Vector3 cloudPosMin;
	public Vector3 cloudPosMax;

	public float speed;

	public float minScale;
	public float maxScale;

	//Interal Fields
	public GameObject[] cloudInstances;


	void Awake(){
		//Create an array to hold our cloud instances
		cloudInstances = new GameObject[numClouds];

		//Find the clouds parent object
		GameObject parent = GameObject.FindGameObjectWithTag ("CloudParent");

		//Iterate through array and create each cloud
		GameObject cloud;
		for (int i=0; i< cloudInstances.Length; i++) {

			//Pick a random cloud prefab between 0 and cloudPrefabs.length - 1
			int PrefabNum = Random.Range (0, cloudPrefabs.Length - 1);
		

			//Instantiate a cloud and position it accordingly 	//Scale the cloud

			cloud = Instantiate (cloudPrefabs [PrefabNum]);

			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range (cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.Range (cloudPosMin.y, cloudPosMax.y);
			//float scaleFactor = Random.Range (minScale, maxScale);

			//Leissler
			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp (minScale, maxScale, scaleU);

			cPos.y = Mathf.Lerp (cloudPosMin.y, cPos.y, scaleU);

			cPos.z = 100 - 90 * scaleU;

			cloud.transform.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;

			//make the cloud a child of the clouds parent
			cloud.transform.parent = parent.transform;

			//Add the cloud to our cloudInstances
			cloudInstances [i] = cloud;
		}
		Debug.Log (cloudInstances.Length);
	}

		void Update(){

			//Iterate over all cloud objects in the background
			foreach(GameObject cloud in cloudInstances){
				// get scale and position of each cloud
			float scaleVal = cloud.transform.localScale.x;
			Vector3 cPos = cloud.transform.position;

				//Move larger clouds faster
				cPos.x -= Time.deltaTime * speed * scaleVal;

			if(cPos.x < cloudPosMin.x){
				cPos.x = cloudPosMax.x;
			}
			cloud.transform.position = cPos;
			}
		}
}






