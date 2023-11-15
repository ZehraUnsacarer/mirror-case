using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadController : MonoBehaviour
{
    public Weapon weapon; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        weapon.RefreshAmmo();
    }
}
