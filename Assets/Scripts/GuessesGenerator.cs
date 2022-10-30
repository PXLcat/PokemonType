using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessesGenerator : MonoBehaviour
{
    [SerializeField]
    private DatabaseSO _data;

    [SerializeField]
    private Transform _wordContainer;

    [SerializeField]
    private Image _illustration;

    [SerializeField]
    private CharacterBehaviour _characterPrefab;

    [Header("SFX")]
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _rightAnswer;

    [SerializeField]
    private AudioClip _wrongAnswer;

    private PokemonSO _currentPokemon;

    private int _currentIndex = 0;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        foreach (Transform child in _wordContainer.transform)
        {
            Destroy(child.gameObject);
        }

        _currentIndex = 0;

        int randomIndex = UnityEngine.Random.Range(1,_data.Database.Count);

        _currentPokemon = _data.Database[randomIndex - 1];

        _illustration.sprite = _currentPokemon.Illustration;

        foreach (char letter in _currentPokemon.Name)
        {
            CharacterBehaviour newLetter = GameObject.Instantiate(_characterPrefab, _wordContainer);
            newLetter.Answer = letter;
        }
    }

    private void Update()
    {
        foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keycode))
            {
                Debug.Log("KeyCode down: " + keycode);

                if (String.Equals(keycode.ToString(),_currentPokemon.Name[_currentIndex].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("correct");

                    _audioSource.clip = _rightAnswer;
                    _audioSource.Play();

                    _wordContainer.GetChild(_currentIndex).GetComponent<CharacterBehaviour>().ShowAnswer();
                    _currentIndex++;

                    if (_currentIndex == (_currentPokemon.Name.Length))
                    {
                        Debug.Log("end of word");
                        Generate();
                    }
                }
            }
        }

    }

}
