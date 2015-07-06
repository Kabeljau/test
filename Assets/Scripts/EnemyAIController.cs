/*using UnityEngine;
using System.Collections;
using Prime31.StateKit; //--> the one we imported (github)
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections.Generic;

public class EnemyAIController : MonoBehaviour {

	public Transform target;

	public List<Transform> wayPoints = new List<Transform>();

	private SKStateMachine<EnemyAIController> _machine; //in angular brackets there is always the classe you're attached to

	public NavMeshAgent agent{ get; private set;} //is a property--> everybody can get the values from it but nobody except for THIS very class can set any values
	public ThirdPersonCharacter character{ get; private set;}

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
		character = GetComponent<ThirdPersonCharacter> ();

		_machine = new SKStateMachine<EnemyAIController> (this, new EnemyAIPatrol()); //enemyaipatrol is a class that does not yet exist
		_machine.addState (new EnemyAIChase());
	}

	void Update(){
		_machine.update (Time.deltaTime);
	}

}*/
