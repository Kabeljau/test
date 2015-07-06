/*using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class EnemyAIPatrol : SKState<EnemyAIController>  {

	public override void begin(){
		Debug.Log ("startedPatrolling");
	}
	
	public override void reason ()
	{
		//can we see the player? if so, go to chasing state
		
		RaycastHit hit;
		if(Physics.Raycast(_context.transform.position, _context.target.transform.position-_context.transform.position, out hit)){//context is the enemyAiCOnroller//pos it starts, pos of direction, fills the hit with out
			if(hit.collider.tag == "Player"){
				_machine.changeState<EnemyAIChase>();
			}
		}
	}
}*/
