using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollDiceBehavior : MonoBehaviour {

	Image diceImg1;
	Image diceImg2;

	Button rollBtn;
	Button backBtn;

	int one;
	int two;
	
	public int[] chances = {1, 1, 1, 1, 1, 1};

	// Use this for initialization
	void Awake () {
		diceImg1 = transform.FindChild ("Content").FindChild ("DiceImgs").FindChild("Dice1").GetComponent<Image>();
		diceImg2 = transform.FindChild ("Content").FindChild ("DiceImgs").FindChild("Dice2").GetComponent<Image>();
		rollBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("RollBtn").GetComponent<Button>();
		backBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("BackBtn").GetComponent<Button>();

		rollBtn.onClick.AddListener (() => {
			RollDice();
		});
		backBtn.onClick.AddListener (() => {
			DestroyImmediate(gameObject);
		});
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void RollDice() {
		rollBtn.interactable = false;

		float sum = SumChances ();
		int[] newChances = {0, 0, 0, 0, 0, 0};
		for (int i = 0; i < newChances.Length; i++) {
			for (int j = 0; j<i; j++) {
				newChances[i] += chances[j];
			}
		}

		float choice = Random.Range (0f, 1f);
		int currentChoice = 0;
		for (int i = 0; i < chances.Length; i++) {
			if (newChances[i]/sum < choice) {
				currentChoice = i;
			}
		}
		one = currentChoice+1;
		Invoke ("Dice1LandOnNumber", 1f);

		choice = Random.Range (0f, 1f);
		currentChoice = 0;
		for (int i = 0; i < chances.Length; i++) {
			if (newChances[i]/sum < choice) {
				currentChoice = i;
			}
		}
		two = currentChoice+1;
		Invoke ("Dice2LandOnNumber", 1f);

		InvokeRepeating ("VisualDiceChange", 0.15f, 0.15f);
	}

	public int SumChances() {
		int sum = 0;
		foreach (int i in chances) {
			sum += i;
		}
		return sum;
	}

	public void Dice1LandOnNumber() {
		CancelInvoke("VisualDiceChange");
		rollBtn.interactable = true;
		diceImg1.sprite = Resources.Load<Sprite> (""+one) as Sprite;
	}
	public void Dice2LandOnNumber() {
		CancelInvoke("VisualDiceChange");
		rollBtn.interactable = true;
		diceImg2.sprite = Resources.Load<Sprite> (""+two) as Sprite;
	}

	public void VisualDiceChange () {
		diceImg1.sprite = Resources.Load<Sprite> (""+Random.Range(1,7)) as Sprite;
		diceImg2.sprite = Resources.Load<Sprite> (""+Random.Range(1,7)) as Sprite;
	}
}
