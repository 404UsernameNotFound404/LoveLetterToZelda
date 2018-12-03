using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 10;
	public float swordSpeed;
	private float MoveVert;
	private float MoveHor;

	public Animator playerAnimation;

	Rigidbody2D RB;

	public Camera cam;

	public GameObject transationToBeach;
	public GameObject transationToTims;

	public GameObject camPositionForBeach;
	public GameObject camPositionForTims;
	public GameObject camPositionForStarting;
	public GameObject camPositionForBeach2;
	public GameObject camPositionForPathToLair;
	public GameObject camPositionForPathToLair2;
	public GameObject camPositionForPathToStairs;
	public GameObject wallForBeach2;
	public GameObject camPositionForBoss;
	public GameObject spawnPointForPlayerBoss;
	//public GameObject triggerForEnenmyBeach2;

	public GameObject enemyBeach2;
	public GameObject enemyFirstOfPath;
	public GameObject enemySecondOfPath;

	public Rigidbody2D teleportEnemy;
	public Rigidbody2D sword;

	public GameObject firePositionUp;
	public GameObject firePositionDown;
	public GameObject firePositionLeft;
	public GameObject firePositionRight;

	public GameObject spawnPointBeach2;

	float spawnTime = 0; 

	Vector3 startingPositionBeach2;

	float toDestroy = 10000.00f;

	public gamePaused pausedScript;
	private bool gamePaused;

	public GameObject TextBoxTims;

	private float fireRate = 0;

	public GameObject startingDilaouge;

	public bool bossBatleCamera = false;
	

	void Start()
	{
		startingDilaouge.SetActive(true);
		DialgougeManger dilMan = startingDilaouge.GetComponent<DialgougeManger>();
		dilMan.Awake();
		dilMan.Starttext();
		RB = GetComponent<Rigidbody2D>(); 
	}

	void FixedUpdate()
	{
		if (pausedScript.isTheGamePaused == false)
		{
			bool MoveRight = Input.GetButton("Right");
			bool MoveLeft = Input.GetButton("Left");
			bool MoveDown = Input.GetButton("Down");
			bool MoveUp = Input.GetButton("Up");
			bool Shoot = Input.GetButton("Fire1");

			if (!MoveRight && !MoveLeft)
			{
				MoveVert = 0;
			}
			if (!MoveUp && !MoveDown)
			{
				MoveHor = 0;
			}
			if (MoveUp)
			{
				playerAnimation.SetInteger("whichAnimation", 0);
				MoveHor = speed;
			}
			if (MoveDown)
			{
				playerAnimation.SetInteger("whichAnimation", 2);
				MoveHor = speed * -1;
			}
			if (MoveRight)
			{
				playerAnimation.SetInteger("whichAnimation", 1);
				MoveVert = speed;
			}
			if (MoveLeft)
			{
				playerAnimation.SetInteger("whichAnimation", 3);
				MoveVert = speed * -1;
			}
			if (Shoot && Time.time > fireRate)
			{
				fireRate = Time.time + 0.5f;
				Rigidbody2D PFSword;
				int directionFacing = playerAnimation.GetInteger("whichAnimation");
				switch (directionFacing)
				{
					case 0:
						PFSword = Instantiate(sword, firePositionUp.transform.position, firePositionUp.transform.rotation) as Rigidbody2D;
						PFSword.velocity = new Vector2(0, swordSpeed);
						break;
					case 1:
						PFSword = Instantiate(sword, firePositionRight.transform.position, firePositionRight.transform.rotation) as Rigidbody2D;
						PFSword.velocity = new Vector2(swordSpeed,0);
						PFSword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
						break;
					case 2:
						PFSword = Instantiate(sword, firePositionDown.transform.position, firePositionDown.transform.rotation) as Rigidbody2D;
						PFSword.velocity = new Vector2(0, -swordSpeed);
						break;
					case 3:
						PFSword = Instantiate(sword, firePositionLeft.transform.position, firePositionLeft.transform.rotation) as Rigidbody2D;
						PFSword.velocity = new Vector2(-swordSpeed,0);
						PFSword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
						break; 
				}
			}

			Vector2 CurrentPosition = RB.position;
			CurrentPosition = new Vector2(CurrentPosition.x + MoveVert, CurrentPosition.y + MoveHor);
			RB.MovePosition(CurrentPosition);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (pausedScript.isTheGamePaused == false)
		{
			float camOffset = 1.25f;
			if (col.gameObject.CompareTag("TransationToTims"))
			{
				Vector3 timsPosition = new Vector3(camPositionForTims.transform.position.x, camPositionForTims.transform.position.y, -10.0f);
				cam.transform.position = timsPosition;
			}
			if (col.gameObject.CompareTag("TransationToBeach"))
			{
				Vector3 beachPostion = new Vector3(camPositionForBeach.transform.position.x, camPositionForBeach.transform.position.y, -10.0f);
				cam.transform.position = beachPostion;
				enemyFirstOfPath.SetActive(false);
			}
			if (col.gameObject.CompareTag("TransationToStarting"))
			{
				Vector3 startingPosition = new Vector3(camPositionForStarting.transform.position.x, camPositionForStarting.transform.position.y, -10.0f);
				cam.transform.position = startingPosition;
			}
			if (col.gameObject.CompareTag("TransationToBeach2"))
			{
				Vector3 startingPositionBeach2 = new Vector3(camPositionForBeach2.transform.position.x, camPositionForBeach2.transform.position.y, -10.0f);
				cam.transform.position = startingPositionBeach2;
				if (enemyBeach2.activeSelf == false)
				{
					enemyBeach2.SetActive(true);
				}
				else
				{
					enemyBeach2.SetActive(false);
				}
			}
			if (col.gameObject.CompareTag("TransationToPathToLair1"))
			{
				Vector3 startingPositionPathToLair = new Vector3(camPositionForPathToLair.transform.position.x - camOffset, camPositionForPathToLair.transform.position.y, -10.0f);
				cam.transform.position = startingPositionPathToLair;
				enemyFirstOfPath.SetActive(true);
				enemySecondOfPath.SetActive(false);
			}
			if (col.gameObject.CompareTag("TransationToPathToLair2"))
			{
				Vector3 startingPositionPathToLair2 = new Vector3(camPositionForPathToLair2.transform.position.x, camPositionForPathToLair2.transform.position.y, -10.0f);
				cam.transform.position = startingPositionPathToLair2;
				enemySecondOfPath.SetActive(true);
				enemyFirstOfPath.SetActive(false);

			}
			if (col.gameObject.CompareTag("TransationToStairs"))
			{
				Vector3 startingPositionPathToStairs = new Vector3(camPositionForPathToStairs.transform.position.x, camPositionForPathToStairs.transform.position.y, -10.0f);
				cam.transform.position = startingPositionPathToStairs;
				enemySecondOfPath.SetActive(false);
			}
			if (col.gameObject.CompareTag("Enemy"))
			{
				Vector2 hitBack = new Vector2(gameObject.transform.position.x + 10f, gameObject.transform.position.y + 10f);
				RB.MovePosition(hitBack);
				Debug.Log("hit");
			}
			if (col.gameObject.CompareTag("TransationToTalkToTims"))
			{
				TextBoxTims.SetActive(true);
			}
			if (col.gameObject.CompareTag("TransationForBoss"))
			{
				gameObject.transform.position = new Vector3(spawnPointForPlayerBoss.transform.position.x, spawnPointForPlayerBoss.transform.position.y,spawnPointForPlayerBoss.transform.position.z);
				cam.transform.position = new Vector3(camPositionForBoss.transform.position.x,camPositionForBoss.transform.position.y,-10);
                cam.orthographicSize = 14;
				//bossBatleCamera = true;
			}
		}
	}
}

