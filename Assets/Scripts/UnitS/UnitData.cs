using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/UnitData")]
public class UnitData : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float targetOffset;
    [SerializeField] private float damage;

    public float Speed { get => speed; set => speed = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public float TargetOffset { get => targetOffset; set => targetOffset = value; }
    public float Health { get => health; set => health = value; }
    public float Damage { get => damage; set => damage = value; }
}
