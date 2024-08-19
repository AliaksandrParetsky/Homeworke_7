using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensivitiHor;
    [SerializeField] private float sensivitiVert;

    public enum RotationsAxes
    {
        MouseX,
        MouseY
    }

    public RotationsAxes axes;

    private float minimumVert = -35.0f;
    private float maximumVert = 35.0f;

    private float verticalRot = 0;

    private Vector2 inputMouse;

    private void OnEnable()
    {
        InputController.mouseXYEvent += InputMouseXY;
    }

    void Update()
    {
        if (axes == RotationsAxes.MouseX)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0f, inputMouse.x * (sensivitiHor
                * Time.deltaTime), 0f);
        }
        else if (axes == RotationsAxes.MouseY)
        {
            verticalRot = verticalRot - inputMouse.y * (sensivitiVert * Time.deltaTime);
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }

    private void InputMouseXY(Vector2 rot)
    {
        inputMouse = rot;
    }

    private void OnDisable()
    {
        InputController.mouseXYEvent -= InputMouseXY;
    }
}
