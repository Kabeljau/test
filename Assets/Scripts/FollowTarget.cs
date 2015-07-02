using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public GameObject target;

	void Update(){

		GetComponent<NavMeshAgent> ().SetDestination (target.transform.position);
	}
}
