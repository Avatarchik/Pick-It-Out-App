using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class AdPanelBehavior : MonoBehaviour {

	Button playAdBtn ;
	Button backBtn;

	// Use this for initialization
	void Awake () {
		playAdBtn = transform.FindChild ("ShowAdBtn").GetComponent<Button> ();
		backBtn = transform.FindChild ("BackBtn").GetComponent<Button> ();

		SetAdBtnState ();

		playAdBtn.onClick.AddListener(() => {
			PlayAVideo("vze08d53ef040643c598");
			PersistantData.userData.lastAd = DateTime.Now;
		});
		backBtn.onClick.AddListener(() => {
			gameObject.SetActive(false);
		});
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetAdBtnState() {
		if (PersistantData.userData.lastAd.AddHours (1.0) > DateTime.Now) {
			int mins = (PersistantData.userData.lastAd.AddHours (1.0) - DateTime.Now).Minutes;
			playAdBtn.transform.FindChild ("Text").GetComponent<Text> ().text = "Come back in " + mins + "minutes.";
			playAdBtn.interactable = false;
		} else {
			playAdBtn.transform.FindChild ("Text").GetComponent<Text> ().text = "Tap here for ad!";
			playAdBtn.interactable = true;
		}
	}

	// When a video is available, you may choose to play it in any fashion you like.
	// Generally you will play them automatically during breaks in your game,
	// or in response to a user action like clicking a button.
	// Below is a method that could be called, or attached to a GUI action.
	public void PlayAVideo( string zoneID )
	{
		// Check to see if a video is available in the zone.
		if(AdColony.IsVideoAvailable(zoneID))
		{
			Debug.Log("Play AdColony Video");
			// Call AdColony.ShowVideoAd with that zone to play an interstitial video.
			// Note that you should also pause your game here (audio, etc.) AdColony will not
			// pause your app for you.
			AdColony.ShowVideoAd(zoneID); 
		}
		else
		{
			Debug.Log("Video Not Available");
		}
	}
}
