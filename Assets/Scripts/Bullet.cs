using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma olduðunda mermiyi yok et
        Destroy(gameObject);

        // Hedefe hasar ver
        // Hedefin bir health componenti varsa onu bul ve hasar ver
        Health target = collision.gameObject.GetComponent<Health>();
        if (target != null)
        {
            target.TakeDamage(10); // Örneðin 10 birim hasar
        }
    }
}

