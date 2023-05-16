using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FactoryTest
{
	// A Test behaves as an ordinary method
	[Test]
	public void ProperTypeGetter()
	{
		var factory = new DrawingStateFactory();
		var start = factory.GetOrCreate<DrawingStartState>();
		Assert.That(start.GetType(), Is.EqualTo(typeof(DrawingStartState)));
		
		var pressed = factory.GetOrCreate<DrawingPressedState>();
		Assert.That(pressed.GetType(), Is.EqualTo(typeof(DrawingPressedState)));
	}
	[Test]
	public void DoNotCreateAlreadyCreatedState()
	{
		var factory = new DrawingStateFactory();
		var someState = factory.GetOrCreate<DrawingStartState>();
		var anotherState = factory.GetOrCreate<DrawingStartState>();
		
		Assert.That(someState, Is.EqualTo(anotherState));
	}

	
}
