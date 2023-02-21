using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAttributes Attributes;

    private void Start()
    {
        Debug.Log(gameObject.name);
        Debug.Log(Attributes.Health);
    }

    private void Update()
    {
        // logica de movimentação

    }
}
