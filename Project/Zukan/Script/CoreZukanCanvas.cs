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
        transform.Find("Panel1/CellName/Text").gameObject.GetComponent<Text>().text = $"セルカードNo.{cardID}\n{coreCard.magicType.CardName}";
        transform.Find("Panel1/Scroll View/Viewport/Content/Description").GetComponent<Text>().text = coreCard.Description;
    }

    void SetEnterPowerUps(ZukanMagicType cellCard)
    {
        if (HasEffect(cellCard.magicType.EnterUpPowerUp))
        {
            EnterUpArrow.sprite = ActiveArrow;
            EnterUp.text = $"上から入力：{PowerUpToText(cellCard.magicType.EnterUpPowerUp)}";
        }
        else
        {
            EnterUpArrow.sprite = InactiveArrow;
            EnterUp.text = $"上から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterUpLeftPowerUp))
        {
            EnterUpLeftArrow.sprite = ActiveArrow;
            EnterUpLeft.text = $"左上から入力：{PowerUpToText(cellCard.magicType.EnterUpLeftPowerUp)}";
        }
        else
        {
            EnterUpLeftArrow.sprite = InactiveArrow;
            EnterUpLeft.text = $"左上から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterLeftPowerUp))
        {
            EnterLeftArrow.sprite = ActiveArrow;
            EnterLeft.text = $"左から入力：{PowerUpToText(cellCard.magicType.EnterLeftPowerUp)}";
        }
        else
        {
            EnterLeftArrow.sprite = InactiveArrow;
            EnterLeft.text = $"左から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterDownLeftPowerUp))
        {
            EnterDownLeftArrow.sprite = ActiveArrow;
            EnterDownLeft.text = $"左下から入力：{PowerUpToText(cellCard.magicType.EnterDownLeftPowerUp)}";
        }
        else
        {
            EnterDownLeftArrow.sprite = InactiveArrow;
            EnterDownLeft.text = $"左下から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterDownPowerUp))
        {
            EnterDownArrow.sprite = ActiveArrow;
            EnterDown.text = $"下から入力：{PowerUpToText(cellCard.magicType.EnterDownPowerUp)}";
        }
        else
        {
            EnterDownArrow.sprite = InactiveArrow;
            EnterDown.text = $"下から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterDownRightPowerUp))
        {
            EnterDownRightArrow.sprite = ActiveArrow;
            EnterDownRight.text = $"右下から入力：{PowerUpToText(cellCard.magicType.EnterDownRightPowerUp)}";
        }
        else
        {
            EnterDownRightArrow.sprite = InactiveArrow;
            EnterDownRight.text = $"右下から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterRightPowerUp))
        {
            EnterRightArrow.sprite = ActiveArrow;
            EnterRight.text = $"右から入力：{PowerUpToText(cellCard.magicType.EnterRightPowerUp)}";
        }
        else
        {
            EnterRightArrow.sprite = InactiveArrow;
            EnterRight.text = $"右から入力：";
        }
        if (HasEffect(cellCard.magicType.EnterUpRightPowerUp))
        {
            EnterUpRightArrow.sprite = ActiveArrow;
            EnterUpRight.text = $"右上から入力：{PowerUpToText(cellCard.magicType.EnterUpRightPowerUp)}";
        }
        else
        {
            EnterUpRightArrow.sprite = InactiveArrow;
            EnterUpRight.text = $"右上から入力：";
        }
    }

    void SetLeavePowerUps(ZukanMagicType cellCard)
    {
        if (HasEffect(cellCard.magicType.LeaveUpPowerUp))
        {
            LeaveUpArrow.sprite = ActiveArrow;
            LeaveUp.text = $"上から出力：{PowerUpToText(cellCard.magicType.LeaveUpPowerUp)}";
        }
        else
        {
            LeaveUpArrow.sprite = InactiveArrow;
            LeaveUp.text = $"上から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveUpLeftPowerUp))
        {
            LeaveUpLeftArrow.sprite = ActiveArrow;
            LeaveUpLeft.text = $"左上から出力：{PowerUpToText(cellCard.magicType.LeaveUpLeftPowerUp)}";
        }
        else
        {
            LeaveUpLeftArrow.sprite = InactiveArrow;
            LeaveUpLeft.text = $"左上から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveLeftPowerUp))
        {
            LeaveLeftArrow.sprite = ActiveArrow;
            LeaveLeft.text = $"左から出力：{PowerUpToText(cellCard.magicType.LeaveLeftPowerUp)}";
        }
        else
        {
            LeaveLeftArrow.sprite = InactiveArrow;
            LeaveLeft.text = $"左から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveDownLeftPowerUp))
        {
            LeaveDownLeftArrow.sprite = ActiveArrow;
            LeaveDownLeft.text = $"左下から出力：{PowerUpToText(cellCard.magicType.LeaveDownLeftPowerUp)}";
        }
        else
        {
            LeaveDownLeftArrow.sprite = InactiveArrow;
            LeaveDownLeft.text = $"左下から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveDownPowerUp))
        {
            LeaveDownArrow.sprite = ActiveArrow;
            LeaveDown.text = $"下から出力：{PowerUpToText(cellCard.magicType.LeaveDownPowerUp)}";
        }
        else
        {
            LeaveDownArrow.sprite = InactiveArrow;
            LeaveDown.text = $"下から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveDownRightPowerUp))
        {
            LeaveDownRightArrow.sprite = ActiveArrow;
            LeaveDownRight.text = $"右下から出力：{PowerUpToText(cellCard.magicType.LeaveDownRightPowerUp)}";
        }
        else
        {
            LeaveDownRightArrow.sprite = InactiveArrow;
            LeaveDownRight.text = $"右下から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveRightPowerUp))
        {
            LeaveRightArrow.sprite = ActiveArrow;
            LeaveRight.text = $"右から出力：{PowerUpToText(cellCard.magicType.LeaveRightPowerUp)}";
        }
        else
        {
            LeaveRightArrow.sprite = InactiveArrow;
            LeaveRight.text = $"右から出力：";
        }
        if (HasEffect(cellCard.magicType.LeaveUpRightPowerUp))
        {
            LeaveUpRightArrow.sprite = ActiveArrow;
            LeaveUpRight.text = $"右上から出力：{PowerUpToText(cellCard.magicType.LeaveUpRightPowerUp)}";
        }
        else
        {
            LeaveUpRightArrow.sprite = InactiveArrow;
            LeaveUpRight.text = $"右上から出力：";
        }
    }

    bool HasEffect(PowerUpType powerUpType) => !(powerUpType.Pattern == PowerUpPattern.Add && powerUpType.PowerUpValue == 0);

    string PowerUpToText(PowerUpType powerUpType)
    {
        if (!HasEffect(powerUpType)) { return "効果なし"; }
        switch (powerUpType.Pattern)
        {
            case PowerUpPattern.Add:
                switch (powerUpType.Target)
                {
                    case PowerUpTarget.Attack:
                        return $"Attackが{powerUpType.PowerUpValue}上昇";
                    case PowerUpTarget.CanHitTimes:
                        return $"CanHitTimesが{powerUpType.PowerUpValue}上昇";
                    case PowerUpTarget.ChargeTime:
                        return $"ChargeTimeが{-powerUpType.PowerUpValue}減少";
                    case PowerUpTarget.Distance:
                        return $"Distanceが{powerUpType.PowerUpValue}上昇";
                    case PowerUpTarget.MP:
                        return $"MPが{-powerUpType.PowerUpValue}減少";
                    case PowerUpTarget.Range:
                        return $"Rangeが{powerUpType.PowerUpValue}上昇";
                    case PowerUpTarget.Rush:
                        return $"Rushが{powerUpType.PowerUpValue}上昇";
                    case PowerUpTarget.RushInterval:
                        return $"RushIntervalが{-powerUpType.PowerUpValue}減少";
                    case PowerUpTarget.Speed:
                        return $"Speedが{powerUpType.PowerUpValue}上昇";
                }
                break;
            case PowerUpPattern.AddAttribute:
                if (powerUpType.Target == PowerUpTarget.Attribute)
                {
                    switch (powerUpType.Attribute)
                    {
                        case MagicAttribute.Darkness:
                            return $"属性が闇に変化";
                        case MagicAttribute.Fire:
                            return $"属性が炎に変化";
                        case MagicAttribute.Ice:
                            return $"属性が氷に変化";
                        case MagicAttribute.Light:
                            return $"属性が光に変化";
                        case MagicAttribute.Lightning:
                            return $"属性が雷に変化";
                        case MagicAttribute.Metal:
                            return $"属性が鋼に変化";
                        case MagicAttribute.Mountain:
                            return $"属性が山に変化";
                        case MagicAttribute.Nothing:
                            return $"属性が無に変化";
                        case MagicAttribute.Tree:
                            return $"属性が木に変化";
                        case MagicAttribute.Water:
                            return $"属性が水に変化";
                        case MagicAttribute.Wind:
                            return $"属性が風に変化";
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
                                retVal += $"脆弱を{powerUpType.BadStatusPossibilities[i] * 100}%で付与 ";
                                break;
                            case BadStatus.burnt:
                                retVal += $"火傷を{powerUpType.BadStatusPossibilities[i] * 100}%で付与 ";
                                break;
                            case BadStatus.frozen:
                                retVal += $"凍結を{powerUpType.BadStatusPossibilities[i] * 100}%で付与 ";
                                break;
                            case BadStatus.paralyzed:
                                retVal += $"麻痺を{powerUpType.BadStatusPossibilities[i] * 100}%で付与 ";
                                break;
                            case BadStatus.poisoned:
                                retVal += $"猛毒を{powerUpType.BadStatusPossibilities[i] * 100}%で付与 ";
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
                        return $"Attackが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.CanHitTimes:
                        return $"CanHitTimesが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.ChargeTime:
                        return $"Chargeが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.Distance:
                        return $"Distanceが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.MP:
                        return $"MPが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.Range:
                        return $"Rangeが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.Rush:
                        return $"Rushが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.RushInterval:
                        return $"RushIntervalが{powerUpType.PowerUpValue}倍";
                        break;
                    case PowerUpTarget.Speed:
                        return $"Speedが{powerUpType.PowerUpValue}倍";
                        break;
                }
                break;
        }
        return "あ";
    }

    void SetPositionPowerUps(ZukanMagicType cellCard)
    {
        for (int i = 0; i < cellCard.magicType.PowerUpPosition.Count; i++)
        {
            var pos = cellCard.magicType.PowerUpPosition[i];
            var powerUp = cellCard.magicType.PositionPowerUp[i];
            transform.Find($"Panel4/Board/X{pos.x}Y{pos.y}").GetComponent<Image>().sprite = ActivePosition;
            var listItem = Instantiate(PositionListItem);
            listItem.GetComponent<Text>().text = $"座標X{pos.x}Y{pos.y}：{PowerUpToText(powerUp)}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel4/Scroll View/Viewport/Content"));
        }
    }

    void SetOtherPowerUps(ZukanMagicType cellCard)
    {
        for (int i = 0; i < cellCard.magicType.CardAttributeNumber.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{CardAttributeToText(cellCard.magicType.PowerUpCardAttribute[i])}属性が{cellCard.magicType.CardAttributeNumber[i]}枚以上で{PowerUpToText(cellCard.magicType.CardAttributePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.RaceNumber.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{RaceToText(cellCard.magicType.PowerUpRace[i])}規格のカード{cellCard.magicType.RaceNumber[i]}枚以上で{PowerUpToText(cellCard.magicType.RacePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.OrderPowerUp.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"{cellCard.magicType.PowerUpOrder[i] + 1}番目に配置すると{PowerUpToText(cellCard.magicType.OrderPowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.PowerUpPreviousCardName.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"「{PathToCardName(cellCard.magicType.PowerUpPreviousCardName[i])}」が直前にあると {PowerUpToText(cellCard.magicType.PreviousCardNamePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
        for (int i = 0; i < cellCard.magicType.PowerUpNextCardName.Count; i++)
        {
            var listItem = Instantiate(OtherListItem);
            listItem.GetComponent<Text>().text = $"「{PathToCardName(cellCard.magicType.PowerUpNextCardName[i])}」が直後にあると {PowerUpToText(cellCard.magicType.NextCardNamePowerUp[i])}";
            listItem.GetComponent<RectTransform>().SetParent(transform.Find("Panel5/Scroll View/Viewport/Content"));
        }
    }

    string CardAttributeToText(MagicAttribute attribute)
    {
        return attribute switch
        {
            MagicAttribute.Wind => "風",
            MagicAttribute.Lightning => "雷",
            MagicAttribute.Tree => "木",
            MagicAttribute.Water => "水",
            MagicAttribute.Fire => "炎",
            MagicAttribute.Ice => "氷",
            MagicAttribute.Mountain => "山",
            MagicAttribute.Metal => "鋼",
            MagicAttribute.Light => "光",
            MagicAttribute.Darkness => "闇",
            MagicAttribute.Nothing => "無",
            _ => ""
        };
    }

    string RaceToText(CardRace race)
    {
        return race switch
        {
            CardRace.experimental => "プロトタイプ",
            CardRace.direction => "ディレクショナテナ",
            CardRace.connection => "コネクテミス",
            CardRace.freedom => "フリーリス",
            CardRace.position => "コーディネア―",
            CardRace.number => "アスペクトライトス",
            CardRace.order => "オーダレス",
            CardRace.cheat => "グリーデミゴッド",
            _ => ""
        };
    }

    string PathToCardName(string Path)
    {
        var powerUp = Resources.Load<PowerUp>($"Project/PowerUpCards/{Path}");
        var magicType = Resources.Load<MagicType>($"Project/MagicTypeCards/{Path}");
        if (powerUp == null && magicType == null) { return "そんなカードねぇ！"; }
        if (powerUp != null)
        {
            return powerUp.CardName;
        }
        if (magicType != null)
        {
            return magicType.CardName;
        }
        return "そんなカードねぇ！";
    }

    void SetGeneralMinorInformation(ZukanMagicType cellCard)
    {
        transform.Find("Panel6/Race").gameObject.GetComponent<Text>().text = $"{string.Join("/", cellCard.magicType.Race.Select(x => $"{RaceToText(x)}規格"))}";
        transform.Find("Panel6/Attribute").gameObject.GetComponent<Text>().text = $"{CardAttributeToText(cellCard.magicType.CardAttribute)}属性";
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
