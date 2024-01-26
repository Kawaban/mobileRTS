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
    [SerializeField] private float attackRange;
    [SerializeField] private float reloadTime;

    public float Speed { get => speed;  }
    public float Acceleration { get => acceleration;}
    public float RotationSpeed { get => rotationSpeed;}
    public float TargetOffset { get => targetOffset; }
    public float Health { get => health;  }
    public float Damage { get => damage;  }
    public float AttackRange { get => attackRange; }
    public float ReloadTime { get => reloadTime;  }
}
