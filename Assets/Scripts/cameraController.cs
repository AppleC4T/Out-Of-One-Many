using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float panSpeed = 15f;
    public float rotationSpeed = 20f;
    public Vector2 camLimit;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 45f;
    public float minRotX = 15f;
    public float maxRotX = 75f;
    public float maxRotY = 50f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 newRotation = transform.rotation.eulerAngles;

        if (Input.GetKey("w"))
        {
            newPosition.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            newPosition.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            newPosition.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            newPosition.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("r") && (transform.eulerAngles.x > minRotX))
        {
            transform.eulerAngles -= new Vector3(rotationSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("f") && (transform.eulerAngles.x < maxRotX))
        {
            transform.eulerAngles += new Vector3(rotationSpeed * Time.deltaTime, 0, 0);
        }
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        newPosition.y += -scrollValue * scrollSpeed * Time.deltaTime * 100f;

        newPosition.x = Mathf.Clamp(newPosition.x, -camLimit.x, camLimit.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.z = Mathf.Clamp(newPosition.z, -camLimit.y, camLimit.y);

        newRotation.x = Mathf.Clamp(newRotation.x, minRotX, maxRotX);
        newRotation.y = Mathf.Clamp(newRotation.z, -maxRotY, maxRotY);

        transform.position = newPosition;

    }
}
