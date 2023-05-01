using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingStateFactory
{
	private Dictionary<string, DrawingState> createdStates;
	
	public DrawingStateFactory() => createdStates = new Dictionary<string, DrawingState>();
	
	public DrawingState GetOrCreate<T>() where T : DrawingState, new()
	{
		string typeName = typeof(T).FullName;
		if(createdStates.ContainsKey(typeName)) 
			return createdStates[typeName];
		
		var state = (T) new T();
		createdStates[typeName] = state;
		return state;
	}
	
}
