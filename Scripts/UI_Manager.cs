using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    [SerializeField]
    Text AmmoText;
    [SerializeField]
    GameObject CoinImage;
   
    public void UpdateAmmoText(int ammoCount) 
    {
        AmmoText.text = ammoCount.ToString();
    }
    public void EndbleCoinImage() {
        CoinImage.SetActive(true);
    }
    public void DisableCoinIMage()
    {
        CoinImage.SetActive(false);
    }


}
