using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/UnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float targetOffset;


    public float Speed { get => speed; }
    public float Acceleration { get => acceleration; }
    public float RotationSpeed { get => rotationSpeed; }
    public float TargetOffset { get => targetOffset; }
    public float Health { get => health; }
   
}
