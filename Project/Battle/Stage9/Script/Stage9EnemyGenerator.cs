using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorUtil;

public class Stage9EnemyGenerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenEnemy());
    }


    public GameObject Player;
    public GameObject[] enemys;
    public GameObject[] effects;
    public GameObject HelpPoint;
    private IEnumerator GenEnemy()
    {
        var enemyPointStatus = GameObject.FindGameObjectWithTag("EnemyHelpPoint").GetComponent<EnemyPointStatus>();

        for (int i = 0; i < 3; i++)
        {
            // フェーズ1(6体)
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
            yield return new WaitForSeconds(6);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
            yield return new WaitForSeconds(6);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            yield return new WaitForSeconds(6);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            yield return new WaitForSeconds(6);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
            yield return new WaitForSeconds(6);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
            yield return new WaitForSeconds(6);

            yield return WaitDamageOfEnemyHelpPoint(enemyPointStatus, 500 + 2500 * i, 10);

            // フェーズ2(12体)
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            yield return new WaitForSeconds(15);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
            yield return new WaitForSeconds(15);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            yield return new WaitForSeconds(15);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
            yield return new WaitForSeconds(15);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            yield return new WaitForSeconds(15);

            yield return WaitDamageOfEnemyHelpPoint(enemyPointStatus, 1500 + 2500 * i, 10);


            // フェーズ3(21体)
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.up, effects[0]);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.down, effects[1]);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.left, effects[3]);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.right, effects[0]);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[1]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 5, effects[2]);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 7, effects[0]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.up, effects[1]);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.down, effects[2]);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[3]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.left, effects[0]);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6 + Vector3.right, effects[1]);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[2]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 5, effects[3]);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 6, effects[0]);
            CreateEnemy(enemys[1], HelpPoint.transform.position + Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.forward * 7, effects[1]);
            yield return new WaitForSeconds(20);
            CreateEnemy(enemys[2], HelpPoint.transform.position + Quaternion.Euler(0, 0, 0) * Vector3.forward * 6 + Vector3.up, effects[2]);
            CreateEnemy(enemys[3], HelpPoint.transform.position + Quaternion.Euler(0, 120, 0) * Vector3.forward * 6 + Vector3.down, effects[3]);
            CreateEnemy(enemys[0], HelpPoint.transform.position + Quaternion.Euler(0, 240, 0) * Vector3.forward * 6, effects[0]);
            yield return new WaitForSeconds(20);

            yield return WaitDamageOfEnemyHelpPoint(enemyPointStatus, 2500 + 2500 * i, 10);
        }
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

        generatedEnemy.transform.LookAt(HelpPoint.transform);
        generatedEnemy.GetComponent<EnemyStatusController>().OnDie.AddListener(() => GameObject.Find("Manager").GetComponent<Stage9SceneControl>().AddKillCounter());

        return generatedEnemy;
    }
}
