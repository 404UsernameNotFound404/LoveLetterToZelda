using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForCamera : MonoBehaviour {

	public GameObject Player;

	public Player playerScript;

	public GameObject topWallForBoss;
	public GameObject bottomWallForBoss;
	public GameObject rightWallForBoss;
	public GameObject leftWallForBoss;
	

	void Start()
	{
	}
	void Update()
	{
		if (playerScript.bossBatleCamera == true)
		{
			if(Player.transform.position.y != topWallForBoss.transform.position.y && Player.transform.position.y != bottomWallForBoss.transform.position.y && Player.transform.position.x != rightWallForBoss.transform.position.x && Player.transform.position.x != leftWallForBoss.transform.position.x)
			{
				Debug.Log("cam position" + Player.transform.position.y);
				Debug.Log("top wall" + topWallForBoss.transform.position.x);
				gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 1);
			}
		}
	}
	
}
