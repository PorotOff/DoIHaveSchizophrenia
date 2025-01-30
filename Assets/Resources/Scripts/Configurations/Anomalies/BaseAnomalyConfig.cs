using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseAnomalyConfig", menuName = "CONFIGURATIONS/BaseAnomalyConfig", order = 0)]
public class BaseAnomalyConfig : ScriptableObject, IIDHaveable, ILocalizable
{
    [field: SerializeField] public int ID { get; private set; }

    [field: SerializeField] public string LocalizationKey { get; private set; }

    public void SetID(int id)
    {
        if (id < 0) throw new Exception("id не может быть меньше 0");

        ID = id;
    }
}