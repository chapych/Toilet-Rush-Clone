using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
	[UnityTest]
	public IEnumerator NoAddingOnCreatingLine()
	{
		LineCreator creator;
		ICharacterData data = Substitute.For<ICharacterData>();
		Line line = CreateLine(data, out creator);
		
		bool isAdded = creator.ContainsLineFor(data);

		Assert.That(isAdded, Is.EqualTo(false));
		GameObject.Destroy(line);
		yield return null;
	}
	[UnityTest]
	public IEnumerator AddOnRegisteringLine()
	{
		LineCreator creator;
		ICharacterData data = Substitute.For<ICharacterData>();
		Line line = CreateLine(data, out creator);
		IFinishData finishData = Substitute.For<IFinishData>();
		finishData.IsGenderNeutral = true;
		
		creator.TryAddCurrentLine(finishData);
		bool isAdded = creator.ContainsLineFor(data);

		Assert.That(isAdded, Is.EqualTo(true));
		GameObject.Destroy(line);
		yield return null;
	}

	private static Line CreateLine(ICharacterData data, out LineCreator creator)
	{
		Line prefab = new GameObject().AddComponent<Line>();
		creator = new LineCreator(prefab);
		Vector2 spawnPosiiton = new Vector2(0, 0);

		return creator.Create(data, spawnPosiiton);
	}
}
