using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override List<Vector2Int> MoveLocations(Vector2Int gridPoint)
    {
        List<Vector2Int> locations = new List<Vector2Int>();

        foreach (Vector2Int dir in BishopDirections)
        {
            for (int i = 1; i < 8; i++)
            {
                Vector2Int nextGridPoint = new Vector2Int(gridPoint.x + i * dir.x, gridPoint.y + i * dir.y);
                locations.Add(nextGridPoint);
                if (GameManager.instance.PieceAtGrid(nextGridPoint))
                {
                    break;
                }
            }
        }

        return locations;
    }
}
