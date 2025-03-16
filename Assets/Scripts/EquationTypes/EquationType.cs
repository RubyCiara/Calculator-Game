using UnityEngine;

public abstract class EquationType : ScriptableObject
{
    public abstract Vector2Int CreateEquation(Vector2Int range1, Vector2Int range2, out int result);

    
}
