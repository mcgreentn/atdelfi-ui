using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class FileReader : MonoBehaviour
{
	/// <summary>
	/// Gets or sets the name of the file.
	/// </summary>
	/// <value>The name of the file.</value>
	public string FileName { get; set; }

	/// <summary>
	/// The t file.
	/// </summary>
	/// 
	public static TutorialFile tFile;
	/// <summary>
	/// Reads the file.
	/// </summary>
	public void ReadFile(string file)
	{
		TextAsset gAsset = Resources.Load(file) as TextAsset;
		string gFile = gAsset.text;

		//Debug.Log(gFile);
		tFile = JsonUtility.FromJson<TutorialFile>(gFile);
		Debug.Log(tFile);
	}
}