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
		
		bool isAdded = creator.ContainsElementFor(data);

		Assert.That(isAdded, Is.EqualTo(false));
		yield return null;
	}
	[UnityTest]
	public IEnumerator AddOnRegisteringLine()
	{
		LineCreator creator;
		ICharacterData data = Substitute.For<ICharacterData>();
		ICharacterData otherData = Substitute.For<ICharacterData>();
		Line line = CreateLine(data, out creator);
		IFinishData finishData = Substitute.For<IFinishData>();
		finishData.IsGenderNeutral = true;
		
		creator.TryAddCurrentLineToList(finishData);
		bool isAdded = creator.ContainsElementFor(data);
		bool isOtherAdded = creator.ContainsElementFor(otherData);

		Assert.That(isAdded, Is.EqualTo(true));
		Assert.That(isOtherAdded, Is.EqualTo(false));
		yield return null;
	}
	
	[UnityTest]
	public IEnumerator SetLineProperties()
	{
		LineCreator creator;
		ICharacterData data = Substitute.For<ICharacterData>();
		Line line = CreateLine(data, out creator);
		line.gameObject.AddComponent<LineRenderer>();
		line.SetInitialProperties();
		
		creator.SetLineProperties(data);
		
		Assert.That(line.transform.parent, Is.EqualTo(data.transform));
		yield return null;
	}
	
	[UnityTearDown]
	public IEnumerator TearingDown()
	{
		Line[] lines = GameObject.FindObjectsOfType<Line>();
		foreach(var line in lines)
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
