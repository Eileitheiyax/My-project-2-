using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public float turnSmoothTime = 0.1f;
    public float fallThreshold = -10f; // Haritadan düşme yüksekliği

    private float turnSmoothVelocity;
    private Vector3 velocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Yerçekimi etkisi
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Küçük negatif değer, sürekli yerle temasta kalmasını sağlar
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Karakter haritadan düştü mü kontrol et
        if (transform.position.y < fallThreshold)
        {
            BackToRespawn();
        }
    }

    public void BackToRespawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        controller.enabled = false;
        transform.position = Vector3.zero;
        yield return null; // Bir frame bekle
        controller.enabled = true;
        velocity = Vector3.zero;  // Düşüş hızını sıfırlamak için
    }
}
