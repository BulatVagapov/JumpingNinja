using System;
using UnityEngine;

[Serializable]
public class OpenedNinjasArrayForSave
{
    [SerializeField] private bool[] openedNinjas;
    public int ChosenNinjaIndex;

    public bool[] OpenedNinjas => openedNinjas;

    public OpenedNinjasArrayForSave()
    {
        openedNinjas = new bool[6] { true, false, false, false, false, false };
        ChosenNinjaIndex = 0;
    }
}
