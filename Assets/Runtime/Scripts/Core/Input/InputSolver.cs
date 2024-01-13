using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSolver : MonoBehaviour
{
    public abstract bool IsPressingRight();
    public abstract bool IsPressingLeft();
    public abstract bool IsPressingUp();
    public abstract bool IsPressingDown();
}