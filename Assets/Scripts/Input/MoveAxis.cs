using UnityEngine;

public abstract class MoveAxis : IAxis 
{
    public abstract Vector3 Axis();
    public abstract void Update();
}

public class KeyboardMoveAxis : MoveAxis
{
    public override Vector3 Axis()
    {
        Vector3 axis = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            axis.z = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            axis.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            axis.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            axis.x = 1f;
        }

        return axis;
    }

    public override void Update()
    {
        
    }
}

public class ControllerMoveAxis : MoveAxis
{
    public override Vector3 Axis()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    public override void Update()
    {
        
    }
}