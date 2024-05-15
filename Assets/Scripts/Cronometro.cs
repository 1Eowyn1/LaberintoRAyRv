using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float totalTime = 300f; // 5 minutos en segundos
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            SceneManager.LoadScene("DeadScene");
            // Timer ha llegado a cero, puedes manejar la lógica aquí si deseas.
            Debug.Log("El tiempo ha terminado!");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = timeString;
    }
}