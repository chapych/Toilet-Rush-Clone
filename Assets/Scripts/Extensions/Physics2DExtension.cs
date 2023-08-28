using UnityEngine;

namespace Extensions
{
    public static class Physics2DExtension
    {
        private static int arrayLength = 1;
        public static bool TryOverlapCircle<T>(Vector2 position, float detectingRadius, out T instance,
            int mask = Physics.AllLayers)
        {
            instance = default(T);
            var overlapped = new Collider2D[arrayLength];
            int t =Physics2D.OverlapCircleNonAlloc(position, detectingRadius, overlapped, mask);
            Debug.Log(t);
            
            Collider2D collider = overlapped[0];
            if (!collider || !collider.TryGetComponent(out T component)) return false;
            instance = component;
            return true;
        } 
    }
}
