using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/New Player")]
public class PlayerAttributes : ScriptableObject
{
    public int Health;
    public float Speed;
    public int Damage;
    public bool CanAttack;
}
