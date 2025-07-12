using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MIniGunMovement : MonoBehaviour
{
    public float MiniGunSpeed;

    void Update()
    {
        transform.Translate(Vector3.up * MiniGunSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            Debug.Log("MiniGun hit the player!");
        }
    }
}
