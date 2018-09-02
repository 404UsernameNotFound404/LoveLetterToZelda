using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForShooter : MonoBehaviour
{
	private Vector3 moveDistance;
	public float moveSpeed;
	public GameObject player;
	public LayerMask playermask;

	public GameObject beach2SceneTransation; 

	public Transform firePoint;
	float delay;
	float fireRate = 0;
	private float fireRateForShooting; 

	public Rigidbody2D bul;
	Rigidbody2D RB;

	public int lives = 3;

	public bool xEqualsFalse = false;

	void Start()
	{
		RB = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		/*
		if (player.transform.position.x < beach2SceneTransation.transform.position.y)
		{
			Debug.Log("DEACTVATE");
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
		}
		*/

		float distanceX;
		float distanceY;
		float distnaceXValue;
		float distanceYValue;
		int moveSpeed = 5;

		bool moveOrNah;
		bool moveOrNahY;
		bool CanShoot = false;
		

		Vector2 shootingDirection = new Vector2(0, 0);

		distanceX = 0; 
		Vector2 whichWayToShoot;

		for (int x = 0; x < 4; x++)
		{
			CanShoot = CanMove(10, x, gameObject.transform.position);
			if (CanShoot)
			{
				//RB.velocity = new Vector2(0, 0);
				switch (x)
				{
					case 0:
						whichWayToShoot = Vector2.down;
						gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
						shootingDirection = new Vector2(0, -moveSpeed);
						//Debug.Log("rotateDown");
						break;
					case 1:
						whichWayToShoot = Vector2.up;
						gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
						shootingDirection = new Vector2(0, moveSpeed);
						//Debug.Log("rotateup");
						break;
					case 2:
						whichWayToShoot = Vector2.right;
						gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
						shootingDirection = new Vector2(moveSpeed, 0);
						//Debug.Log("Rotate Right");
						break;
					case 3:
						whichWayToShoot = Vector2.left;
						gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
						shootingDirection = new Vector2(-moveSpeed, 0);
						//Debug.Log("Rotate Left");
						break;
				}//switch case for which direction it is shooting
				if (Time.time > fireRateForShooting)
				{
					//Debug.Log("entering fire stage");
					fireRateForShooting = Time.time + 0.5f;
					Rigidbody2D PFbullet;
					PFbullet = Instantiate(bul, firePoint.position, firePoint.rotation) as Rigidbody2D;
					PFbullet.velocity = shootingDirection;
				}
				break; 
			}//can shoot is true
		}
			if (!CanShoot)
			{
			if (xEqualsFalse == false)
			{

				//Debug.Log(gameObject.transform.position.x);
				//Debug.Log(player.transform.position.y + "player");
				fireRate = Time.time + 0.5f;
				distanceX = gameObject.transform.position.x - player.transform.position.x;
				if (gameObject.transform.position.x < player.transform.position.x)
				{
					//Debug.Log(gameObject.transform.position.x - player.transform.position.x);
					RB.velocity = new Vector2(2.5f, 0);
					//Debug.Log("5");
				}
				else
				{
					//Debug.Log("-5");
					RB.velocity = new Vector2(-2.5f, 0);
				}
			}
			else
			{
				//Debug.Log(gameObject.transform.position.x);
				//Debug.Log(player.transform.position.y + "player");
				fireRate = Time.time + 0.5f;
				distanceX = gameObject.transform.position.y - player.transform.position.y;
				if (gameObject.transform.position.y < player.transform.position.y)
				{
					//Debug.Log(gameObject.transform.position.x - player.transform.position.x);
					RB.velocity = new Vector2(0, 2.5f);
					//Debug.Log("5");
				}
				else
				{
					//Debug.Log("-5");
					RB.velocity = new Vector2(0,-2.5f);
				}
			}
			}//(!CanShoot)
	}//end of update loop 
	bool CanMove(float dis, int dir, Vector2 pos)
	{
		Vector2 direction = Vector2.down;
		Vector2 position = pos;
		float distance = dis;
		switch (dir)
		{
			case 0:
				direction = Vector2.down;
				break;
			case 1:
				direction = Vector2.up;
				break;
			case 2:
				direction = Vector2.right;
				break;
			case 3:
				direction = Vector2.left;
				break;
		}
		Debug.DrawRay(position, direction, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playermask);
		return hit;
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.CompareTag("Sword"))
		{
			lives--;
			if (lives == 0)
			{
				Destroy(gameObject);
			}
			Debug.Log("Hit Enemy life lost");
		}
	}
}


