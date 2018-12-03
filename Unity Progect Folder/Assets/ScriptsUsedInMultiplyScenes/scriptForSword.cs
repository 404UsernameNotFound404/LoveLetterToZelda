using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptForSword : MonoBehaviour
{
	Rigidbody2D rb;
	Vector2 pushspeed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("enemy"))
		{
			Debug.Log("Hit Enenmy"); 
			Destroy(gameObject);
		}
        if(col.gameObject.CompareTag("Solid Objects"))
        {
            Debug.Log("Hit somthign");
            Destroy(gameObject);
        }
	}
	private void Update()
	{
		/*if (Time.time > 5.0f)
		{
			Debug.Log("Destroy");
			Destroy(gameObject);
		}
		*/
	}
}
