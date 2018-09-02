using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeMangerConvo : MonoBehaviour
{
	public string name1;
	public string name2;

	public string[] text;

	public Text TextBox;

	private Queue<string> QueueFortext;

	public bool isPaused;

	void Start ()
	{
		QueueFortext = new Queue<string>();
		StartConvo();
	}

	public void StartConvo()
	{
		QueueFortext.Clear();

		foreach (string sentences in text)
		{
			QueueFortext.Enqueue(sentences);
		}
		DisplaySentences();
	}
	public void DisplaySentences()
	{
		if (QueueFortext.Count == 0)
		{
			gameObject.SetActive(false);
			isPaused = false;
			Debug.Log("end of convo");
		}
		else
		{
			isPaused = true;
			if (QueueFortext.Count % 2 != 1)
			{
				StartCoroutine(StartTyping(QueueFortext.Dequeue(), name1));
				//Debug.Log(name1 + QueueFortext.Dequeue());
			}
			else
			{
				StartCoroutine(StartTyping(QueueFortext.Dequeue(), name2));
				//Debug.Log(name2 + QueueFortext.Dequeue());
			}
		}
	}
	IEnumerator StartTyping(string text, string name)
	{
		TextBox.text = "";
		TextBox.text = name + "\n";
		foreach (char ch in text.ToCharArray())
		{
			TextBox.text = TextBox.text + ch;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
