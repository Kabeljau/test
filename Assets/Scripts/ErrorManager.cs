using UnityEngine;
using System.Collections;

public class ErrorManager : MonoBehaviour {

	public Transform[] errorPoints;

	public GameObject obj_spawn;
	public GameObject obj_twitch;
	public GameObject obj_unicorn;
	private AudioSource audio_twitch;
	private AudioSource audio;

	private GameObject cam;


	public int numTrees;
	
	public GameObject[] treePrefabs;
	
	public Vector3 treePosMin;
	public Vector3 treePosMax;
	public float minScale;
	public float maxScale;
	private GameObject[] treeInstances;
	public GameObject treeParent;
	public static bool allTreesPink;
	private Trees[] trees;

	bool runs_1;
	bool runs_2;
	bool runs_3;
	bool runs_4;
	bool runs_5;

	void Start(){
		runs_1 = false;
		runs_2 = false;
		runs_3 = false;
		runs_4 = false;
		runs_5 = false;
		GameManager.OnScoreChange += activateError;
		Trees.onTreeTurnPink += checkTrees;
		cam = GameObject.FindWithTag ("MainCamera");
		audio = gameObject.GetComponent<AudioSource> ();
		spawnTrees ();
	}

	void activateError(){

		if(GameManager.score > 20 && !runs_1){  //how to tell him to call it only once??
		
			runs_1 = true;
		}else if(GameManager.score > 40 && !runs_2){
			StartCoroutine(twitch (errorPoints[0]));
			runs_2 = true;
		}else if(GameManager.score > 60 && !runs_3){
			pfudor (errorPoints[1]);
			runs_3 = true;
		}else if(GameManager.score > 80 && !runs_4){
			StartCoroutine(spawn (errorPoints[2]));
			audio.Play ();
			runs_4 = true;
		}else if(GameManager.score > GameManager.s.minScore-1  &&!runs_5){
				flipCamera();
			runs_5 = true;
		}
	}

	private IEnumerator twitch(Transform pos){
		GameObject obj = Instantiate (obj_twitch, pos.position, pos.rotation) as GameObject;
		audio_twitch = obj.GetComponent<AudioSource> ();
		Debug.Log ("twitch is running");
		float counter = 0;
		float time = Random.Range (0, 1.2f);
		while (true) {
			obj.transform.position += new Vector3 (0.2f, 0.4f, 0);
			counter += 0.03f;
			if(counter > time){
				obj.transform.position = pos.position;
				counter = 0;
				audio_twitch.Stop ();
				audio_twitch.Play ();
				time = Random.Range (0, 1.6f);
			}
			yield return null;
		}


	}



	private IEnumerator spawn(Transform pos){
		Debug.Log ("spawn is running");
		while (true) {
			Instantiate (obj_spawn, pos.position, pos.rotation);
			yield return new WaitForSeconds(0.05f);
		}
	}

	private void flipCamera(){
		Debug.Log ("flips Camera");
		cam.transform.Rotate (0, 0, -200);

	}

	private void pfudor(Transform pos){
		Debug.Log ("pfudor is running");
		Instantiate (obj_unicorn, pos.position, pos.rotation);
	}

	private void spawnTrees(){
		//Create an array to hold our cloud instances
		treeInstances = new GameObject[numTrees];

		trees = new Trees[numTrees];
		
		
		//Iterate through array and create each cloud
		GameObject tree;
		for (int i=0; i< treeInstances.Length; i++) {
			
			//Pick a random cloud prefab between 0 and cloudPrefabs.length - 1
			int PrefabNum = Random.Range (0, treePrefabs.Length - 1);
			
			
			//Instantiate a cloud and position it accordingly 	//Scale the cloud
			
			tree = Instantiate (treePrefabs [PrefabNum]);
			
			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range (treePosMin.x, treePosMax.x);
			cPos.y = Random.Range (treePosMin.y, treePosMax.y);
			//float scaleFactor = Random.Range (minScale, maxScale);
			
			//Leissler
			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp (minScale, maxScale, scaleU);
			
			cPos.y = Mathf.Lerp (treePosMin.y, cPos.y, scaleU);
			
			cPos.z = 0;
			
			tree.transform.position = cPos;
			tree.transform.localScale = Vector3.one * scaleVal;
			
			//make the cloud a child of the clouds parent
			tree.transform.parent = treeParent.transform;
			
			//Add the cloud to our cloudInstances
			treeInstances [i] = tree;
			
			trees[i] = treeInstances[i].GetComponent<Trees>();
		}
	}

	void checkTrees(){
//		Debug.Log ("checksTrees");
		allTreesPink = true;
		for (int i = 0; i<trees.Length; i++) {
			if(!trees[i].isPink){
				allTreesPink = false;
			}
		}
		if(allTreesPink){
			Debug.Log ("all trees are pink");
		}
	}
}
