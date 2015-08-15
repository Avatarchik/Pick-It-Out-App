using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinFlipBehavior : MonoBehaviour {

	Image coinImg;
	Button flipBtn;
	Button backBtn;

	private bool isSpinning = false;
	float chance = 0.5f;

	void Awake() {
		coinImg = transform.FindChild ("Content").FindChild ("CoinBG").FindChild("CoinImg").GetComponent<Image>();
		flipBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild ("FlipBtn").GetComponent<Button> ();
		backBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild ("BackBtn").GetComponent<Button> ();

		flipBtn.onClick.AddListener (() => {FlipCoin();});
		backBtn.onClick.AddListener (() => {DestroyImmediate(this.gameObject);});
	}

	void Update() {
		if (isSpinning) {
			coinImg.rectTransform.Rotate(new Vector2(Random.Range(0f, 20f), Random.Range(0f, 20f)));
		}
	}

	public void FlipCoin() {
		if ( Random.Range(0f, 1f) < chance) {
			flipBtn.interactable = false;
			isSpinning = true;
			Invoke ("FlipToHeads", 1f);
		} else {
			isSpinning = true;
			flipBtn.interactable = false;
			Invoke ("FlipToTails", 1f);
		}
		InvokeRepeating ("VisualCoinChange", 0.15f, 0.15f);
	}
	
	public void FlipToHeads() {
		CancelInvoke("VisualCoinChange");
		flipBtn.interactable = true;
		isSpinning = false;
		coinImg.rectTransform.eulerAngles = Vector2.zero;
		coinImg.sprite = Resources.Load<Sprite> ("Heads") as Sprite;
	}

	public void FlipToTails() {
		CancelInvoke("VisualCoinChange");
		flipBtn.interactable = true;
		isSpinning = false;
		coinImg.rectTransform.eulerAngles = Vector2.zero;
		coinImg.sprite = Resources.Load<Sprite> ("Tails") as Sprite;
	}

	public void VisualCoinChange () {
		if (Random.Range (0f, 1f) < 0.5f) {
			coinImg.sprite = Resources.Load<Sprite> ("Heads") as Sprite;
		} else {
			coinImg.sprite = Resources.Load<Sprite> ("Tails") as Sprite;
		}
	}
}
