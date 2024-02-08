using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/FactoryData")]
public class FactoryData : ScriptableObject
{
    [SerializeField] private GameObject generatedUnit;
    [SerializeField] private float secondsToGenerate;
    [SerializeField] private float costOfGeneration;

    public GameObject GeneratedUnit { get => generatedUnit;  }
    public float SecondsToGenerate { get => secondsToGenerate; }
    public float CostOfGeneration { get => costOfGeneration; }
}
