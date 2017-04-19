using UnityEngine;

public class BackViewBehaviour : UIBehaviour 
{
    public override void OnUpdate()
    {
        base.OnUpdate();

#if !MOBILE_PLATFORM
        if (Input.GetButtonDown("Cancel"))
        {
            ViewController.instance.AddCommond(new CloseCommond());
        }
#endif
    }
}
