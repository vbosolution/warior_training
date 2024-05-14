using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public WeaponSpawner weaponSpawner;
    public Warrior warrior;
    public Text scoreText;
    public GameObject gameOverPanel;

    private int score;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        score = 0;
        UpdateScore();
        gameOverPanel.SetActive(false);
        weaponSpawner.enabled = true;
    }

    public void EndGame()
    {
        weaponSpawner.enabled = false;
        gameOverPanel.SetActive(true);
        // need more logic
    }

    public void HandleWeaponCollision(Weapon weapon)
    {
        if (Input.GetKeyDown(weapon.key))
        {
            score++;
            UpdateScore();
            Destroy(weapon.gameObject);
        }
        else
        {
            EndGame();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
