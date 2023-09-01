using System;
using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;
using Zenject;

namespace Character
{
    public class ParticlesOnCollision : MonoBehaviour
    {
        [SerializeField] private CollisionObserver collisionObserver;
        [SerializeField] private ParticleSystem dustParticles;

        private void Awake()
        {
            collisionObserver.OnRaised += PlayDustAnimation;
        }

        private void PlayDustAnimation(object sender, CollisionEventArgs args)
        {
            PlayDustAnimation(args.Collision.contacts[0].point);
        }

        public void PlayDustAnimation(Vector2 at)
        {
            Instantiate(dustParticles, at, Quaternion.identity);
        }

        private void OnDestroy()
        {
            collisionObserver.OnRaised -= PlayDustAnimation;
        }
    }
}