using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform firePoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 20f; // Merminin h�z�
    public float fireRate = 0.5f; // Ate� etme s�kl���
    private float nextFireTime = 0f; // Bir sonraki ate� etme zaman�

    void Update()
    {
        // Mouse sol tu�u veya belirli bir tu�a bas�ld���nda ate� et
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Mermiyi olu�tur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        // Mermiyi belirli bir s�re sonra yok et
        Destroy(bullet, 2.0f);
    }
}

