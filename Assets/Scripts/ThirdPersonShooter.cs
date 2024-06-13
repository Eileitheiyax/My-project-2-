using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f; 
    public float fireRate = 0.5f; 
    private float nextFireTime = 0f;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.transform.forward * bulletSpeed;

        gameManager.audioManager.PlayOneShotAudio(0); ;
        Destroy(bullet, 2.0f);
    }

}

