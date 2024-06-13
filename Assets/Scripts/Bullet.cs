using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Health target = other.GetComponent<Health>();
        if (target != null)
        {
            target.TakeDamage(10);
        }
    }
}
