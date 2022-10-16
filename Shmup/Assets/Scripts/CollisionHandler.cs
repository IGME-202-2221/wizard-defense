using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        PlayerEnemCollide();
        ProjEnemCollide();
        ProjPlayerCollide();
    }

    public void PlayerEnemCollide()
    {
        foreach (GameObject enemy in EnemyManager.enemies)
        {
            if (CollisionDetection.CircleCollision(player, enemy))
            {
                player.GetComponent<SpriteRenderer>().color = Color.red;
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            }
            else
            {
                player.GetComponent<SpriteRenderer>().color = Color.white;
                enemy.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void ProjEnemCollide()
    {
        foreach (GameObject enemy in EnemyManager.enemies)
        {
            foreach (GameObject projectile in Vehicle.playerProjectiles)
            {
                if (projectile != null && CollisionDetection.PointCircleCollision(projectile, enemy))
                {
                    enemy.GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
                }
                else
                {
                    enemy.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }

    public void ProjPlayerCollide()
    {
        foreach (GameObject projectile in Enemy.enemyProjectiles)
        {
            if (projectile != null && CollisionDetection.AABBCollision(projectile, player))
            {
                player.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            }
            else
            {
                player.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.transform.position, SpriteInfo.GetRadius(player));
        Gizmos.DrawWireCube(player.transform.position, SpriteInfo.Maximum(player) - SpriteInfo.Minimum (player));
        foreach (GameObject enemy in EnemyManager.enemies)
        {
            if (enemy != null)
            {
                Gizmos.DrawWireSphere(enemy.transform.position, SpriteInfo.GetRadius(enemy));
            }
        }
        foreach (GameObject proj in Vehicle.playerProjectiles)
        {
            if(proj != null)
            {
                Gizmos.DrawWireSphere(proj.transform.position, SpriteInfo.GetRadius(proj));
            }
        }
        foreach (GameObject proj in Enemy.enemyProjectiles)
        {
            if (proj != null)
            {
                Gizmos.DrawWireSphere(proj.transform.position, SpriteInfo.GetRadius(proj));
            }
        }
    }
}
