using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float cameraSpeed = 70f;
    const float rotationSpeed = 50f;
    const float zoomSpeed = 500f;

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
            cameraPos.z += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            cameraPos.x -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            cameraPos.z -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            cameraPos.x += cameraSpeed * Time.deltaTime;
        }
        #endregion
        #region CameraRotation

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(transform.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
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