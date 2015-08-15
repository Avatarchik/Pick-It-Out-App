using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SetChoicesBehavior : MonoBehaviour {

	Button backBtn;
	Button doneBtn;

	public GameObject customPanelPrefab;

	void Awake() {
		backBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild ("BackBtn").GetComponent<Button> ();
		doneBtn = transform.FindChild ("Content").FindChild ("Btns").FindChild ("DoneBtn").GetComponent<Button> ();

		backBtn.onClick.AddListener (() => {
			DestroyImmediate(gameObject);
		});
		doneBtn.onClick.AddListener (() => {
			GameObject customPanel = Instantiate(customPanelPrefab) as GameObject;
			customPanel.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
			customPanel.transform.SetAsLastSibling();

			CustomBehavior cb = customPanel.GetComponent<CustomBehavior>();
			List<string> choices = new List<string>();
			foreach (InputField inptFld in GetComponentsInChildren<InputField>()) {
				if (!inptFld.text.Equals("")) {
					choices.Add(inptFld.text);
				}
			}
			cb.Init(choices);

		});
	}



}
