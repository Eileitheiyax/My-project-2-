using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // Hedef Transform (Unity arayüzünden atanacak)
    public float speed = 5f; // Hız
    public float stoppingDistance = 2f; // Durdurma mesafesi

    void Update()
    {
        // Hedefe olan mesafeyi hesapla
        float distance = Vector3.Distance(transform.position, target.position);

        // Eğer mesafe durdurma mesafesinden büyükse hareket et
        if (distance > stoppingDistance)
        {
            // Hedefe doğru yönel
            Vector3 direction = target.position - transform.position;
            direction.Normalize(); // Yön vektörünü normalize et

            // Hareket
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Mesafe durdurma mesafesinden küçük veya eşitse Kill fonksiyonunu çağır
            Kill();
        }

        // Hedefe bak
        Vector3 lookDirection = target.position - transform.position;
        lookDirection.y = 0; // Y ekseninde dönmeyi engelle (opsiyonel)
        if (lookDirection != Vector3.zero) // lookDirection'un sıfır vektör olmadığından emin ol
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        }
    }

    // Kill fonksiyonu
    void Kill()
    {
        // Bu fonksiyonu daha sonra doldurabilirsiniz
        Debug.Log("Target killed");
    }
}
