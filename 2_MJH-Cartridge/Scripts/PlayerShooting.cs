using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
    
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            if (PlatformDetector.IsMobile())
            {
                if (CrossPlatformInput.GetInputButton())
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
            else
            {
                if (Input.GetButton("Fire1"))
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
            }
        }
    }
    
    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
            
            AudioManager.Instance?.PlaySFX("Gunshot_Pistol");
        }
    }
}
