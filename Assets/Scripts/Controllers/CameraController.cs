using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float cameraSpeed = 40f;
    const float rotationSpeed = 100f;
    const float zoomSpeed = 400f;

    [Header("Camera Limitations")]
    public Vector2 xAxis;
    public Vector2 zAxis;
    public Vector2 zoomLimit;

    Vector3 cameraPos; // Current position of camera
 
    void Update()
    {
        cameraPos = transform.position;

        #region CameraMovement
        if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Translate(0, 0, cameraSpeed * Time.deltaTime);
            cameraPos = transform.localPosition;
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Translate((-cameraSpeed * Time.deltaTime), 0, 0);
            cameraPos = transform.localPosition;
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Translate(0, 0, (-cameraSpeed * Time.deltaTime));
            cameraPos = transform.localPosition;
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Translate(cameraSpeed * Time.deltaTime, 0, 0);
            cameraPos = transform.localPosition;
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }
        #endregion
        #region CameraRotation

        if (Input.GetKey(KeyCode.Q))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Rotate(transform.up, -rotationSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(50, transform.localEulerAngles.y, 0);
        }

        #endregion
        #region CameraZoom

        float currentZoom = Input.GetAxis("Mouse ScrollWheel");

        cameraPos.y -= currentZoom * zoomSpeed * Time.deltaTime;

        #endregion

        // Movement limitations
        /*cameraPos.x = Mathf.Clamp(cameraPos.x, xAxis.x, xAxis.y);
        cameraPos.z = Mathf.Clamp(cameraPos.z, zAxis.x, zAxis.y);
        // Zoom limitations
        cameraPos.y = Mathf.Clamp(cameraPos.y, zoomLimit.x, zoomLimit.y);*/

        transform.position = cameraPos;
    }
}