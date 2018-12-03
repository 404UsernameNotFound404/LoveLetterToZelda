using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePaused : MonoBehaviour
{
	public DialgougeManger startingText;
	public DialougeMangerConvo talkingWithTim;

	public bool isTheGamePaused;

	void Start ()
	{
		
	}

	void Update ()
	{
		if (startingText.isPaused == true || talkingWithTim.isPaused == true)
		{
			Debug.Log("game is paused with start text");
			isTheGamePaused = true;
		}
		else
		{
			isTheGamePaused = false;
		}
	}
}
