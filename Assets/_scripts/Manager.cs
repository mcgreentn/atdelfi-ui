using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{

	/// <summary>
	/// The rule prefab for creating new rules
	/// </summary>
	public GameObject RulePrefab;
	public GameObject RuleGoodPrefab;
	public GameObject RuleBadPrefab;
	public GameObject RuleWinPrefab;

	/// <summary>
	/// The window panels.
	/// </summary>
	public GameObject WinPanel;
	public GameObject LosePanel;
	public GameObject PointsPanel;

	/// <summary>
	/// The win rules list.
	/// </summary>
	public GameObject WinList;

	/// <summary>
	/// The lose rules list.
	/// </summary>
	public GameObject LoseList;

	/// <summary>
	/// The points rules list.
	/// </summary>
	public GameObject PointsList;


	public GameObject LoadingMenu;
	public GameObject StartMenu;
	public Text Movement;
	public Text WhoAmI;
	public Text GameName;
	public Image avatarImage;

	public FileReader fr;
	public string gameFile = "visTutorial";

	void Start()
	{
		
//		fr.ReadFile(gameFile + "/visTutorial");
//
//		AvatarSetUp();
//		PointsSetUp();
//		WinSetUp();
//		LoseSetUp();
	}

	public void CloseLoading() 
	{
		LoadingMenu.SetActive (false);	
	}
	public void OpenLoading() 
	{
		LoadingMenu.SetActive (true);
	}

	public void LoadTutorial(string file)
	{
		gameFile = file;
		fr.ReadFile(gameFile + "/visTutorial");
		AvatarSetUp();
		PointsSetUp();
		WinSetUp();
		LoseSetUp();
	}
	public void AvatarSetUp()
	{

		GameName.text = "Tutorial for " + FirstCharToUpper(FileReader.tFile.gameInfo.gameName);
		WhoAmI.text = FileReader.tFile.gameInfo.avatarInfo;
		Movement.text = FileReader.tFile.gameInfo.controlsInfo;
		string avatar = FileReader.tFile.gameInfo.avatarImage.Replace(".png", "");
		if (Resources.Load(FileReader.tFile.gameInfo.avatarImage.Replace(".png", "")) == null)
		{
			avatar = avatar + "_0";
		}
		Debug.Log(FileReader.tFile.gameInfo.avatarImage.Replace(".png", ""));
		Debug.Log(Resources.Load(FileReader.tFile.gameInfo.avatarImage.Replace(".png", "")));
		avatarImage.sprite = Resources.Load<Sprite>(avatar);
		//Debug.Log(avatarImage.sprite);

	}
	public void PointsSetUp()
	{
		DestroyAllKids (PointsList);
		Rule[] pointsRules = FileReader.tFile.pointsRules;
		foreach (Rule r in pointsRules)
		{
			GameObject rule = Instantiate(RuleGoodPrefab, PointsList.transform);
			RuleManager rm = rule.GetComponent<RuleManager>();

			// set up text for this rule
			rm.SetText(r.text);

			//rm.SetImages(r.image0, r.image1, r.image2);
			rm.SetImages(r.images);
		}
	}

	public void WinSetUp()
	{
		DestroyAllKids (WinList);
		Rule[] winRules = FileReader.tFile.winRules;
		foreach (Rule r in winRules)
		{
			GameObject rule = Instantiate(RuleWinPrefab, WinList.transform);
			RuleManager rm = rule.GetComponent<RuleManager>();

			// set up text for this rule
			rm.SetText(r.text);
			//rm.SetImages(r.image0, r.image1, r.image2);
			rm.SetImages(r.images);
		}
	}
	public void LoseSetUp()
	{
		DestroyAllKids (LoseList);
		Rule[] loseRules = FileReader.tFile.loseRules;
		foreach (Rule r in loseRules)
		{
			GameObject rule = Instantiate(RuleBadPrefab, LoseList.transform);
			RuleManager rm = rule.GetComponent<RuleManager>();

			// set up text for this rule
			rm.SetText(r.text);
			//rm.SetImages(r.image0, r.image1, r.image2);
			rm.SetImages(r.images);
		}
	}
	public void StartGen() 
	{
		StartMenu.SetActive (false);
		LoadingMenu.SetActive (true);
	}
	/// Utility Methods
	public static string FirstCharToUpper(string input)
	{
		
		return input.ToCharArray()[0].ToString().ToUpper() + input.Substring(1);

	}

	public void DestroyAllKids(GameObject obj) 
	{
		foreach (Transform child in obj.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}



	public void PressWin() 
	{
		WinPanel.transform.SetAsLastSibling ();
	}

	public void PressLose() 
	{
		LosePanel.transform.SetAsLastSibling ();
	}

	public void PressPoints() 
	{
		PointsPanel.transform.SetAsLastSibling ();
	}

}
