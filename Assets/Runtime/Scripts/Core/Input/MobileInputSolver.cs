using UnityEngine;
using UnityEngine.UI;

public class MobileInputSolver : InputSolver
{
    public override bool IsPressingRight() => Input.GetKeyDown(KeyCode.RightArrow);
    public override bool IsPressingLeft() => Input.GetKeyDown(KeyCode.LeftArrow);
    public override bool IsPressingUp() => Input.GetKeyDown(KeyCode.UpArrow);
    public override bool IsPressingDown() => Input.GetKeyDown(KeyCode.DownArrow);
}