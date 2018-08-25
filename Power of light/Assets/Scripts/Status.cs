using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public static IEnumerator Slowing(Enemy enemy, float slowPerc, float duration)
    {
        if (enemy.speed == enemy.defaultSpeed)
        {
            enemy.speed -= enemy.speed * slowPerc / 100;
            yield return new WaitForSeconds(duration);
            enemy.speed = enemy.defaultSpeed;
        }
        yield break;
    }

    public static void Damage (Enemy enemy, float damage)
    {
        Debug.Log(enemy.Health);
        enemy.Health -= damage;
        Debug.Log(enemy.Health);
    }
}
