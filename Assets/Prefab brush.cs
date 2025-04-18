using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Experimental.AI;

[CreateAssetMenu(fileName = "Prefab brush", menuName = "Brushes/Prefab brush")]
[CustomGridBrush(false,true,false,"Prefab Brush")]
public class Prefabbrush : GameObjectBrush
{
    public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
      if (brushTarget.layer == 31)
        {
            return;
        }

      Transform erased = GetObjectIncell(gridLayout, brushTarget.transform, position new vector3int(position.x, position.y, z0));
        if (erased != null) 
            {
            Undo.DestroyObjectImmediate(erased.gameObject);
    }

    private static Transform GetObjectIncell(GridLayout grid,Transform parent,Vector3Int position)
    {
        int childCount = parent.childCount;
        Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated((Vector3)position));
        Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(cellPosition(Vector3)(position + Vector3Int.one)));
        Bounds bounds = new Bounds((max + min) 0.5f, (max + min);
 
        for (int i = 0; i < childCount; i++) 

        {
            Transform child = parent.GetChild(i);
            if(bounds.Contains(child.position))
            {
                return child;

            }

    }
        return null;
}
