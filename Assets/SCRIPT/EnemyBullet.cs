using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by enemy bullet!");

            PlayerLives player= other.GetComponent<PlayerLives>();
            if(player != null)
            {
                player.LoseLife();
            }
            
            Destroy(gameObject);
        }
    }
}
