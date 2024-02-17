using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float constructionCost;
    [SerializeField] private float width;
    [SerializeField] private float length;
    [SerializeField] private float height;

    public float Health { get => health; }
    public float Width { get => width; }
    public float Length { get => length; }  
    public float Height { get => height; }
    public float ConstructionCost { get => constructionCost; }
   
}
