using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBox : MonoBehaviour
{
    [SerializeField]
    private GameObject _DestructibleBox;

    public void SwapToDestructible() 
    {
        Instantiate(_DestructibleBox, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
