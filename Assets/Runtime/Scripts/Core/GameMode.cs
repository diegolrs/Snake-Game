using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    [SerializeField] FrameTicker _ticker;
    [SerializeField] InputHandler _input;
    [SerializeField] Snake _snake;
    [SerializeField] Food _food;

    private void Awake() 
    {
        if(_ticker) _ticker.OnFrameTick += TickFrame;
        if(_snake) _snake.OnSelfCollision += OnSnakeDies;
    }

    private void OnDestroy() 
    {
        if(_ticker) _ticker.OnFrameTick -= TickFrame;
        if(_snake) _snake.OnSelfCollision -= OnSnakeDies;
    }

    void Start()
    {
        var middle = new Vector2Int(GameConstants.Width/2, -GameConstants.Height/2);
        _snake.InstantiateHead(middle);
        _food.Spawn();
    }

    void TickFrame()
    {
        var dir = _input.GetDirection();
        var target = TargetClamped(_snake.GetHeadPosition() + dir);

        bool grow = target == _food.GetPosition();
        _snake.MoveHead(target, grow);

        if(grow)
        {
            bool hasEmptyPositions = false;
            var pos = RandomEmptyPosition(out hasEmptyPositions);

            if(hasEmptyPositions)
                _food.Spawn(pos);
            else
                Debug.Log("Você Ganhou");
        }
    }

    void OnSnakeDies()
    {
        Debug.Log("MORREU");
        Time.timeScale = 0f;
    }

    Vector2 TargetClamped(Vector2 target)
    {
        // Clamp Horizontal
        if(target.x < 0)
            target.x = GameConstants.Width-1;
        else if(target.x >= GameConstants.Width)
            target.x = 0;

        // Clamp Vertical
        if(target.y > 0)
            target.y = -(GameConstants.Height-1);
        else if(target.y < -(GameConstants.Height-1))
            target.y = 0;

        return target;
    }

    Vector2Int RandomEmptyPosition(out bool success)
    {
        var body = _snake.GetBody();
        var emptyPositions = new List<Vector2Int>();
        
        for (int i = 0; i < GameConstants.Width; i++)
        {
            for (int j = 0; j < GameConstants.Height; j++)
            {
                var vec2 = new Vector2Int(i, -j);
                if (!body.Contains(vec2))
                {
                    emptyPositions.Add(vec2);
                }
            }
        }

        success = emptyPositions.Count > 0;
        return success ? emptyPositions[Random.Range(0, emptyPositions.Count)] : Vector2Int.zero;
    }
}