using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���p����g�ރJ�[�h
/// �J�[�h�̊�{�I�ȋ������͂��ׂ�ScriptableObject�Ɏ������Ă���
/// </summary>
[System.Serializable]
public abstract class MagicCard
{
    public string CardName;
    protected string Path { get; set; }
    public MagicAttribute CardAttribute;
    public List<CardRace> Race;

    // ���i�n�̃p�����[�^
    public int BuyPrice { protected set; get; }
    public int SellPrice { protected set; get; }
    public MagicCard(string path)
    {
        Path = path;
        LoadFromPath();
    }

    public MagicCard()
    {

    }

    public abstract Sprite GetIcon();

    /// <summary>
    /// �w�肵���p�X�ɑ��݂���ScriptableObject����A�J�[�h�̏���ǂݎ��
    /// </summary>
    /// <param name="path">ScriptableObject�̑��݃f�B���N�g���̃p�X</param>
    public abstract void LoadFromPath();

    /// <summary>
    /// �����Ă��������ɂ��␳���v�Z����
    /// </summary>
    /// <param name="cardDirection">�����Ă�������</param>
    public abstract void AddEnterPowerUp(CardDirection cardDirection, List<PowerUpType> powerUps);

    /// <summary>
    /// �o�Ă��������ɂ��␳���v�Z����
    /// </summary>
    /// <param name="cardDirection">�o�Ă�������</param>
    public abstract void AddLeavePowerUp(CardDirection cardDirection, List<PowerUpType> powerUps);

    /// <summary>
    /// ���O�̃J�[�h�Ƃ̑����ɂ��␳���v�Z����
    /// </summary>
    /// <param name="previousCard">���O�̃J�[�h</param>
    public abstract void AddPreviousMemberPowerUp(MagicCard previousCard, List<PowerUpType> powerUps);

    /// <summary>
    /// ����̃J�[�h�Ƃ̑����ɂ��␳���v�Z����
    /// </summary>
    /// <param name="nextCard">����̃J�[�h</param>
    public abstract void AddNextMemberPowerUp(MagicCard nextCard, List<PowerUpType> powerUps);

    public abstract void AddRacePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps);

    public abstract void AddOrderPowerUp(int index, List<PowerUpType> powerUps);

    public abstract void AddPositionPowerUp(Vector2Int position, List<PowerUpType> powerUps);

    public abstract void AddCardAttributePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps);

    public abstract List<CardDirection> GetAllEnterPowerUpDirections();
    public abstract List<CardDirection> GetAllLeavePowerUpDirections();
    public abstract bool HasOrderPowerUp(int index);
    public abstract bool HasPositionPowerUp(Vector2Int position);
}
