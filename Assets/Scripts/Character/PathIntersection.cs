using System;
using Extensions;
using Logic.GamePlay;
using UnityEngine;
using Zenject;

namespace Character
{
	public class PathIntersection : MonoBehaviour
	{
		private static bool passed;
		
		private GameOver gameOver;
		private DustControl dustControl;
		private new Collider2D collider;
		public EventHandler<CollisionEventArgs> OnCollision;
	
		// [Inject]
		// public void Costruct(GameOver gameOver, DustControl dustControl)
		// {
		// 	this.gameOver = gameOver;
		// 	this.dustControl = dustControl;
		// }

		private void Start()
		{
			passed = false;
			collider = GetComponent<Collider2D>();
			//Subscribe();
		}
		
		private void Update()
		{
			if(Physics2DExtension.TryOverlapCircle(transform.position, Constants.DETECTING_RADIUS, out Collider2D instance))
			{
				GameObject other = instance.gameObject;
				if(other != gameObject && other.TryGetComponent(out ICharacterData _))
				{
					HandleCollision(other);
				}
			}
		}
		
		private void HandleCollision(GameObject other)
		{
			var movingObject = GetComponent<MoveComponent>();
			
			InvokeEventOnce(other);
			//Unsubcribe();
		
			StopMovement(movingObject);
			collider.enabled = false;
		}

		private void InvokeEventOnce(GameObject other)
		{
			if (passed) return;
		
			Debug.Log("collided");
			//Vector2 medianCollisionPoint = (transform.position + other.transform.position) / 2;
			//OnCollision?.Invoke(this, new CollisionEventArgs(medianCollisionPoint));
			passed = true;
		}
	
		private void StopMovement(MoveComponent movingObject) => movingObject.StopMovement();

		public void Subscribe()
		{
			OnCollision += gameOver.OnCollisionHandleAsync;
			OnCollision += dustControl.OnCollisionHandle;
		}

		public void Unsubcribe()
		{
			OnCollision -= gameOver.OnCollisionHandleAsync;
			OnCollision -= dustControl.OnCollisionHandle;
		}
	}
}
