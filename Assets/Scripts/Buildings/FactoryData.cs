using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/FactoryData")]
public class FactoryData : ScriptableObject
{
    [SerializeField] private GameObject generatedUnit;
    [SerializeField] private float secondsToGenerate;

    public GameObject GeneratedUnit { get => generatedUnit; set => generatedUnit = value; }
    public float SecondsToGenerate { get => secondsToGenerate; set => secondsToGenerate = value; }
}
