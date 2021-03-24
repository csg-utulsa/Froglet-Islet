using UnityEngine;

public class InputController : MonoBehaviour
{
    public float mouseSence = 1f;

    private static bool use;

    public static bool Use
    {
        get
        {
            bool b = use;
            use = false;
            return b;
        }
    }

    void Update()
    {
       
        use = Input.GetKeyDown(KeyCode.E);
    }
}
