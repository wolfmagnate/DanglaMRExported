using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicShooter
{
    public virtual bool CanShoot()
    {
        return shootPlayer.MP > GetConsumeMP();
    }
    // �e�ۂ������ꂽ�Ƃ��Ƀ`���[�W����B�`���[�W�^�C�������������ꂽ��CanShoot()��true��Ԃ�
    public abstract void Charge();

    protected ShootPlayer shootPlayer;
    protected ChargeUIControl chargeUI;
    public MagicShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI)
    {
        this.shootPlayer = shootPlayer;
        this.chargeUI = chargeUI;
    }

    // �ł��o���e�ۂ𐶐�����
    public abstract GameObject[] GenerateShot();

    public void ConsumeMP(ShootPlayer player)
    {
        player.DecreaceMP(GetConsumeMP());
    }

    //�L�[�������ꂽ�u�ԂɌĂ΂��
    public abstract void AfterShoot();
    public abstract void OnClickLeave(ShootPlayer player);
    protected virtual float GetConsumeMP()
    {
        return ShootPlayer.usingMagic.MP;
    }

    public abstract void OnClickStart();

    public virtual void Shoot(GameObject[] shots)
    {
        foreach(var shot in shots)
        {
            shot.transform.position = shootPlayer.transform.position;
            shot.transform.rotation = shootPlayer.transform.rotation;
            shot.GetComponent<AttackShot>().SetDirection(ShootPlayer.usingDirection);
            shot.GetComponent<AttackShot>().Go();
        }
    }

    public GameObject Effect { get; set; }
    public GameObject HitEffect { get; set; }
}
