using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/FighterData")]
public class FighterData : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float reloadTime;
    [SerializeField] private PointType typeOf;

    public float Damage { get => damage; }
    public float AttackRange { get => attackRange; }
    public float ReloadTime { get => reloadTime; }
    public PointType TypeOf { get => typeOf; }
}
