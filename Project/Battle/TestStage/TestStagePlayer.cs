using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStagePlayer : MonoBehaviour
{
    void Start()
    {
        // (デバッグ用)

        // ファイル名の指定は拡張子を除く(以下の5行は順番関係ない)
        var Jutsushiki = new MagicTypeCard("DemoFireGatling1");
        var PowerUp1 = new PowerUpCard("DemoPUDirectionSpeedBoost1");
        var PowerUp2 = new PowerUpCard("DemoPUConnectionSpeedBoost1");
        var PowerUp3 = new PowerUpCard("DemoPUFreedomDistanceExtend1");
        var PowerUp4 = new PowerUpCard("DemoPUFreedomDistanceExtend1");

        // 魔方陣、移動履歴データの保管場所を作成
        var field = new MagicField(5, 5);
        var MoveHistory = new List<Vector2Int>();

        // 魔方陣にカードを置く(以下の5行は順番関係ない)
        field.MagicCards[0, 0] = Jutsushiki;
        field.MagicCards[1, 1] = PowerUp1;
        field.MagicCards[2, 2] = PowerUp2;
        field.MagicCards[3, 3] = PowerUp3;
        field.MagicCards[4, 4] = PowerUp4;

        // カードの順番を指定(魔方陣に置いた場所に対応させること)(以下の5行は順番関係あるので注意)
        MoveHistory.Add(new Vector2Int(0, 0));
        MoveHistory.Add(new Vector2Int(1, 1));
        MoveHistory.Add(new Vector2Int(2, 2));
        MoveHistory.Add(new Vector2Int(3, 3));
        MoveHistory.Add(new Vector2Int(4, 4));

        // 魔法を作成して発射する魔法に登録
        ShootPlayer.usingMagic = MagicCreater.Create(field, MoveHistory);
    }

}
