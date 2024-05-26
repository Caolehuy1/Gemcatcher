using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private  static float remainingTime;
    [SerializeField] private CharacterMovement CharacterMovement;
    [SerializeField] private GemFallScript GemFallScript;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;

    private void GameOver()
    {
        GemFallScript.setGameOrver(true);
        CharacterMovement.setGameOrver(true);
        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }
    // ...rest of the script...


public static void AddScore(int amount)
    {
        
        score += amount;
        if (score <= 0 )score=0 ;
           
    }
    public static void MutipleScore(int amount)
    {
        score *= amount;
    }

    void Start() // đếm giờ khi trò chơi bắt đầu

    {

        remainingTime = 30f;
       
        //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }
    public static void AddTime(float amount)
    {
        remainingTime += amount;
    }
    void Update()
    {
    if (remainingTime <= 0)
    {
        GameOver();
}
    scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime); //Mathf.CeilToInt(remainingTime) làm tròn số nguyên dương
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
    }
}