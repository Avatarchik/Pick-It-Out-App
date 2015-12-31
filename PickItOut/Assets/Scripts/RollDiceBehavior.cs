using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollDiceBehavior : MonoBehaviour {

	Image diceImg1;
	Image diceImg2;

	public GridLayoutGroup diceGrid;

	Button rollBtn;
	Button backBtn;

	int one;
	int two;
	public int vis1;
	public int vis2;
	
	public int[] chances = {1, 1, 1, 1, 1, 1};

	// Use this for initialization
	void Awake () {
		diceImg1 = transform.FindChild ("Content").FindChild ("DiceImgs").FindChild("Dice1").GetComponent<Image>();
		diceImg2 = transform.FindChild ("Content").FindChild ("DiceImgs").FindChild("Dice2").GetComponent<Image>();
		rollBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("RollBtn").GetComponent<Button>();
		backBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild("BackBtn").GetComponent<Button>();

		vis1 = 1;
		vis2 = 1;

		rollBtn.onClick.AddListener (() => {
			RollDice();
		});
		backBtn.onClick.AddListener (() => {
			PlayRandSound();
			DestroyImmediate(gameObject);
		});

		UpdateGridCellSize ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ToggleTwoDice(bool b) {
		if (b) {
			diceImg2.gameObject.SetActive(true);
		} else {
			diceImg2.gameObject.SetActive(false);
		}
		UpdateGridCellSize ();
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

		vis1 = one;
		vis2 = two;

		InvokeRepeating ("VisualDiceChange", 0.15f, 0.15f);
		InvokeRepeating ("PlayRandSound", 0.15f, 0.15f);
	}

	public int SumChances() {
		int sum = 0;
		foreach (int i in chances) {
			sum += i;
		}
		return sum;
	}

	public void Dice1LandOnNumber() {
		if (!diceImg2.IsActive ()) {
			CancelInvoke ("VisualDiceChange");
			CancelInvoke ("PlayRandSound");
			rollBtn.interactable = true;
		}
		diceImg1.sprite = Resources.Load<Sprite> (""+one) as Sprite;
	}
	public void Dice2LandOnNumber() {
		CancelInvoke("VisualDiceChange");
		CancelInvoke ("PlayRandSound");
		rollBtn.interactable = true;
		diceImg2.sprite = Resources.Load<Sprite> (""+two) as Sprite;
	}

	public void VisualDiceChange () {
		int i1 = Random.Range (1, 7);
		int i2 = Random.Range (1, 7);
		if (vis1 == i1 || vis2 == i2) {
			VisualDiceChange ();
		} else {
			vis1 = i1;
			vis2 = i2;
			diceImg1.sprite = Resources.Load<Sprite> (""+i1) as Sprite;
			diceImg2.sprite = Resources.Load<Sprite> (""+i2) as Sprite;
		}
	}

	void UpdateGridCellSize() {
		if (diceImg2.IsActive ()) {
			diceGrid.cellSize = new Vector2 (Screen.width/3f, Screen.height/5f);
		} else {
			diceGrid.cellSize = new Vector2 (Screen.width/2f, Screen.height/4.5f);
		}
	}

	public void PlayRandSound() {
		AudioClip sfx = Resources.Load ("Sound/"+Random.Range(1,10)) as AudioClip;
		AudioSource.PlayClipAtPoint (sfx, Vector3.zero);
	}
}
