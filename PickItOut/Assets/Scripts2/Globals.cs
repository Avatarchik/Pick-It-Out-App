using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Globals : MonoBehaviour {
	
	// Coin Params
	public static float COIN_SHRINK_TIME = 0.1f;
	public static float COIN_GROW_TIME = 0.1f;
	public static float COIN_SHRINK_PERCENT = 0.15f;

	// Spinner Params
	public static float SPIN_TIME = 1f;
	
	// Game State
	public static PIO_gamestate gamestate;
	private static string gamestateFileName = "/PickItOutGameState.dat";

	public enum modes {coin, dice, spin, ad};
	public Text appModeLabel;
	public Image appTopBar;
	public Image appTopSidebar;
	public Image appHamburger;
	public Color coinModeColor;
	public Color diceModeColor;
	public Color spinnerModeColor;
	public Color adModeColor;

	public MaterialUI.ScreenManager screenManager;

	void Awake() {
		Globals.Load ();
	}
	void Start() {
		screenManager.Set (gamestate.currentMode);
		RegisterChangeInMode (gamestate.currentMode);
	}
	
	public static void Save() {
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream file = File.Open (Application.persistentDataPath + Globals.gamestateFileName, FileMode.Create);
		formatter.Serialize(file, Globals.gamestate);
		file.Close();
	}
	
	public static void Load() {
		if (File.Exists (Application.persistentDataPath + gamestateFileName)) {
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + Globals.gamestateFileName, FileMode.Open);
			Globals.gamestate = (PIO_gamestate)formatter.Deserialize (file);
			file.Close ();
		} else {
			Globals.gamestate = new PIO_gamestate();
			Globals.Save();
		}
	}

	public void RegisterChangeInMode(int c) {
		switch (c) {
		case (int)Globals.modes.coin:
			appTopBar.color = coinModeColor;
			appTopSidebar.color = coinModeColor;
			appHamburger.color = coinModeColor;
			appModeLabel.text = "Flip A Coin";
			gamestate.currentMode = (int)Globals.modes.coin;
			Globals.Save();
			break;
		case (int)Globals.modes.dice:
			appTopBar.color = diceModeColor;
			appTopSidebar.color = diceModeColor;
			appHamburger.color = diceModeColor;
			appModeLabel.text = "Roll Dice";
			gamestate.currentMode = (int)Globals.modes.dice;
			Globals.Save();
			break;
		case (int)Globals.modes.spin:
			appTopBar.color = spinnerModeColor;
			appTopSidebar.color = spinnerModeColor;
			appHamburger.color = spinnerModeColor;
			appModeLabel.text = "Spin the Spinner";
			gamestate.currentMode = (int)Globals.modes.spin;
			Globals.Save();
			break;
		case (int)Globals.modes.ad:
			appTopBar.color = adModeColor;
			appTopSidebar.color = adModeColor;
			appHamburger.color = adModeColor;
			appModeLabel.text = "Support The Developer";
			gamestate.currentMode = (int)Globals.modes.ad;
			Globals.Save();
			break;
		}
	}

	// When a video is available, you may choose to play it in any fashion you like.
	// Generally you will play them automatically during breaks in your game,
	// or in response to a user action like clicking a button.
	// Below is a method that could be called, or attached to a GUI action.
	public static void PlayAVideo( string zoneID )
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

[Serializable]
public class PIO_gamestate {
	
	public string currentCoinState;
	public int currentDice1State;
	public int currentDice2State;
	public string[] currentSpinnerOptions = new string[8];
	public float currentSpinnerRotaion;
	public int currentMode;

	// Chances
	public float COIN_CHANCE_HEADS;
	public int[] DICE_CHANCES;
	public int[] SPINNER_CHANCES;

	
	public PIO_gamestate() {
		currentCoinState = "Heads";
		currentDice1State = 5;
		currentDice2State = 3;
		currentSpinnerOptions = new string[] {"Orange", "Yellow", "Green", "Blue", "Indigo", "Violet", "Pink", "Red"};
		currentSpinnerRotaion = 0f;
		currentMode = 0;

		COIN_CHANCE_HEADS = 0.5f;
		DICE_CHANCES = new int[] {1, 1, 1, 1, 1, 1};
		SPINNER_CHANCES = new int[] {1, 1, 1, 1, 1, 1, 1, 1};
	}
}