using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomsInformation", menuName = "CONFIGURATIONS/RoomsInformation", order = 0)]
public class RoomsInformation : ScriptableObject
{
    [field: SerializeField] public List<string> rooms { get; private set; }
}