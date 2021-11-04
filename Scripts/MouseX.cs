using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseX : MonoBehaviour
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
        float mouseX = Input.GetAxis("Mouse X");//gets mouse input on X 
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * sensetivety ;//changes Players Y roatation based on mouse input and stores in a temp variable
        transform.localEulerAngles = newRotation;//edits players roatation
    }
}
