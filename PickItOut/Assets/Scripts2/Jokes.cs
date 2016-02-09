using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jokes : MonoBehaviour {

	string[] jokes = {
		"I gotta eat too ya know...",
		"My rent ain't cheap!",
		"An ad a day, keeps my landlord away!",
		"Like you got anything else going on...",
		"You won't, no balls.",
		"Maybe it will be a funny one!"
	};

	// Use this for initialization
	void Awake () {
		ChangeJoke ();
		InvokeRepeating ("ChangeJoke", 30f, 30f);
	}

	public void ChangeJoke() {
		GetComponent<Text> ().text = jokes [ Random.Range(0, jokes.Length)];
	}

}
