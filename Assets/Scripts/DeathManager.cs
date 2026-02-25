using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public string sceneName;

    private bool isDead = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerDeath();
    }

    public void TriggerDeath()
    {
        if (isDead) return;
        isDead = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        isDead = false;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
