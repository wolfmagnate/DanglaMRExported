using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorUtil;

public class Stage3EnemyGenerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenEnemy());
    }


    public GameObject Player;
    public GameObject[] enemys;
    public GameObject[] effects;
    private IEnumerator GenEnemy()
    {
        
        // フェーズ1(10体)
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);

        // フェーズ2(20体)
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[1]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[2]);
        yield return new WaitForSeconds(8);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        CreateEnemy(enemys[0], forwordPosition(Random.Range(3, 6), Random.Range(0, 360)), effects[0]);
        yield return new WaitForSeconds(8);

        // フェーズ3(21体)
        CreateEnemy(enemys[0], forwordPosition(6, 0) + Vector3.up, effects[0]);
        CreateEnemy(enemys[0], forwordPosition(6, 0), effects[0]);
        CreateEnemy(enemys[0], forwordPosition(6, 0) + Vector3.down, effects[0]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[1], forwordPosition(6, 30), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(6, 0), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(6, -30), effects[1]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[2], forwordPosition(6, 120), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(6, 0), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(6, -120), effects[2]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[0], forwordPosition(6, 20) + Vector3.up, effects[0]);
        CreateEnemy(enemys[1], forwordPosition(6, 0), effects[1]);
        CreateEnemy(enemys[2], forwordPosition(6, -20) + Vector3.down, effects[2]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[0], forwordPosition(6, 0) + Vector3.up, effects[0]);
        CreateEnemy(enemys[0], forwordPosition(6, 0), effects[0]);
        CreateEnemy(enemys[0], forwordPosition(6, 0) + Vector3.down, effects[0]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[1], forwordPosition(6, 30), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(6, 0), effects[1]);
        CreateEnemy(enemys[1], forwordPosition(6, -30), effects[1]);
        yield return new WaitForSeconds(12);
        CreateEnemy(enemys[2], forwordPosition(6, 120), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(6, 0), effects[2]);
        CreateEnemy(enemys[2], forwordPosition(6, -120), effects[2]);
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
        generatedEnemy.GetComponent<EnemyStatusController>().OnDie.AddListener(() => GameObject.Find("Manager").GetComponent<Stage3SceneController>().AddKillCounter());

        return generatedEnemy;
    }
    private Vector3 forwordPosition(float meter, float ratateDegree)
    {
        var rawnormal = new Vector3(transform.forward.x, 0, transform.forward.z);
        return Player.transform.position + Quaternion.Euler(0, ratateDegree, 0) * rawnormal.normalized * meter;
    }
}
