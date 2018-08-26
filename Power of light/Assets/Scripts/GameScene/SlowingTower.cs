using UnityEditor;
using UnityEngine;

public class SlowingTower : Tower {

    [SerializeField] float damage;
    [SerializeField] float slowPerc;
    [SerializeField] float slowDuration; 
    [SerializeField] float cooldown;
    [SerializeField] float Range;
    float timer = 0;
    [SerializeField] LayerMask WhatToHit;

    private void Awake()
    {
        range = Range;
        whatToHit = WhatToHit; 
    }

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;
        if (timer <= 0)
        {
            Attack();
            timer = cooldown; 
        }
        timer -= Time.deltaTime; 
    }

    void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range, whatToHit);
        foreach (Collider h in hits)
        {
            Enemy enemy = h.transform.GetComponentInParent<Enemy>();
            Status.Slowing(enemy, slowPerc, slowDuration);
            Status.Damage(enemy, damage); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range); 
    }
}
