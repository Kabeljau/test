using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public GameObject target;

	void Update(){
		if (target == null) {
			return;
		}
		GetComponent<NavMeshAgent> ().SetDestination (target.transform.position);
	}
}
