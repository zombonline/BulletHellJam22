using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    Area area;
    [Header("Score Text")]
    [SerializeField] Text scoreText;
    [Header("Director")]
    [SerializeField] Image directorImage, directorSpeech;
    [SerializeField] Sprite directorAngry, directorHappy;
    [SerializeField] Text directorText;
    [SerializeField] TextAsset[] directorDialogue;
    [SerializeField] float directorAngryTextCountdownTime = 5;
    float directorAngryTextCountdown;

    public bool directorSpeechDone = false;
    [SerializeField] DirectorSpeech[] directorSpeeches;
    int clicks = 0;
    private void Awake()
    {
        area = FindObjectOfType<Area>();
    }
    private void Update()
    {
        DisplayScorePercentage();
        DirectorDuringGameplay();
        DirectorBeforeGameplay();
    }


    private void DirectorBeforeGameplay()
    {
        if(directorSpeeches.Length > clicks && !directorSpeechDone)
        {
            directorImage.sprite = directorSpeeches[clicks].directorSprite;
            directorText.text = directorSpeeches[clicks].speech.ToString();
            directorSpeech.enabled = true;
            directorText.enabled = true;
        }
        if(Input.anyKeyDown && !directorSpeechDone)
        {
            if((clicks + 1) >= directorSpeeches.Length)
            {
                directorSpeechDone = true;
                directorSpeech.enabled = false;
                directorText.enabled = false;
            }
            else
            {
                clicks++;
            }
        }

    }

    private void DirectorDuringGameplay()
    {
        if (LevelTimer.levelRunning)
        {
            if (area.playerInArea)
            {
                directorImage.sprite = directorHappy;
                directorAngryTextCountdown = directorAngryTextCountdownTime;
                directorSpeech.enabled = false;
                directorText.enabled = false;
            }
            else
            {
                directorImage.sprite = directorAngry;
                directorAngryTextCountdown -= Time.deltaTime;
                if (directorAngryTextCountdown < 0)
                {
                    if (directorSpeech.enabled != false)
                    {
                        return;
                    }
                    directorSpeech.enabled = true;
                    directorText.enabled = true;
                    directorText.text = directorDialogue[Random.Range(0, directorDialogue.Length)].ToString();
                }
            }
        }
    }

    private void DisplayScorePercentage()
    {
        var score = (area.timeInArea / area.totalTime) * 100;
        scoreText.text = score.ToString("00") + "%";
    }
}
