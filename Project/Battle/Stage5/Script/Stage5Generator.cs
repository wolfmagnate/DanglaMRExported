using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Generator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GenEnemy());
        enemyCash = null;
    }


    public GameObject Player;
    public GameObject enemy;
    public GameObject enemyCash { get; set; }
    public GameObject Cast;
    public GameObject Aura;
    public GameObject Orbital;
    public GameObject Explosion;
    public GameObject LastExplosion;
    private IEnumerator GenEnemy()
    {
        // エフェクトをガン積みする
        var gencast = Instantiate(Cast, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0,0,0));
        gencast.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        var genAura = Instantiate(Aura, Player.transform.position + Player.transform.forward * 5 + Vector3.down, Quaternion.Euler(-90, 0, 0));
        yield return new WaitForSeconds(0.5f);
        var genOrbital = Instantiate(Orbital, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(1.5f);
        Instantiate(Explosion, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Explosion, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        Instantiate(Explosion, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.3f);
        var lastgenexplosion = Instantiate(LastExplosion, Player.transform.position + Player.transform.forward * 5, Quaternion.Euler(0, 0, 0));
        lastgenexplosion.transform.localScale = new Vector3(2, 2, 2);
        yield return new WaitForSeconds(0.3f);
        Destroy(gencast);
        Destroy(genAura);
        Destroy(genOrbital);
        // プレイヤーの5m前方に出現
        var genenemy = Instantiate(enemy, forwordPosition(5, 0), Player.transform.rotation);
        genenemy.transform.LookAt(Player.transform);
        genenemy.GetComponent<EnemyStatusController>().OnDie.AddListener(() => { GameObject.Find("Manager").GetComponent<Stage5Controller>().Win(); });
        enemyCash = genenemy;
        yield return null;
    }
    private Vector3 forwordPosition(float meter, float ratateDegree)
    {
        var rawnormal = new Vector3(transform.forward.x, 0, transform.forward.z);
        return Player.transform.position + Quaternion.Euler(0, ratateDegree, 0) * rawnormal.normalized * meter;
    }
}
