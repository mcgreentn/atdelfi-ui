using System;

[System.Serializable]
public class TutorialFile
{
	/// <summary>
	/// The game info.
	/// </summary>
	public GameInfo gameInfo;

	/// <summary>
	/// The lose rules.
	/// </summary>
	public Rule[] loseRules;

	/// <summary>
	/// The points rules.
	/// </summary>
	public Rule[] pointsRules;

	/// <summary>
	/// The window rules.
	/// </summary>
	public Rule[] winRules;

}

