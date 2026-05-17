using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public int maxAmmo = 30;
    public float reloadTime = 2f;

    [Header("Effects")]
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletHolePrefab;

    [Header("References")]
    public Transform weaponPoint;
    public Camera playerCamera;

    private int currentAmmo;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        if (GameManager.Instance.currentState != GameState.Playing)
            return;

        if (isReloading)
            return;

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash?.Play();
        AudioManager.Instance?.PlaySFX("Gunshot_Rifle");
        
        currentAmmo--;
        UIManager.Instance?.UpdateAmmoUI(currentAmmo, maxAmmo);

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log($"Hit: {hit.transform.name}");
            
            // ইমপ্যাক্ট ইফেক্ট
            if (impactEffect != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            
            // বুলেট হোল
            if (bulletHolePrefab != null)
            {
                GameObject hole = Instantiate(bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hole, 5f);
            }

            // এনিমিতে ড্যামেজ
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        AudioManager.Instance?.PlaySFX("Reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        UIManager.Instance?.UpdateAmmoUI(currentAmmo, maxAmmo);
    }
}
