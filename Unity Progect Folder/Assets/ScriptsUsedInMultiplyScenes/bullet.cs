using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

	Rigidbody2D rb;
	Vector2 pushspeed;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
		if (col.gameObject.CompareTag("walls"))
		{
			Destroy(gameObject);
		}
	}
}
