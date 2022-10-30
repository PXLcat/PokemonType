using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterBehaviour : MonoBehaviour
{
    public char Answer;
    public TMP_Text CharacterDisplay;
    public char CurrentCharacter = '_';

    public void ShowAnswer()
    {
        CharacterDisplay.text = Answer.ToString();
    }
}
