using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicFieldChainModel
{
    /**
     * �ǂ��������f���H
     * ��ʂ̕`��𖳎����āu���@�w�쐬�v���l��������
     * �J�[�h���z�u���ꂽ5*5�̕��ʂ�����
     * �J�[�h�ɂ͑I���E��I��������
     * �I����Ԃ̂̓J�[�h�́A�I�����ꂽ���Ԃɂ���đI��ԍ�������
     * �J�[�h�́A�I�����ꂽ���̃J�[�h�Ƃ̊֌W�ɂ���āA�␳�A���܂��͕␳�i�V�̏�Ԃ��Ƃ�
     * �P���ȑI��ԍ��ɂ��␳�̗L�薳��
     * �����␳�̗L�薳��
     */

    public MagicCard[,] MagicField { get; private set; }
    public List<Vector2Int> SelectPositions { get; private set; }
    public Dictionary<Vector2Int, List<CardDirection>> EnterPowerUps { get; private set; }
    public Dictionary<Vector2Int, List<CardDirection>> LeavePowerUps { get; private set; }
    List<CardDirection> UsedEnterPowerUps { get; set; }
    List<CardDirection> UsedLeavePowerUps { get; set; }
    List<bool> OrderPowerUpList { get; set; }

    public MagicFieldChainModel(MagicCard[,] magicField)
    {
        MagicField = magicField;
        SelectPositions = new List<Vector2Int>();
        EnterPowerUps = new Dictionary<Vector2Int, List<CardDirection>>();
        LeavePowerUps = new Dictionary<Vector2Int, List<CardDirection>>();
        UsedEnterPowerUps = new List<CardDirection>();
        UsedLeavePowerUps = new List<CardDirection>();
        OrderPowerUpList = new List<bool>();


        CheckEnterPowerUp();
        CheckLeavePowerUp();
    }
    
    bool HasEnterDirectionPowerUp(MagicCard magicCard, CardDirection enterDirection)
    {
        return magicCard.GetAllEnterPowerUpDirections().Contains(enterDirection);
    }

    bool HasLeaveDirectionPowerUp(MagicCard magicCard, CardDirection enterDirection)
    {
        return magicCard.GetAllLeavePowerUpDirections().Contains(enterDirection);
    }

    CardDirection GetEnterDirection(Vector2Int prev, Vector2Int current)
    {
        // ���ӁI�Ⴆ�΁A���ォ������Ă���Ƃ��́A���O�̃J�[�h������ɂ���̂ŁAprev - current������
        return MagicCreater.CalcDirection((prev - current));
    }
    CardDirection GetLeaveDirection(Vector2Int current, Vector2Int leave)
    {
        return MagicCreater.CalcDirection(leave - current);
    }

    // ����ɊO������R�}���h���󂯎��悤�ɑ����p��

    void ResetSelectList()
    {
        SelectPositions.Clear();
        UsedEnterPowerUps.Clear();
        UsedLeavePowerUps.Clear();
        OrderPowerUpList.Clear();
    }

    public void StopSelect()
    {
        CreateMagic();
        ResetSelectList();
    }

    bool IsCardPosition(Vector2Int position)
    {
        return MagicField[position.y, position.x] != null;
    }

    public void SelectPosition(Vector2Int position)
    {
        if (!IsCardPosition(position)) { return; }
        if (SelectPositions.Contains(position)) { return; }
        SelectPositions.Add(position);
        // ��������͊e��␳����
        CheckUsedEnterPowerUp();
        CheckUsedLeavePowerUp();
        CheckOrderPowerUp();
    }

    public bool IsSelectMode()
    {
        return SelectPositions.Count != 0;
    }

    public int GetSelectedIndex(Vector2Int position)
    {
        if (!SelectPositions.Contains(position)) { return -1; }
        return SelectPositions.IndexOf(position);
    }

    void CheckUsedEnterPowerUp()
    {
        UsedEnterPowerUps.Clear();
        UsedEnterPowerUps.Add(CardDirection.none);
        for(int i = 1;i < SelectPositions.Count; i++)
        {
            var direc = GetEnterDirection(SelectPositions[i - 1], SelectPositions[i]);
            bool hasPowerUp = HasEnterDirectionPowerUp(MagicField[SelectPositions[i].y, SelectPositions[i].x], direc);
            if (hasPowerUp)
            {
                UsedEnterPowerUps.Add(direc);
            }
            else
            {
                UsedEnterPowerUps.Add(CardDirection.none);
            }
        }
    }

    void CheckUsedLeavePowerUp()
    {
        UsedLeavePowerUps.Clear();
        for (int i = 0;i < SelectPositions.Count - 1; i++)
        {
            var direc = GetLeaveDirection(SelectPositions[i], SelectPositions[i + 1]);
            bool hasPowerUp = HasLeaveDirectionPowerUp(MagicField[SelectPositions[i].y, SelectPositions[i].x], direc);
            if (hasPowerUp)
            {
                UsedLeavePowerUps.Add(direc);
            }
            else
            {
                UsedLeavePowerUps.Add(CardDirection.none);
            }
        }
        UsedLeavePowerUps.Add(CardDirection.none);
    }

    void CheckEnterPowerUp()
    {
        if(EnterPowerUps.Count != 0) { return; }
        for(int x = 0;x < 5; x++)
        {
            for(int y = 0; y < 5; y++)
            {
                if(MagicField[y,x] == null) { continue; }
                EnterPowerUps.Add(new Vector2Int(x,y), MagicField[y, x].GetAllEnterPowerUpDirections());
            }
        }
    }

    void CheckLeavePowerUp()
    {
        if (LeavePowerUps.Count != 0) { return; }
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (MagicField[y, x] == null) { continue; }
                LeavePowerUps.Add(new Vector2Int(x, y), MagicField[y, x].GetAllLeavePowerUpDirections());
            }
        }
    }

    public CardDirection GetUsedEnterDirection(Vector2Int position)
    {
        if (!SelectPositions.Contains(position)) { return CardDirection.none; }
        int selectIndex = SelectPositions.IndexOf(position);
        return UsedEnterPowerUps[selectIndex];
        
    }
    public CardDirection GetUsedLeaveDirection(Vector2Int position)
    {
        if (!SelectPositions.Contains(position)) { return CardDirection.none; }
        int selectIndex = SelectPositions.IndexOf(position);
        return UsedLeavePowerUps[selectIndex];
    }

    void CheckOrderPowerUp()
    {
        OrderPowerUpList.Clear();
        for(int i = 0;i < SelectPositions.Count; i++)
        {
            OrderPowerUpList.Add(MagicField[SelectPositions[i].y, SelectPositions[i].x].HasOrderPowerUp(i));
        }
    }

    public bool HasOrderPowerUp(Vector2Int position)
    {
        if (!SelectPositions.Contains(position)) { return false; }
        int selectIndex = SelectPositions.IndexOf(position);
        return OrderPowerUpList[selectIndex];
    }

    void CreateMagic()
    {
        if(SelectPositions.Count != 5) { return; }
        var field = new MagicField(5, 5);
        var MoveHistory = SelectPositions;
        foreach (var pos in SelectPositions)
        {
            field.MagicCards[pos.y, pos.x] = MagicField[pos.y, pos.x];
        }
        var magic = MagicCreater.Create(field, MoveHistory);

        DisplayMagicInfo.DisplayMagic = magic;
        ResetSelectList();
        SceneManager.LoadScene("Project/CheckMagic/CheckMagic");
    }
}
