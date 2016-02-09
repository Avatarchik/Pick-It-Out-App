using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spinner : MonoBehaviour {
	
	enum SectionColors {Orange, Yellow, Green, Blue, Indigo, Violet, Pink, Red};
	public int[] sectionThresholds = {0, 45, 90, 135, 180, 225, 270, 315};

	public float currentRestingRotation = 0f;

	public string[] options = new string[8];
	public InputField[] optionFields = new InputField[8];
	public GameObject resultsCard;
	public Text resultText;
	public Image resultsHeader;

	private bool isSpinning = false;

	// Use this for initialization
	void Start () {
		options = Globals.gamestate.currentSpinnerOptions;
		transform.eulerAngles = new Vector3(0, 
		                                    0,
		                                    Globals.gamestate.currentSpinnerRotaion);
		currentRestingRotation = Globals.gamestate.currentSpinnerRotaion;
	}

	private int SelectSection() {
		// Get total of all chance values.
		int chanceSum = 0;
		foreach (int i in Globals.gamestate.SPINNER_CHANCES) {
			chanceSum += i;
		}
		
		// Generate random number between 0 and chanceSum
		int r = Random.Range (0, chanceSum);
		
		// Loop through chances in Globals to find which value was section was landed on.
		int j = 0;
		for (int i = 0; i < Globals.gamestate.SPINNER_CHANCES.Length; i++) {
			if (j >= r) {
				return i;
			}
			j += Globals.gamestate.SPINNER_CHANCES[i];
		}
		return -1;
	}

	public void Spin() {
		int section = SelectSection ();
		int targetZRot = sectionThresholds [section] + Random.Range (0, 44);
		int degreesToSpin = 0;
		if (targetZRot < transform.eulerAngles.z) {
			degreesToSpin = (360 - (int)transform.eulerAngles.z) + targetZRot + 360;
		} else {
			degreesToSpin = (targetZRot - (int)transform.eulerAngles.z) + 360;
		}
		StartCoroutine (ExecuteSpin (degreesToSpin));
	}

	IEnumerator ExecuteSpin(int degrees) {
		float t = 0f;
		while (t < Globals.SPIN_TIME) {
			t += Time.deltaTime;
			transform.eulerAngles = new Vector3(0, 
			                                    0,
			                                    currentRestingRotation + ((float)degrees * (t/Globals.SPIN_TIME)));
			yield return null;
		}
		currentRestingRotation = (currentRestingRotation + degrees) % 360;
		transform.eulerAngles = new Vector3(0, 
		                                    0,
		                                    currentRestingRotation);
		Globals.gamestate.currentSpinnerRotaion = currentRestingRotation;
		Globals.Save ();
		ShowResults ();
	}

	public void ShowResults() {
		//
		resultsCard.SetActive (true);
		//
		float rot = currentRestingRotation;
		int section = (((int)rot) / 45);
		resultText.text = options [section];

		switch (section) {
		case (int)SectionColors.Orange:
			resultsHeader.color = new Color(0.9f,0.5f,0);
			break;
		case (int)SectionColors.Yellow:
			resultsHeader.color = new Color(0.9f, 0.82f, 0.13f);
			break;
		case (int)SectionColors.Green:
			resultsHeader.color = new Color(0.21f, 0.59f, 0.21f);
			break;
		case (int)SectionColors.Blue:
			resultsHeader.color = new Color(0.167f, 0.44f, 0.9f);
			break;
		case (int)SectionColors.Indigo:
			resultsHeader.color = new Color(0.15f, 0.22f, 0.61f);
			break;
		case (int)SectionColors.Violet:
			resultsHeader.color = new Color(0.78f, 0.15f, 0.88f);
			break;
		case (int)SectionColors.Pink:
			resultsHeader.color = new Color(0.81f, 0.02f, 0.29f);
			break;
		case (int)SectionColors.Red:
			resultsHeader.color = new Color(0.9f, 0.22f, 0.22f);
			break;
		}
	}

	public void SetOptions() {
		for (int i = 0; i < options.Length; i++) {
			options[i] = optionFields[i].text;
			if (options[i].Equals("")) {
				options[i] = "None";
			}
		}
		Globals.gamestate.currentSpinnerOptions = options;
		Globals.Save ();
	}
}
