using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    Player player;
    GameObject Canvas;
    [SerializeField]
    AudioSource WinSound;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Canvas = GameObject.Find("Canvas");

        if (player == null) { Debug.Log("Shark: Player not Set"); }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player.HasCoin == true)
                {
                    player.HasCoin = false;
                    Canvas.GetComponent<UI_Manager>().DisableCoinIMage();
                    WinSound.Play();

                    player._canShoot = true;
                    player.SetWeaponActive();
                }
                else
                {
                    Debug.Log("FUCK  OFF YOU PIECE OF SHIT , YOUR MOM FAT");
                }
            }
            
        }
    }

}
