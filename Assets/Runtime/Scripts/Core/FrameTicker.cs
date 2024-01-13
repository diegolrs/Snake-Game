using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Used to simulate Nokia's hardware frame 
/// update independent of the device.
/// </summary>
public class FrameTicker : MonoBehaviour
{
    [SerializeField] float _tickSize = 1.15f;
    [SerializeField] float _tickSpeed = 3f;
    float _currentTick = 0f;

    public event Action OnFrameTick;

    void Update()
    {
        _currentTick += Time.deltaTime * _tickSpeed;

        if(_currentTick >= _tickSize)
        {
            OnFrameTick?.Invoke();
            _currentTick -= _tickSize;
        }
    }
}