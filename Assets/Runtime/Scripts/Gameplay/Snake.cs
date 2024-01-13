using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    Queue<Vector2> _body;
    Vector2 _head;
    public event Action OnSelfCollision;

    [SerializeField] List<Vector2> queueList;

    private void Awake() 
    {
        _body = new Queue<Vector2>();    
    }

    public void InstantiateHead(Vector2 position)
    {
        _body.Enqueue(position);
        _head = position;
    }

    public void MoveHead(Vector2 position, bool alsoGrow)
    {
        bool collided = _body.Contains(position);

        if(!alsoGrow)
            _body.Dequeue(); // remove tail

        _body.Enqueue(position); // new head position
        _head = position;
        if(collided) OnSelfCollision?.Invoke();
    }

    public List<Vector2> GetBody()
    {
        return _body.ToList();
    }

    public Vector2 GetHeadPosition()
    {
        return _head;
    }

    void Update()
    {
        queueList = _body.ToList();
    }
}