using UnityEngine;
[CreateAssetMenu(fileName = "Multiplication", menuName = "Equations/Multiplication")]
public class Multiplication : EquationType
{
    public override Vector2Int CreateEquation(Vector2Int range1, Vector2Int range2, out int result)
    {
        int first = Random.Range(range1.x, range1.y);
        int second = Random.Range(range2.x, range2.y);
        result = first * second;
        return new Vector2Int(first, second);
    }
}
