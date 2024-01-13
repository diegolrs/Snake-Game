using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] RectTransform _renderer;
    Vector2 _gridedPosition;

    public Vector2 GetPosition()
    {
        return _gridedPosition;
    }

    public void Spawn()
    {
        _gridedPosition = new Vector2Int(GameConstants.Width/2, -GameConstants.Height/2);
        _renderer.anchoredPosition = _gridedPosition * GameConstants.GridSize;
    }

    public void Spawn(Vector2Int gridedPosition)
    {
        _gridedPosition = gridedPosition;
        _renderer.anchoredPosition = _gridedPosition * GameConstants.GridSize;
    }
}