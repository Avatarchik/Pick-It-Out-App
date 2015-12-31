using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuBehavior : MonoBehaviour {

	Canvas mainCanvas;

	Button flipCoinBtn;
	Button rollDiceBtn;
	Button customBtn;
	Button supportBtn;

	public GameObject flipCoinPrefab;
	public GameObject rollDicePrefab;
	public GameObject customPrefab;
	public GameObject supportPrefab;

	// Ad Stuff
	public GameObject adPanel;

	// Use this for initialization
	void Awake () {
		// App Stuff
		mainCanvas = GameObject.FindGameObjectWithTag ("MainCanvas").GetComponent<Canvas> ();
		flipCoinBtn = GameObject.FindGameObjectWithTag ("FlipCoinBtn").GetComponent<Button>();
		rollDiceBtn = GameObject.FindGameObjectWithTag ("RollDiceBtn").GetComponent<Button>();
		customBtn = GameObject.FindGameObjectWithTag ("CustomBtn").GetComponent<Button>();
		supportBtn = GameObject.FindGameObjectWithTag ("SupportBtn").GetComponent<Button>();
		adPanel = GameObject.FindGameObjectWithTag ("AdPopup");
		adPanel.SetActive (false);

		flipCoinBtn.onClick.AddListener(() => {
			PlayRandSound();
			GameObject page = Instantiate(flipCoinPrefab) as GameObject;
			page.transform.SetParent(mainCanvas.transform, false);
			page.transform.SetAsLastSibling();
		});
		rollDiceBtn.onClick.AddListener(() => {
			PlayRandSound();
			GameObject page = Instantiate(rollDicePrefab) as GameObject;
			page.transform.SetParent(mainCanvas.transform, false);
			page.transform.SetAsLastSibling();
		});
		customBtn.onClick.AddListener(() => {
			PlayRandSound();
			GameObject page = Instantiate(customPrefab) as GameObject;
			page.transform.SetParent(mainCanvas.transform, false);
			page.transform.SetAsLastSibling();
		});
		supportBtn.onClick.AddListener(() => {
			PlayRandSound();
			//PlayAVideo("vze08d53ef040643c598");
			adPanel.SetActive(true);
			adPanel.GetComponent<AdPanelBehavior>().SetAdBtnState();
		});

		// AdColony Stuff
		InitializeAdStuff ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayRandSound() {
		AudioClip sfx = Resources.Load ("Sound/"+Random.Range(1,10)) as AudioClip;
		AudioSource.PlayClipAtPoint (sfx, Vector3.zero);
	}

	public void InitializeAdStuff()
	{
		// Assign any AdColony Delegates before calling Configure
		AdColony.OnVideoFinished = this.OnVideoFinished;
		
		// If you wish to use a the customID feature, you should call  that now.
		// Then, configure AdColony:
		AdColony.Configure
			(
				"version:0.1,store:google", // Arbitrary app version and Android app store declaration.
				"app5f0c212e852d435d9b",   // ADC App ID from adcolony.com
				"vze08d53ef040643c598" // A zone ID from adcolony.com
				);
	}

	public void OnVideoFinished(bool ad_was_shown)
	{
		Debug.Log("On Video Finished");
		// Resume your app here.
		
		// MAYBE A THANK YOU MESSAGE
	}
}
