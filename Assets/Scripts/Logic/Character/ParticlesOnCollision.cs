using Logic.BaseClasses;
using Logic.BaseClasses.CustomEventArgs;
using UnityEngine;

namespace Logic.Character
{
    public class ParticlesOnCollision : MonoBehaviour
    {
        [SerializeField] private CollisionObserver collisionObserver;
        [SerializeField] private ParticleSystem dustParticles;

        private void Awake()
        {
            collisionObserver.OnCollision += PlayDustAnimation;
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
            collisionObserver.OnCollision -= PlayDustAnimation;
        }
    }
}