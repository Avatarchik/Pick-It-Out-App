using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Coin : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Text coinText;
	public Button button;

	private bool isShrinking = false;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FlipCoin() {
		//flipSound.Play ();
		if ( Random.Range(0f, 1f) < Globals.COIN_CHANCE_HEADS) {
			coinText.text = "Heads";
		} else {
			coinText.text = "Tails";
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		StartCoroutine ("Shrink");
	}

	public void OnPointerUp(PointerEventData eventData) {
		isShrinking = false;
		StartCoroutine ("Grow");
		FlipCoin ();
	}

	private IEnumerator Shrink() {
		isShrinking = true;
		float timeCounter = 0;
		while (timeCounter < Globals.COIN_SHRINK_TIME && isShrinking) {
			timeCounter += Time.deltaTime;
			transform.localScale = new Vector2(1f - (Globals.COIN_SHRINK_PERCENT * (timeCounter / Globals.COIN_SHRINK_TIME)),
			                                   1f - (Globals.COIN_SHRINK_PERCENT * (timeCounter / Globals.COIN_SHRINK_TIME)));
			coinText.color = new Color (coinText.color.r,
			                            coinText.color.g,
			                            coinText.color.b,
			                            (1 - (timeCounter / Globals.COIN_SHRINK_TIME)));
			yield return null;
		}
		coinText.color = new Color (coinText.color.r,
		                            coinText.color.g,
		                            coinText.color.b,
		                            0f);
	}

	private IEnumerator Grow() {
		float timeCounter = 0;
		while (timeCounter < Globals.COIN_GROW_TIME) {
			timeCounter += Time.deltaTime;
			transform.localScale = new Vector2((1 - Globals.COIN_SHRINK_PERCENT) + (Globals.COIN_SHRINK_PERCENT * (timeCounter / Globals.COIN_SHRINK_TIME)),
			                                   (1 - Globals.COIN_SHRINK_PERCENT) + (Globals.COIN_SHRINK_PERCENT * (timeCounter / Globals.COIN_SHRINK_TIME)));
			coinText.color = new Color (coinText.color.r,
			                            coinText.color.g,
			                            coinText.color.b,
			                            (timeCounter / Globals.COIN_GROW_TIME));
			yield return null;
		}
		transform.localScale = new Vector2 (1f, 1f);
		coinText.color = new Color (coinText.color.r,
		                            coinText.color.g,
		                            coinText.color.b,
		                            255f);
	}
}
