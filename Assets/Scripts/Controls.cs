using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Level;
    public float Sensetivity=1;

    private Vector3 _previousMousePosition;
    


    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta=Input.mousePosition-_previousMousePosition;
            Level.Rotate(0, -delta.x*Sensetivity, 0);
        }
        _previousMousePosition = Input.mousePosition;

    }
}
