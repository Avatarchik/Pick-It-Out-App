using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dice : MonoBehaviour {

	public Button die1;
	public Button die2;

	public Sprite[] possibleStates = new Sprite[6];

	// Use this for initialization
	void Start () {
		die1.image.sprite = possibleStates[Globals.gamestate.currentDice1State];
		die2.image.sprite = possibleStates[Globals.gamestate.currentDice2State];
	}

	public void RollDice() {
		RollDie (die1, 1);
		RollDie (die2, 2);
	}

	void RollDie(Button die, int dieNum) {
		// Get total of all chance values.
		int chanceSum = 0;
		foreach (int i in Globals.gamestate.DICE_CHANCES) {
			chanceSum += i;
		}

		// Generate random number between 0 and chanceSum
		int r = Random.Range (0, chanceSum);

		// Loop through chances in Globals to find which value was rolled
		int j = 0;
		for (int i = 0; i < Globals.gamestate.DICE_CHANCES.Length; i++) {
			if (j >= r) {
				die.image.sprite = possibleStates[i];
				if (dieNum == 1) {
					Globals.gamestate.currentDice1State = i;
				} else {
					Globals.gamestate.currentDice2State = i;
				}
				Globals.Save();
				return;
			}
			j += Globals.gamestate.DICE_CHANCES[i];
		}
	}
}
