using UnityEngine;

public static class Physics2DExtension
{
    public static bool TryOverlapCircle<T>(Vector2 position, float detectingRadius,
         out T instance)
   {
       instance = default(T);
       Collider2D collider = Physics2D.OverlapCircle(position, detectingRadius);
       if (!collider || !collider.TryGetComponent(out T component)) return false;
       instance = component;
       return true;
   } 
}
