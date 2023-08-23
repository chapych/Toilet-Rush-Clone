using System.Collections;
using System.Collections.Generic;
using Logic.GamePlay;
using UnityEngine;

public class DustControl : MonoBehaviour
{
	private ParticleSystem particles;
	
	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
	}
	public void OnCollisionHandle(object sender, CollisionEventArgs args)
	{
		particles.transform.position = args.Position;
		particles.Play(true);
	}
}
