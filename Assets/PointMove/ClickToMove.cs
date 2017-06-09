using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private bool objSelected;
    private Transform selectedObj;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.blue);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                objSelected=true;
                selectedObj = hit.transform;
            }
        }
        if (objSelected )
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //selectedObj.Translate(Vector3.forward*Time.deltaTime);
                selectedObj.GetComponent<Rigidbody>().MovePosition(selectedObj.position + Vector3.forward * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //selectedObj.Translate(Vector3.back*Time.deltaTime);
                selectedObj.GetComponent<Rigidbody>().MovePosition(selectedObj.position + Vector3.back * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //selectedObj.Translate(Vector3.left*Time.deltaTime);
                selectedObj.GetComponent<Rigidbody>().MovePosition(selectedObj.position + Vector3.left * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //selectedObj.Translate(Vector3.right * Time.deltaTime);
                selectedObj.GetComponent<Rigidbody>().MovePosition(selectedObj.position + Vector3.right * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            objSelected = false;
            selectedObj = null;
        }

    }
}
