using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 魔術式を組むカード
/// カードの基本的な強化情報はすべてScriptableObjectに持たせている
/// </summary>
[System.Serializable]
public abstract class MagicCard
{
    public string CardName;
    protected string Path { get; set; }
    public MagicAttribute CardAttribute;
    public List<CardRace> Race;

    // 商品系のパラメータ
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
    /// 指定したパスに存在するScriptableObjectから、カードの情報を読み取る
    /// </summary>
    /// <param name="path">ScriptableObjectの存在ディレクトリのパス</param>
    public abstract void LoadFromPath();

    /// <summary>
    /// 入ってきた方向による補正を計算する
    /// </summary>
    /// <param name="cardDirection">入ってきた方向</param>
    public abstract void AddEnterPowerUp(CardDirection cardDirection, List<PowerUpType> powerUps);

    /// <summary>
    /// 出ていく方向による補正を計算する
    /// </summary>
    /// <param name="cardDirection">出ていく方向</param>
    public abstract void AddLeavePowerUp(CardDirection cardDirection, List<PowerUpType> powerUps);

    /// <summary>
    /// 直前のカードとの相性による補正を計算する
    /// </summary>
    /// <param name="previousCard">直前のカード</param>
    public abstract void AddPreviousMemberPowerUp(MagicCard previousCard, List<PowerUpType> powerUps);

    /// <summary>
    /// 直後のカードとの相性による補正を計算する
    /// </summary>
    /// <param name="nextCard">直後のカード</param>
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
