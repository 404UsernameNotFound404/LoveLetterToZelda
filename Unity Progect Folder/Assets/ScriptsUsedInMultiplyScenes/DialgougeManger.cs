using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialgougeManger : MonoBehaviour
{
	public string[] text;

	private Queue<string> QueueFortext;

	public Text textBox;

	public bool isPaused;


	public void Awake()
	{
		QueueFortext = new Queue<string>();
	}

	public void Starttext()
	{
		Debug.Log("StartText()");
		QueueFortext.Clear();

		foreach (string sentences in text)
		{
			QueueFortext.Enqueue(sentences);
		}
		DisplayTextFortext();
	}
	public void DisplayTextFortext()
	{
		Debug.Log("Hello");
		if (QueueFortext.Count == 0)
		{
			isPaused = false;
			Debug.Log("end of convo");
			gameObject.SetActive(false);
		}
		else
		{
			isPaused = true;
			StartCoroutine(StartTyping(QueueFortext.Dequeue()));
		}
	}
	IEnumerator StartTyping(string text)
	{
		textBox.text = "";
		foreach (char ch in text.ToCharArray())
		{
			textBox.text = textBox.text + ch;
			yield return new WaitForSeconds(0.05f);
		}
	}

}

		

		
