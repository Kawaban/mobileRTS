using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/CommanderData")]
public class CommanderData : ScriptableObject
{
    [SerializeField] private GameObject factory;
    [SerializeField] private GameObject miningComplex;
    [SerializeField] private GameObject turret;

    public GameObject Factory { get => factory; }
    public GameObject MiningComplex { get => miningComplex;  }
    public GameObject Turret { get => turret; }
}
