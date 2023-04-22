using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 300f; // 5 minutes in seconds
    private float timer = 0f;
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro UI object

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= levelTime)
        {
            SceneManager.LoadScene("Lose");
        }

        // Update timer text
        float remainingTime = levelTime - timer;
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}