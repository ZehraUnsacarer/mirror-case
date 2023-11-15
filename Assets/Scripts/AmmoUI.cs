using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class AmmoUI : MonoBehaviour
{
    public Text ammoText;

    
    private int currentAmmo = 30; 

    void Start()
    {
        
        UpdateAmmoUI();
    }

   
    public void UpdateAmmo(int newAmmo)
    {
        currentAmmo = newAmmo;

      
        UpdateAmmoUI();
    }

 
    void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }
}
