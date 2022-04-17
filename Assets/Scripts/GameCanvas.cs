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
    private void Awake()
    {
        area = FindObjectOfType<Area>();
    }
    private void Update()
    {
        DisplayScorePercentage();
        DirectorDuringGameplay();
    }

    private void DirectorDuringGameplay()
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

    private void DisplayScorePercentage()
    {
        var score = (area.timeInArea / area.totalTime) * 100;
        scoreText.text = score.ToString("00") + "%";
    }
}
