using UnityEngine;

public class CommanderData : ScriptableObject
{
    [SerializeField] private GameObject factory;

    public GameObject Factory { get => factory; }
}
