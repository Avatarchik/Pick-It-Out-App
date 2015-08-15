using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CustomBehavior : MonoBehaviour {

	private List<string> choices;

	private Text currentChoice;
	private Button chooseBtn;
	private Button backBtn;

	private string upcomingChoice;
	private int[] chances = {1, 1, 1, 1, 1, 1, 1, 1};

	// Use this for initialization
	void Awake () {
		currentChoice = transform.FindChild ("Content").FindChild ("ChoicesBG").FindChild ("CurrentChoice").GetComponent<Text> ();
		chooseBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("ChooseBtn").GetComponent<Button>();
		backBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("BackBtn").GetComponent<Button>();
	}

	public void Init(List<string> c) {
		choices = c;

		chooseBtn.onClick.AddListener (() => {
			ChooseChoice();
		});
		backBtn.onClick.AddListener (() => {
			DestroyImmediate(gameObject);
		});
	}

	public void ChooseChoice() {
		chooseBtn.interactable = false;

		float sum = SumChances ();
		int[] newChances = new int[choices.Count];
		for (int i = 0; i < newChances.Length; i++) {
			newChances[i] = 0;
			for (int j = 0; j<i; j++) {
				newChances [i] += chances [j];
			}
		}
		
		float choice = Random.Range (0f, sum);
		int currentChoice = 0;
		for (int i = 0; i < newChances.Length; i++) {
			if (newChances [i] < choice) {
				currentChoice = i;
			}
		}
		upcomingChoice = choices[currentChoice];
		Invoke ("LandOnChoice", 1f);
		InvokeRepeating ("VisualChoiceChange", 0.1f, 0.1f);
	}

	public void LandOnChoice() {
		CancelInvoke("VisualChoiceChange");
		chooseBtn.interactable = true;
		currentChoice.text = upcomingChoice;
		print (upcomingChoice);
	}

	public int SumChances() {
		int sum = 0;
		for (int i = 0; i < choices.Count; i++) {
			sum += chances[i];
		}
		return sum;
	}

	public void VisualChoiceChange () {
		string newText = choices [Random.Range (0, choices.Count)];
		if (choices.Count > 1 && currentChoice.text.Equals (newText)) {
			VisualChoiceChange ();
		} else {
			currentChoice.text = newText;
		}
	}
}
