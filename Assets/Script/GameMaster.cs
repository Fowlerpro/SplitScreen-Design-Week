using UnityEngine;

public class GameMaster : MonoBehaviour
{
    float endTime = 0;
    public float startTime = 240;
    bool timerActive = true;
    public float countdownTimer = 5;
    public GameObject scorePanel;
    public GameObject namePanel;



    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0f)
        {
            timerActive = true;
            Debug.Log("Game Start!");
        }

        if (timerActive)
        {
            startTime -= Time.deltaTime;
            if (startTime <= 0f)
            {
                Debug.Log("Game Over!");
                scorePanel.SetActive(true);
                namePanel.SetActive(true);
            }
        }
    }
}
