using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    private float scrollSpeed = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if(GameManager.GameIsOver)
        {
            enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);//is the same as v3(0,0,1)
        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);//is the same as v3(0,0,1)
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);//is the same as v3(0,0,1)
        }
        else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);//is the same as v3(0,0,1)
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 currentPos = transform.position;

        currentPos.y -= scroll * 1000 *scrollSpeed * Time.deltaTime;
        currentPos.y = Mathf.Clamp(currentPos.y, minY, maxY);

        transform.position = currentPos;
    }
}
