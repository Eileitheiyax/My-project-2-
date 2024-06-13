using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            ThirdPersonMovement thirdPersonMovement = other.GetComponent<ThirdPersonMovement>();
            thirdPersonMovement.BackToRespawn();
            Debug.Log(other.gameObject.name+"1");
        }
    }
}
