using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject EnemyBulletPrefab;
    public float fireRate = 1f;

    private float nextFireTime;

    void Start()
    {
        nextFireTime = fireRate;
    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        nextFireTime -= Time.deltaTime;
        if (nextFireTime <= 0f)
        {
            Fire();
            nextFireTime = fireRate;
        }
    }

    void Fire()
    {
        Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player hit by enemy!");

        PlayerLives player = other.GetComponent<PlayerLives>();
        if (player != null)
        {
            player.LoseLife(); 
        }

        Destroy(gameObject); 
    }
}
}
