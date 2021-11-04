using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    [SerializeField]
    private float sensetivety = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");//gets mouse input on X 
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * sensetivety;//changes Players Y roatation based on mouse input and stores in a temp variable
         // newRotation.x = Mathf.Clamp(newRotation.x,-130, 90);
        transform.localEulerAngles = newRotation;//edits players roatation
    }
}
