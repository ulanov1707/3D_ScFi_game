using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;
  

    private void OnTriggerStay(Collider other)
    {
       
        if (other.tag == "Player")
        {
           
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Player player = other.GetComponent<Player>();
                player.HasCoin = true;

                sound.Play();
                GameObject.Find("Canvas").GetComponent<UI_Manager>().EndbleCoinImage();
               
                Destroy(this.gameObject, 1f);
            }
        }
    }
}
