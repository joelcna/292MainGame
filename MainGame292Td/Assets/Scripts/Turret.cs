using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float range = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Transform target;

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsEnemy();
        if (checkTargetIsInRange())
        {
            target = null;
            return;
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool checkTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    private void RotateTowardsEnemy()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - target.position.x)*Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
