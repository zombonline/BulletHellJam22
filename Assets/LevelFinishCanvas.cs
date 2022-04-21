using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelFinishCanvas : MonoBehaviour
{

    [SerializeField] float possiblePay = 1000;

    [SerializeField] Text overallPerformanceText, timeInFrameText,  totalPayText;
    float overallPerformance, timeInFrame, totalPay;

    void OnEnable()
    {
        Debug.Log("Enabled");
        var playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        overallPerformance = playerHealth.GetHealth() / playerHealth.GetMaxHealth();

        var area = FindObjectOfType<Area>();
        timeInFrame = area.timeInArea / area.totalTime;
        Debug.Log(((overallPerformance + timeInFrame)/2));
        totalPay = possiblePay * ((overallPerformance + timeInFrame)/2);

        overallPerformanceText.text = (overallPerformance * 100).ToString("00") + "%";
        timeInFrameText.text = (timeInFrame*100).ToString("00") + "%";
        totalPayText.text = "$" + totalPay.ToString(".00");
    }

    public void NextButton()
    {
        FindObjectOfType<GameSession>().totalScore += totalPay;
        FindObjectOfType<MusicPlayer>().ResetVolume();
        SceneLoader.LoadNextScene();
    }
    
    public void QuitButton()
    {
        Destroy(FindObjectOfType<GameSession>().gameObject);
        SceneLoader.LoadMenu();
    }
}
