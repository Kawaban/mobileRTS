using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/FactoryData")]
public class TurretData : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float reloadTime;
    [SerializeField] private PointType typeOf;
    [SerializeField] private AttackType attackType;
    [SerializeField] private AttackRule attackRule;

    public float Damage { get => damage; }
    public float AttackRange { get => attackRange; }
    public float ReloadTime { get => reloadTime; }
    public PointType TypeOf { get => typeOf; }
    public AttackType AttackType { get => attackType; }
    public AttackRule AttackRule { get => attackRule; }
}
