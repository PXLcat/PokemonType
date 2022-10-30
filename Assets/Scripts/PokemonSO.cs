using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "ScriptableObjects/Pokemon")]
public class PokemonSO : ScriptableObject
{
    public int EntryNumber;
    public string Name;
    public Sprite Illustration;
}
