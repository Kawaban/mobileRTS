using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private float health;

    public float Health { get => health; }
}
