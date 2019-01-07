using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RuleManager : MonoBehaviour
{

	public Text Rule;
	public Text BigRule;
	public GameObject ExampleNotFound;
	public Image image;
	public Image img;
	public Sprite[] sprites;
	public Manager M;

	void Start()
	{

	}
	public void SetText(string text)
	{
		Rule.text = text;
		BigRule.text = text;
	}

	public void SetImages(string image1, string image2, string image3) {
		sprites = new Sprite[3];

		sprites[0] = Resources.Load<Sprite>(image1.Replace(".png", ""));
		sprites[1] = Resources.Load<Sprite>(image2.Replace(".png", ""));
		sprites[2] = Resources.Load<Sprite>(image3.Replace(".png", ""));

		Debug.Log(sprites[0]);
		Debug.Log(Resources.Load(image1.Replace(".png", "")));
		Debug.Log(image1);

		if (sprites[0] == null)
		{
			ExampleNotFound.SetActive(true);
		}
		StartCoroutine(SpinSprites());
	}

	public void SetImages(string[] images)
	{
		M = GameObject.FindWithTag("GameManager").GetComponent<Manager>();
		sprites = new Sprite[images.Length];
		for (int i = 0; i < images.Length; i++)
		{
			Debug.Log(M.gameFile + "/" + images[i].Replace(".png", ""));
			sprites[i] = Resources.Load<Sprite>(M.gameFile + "/" + images[i].Replace(".png", ""));
		}
		StartCoroutine(SpinSprites());
	}
	IEnumerator SpinSprites()
	{
		if (sprites.Length > 0)
		{
			int index = 0;
			while (true)
			{
				image.sprite = sprites[index];
				yield return new WaitForSeconds(0.5f);
				index++;
				if (index == sprites.Length)
				{
					index = 0;
				}
			}
		}
		else
		{
			Rule.gameObject.SetActive(false);
			BigRule.gameObject.SetActive(true);
			image.gameObject.SetActive(false);
		}
	}
}
