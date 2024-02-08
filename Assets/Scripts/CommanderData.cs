using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/CommanderData")]
public class CommanderData : ScriptableObject
{
    [SerializeField] private GameObject factory;
    [SerializeField] private GameObject miningComplex;

    public GameObject Factory { get => factory; }
    public GameObject MiningComplex { get => miningComplex; set => miningComplex = value; }
}
