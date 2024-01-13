using UnityEngine;
using System.Collections.Generic;

public class CompositeInputSolver : InputSolver
{
    [SerializeField] List<InputSolver> _solvers;


    public override bool IsPressingRight()
    {
        bool value = false;
        foreach (var solver in _solvers)
        {
            value |= solver.IsPressingRight();
        }
        return value;
    }

    public override bool IsPressingLeft()
    {
        bool value = false;
        foreach (var solver in _solvers)
        {
            value |= solver.IsPressingLeft();
        }
        return value;
    }

    public override bool IsPressingUp()
    {
        bool value = false;
        foreach (var solver in _solvers)
        {
            value |= solver.IsPressingUp();
        }
        return value;
    }

    public override bool IsPressingDown()
    {
        bool value = false;
        foreach (var solver in _solvers)
        {
            value |= solver.IsPressingDown();
        }
        return value;
    }
}