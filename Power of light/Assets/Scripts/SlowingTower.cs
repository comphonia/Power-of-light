using UnityEditor;
using UnityEngine;

public class SlowingTower : Tower {

    [SerializeField] float damage;
    [SerializeField] float slowPerc;
    [SerializeField] float slowDuration; 
    [SerializeField] float cooldown;
    [SerializeField] float radius;
    float timer = 0;
    [SerializeField] LayerMask whatToHit;

    private void Update()
    {
        if (timer <= 0 && ThereIsEnemy())
        {
            Attack();
            timer = cooldown; 
        }
        timer -= Time.deltaTime; 
    }

    bool ThereIsEnemy()
    {
        return true; 
    }

    void Attack()
    {
        Debug.Log("attack!");
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.right, Mathf.Infinity, whatToHit);
        Debug.Log(hits.Length); 
        for (int i = 0; i < hits.Length; i++)
        {
            try
            {
                Enemy enemy = hits[i].transform.GetComponent<Enemy>();
                Debug.Log(enemy.name);
                Status.Slowing(enemy, slowPerc, slowDuration); 
            }
            catch
            {
                Debug.Log(hits[i].transform.name + "has no enemy component"); 
            }
        }
    }
}
