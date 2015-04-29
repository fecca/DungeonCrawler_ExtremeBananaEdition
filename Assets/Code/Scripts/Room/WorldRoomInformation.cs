using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class WorldRoomInformation
{
    [SerializeField]
    private Door door = null;
    [SerializeField]
    private Text text = null;
    [SerializeField]
    private Transform spawnPoint = null;

    public Door Door
    {
        get { return door; }
    }
    public Text Text
    {
        get { return text; }
    }
    public Transform SpawnPoint
    {
        get { return spawnPoint; }
    }
}