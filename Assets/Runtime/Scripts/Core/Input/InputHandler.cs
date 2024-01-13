using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputSolver _input;
    Vector2 _direction;

    public Vector2 GetDirection()
    {
        return _direction;
    }

    void Start()
    {
        _direction = Vector2.right;
    }

    void Update()
    {
        ProcessHorizontal();  
        ProcessVertical();
    }

    ///<summary>Only allowed if last input was in vertical axis</summary>
    void ProcessHorizontal()
    {
        if(_direction.x != 0)
            return;

        if(_input.IsPressingRight())
            _direction = Vector2.right;
        else if(_input.IsPressingLeft())
            _direction = Vector2.left;    
    }

    ///<summary>Only allowed if last input was in horizontal axis</summary>
    void ProcessVertical()
    {
        if(_direction.y != 0)
            return;

        if(_input.IsPressingUp())
            _direction = Vector2.up;
        else if(_input.IsPressingDown())
            _direction = Vector2.down;
    }
}