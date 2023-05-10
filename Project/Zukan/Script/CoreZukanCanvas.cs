using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CoreZukanCanvas : MonoBehaviour
{
    public Sprite ActiveArrow;
    public Sprite InactiveArrow;
    public Sprite ActivePosition;
    public Sprite InactivePosition;

    Image EnterUpArrow;
    Image EnterUpLeftArrow;
    Image EnterLeftArrow;
    Image EnterDownLeftArrow;
    Image EnterDownArrow;
    Image EnterDownRightArrow;
    Image EnterRightArrow;
    Image EnterUpRightArrow;

    Text EnterUp;
    Text EnterUpLeft;
    Text EnterLeft;
    Text EnterDownLeft;
    Text EnterDown;
    Text EnterDownRight;
    Text EnterRight;
    Text EnterUpRight;

    Image LeaveUpArrow;
    Image LeaveUpLeftArrow;
    Image LeaveLeftArrow;
    Image LeaveDownLeftArrow;
    Image LeaveDownArrow;
    Image LeaveDownRightArrow;
    Image LeaveRightArrow;
    Image LeaveUpRightArrow;

    Text LeaveUp;
    Text LeaveUpLeft;
    Text LeaveLeft;
    Text LeaveDownLeft;
    Text LeaveDown;
    Text LeaveDownRight;
    Text LeaveRight;
    Text LeaveUpRight;

    GameObject PositionPowerUpListParent;
    GameObject OtherPowerUpListParent;
    public GameObject PositionListItem;
    public GameObject OtherListItem;

    // Start is called before the first frame update
    void Start()
    {
        EnterUp = transform.Find("Panel2/PowerUps/Up").gameObject.GetComponent<Text>();
        EnterUpLeft = transform.Find("Panel2/PowerUps/UpLeft").gameObject.GetComponent<Text>();
        EnterLeft = transform.Find("Panel2/PowerUps/Left").gameObject.GetComponent<Text>();
        EnterDownLeft = transform.Find("Panel2/PowerUps/DownLeft").gameObject.GetComponent<Text>();
        EnterDown = transform.Find("Panel2/PowerUps/Down").gameObject.GetComponent<Text>();
        EnterDownRight = transform.Find("Panel2/PowerUps/DownRight").gameObject.GetComponent<Text>();
        EnterRight = transform.Find("Panel2/PowerUps/Right").gameObject.GetComponent<Text>();
        EnterUpRight = transform.Find("Panel2/PowerUps/UpRight").gameObject.GetComponent<Text>();

        EnterUpArrow = transform.Find("Panel2/Frame/UpArrow").gameObject.GetComponent<Image>();
        EnterUpLeftArrow = transform.Find("Panel2/Frame/UpLeftArrow").gameObject.GetComponent<Image>();
        EnterLeftArrow = transform.Find("Panel2/Frame/LeftArrow").gameObject.GetComponent<Image>();
        EnterDownLeftArrow = transform.Find("Panel2/Frame/DownLeftArrow").gameObject.GetComponent<Image>();
        EnterDownArrow = transform.Find("Panel2/Frame/DownArrow").gameObject.GetComponent<Image>();
        EnterDownRightArrow = transform.Find("Panel2/Frame/DownRightArrow").gameObject.GetComponent<Image>();
        EnterRightArrow = transform.Find("Panel2/Frame/RightArrow").gameObject.GetComponent<Image>();
        EnterUpRightArrow = transform.Find("Panel2/Frame/UpRightArrow").gameObject.GetComponent<Image>();

        LeaveUp = transform.Find("Panel3/PowerUps/Up").gameObject.GetComponent<Text>();
        LeaveUpLeft = transform.Find("Panel3/PowerUps/UpLeft").gameObject.GetComponent<Text>();
        LeaveLeft = transform.Find("Panel3/PowerUps/Left").gameObject.GetComponent<Text>();
        LeaveDownLeft = transform.Find("Panel3/PowerUps/DownLeft").gameObject.GetComponent<Text>();
        LeaveDown = transform.Find("Panel3/PowerUps/Down").gameObject.GetComponent<Text>();
        LeaveDownRight = transform.Find("Panel3/PowerUps/DownRight").gameObject.GetComponent<Text>();
        LeaveRight = transform.Find("Panel3/PowerUps/Right").gameObject.GetComponent<Text>();
        LeaveUpRight = transform.Find("Panel3/PowerUps/UpRight").gameObject.GetComponent<Text>();

        LeaveUpArrow = transform.Find("Panel3/Frame/UpArrow").gameObject.GetComponent<Image>();
        LeaveUpLeftArrow = transform.Find("Panel3/Frame/UpLeftArrow").gameObject.GetComponent<Image>();
        LeaveLeftArrow = transform.Find("Panel3/Frame/LeftArrow").gameObject.GetComponent<Image>();
        LeaveDownLeftArrow = transform.Find("Panel3/Frame/DownLeftArrow").gameObject.GetComponent<Image>();
        LeaveDownArrow = transform.Find("Panel3/Frame/DownArrow").gameObject.GetComponent<Image>();
        LeaveDownRightArrow = transform.Find("Panel3/Frame/DownRightArrow").gameObject.GetComponent<Image>();
        LeaveRightArrow = transform.Find("Panel3/Frame/RightArrow").gameObject.GetComponent<Image>();
        LeaveUpRightArrow = transform.Find("Panel3/Frame/UpRightArrow").gameObject.GetComponent<Image>();

        PositionPowerUpListParent = transform.Find("Panel4/Scroll View/Viewport/Content").gameObject;
        OtherPowerUpListParent = transform.Find("Panel5/Scroll View/Viewport/Content").gameObject;
        ChangePanel(currentPanelID);
    }

    static int PanelLength = 7;
    int currentPanelID = 1;

    public void NextPanel()
    {
        MenuSESoundManager.Instance.PlayClick();
        if (currentPanelID == PanelLength)
        {
            currentPanelID = 1;
        }
        else
        {
            currentPanelID++;
        }
        ChangePanel(currentPanelID);
    }

    public void PreviousPanel()
    {
        MenuSESoundManager.Instance.PlayClick();
        if (currentPanelID == 1)
        {
            currentPanelID = PanelLength;
        }
        else
        {
            currentPanelID--;
        }
        ChangePanel(currentPanelID);
    }

    void ChangePanel(int panelID)
    {
        for (int i = 1; i <= PanelLength; i++)
        {
            transform.Find($"Panel{i}").gameObject.SetActive(false);
        }
        transform.Find($"Panel{panelID}").gameObject.SetActive(true);
    }

    public void Close()
    {
        MenuSESoundManager.Instance.PlayCancel();
        GetComponent<Canvas>().sortingOrder = -1;
    }

    public void SetCoreCard(ZukanMagicType coreCard, int cardID)
    {
        GetComponent<Canvas>().sortingOrder = 1;
        SetGeneralInformation(coreCard, cardID);
        SetEnterPowerUps(coreCard);
        SetLeavePowerUps(coreCard);
        SetPositionPowerUps(coreCard);
        SetOtherPowerUps(coreCard);
        SetGeneralMinorInformation(coreCard);
        SetMagicStatus(coreCard);
        transform.Find("Panel1/Frame/Icon").GetComponent<Image>().sprite = coreCard.magicType.Icon;
        transform.Find("Panel2/Frame/Icon").GetComponent<Image>().sprite = coreCard.magicType.Icon;
        transform.Find("Panel3/Frame/Icon").GetComponent<Image>().sprite = coreCard.magicType.Icon;
    }

    void SetGeneralInformation(ZukanMagicType coreCard, int cardID)
    {
        transform.Find("Panel1/CellName/Text").gameObject.GetComponent<Text>().text = $"�Z���J�[�hNo.{cardID}\n{coreCard.magicType.CardName}";
        transform.Find("Panel1/Scroll View/Viewport/Content/Description").GetComponent<Text>().text = coreCard.Description;
    }

    void SetEnterPowerUps(ZukanMagicType cellCard)
    {
        if (HasEffect(cellCard.magicType.EnterUpPowerUp))
        {
            EnterUpArrow.sprite = ActiveArrow;
            EnterUp.text = $"�ォ����́F{PowerUpToText(cellCard.magicType.EnterUpPowerUp)}";
        }
        else
        {
            EnterUpArrow.sprite = InactiveArrow;
            EnterUp.text = $"�ォ����́F";
        }
        if (HasEffect(cellCard.magicType.EnterUpLeftPowerUp))
        {
            EnterUpLeftArrow.sprite = ActiveArrow;
            EnterUpLeft.text = $"���ォ����́F{PowerUpToText(cellCard.magicType.EnterUpLeftPowerUp)}";
        }
        else
        {
            EnterUpLeftArrow.sprite = InactiveArrow;
            EnterUpLeft.text = $"���ォ����́F";
        }
        if (HasEffect(cellCard.magicType.EnterLeftPowerUp))
        {
            EnterLeftArrow.sprite = ActiveArrow;
            EnterLeft.text = $"��������́F{PowerUpToText(cellCard.magicType.EnterLeftPowerUp)}";
        }
        else
        {
            EnterLeftArrow.sprite = InactiveArrow;
            EnterLeft.text = $"��������́F";
        }
        if (HasEffect(cellCard.magicType.EnterDownLeftPowerUp))
        {
            EnterDownLeftArrow.sprite = ActiveArrow;
            EnterDownLeft.text = $"����������́F{PowerUpToText(cellCard.magicType.EnterDownLeftPowerUp)}";
        }
        else
        {
            EnterDownLeftArrow.sprite = InactiveArrow;
            EnterDownLeft.text = $"����������́F";
        }
        if (HasEffect(cellCard.magicType.EnterDownPowerUp))
        {
            EnterDownArrow.sprite = ActiveArrow;
            EnterDown.text = $"��������́F{PowerUpToText(cellCard.magicType.EnterDownPowerUp)}";
        }
        else
        {
            EnterDownArrow.sprite = InactiveArrow;
            EnterDown.text = $"��������́F";
        }
        if (HasEffect(cellCard.magicType.EnterDownRightPowerUp))
        {
            EnterDownRightArrow.sprite = ActiveArrow;
            EnterDownRight.text = $"�E��������́F{PowerUpToText(cellCard.magicType.EnterDownRightPowerUp)}";
        }
        else
        {
            EnterDownRightArrow.sprite = InactiveArrow;
            EnterDownRight.text = $"�E��������́F";
        }
        if (HasEffect(cellCard.magicType.EnterRightPowerUp))
        {
            EnterRightArrow.sprite = ActiveArrow;
            EnterRight.text = $"�E������́F{PowerUpToText(cellCard.magicType.EnterRightPowerUp)}";
        }
        else
        {
            EnterRightArrow.sprite = InactiveArrow;
            EnterRight.text = $"�E������́F";
        }
        if (HasEffect(cellCard.magicType.EnterUpRightPowerUp))
        {
            EnterUpRightArrow.sprite = ActiveArrow;
            EnterUpRight.text = $"�E�ォ����́F{PowerUpToText(cellCard.magicType.EnterUpRightPowerUp)}";
        }
        else
        {
            EnterUpRightArrow.sprite = InactiveArrow;
            EnterUpRight.text = $"�E�ォ����́F";
        }
    }

    void SetLeavePowerUps(ZukanMagicType cellCard)
    {
        if (HasEffect(cellCard.magicType.LeaveUpPowerUp))
        {
            LeaveUpArrow.sprite = ActiveArrow;
            LeaveUp.text = $"�ォ��o�́F{PowerUpToText(cellCard.magicType.LeaveUpPowerUp)}";
        }
        else
        {
            LeaveUpArrow.sprite = InactiveArrow;
            LeaveUp.text = $"�ォ��o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveUpLeftPowerUp))
        {
            LeaveUpLeftArrow.sprite = ActiveArrow;
            LeaveUpLeft.text = $"���ォ��o�́F{PowerUpToText(cellCard.magicType.LeaveUpLeftPowerUp)}";
        }
        else
        {
            LeaveUpLeftArrow.sprite = InactiveArrow;
            LeaveUpLeft.text = $"���ォ��o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveLeftPowerUp))
        {
            LeaveLeftArrow.sprite = ActiveArrow;
            LeaveLeft.text = $"������o�́F{PowerUpToText(cellCard.magicType.LeaveLeftPowerUp)}";
        }
        else
        {
            LeaveLeftArrow.sprite = InactiveArrow;
            LeaveLeft.text = $"������o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveDownLeftPowerUp))
        {
            LeaveDownLeftArrow.sprite = ActiveArrow;
            LeaveDownLeft.text = $"��������o�́F{PowerUpToText(cellCard.magicType.LeaveDownLeftPowerUp)}";
        }
        else
        {
            LeaveDownLeftArrow.sprite = InactiveArrow;
            LeaveDownLeft.text = $"��������o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveDownPowerUp))
        {
            LeaveDownArrow.sprite = ActiveArrow;
            LeaveDown.text = $"������o�́F{PowerUpToText(cellCard.magicType.LeaveDownPowerUp)}";
        }
        else
        {
            LeaveDownArrow.sprite = InactiveArrow;
            LeaveDown.text = $"������o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveDownRightPowerUp))
        {
            LeaveDownRightArrow.sprite = ActiveArrow;
            LeaveDownRight.text = $"�E������o�́F{PowerUpToText(cellCard.magicType.LeaveDownRightPowerUp)}";
        }
        else
        {
            LeaveDownRightArrow.sprite = InactiveArrow;
            LeaveDownRight.text = $"�E������o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveRightPowerUp))
        {
            LeaveRightArrow.sprite = ActiveArrow;
            LeaveRight.text = $"�E����o�́F{PowerUpToText(cellCard.magicType.LeaveRightPowerUp)}";
        }
        else
        {
            LeaveRightArrow.sprite = InactiveArrow;
            LeaveRight.text = $"�E����o�́F";
        }
        if (HasEffect(cellCard.magicType.LeaveUpRightPowerUp))
        {
            LeaveUpRightArrow.sprite = ActiveArrow;
            LeaveUpRight.text = $"�E�ォ��o�́F{PowerUpToText(cellCard.magicType.LeaveUpRightPowerUp)}";
        }
        else
        {
            LeaveUpRightArrow.sprite = InactiveArrow;
            LeaveUpRight.text = $"�E�ォ��o�́F";
        }
    }

    bool HasEffect(PowerUpType powerUpType) => !(powerUpType.Pattern == PowerUpPattern.Add && powerUpType.PowerUpValue == 0);

    string PowerUpToText(PowerUpType powerUpType)
    {
        if (!HasEffect(powerUpType)) { return "���ʂȂ�"; }
        switch (powerUpType.Pattern)
        {
            case PowerUpPattern.Add:
                switch (powerUpType.Target)
                {
                    case PowerUpTarget.Attack:
                        return $"Attack��{powerUpType.PowerUpValue}�㏸";
                    case PowerUpTarget.CanHitTimes:
                        return $"CanHitTimes��{powerUpType.PowerUpValue}�㏸";
                    case PowerUpTarget.ChargeTime:
                        return $"ChargeTime��{-powerUpType.PowerUpValue}����";
                    case PowerUpTarget.Distance:
                        return $"Distance��{powerUpType.PowerUpValue}�㏸";
                    case PowerUpTarget.MP:
                        return $"MP��{-powerUpType.PowerUpValue}����";
                    case PowerUpTarget.Range:
                        return $"Range��{powerUpType.PowerUpValue}�㏸";
                    case PowerUpTarget.Rush:
                        return $"Rush��{powerUpType.PowerUpValue}�㏸";
                    case PowerUpTarget.RushInterval:
                        return $"RushInterval��{-powerUpType.PowerUpValue}����";
                    case PowerUpTarget.Speed:
                        return $"Speed��{powerUpType.PowerUpValue}�㏸";
                }
                break;
            case PowerUpPattern.AddAttribute:
                if (powerUpType.Target == PowerUpTarget.Attribute)
                {
                    switch (powerUpType.Attribute)
                    {
                        case MagicAttribute.Darkness:
                            return $"�������łɕω�";
                        case MagicAttribute.Fire:
                            return $"���������ɕω�";
                        case MagicAttribute.Ice:
                            return $"�������X�ɕω�";
                        case MagicAttribute.Light:
                            return $"���������ɕω�";
                        case MagicAttribute.Lightning:
                            return $"���������ɕω�";
                        case MagicAttribute.Metal:
                            return $"�������|�ɕω�";
                        case MagicAttribute.Mountain:
                            return $"�������R�ɕω�";
                        case MagicAttribute.Nothing:
                            return $"���������ɕω�";
                        case MagicAttribute.Tree:
                            return $"�������؂ɕω�";
                        case MagicAttribute.Water:
                            return $"���������ɕω�";
                        case MagicAttribute.Wind:
                            return $"���������ɕω�";
                    }
                }
                if (powerUpType.Target == PowerUpTarget.BadStatus)
                {

                    string retVal = "";
                    for (int i = 0; i < powerUpType.BadStatuses.Count; i++)
                    {
                        switch (powerUpType.BadStatuses[i])
                        {
                            case BadStatus.broken:
                                retVal += $"�Ǝ��{powerUpType.BadStatusPossibilities[i] * 100}%�ŕt�^ ";
                                break;
                            case BadStatus.burnt:
                                retVal += $"�Ώ���{powerUpType.BadStatusPossibilities[i] * 100}%�ŕt�^ ";
                                break;
                            case BadStatus.frozen:
                                retVal += $"������{powerUpType.BadStatusPossibilities[i] * 100}%�ŕt�^ ";
                                break;
                            case BadStatus.paralyzed:
                                retVal += $"��Ⴢ�{powerUpType.BadStatusPossibilities[i] * 100}%�ŕt�^ ";
                                break;
                            case BadStatus.poisoned:
                                retVal += $"�ғł�{powerUpType.BadStatusPossibilities[i] * 100}%�ŕt�^ ";
                                break;
                        }
                    }
                    return retVal;
                }
                break;
            case PowerUpPattern.Product:
                switch (powerUpType.Target)
                {
                    case PowerUpTarget.Attack:
                        return $"Attack��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.CanHitTimes:
                        return $"CanHitTimes��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.ChargeTime:
                        return $"Charge��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.Distance:
                        return $"Distance��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.MP:
                        return $"MP��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.Range:
                        return $"Range��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.Rush:
                        return $"Rush��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.RushInterval:
                        return $"RushInterval��{powerUpType.PowerUpValue}�{";
                        break;
                    case PowerUpTarget.Speed:
                        return $"Speed��{powerUpType.PowerUpValue}�{";
                        break;
                }
                break;
        }
        return "��";
    }

    void SetPositionPowerUps(ZukanMagicType cellCard)
    {
        for (int i = 0; i < cellCard.magicType.PowerUpPosition.Count; i++)
        {
            var pos = cellCard.magicType.PowerUpPosition[i];
            var powerUp = cellCard.magicType.PositionPowerUp[i];
            transform.Find($"Panel4/Board/X{pos.x}Y{pos.y}").GetComponent<Image>().sprite = ActivePosition;
            var listItem = Instantiate(PositionListItem);
            listItem.GetComponent<Text>().text = $"���WX{pos.x}Y{pos.y}�F{PowerUpToText(powerUp)}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel4/Scroll View/Viewport/Content"));
        }
    }

    void SetOtherPowerUps(ZukanMagicType cellCard)
    {
        for (int i = 0; i < cellCard.magicType.CardAttributeNumber.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{CardAttributeToText(cellCard.magicType.PowerUpCardAttribute[i])}������{cellCard.magicType.CardAttributeNumber[i]}���ȏ��{PowerUpToText(cellCard.magicType.CardAttributePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.RaceNumber.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{RaceToText(cellCard.magicType.PowerUpRace[i])}�K�i�̃J�[�h{cellCard.magicType.RaceNumber[i]}���ȏ��{PowerUpToText(cellCard.magicType.RacePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.OrderPowerUp.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{cellCard.magicType.PowerUpOrder[i] + 1}�Ԗڂɔz�u�����{PowerUpToText(cellCard.magicType.OrderPowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.PowerUpPreviousCardName.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"�u{PathToCardName(cellCard.magicType.PowerUpPreviousCardName[i])}�v�����O�ɂ���� {PowerUpToText(cellCard.magicType.PreviousCardNamePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.PowerUpNextCardName.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"�u{PathToCardName(cellCard.magicType.PowerUpNextCardName[i])}�v������ɂ���� {PowerUpToText(cellCard.magicType.NextCardNamePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
    }

    string CardAttributeToText(MagicAttribute attribute)
    {
        return attribute switch
        {
            MagicAttribute.Wind => "��",
            MagicAttribute.Lightning => "��",
            MagicAttribute.Tree => "��",
            MagicAttribute.Water => "��",
            MagicAttribute.Fire => "��",
            MagicAttribute.Ice => "�X",
            MagicAttribute.Mountain => "�R",
            MagicAttribute.Metal => "�|",
            MagicAttribute.Light => "��",
            MagicAttribute.Darkness => "��",
            MagicAttribute.Nothing => "��",
            _ => ""
        };
    }

    string RaceToText(CardRace race)
    {
        return race switch
        {
            CardRace.experimental => "�v���g�^�C�v",
            CardRace.direction => "�f�B���N�V���i�e�i",
            CardRace.connection => "�R�l�N�e�~�X",
            CardRace.freedom => "�t���[���X",
            CardRace.position => "�R�[�f�B�l�A�\",
            CardRace.number => "�A�X�y�N�g���C�g�X",
            CardRace.order => "�I�[�_���X",
            CardRace.cheat => "�O���[�f�~�S�b�h",
            _ => ""
        };
    }

    string PathToCardName(string Path)
    {
        var powerUp = Resources.Load<PowerUp>($"Project/PowerUpCards/{Path}");
        var magicType = Resources.Load<MagicType>($"Project/MagicTypeCards/{Path}");
        if (powerUp == null && magicType == null) { return "����ȃJ�[�h�˂��I"; }
        if (powerUp != null)
        {
            return powerUp.CardName;
        }
        if (magicType != null)
        {
            return magicType.CardName;
        }
        return "����ȃJ�[�h�˂��I";
    }

    void SetGeneralMinorInformation(ZukanMagicType cellCard)
    {
        transform.Find("Panel6/Race").gameObject.GetComponent<Text>().text = $"{string.Join("/", cellCard.magicType.Race.Select(x => $"{RaceToText(x)}�K�i"))}";
        transform.Find("Panel6/Attribute").gameObject.GetComponent<Text>().text = $"{CardAttributeToText(cellCard.magicType.CardAttribute)}����";
    }

    void SetMagicStatus(ZukanMagicType coreCard)
    {
        float attack = coreCard.magicType.Attack;
        float distance = coreCard.magicType.Distance;
        float canHitTimes = coreCard.magicType.CanHitTimes;
        float mp = coreCard.magicType.MP;
        float range = coreCard.magicType.Range;
        float rush = coreCard.magicType.Rush;
        float rushInterval = coreCard.magicType.RushInterval;
        float speed = coreCard.magicType.Speed;
        float chargeTime = coreCard.magicType.ChargeTime;

        GameObject content = transform.Find("Panel7/Scroll View/Viewport/Content").gameObject;
        content.transform.Find("Attack/StatusValue").gameObject.GetComponent<Text>().text = $"{attack}";
        content.transform.Find("Distance/StatusValue").gameObject.GetComponent<Text>().text = $"{distance}";
        content.transform.Find("CanHitTimes/StatusValue").gameObject.GetComponent<Text>().text = $"{canHitTimes}";
        content.transform.Find("MP/StatusValue").gameObject.GetComponent<Text>().text = $"{mp}";
        content.transform.Find("Range/StatusValue").gameObject.GetComponent<Text>().text = $"{range}";
        content.transform.Find("Rush/StatusValue").gameObject.GetComponent<Text>().text = $"{rush}";
        content.transform.Find("RushInterval/StatusValue").gameObject.GetComponent<Text>().text = $"{rushInterval}";
        content.transform.Find("Speed/StatusValue").gameObject.GetComponent<Text>().text = $"{speed}";
        content.transform.Find("ChargeTime/StatusValue").gameObject.GetComponent<Text>().text = $"{chargeTime}";
    }
}
