using System;
using UnityEngine;
using UnityEngine.UI;
public class LoadTutorialScript : MonoBehaviour
{
	public string name;

	public Manager m;
	public void Load() {
		name = this.gameObject.GetComponentInChildren<Text> ().text;
		m = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Manager>();
		m.LoadTutorial (name);
		m.CloseLoading ();
	}

}


