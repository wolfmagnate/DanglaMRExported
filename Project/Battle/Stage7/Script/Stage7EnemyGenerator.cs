using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorUtil;

public class Stage7EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenEnemy());
    }


    public GameObject Player;
    public GameObject[] enemys;
    public GameObject[] effects;
    private IEnumerator GenEnemy()
    {
        // フェーズ1
        var tutorialEnemy1 = CreateEnemy(enemys[0], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });
        tutorialEnemy1 = CreateEnemy(enemys[1], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });
        tutorialEnemy1 = CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });
        tutorialEnemy1 = CreateEnemy(enemys[3], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });
        tutorialEnemy1 = CreateEnemy(enemys[3], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
        yield return WaitDieOf(new EnemyStatusController[] { tutorialEnemy1.GetComponent<EnemyStatusController>() });

        // フェーズ2
        var enemies = new List<EnemyStatusController>();
        enemies.Add(CreateEnemy(enemys[0], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[1], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(10);
        enemies.Add(CreateEnemy(enemys[1], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[2], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(10);
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[3], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(10);
        enemies.Add(CreateEnemy(enemys[3], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[0], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(10);
        enemies.Add(CreateEnemy(enemys[3], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[1], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(10);
        yield return WaitDieOf(enemies.ToArray());

        // フェーズ3
        enemies = new List<EnemyStatusController>();
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(12);
        enemies.Add(CreateEnemy(enemys[3], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[3], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[3], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(12);
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[2], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        enemies.Add(CreateEnemy(enemys[1], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[1], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        enemies.Add(CreateEnemy(enemys[3], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[3], new Vector3(2, 0, 2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]).GetComponent<EnemyStatusController>());
        yield return new WaitForSeconds(8);
        enemies.Add(CreateEnemy(enemys[0], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]).GetComponent<EnemyStatusController>());
        enemies.Add(CreateEnemy(enemys[0], new Vector3(-2, 0, -2) + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]).GetComponent<EnemyStatusController>());
        yield return WaitDieOf(enemies.ToArray());

        GameObject.Find("Manager").GetComponent<Stage7SceneControl>().HasWin = true;

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
        generatedEnemy.GetComponent<EnemyStatusController>().OnDie.AddListener(() => GameObject.Find("Manager").GetComponent<Stage7SceneControl>().AddKillCounter());

        return generatedEnemy;
    }
}
