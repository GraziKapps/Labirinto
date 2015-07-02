﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


[RequireComponent(typeof(Rigidbody))]
public class NPCControl : MonoBehaviour {

	public GameObject player;
	public Transform[] path;
	private FSMSystem fsm;
	
	public void SetTransition(Transition t) { fsm.PerformTransition(t); }
	
	public void Start()
	{
		Debug.Log("START");
		//player = GameObject.FindGameObjectWithTag ("Player");
		MakeFSM();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("UPDATE");
		
	}
	
	public void FixedUpdate()
	{
		//Debug.Log("FIXED UPDATE");
		fsm.CurrentState.Reason(player, gameObject);
		fsm.CurrentState.Act(player, gameObject);
	}
	
	// The NPC has two states: FollowPath and ChasePlayer
	// If it's on the first state and SawPlayer transition is fired, it changes to ChasePlayer
	// If it's on ChasePlayerState and LostPlayer transition is fired, it returns to FollowPath
	private void MakeFSM()
	{
		FollowPathState follow = new FollowPathState(path);
		follow.AddTransition(Transition.SawPlayer, StateID.ChasingPlayer);
		
		ChasePlayerState chase = new ChasePlayerState();
		chase.AddTransition(Transition.LostPlayer, StateID.FollowingPath);
		
		fsm = new FSMSystem();
		fsm.AddState(follow);
		fsm.AddState(chase);
	}

}

public class FollowPathState : FSMState
{
	private int currentWayPoint;
	private Transform[] waypoints;
	
	public FollowPathState(Transform[] wp) 
	{ 
		waypoints = wp;
		currentWayPoint = 0;
		stateID = StateID.FollowingPath;
	}
	
	public override void Reason(GameObject player, GameObject npc)
	{

		Debug.Log("REASON");
		// If the Player passes less than 15 meters away in front of the NPC
		RaycastHit hit;
		if (Physics.Raycast(npc.transform.position, npc.transform.forward, out hit, 15F))
		{
			Debug.Log("MENOS DE 15 METROS");
			if (hit.transform.gameObject.tag == "Player"){
				npc.GetComponent<NPCControl>().SetTransition(Transition.SawPlayer);
				Debug.Log("VIU JOGADOR");
			}
		}
	}
	
	public override void Act(GameObject player, GameObject npc)
	{
		Debug.Log("ACT");
		// Follow the path of waypoints
		// Find the direction of the current way point 
		//Vector3 vel = npc.rigidbody.velocity;
		Vector3 vel = npc.GetComponent<Rigidbody>().velocity;
		Vector3 moveDir = waypoints[currentWayPoint].position - npc.transform.position;
		
		if (moveDir.magnitude < 1)
		{
			currentWayPoint++;
			if (currentWayPoint >= waypoints.Length)
			{
				currentWayPoint = 0;
			}
		}
		else
		{
			vel = moveDir.normalized * 10;
			
			// Rotate towards the waypoint
			npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
			                                          Quaternion.LookRotation(moveDir),
			                                          5 * Time.deltaTime);
			npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);
			
		}
		
		// Apply the Velocity
		//npc.rigidbody.velocity = vel;
		npc.GetComponent<Rigidbody> ().velocity = vel;
	}
	
} // FollowPathState

public class ChasePlayerState : FSMState
{
	public ChasePlayerState()
	{
		stateID = StateID.ChasingPlayer;
	}
	
	public override void Reason(GameObject player, GameObject npc)
	{
		// If the player has gone 30 meters away from the NPC, fire LostPlayer transition
		if (Vector3.Distance (npc.transform.position, player.transform.position) >= 30) {
			npc.GetComponent<NPCControl> ().SetTransition (Transition.LostPlayer);
			Debug.Log("NAO ESTA VENDO O JOGADOR");
		}
	}
	
	public override void Act(GameObject player, GameObject npc)
	{
		// Follow the path of waypoints
		// Find the direction of the player 		
		//Vector3 vel = npc.rigidbody.velocity;
		Vector3 vel = npc.GetComponent<Rigidbody>().velocity;
		Vector3 moveDir = player.transform.position - npc.transform.position;
		
		// Rotate towards the waypoint
		npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
		                                          Quaternion.LookRotation(moveDir),
		                                          5 * Time.deltaTime);
		npc.transform.eulerAngles = new Vector3(0, npc.transform.eulerAngles.y, 0);
		
		vel = moveDir.normalized * 10;
		
		// Apply the new Velocity
		//npc.rigidbody.velocity = vel;
		npc.GetComponent<Rigidbody>().velocity = vel;
	}
	
} // ChasePlayerState