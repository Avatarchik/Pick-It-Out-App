using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dice : MonoBehaviour {

	public Button die1;
	public Button die2;

	public Sprite[] possibleStates = new Sprite[6];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RollDice() {
		RollDie (die1);
		RollDie (die2);
	}

	void RollDie(Button die) {
		// Get total of all chance values.
		int chanceSum = 0;
		foreach (int i in Globals.DICE_CHANCES) {
			chanceSum += i;
		}

		// Generate random number between 0 and chanceSum
		int r = Random.Range (0, chanceSum);

		// Loop through chances in Globals to find which value was rolled
		int diceNum = -1;
		int j = 0;
		for (int i = 0; i < Globals.DICE_CHANCES.Length; i++) {
			if (j >= r) {
				die.image.sprite = possibleStates[i];
				return;
			}
			j += Globals.DICE_CHANCES[i];
		}
	}
}
