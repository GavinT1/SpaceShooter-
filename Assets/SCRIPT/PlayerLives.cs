using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public TMP_Text livesText;
    public float respawnDelay = 1f;
    public GameObject gameOverPanel;

    public AudioClip gameOverSound;
    public AudioSource audioSource;

    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;
    private bool isRespawning = false;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        UpdateLivesUI();
        gameOverPanel.SetActive(false);
    }

    public void LoseLife()
    {
        if (isRespawning)
            return;

        lives--;

        if (lives > 0)
        {
            UpdateLivesUI();
            StartCoroutine(Respawn());
        }
        else
        {
            UpdateLivesUI();
            Debug.Log("Game Over");
            StartCoroutine(GameOverSequence()); 
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! No lives left.");

        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator GameOverSequence()
    {
        GameOver();

       
        float delay = (gameOverSound != null) ? gameOverSound.length : 1f;
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }

    IEnumerator Respawn()
    {
        isRespawning = true;
        spriteRenderer.enabled = false;
        playerCollider.enabled = false;
        transform.position = startPosition;

        yield return new WaitForSeconds(respawnDelay);

        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
        isRespawning = false;
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
