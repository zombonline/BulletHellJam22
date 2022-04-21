using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Director Speech")]
public class DirectorSpeech : ScriptableObject
{
    [SerializeField] public TextAsset speech;
    [SerializeField] public Sprite directorSprite;
}

