using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStageEnemyGenerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenEnemy());
    }


    public GameObject Player;
    public GameObject enemy;
    private IEnumerator GenEnemy()
    {
        while (true)
        {
            // プレイヤーの3m前方に出現
            var genenemy = Instantiate(enemy, Player.transform.position + Player.transform.forward * 3, Player.transform.rotation);
            genenemy.transform.LookAt(Player.transform);
            yield return new WaitForSeconds(10000);
        }
    }
}
