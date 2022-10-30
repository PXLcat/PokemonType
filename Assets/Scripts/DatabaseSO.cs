using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "ScriptableObjects/PokemonDatabase")]
public class DatabaseSO : ScriptableObject
{
    public List<PokemonSO> Database;
}
