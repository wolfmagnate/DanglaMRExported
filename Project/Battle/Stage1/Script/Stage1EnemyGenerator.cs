using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RandomUtil;
using static GeneratorUtil;

public class Stage1EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenEnemy());
    }


    public GameObject Player;
    public GameObject[] enemys;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;

    public GameObject[] enemyEffects;

    private IEnumerator GenEnemy()
    {
        // フェーズ1
        var tutorialEnemy1 = CreateEnemy(tutorial1, forwordPosition(8,0), enemyEffects[0]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });
        var tutorialEnemy2 = CreateEnemy(tutorial2, forwordPosition(8, 30), enemyEffects[1]);
        var tutorialEnemy3 = CreateEnemy(tutorial2, forwordPosition(8, -30), enemyEffects[1]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy2.GetComponent<EnemyStatusController>(), tutorialEnemy3.GetComponent<EnemyStatusController>() });
        var tutorialEnemy4 = CreateEnemy(tutorial3, forwordPosition(8, 0), enemyEffects[2]);
        var tutorialEnemy5 = CreateEnemy(tutorial3, forwordPosition(8, 120), enemyEffects[2]);
        var tutorialEnemy6 = CreateEnemy(tutorial3, forwordPosition(8, 240), enemyEffects[2]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy4.GetComponent<EnemyStatusController>(), tutorialEnemy5.GetComponent<EnemyStatusController>(), tutorialEnemy6.GetComponent<EnemyStatusController>() });

        List<EnemyStatusController> battleEnemies = new List<EnemyStatusController>();

        // フェーズ2
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6, 0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(5);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6, 0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(5);
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6, 0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(5);
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6, 0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6, 0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(5);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6, 0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6, 0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(5);
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6, 0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6, 0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return WaitDieOf(battleEnemies.ToArray());
        battleEnemies = new List<EnemyStatusController>();

        // フェーズ3
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6,0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6,0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(4);
        yield return new WaitForSeconds(6);
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8); 
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6,0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6,0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(6);
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[2], forwordPosition(6,0), enemyEffects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[0], forwordPosition(6,0), enemyEffects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6,0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        battleEnemies.Add(CreateEnemy(enemys[1], forwordPosition(6, 0), enemyEffects[1]).GetComponent<EnemyStatusController>());
        yield return WaitDieOf(battleEnemies.ToArray());
        GameObject.Find("Manager").GetComponent<Stage1SceneControl>().HasWin = true;
    }

    private GameObject CreateEnemy(GameObject enemy, Vector3 position, GameObject effect)
    {
        var generatedEnemy = Instantiate(enemy,
               position,
               Quaternion.identity
            );

        var generatedeffect = Instantiate(effect, position, Quaternion.Euler(90, 0, 0));
        generatedeffect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(generatedeffect, 5);


        generatedEnemy.transform.LookAt(Player.transform);
        generatedEnemy.GetComponent<EnemyStatusController>().OnDie.AddListener(() => GameObject.Find("Manager").GetComponent<Stage1SceneControl>().AddKillCounter());

        return generatedEnemy;
    }

    private Vector3 forwordPosition(float meter, float ratateDegree)
    {
        var rawnormal = new Vector3(transform.forward.x, 0, transform.forward.z);
        return Player.transform.position + Quaternion.Euler(0,ratateDegree,0) * rawnormal.normalized * meter;
    }
}
