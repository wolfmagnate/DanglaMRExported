using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPointStatus : EnemyStatusController
{
    public float MaxHP { get; private set; }
    private GameObject HPCanvas;
    private Image HPBar;
    private GameObject Player;

    private void Start()
    {
        MaxHP = HP;
        HPBar = transform.Find("HPCanvas/HPBar").gameObject.GetComponent<Image>();
        HPCanvas = transform.Find("HPCanvas").gameObject;
        HPCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyPointShieldCashed = Instantiate(EnemyPointShield, transform.position, Quaternion.identity);
        DeleteShield();
        OnDamageWithAmount.AddListener(RecordDamage);
    }

    protected override void UpdateMethod()
    {
        HPBar.fillAmount = HP / MaxHP;
        HPCanvas.transform.LookAt(Player.transform.position);
        if(DamageQueue.Sum() >= MaxHP / 9 && (!ShieldOpen))
        {
            StartCoroutine(DamageCutCoroutine());
        }
    }

    private float TooBigDamageCut = 1;
    public GameObject EnemyPointShield;
    GameObject EnemyPointShieldCashed;
    public Queue<float> DamageQueue = new Queue<float>();
    public override void Damage(float attack, MagicAttribute attribute)
    {
        float amount = TooBigDamageCut * broken * attack * attribute switch
        {
            MagicAttribute.Darkness => resistance.Darkness,
            MagicAttribute.Fire => resistance.Fire,
            MagicAttribute.Ice => resistance.Ice,
            MagicAttribute.Light => resistance.Light,
            MagicAttribute.Lightning => resistance.Lightning,
            MagicAttribute.Metal => resistance.Metal,
            MagicAttribute.Mountain => resistance.Mountain,
            MagicAttribute.Tree => resistance.Tree,
            MagicAttribute.Water => resistance.Water,
            MagicAttribute.Wind => resistance.Wind,
            _ => 0
        };
        HP -= amount;
        OnDamage.Invoke();
        OnDamageWithAmount.Invoke(amount);
    }

    public override void AddBadStatus(BadStatus badStatus, float possibility)
    {
    }

    void RecordDamage(float amount)
    {
        // 300ƒ_ƒ[ƒW‚ðŽó‚¯‚½ê‡‚ÉAƒV[ƒ‹ƒh‚ð“\‚Á‚Ä10•bŠÔUŒ‚‚ð–h‚®
        StartCoroutine(RecordDamageCoroutine(amount));
    }
    IEnumerator RecordDamageCoroutine(float amount)
    {
        DamageQueue.Enqueue(amount);
        yield return new WaitForSeconds(300);
        DamageQueue.Dequeue();
    }

    IEnumerator DamageCutCoroutine()
    {
        TooBigDamageCut = 0;
        CreateShield();
        transform.DOScale(0.5f * Vector3.one, 0.5f);
        DamageQueue.Clear();
        yield return new WaitForSeconds(10);
        TooBigDamageCut = 1;
        DeleteShield();
        transform.DOScale(Vector3.one, 0.5f);
    }

    bool ShieldOpen { get => EnemyPointShieldCashed.transform.localPosition.x > 0.5f; }
    void CreateShield()
    {
        EnemyPointShieldCashed.transform.localScale = 0.4f * Vector3.one;
    }

    void DeleteShield()
    {
        EnemyPointShieldCashed.transform.localScale = Vector3.zero;
    }
}
