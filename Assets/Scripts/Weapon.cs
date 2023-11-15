using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float shootForce = 10f;
    public float projectileMass = 0.1f;

    public AmmoUI ammoUI;
    private int currentAmmo = 30; 
    private int maxAmmo = 30;


    void Start()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        if (spawnPoint != null)
        {
            float cameraRotationX = Camera.main.transform.eulerAngles.x;
            float cameraRotationY = Camera.main.transform.eulerAngles.y;

            spawnPoint.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();

            DecreaseAmmo();
        }
    }

    
    void Fire()
    {
        if (currentAmmo <= 0)
        {
            Debug.LogWarning("No ammo left!");
            return;
        }

        Vector3 spawnPointPosition = spawnPoint.position;
        Quaternion spawnPointRotation = spawnPoint.rotation;

        GameObject projectileGO = Instantiate(projectilePrefab, spawnPointPosition, spawnPointRotation);
        Rigidbody projectileRigidbody = projectileGO.GetComponent<Rigidbody>();

        if (projectileRigidbody != null)
        {
            projectileRigidbody.mass = projectileMass;

            Vector3 shootDirection = spawnPoint.forward;

            projectileRigidbody.velocity = shootDirection * shootForce;

            DecreaseAmmo();
        }
    }

    void DecreaseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;

            UpdateAmmoUI();
        }
        else
        {
            Debug.LogWarning("No ammo left!");
        }
    }

    void UpdateAmmoUI()
    {
        ammoUI.UpdateAmmo(currentAmmo);
    }

    public void RefreshAmmo()
    {
        currentAmmo = maxAmmo;

        UpdateAmmoUI();
    }
}




