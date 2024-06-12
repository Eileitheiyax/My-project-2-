using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'ý
    public Transform firePoint; // Merminin çýkýþ noktasý
    public float bulletSpeed = 20f; // Merminin hýzý
    public float fireRate = 0.5f; // Ateþ etme sýklýðý
    private float nextFireTime = 0f; // Bir sonraki ateþ etme zamaný

    void Update()
    {
        // Mouse sol tuþu veya belirli bir tuþa basýldýðýnda ateþ et
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Mermiyi oluþtur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        // Mermiyi belirli bir süre sonra yok et
        Destroy(bullet, 2.0f);
    }
}

