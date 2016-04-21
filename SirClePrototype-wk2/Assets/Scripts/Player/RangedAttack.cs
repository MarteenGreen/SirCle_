using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {
	
	private PlayerMove playerMove;
	private CharacterMotor characterMotor;

	public GameObject ProjectileObject;
	public Transform SpawnPosition;

	public float WaitBeforeFiring =0.2f;
	public float CooldownTime =1f;

	private GameObject LastFiredProjectile;
	
	private bool CanShoot;

	// Use this for initialization
	void Start () {
		//We're supposed to be on the same gameobject as the PlayerMove...
		//I'll need to talk with the animator so I'll just grab a reference from him.
		playerMove = GetComponent<PlayerMove>();
		CanShoot=true;
	}
	
	//Runs every frame
	void Update () {
		//If the player pressed the P key & isn't on CoolDown
		if (Input.GetKeyDown(KeyCode.P)&&CanShoot) {				
			//Now start a coroutine that will wait before firing.
			StartCoroutine(WaitAndFire(WaitBeforeFiring));
			CanShoot=false;
			StartCoroutine(CoolDown(CooldownTime));			
		}
	}

	IEnumerator WaitAndFire(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Vector3 spawnPos = Vector3.zero;

		spawnPos = SpawnPosition.position;		

		//Instantiate mustache on our spawn position.
		LastFiredProjectile = GameObject.Instantiate(ProjectileObject,spawnPos,gameObject.transform.rotation) as GameObject;

		//Using other script to fire our stache.
		LastFiredProjectile.GetComponent<ScriptProjectile>().Initialize();
	}
	
	//Stops the player from spamming shots.
	IEnumerator CoolDown(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		CanShoot=true;
	}
}
