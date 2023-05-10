using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ZukanEnemy")]
public class ZukanEnemy : ScriptableObject
{
    [Obsolete]
    public string EnemyStatus { get => $"HPF{statusController.HP}, AttackF{controlEnemy.Attack}"; }

    public GameObject Enemy;
    EnemyStatusController _statusController;
    EnemyStatusController statusController { get => _statusController ?? (_statusController = Enemy.GetComponent<EnemyStatusController>()); }
    ControlEnemy _controlEnemy;
    ControlEnemy controlEnemy { get => _controlEnemy ?? (_controlEnemy = Enemy.GetComponent<ControlEnemy>()); }
    public Sprite Icon;
    public string Description;

    public float HP { get => statusController.HP; }
    public float Attack { get => controlEnemy.Attack; }
    public string Name;
    public int Stage;
}
