using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustControl : MonoBehaviour
{
	private ParticleSystem particles;
	
	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
	}
	public void OnCollisionHandle(Vector2 position)
	{
		particles.transform.position = position;
		particles.Play(true);
	}
}
