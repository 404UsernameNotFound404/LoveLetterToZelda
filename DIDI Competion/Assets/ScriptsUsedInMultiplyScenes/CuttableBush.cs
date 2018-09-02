using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableBush : MonoBehaviour {

	public Rigidbody2D RB;
	public SpriteRenderer SR;
	private BoxCollider2D BC;

	void Start ()
	{
		RB = gameObject.GetComponent<Rigidbody2D>();
		SR = gameObject.GetComponent<SpriteRenderer>();
		BC = gameObject.GetComponent<BoxCollider2D>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Sword"))
		{
			Debug.Log("andy samberg");
			//gameObject.SetActive(false);
			Destroy(RB);
			SR.enabled = true;
			BC.enabled = false;
		}
	}
}
