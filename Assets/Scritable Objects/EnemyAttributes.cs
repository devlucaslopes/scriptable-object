using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/New Enemy")]
public class EnemyAttributes : ScriptableObject
{
    public int Health;
    public float Speed;
    public int Damage;
}
