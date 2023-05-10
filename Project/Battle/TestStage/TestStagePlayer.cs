using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStagePlayer : MonoBehaviour
{
    void Start()
    {
        // (�f�o�b�O�p)

        // �t�@�C�����̎w��͊g���q������(�ȉ���5�s�͏��Ԋ֌W�Ȃ�)
        var Jutsushiki = new MagicTypeCard("DemoFireGatling1");
        var PowerUp1 = new PowerUpCard("DemoPUDirectionSpeedBoost1");
        var PowerUp2 = new PowerUpCard("DemoPUConnectionSpeedBoost1");
        var PowerUp3 = new PowerUpCard("DemoPUFreedomDistanceExtend1");
        var PowerUp4 = new PowerUpCard("DemoPUFreedomDistanceExtend1");

        // �����w�A�ړ������f�[�^�̕ۊǏꏊ���쐬
        var field = new MagicField(5, 5);
        var MoveHistory = new List<Vector2Int>();

        // �����w�ɃJ�[�h��u��(�ȉ���5�s�͏��Ԋ֌W�Ȃ�)
        field.MagicCards[0, 0] = Jutsushiki;
        field.MagicCards[1, 1] = PowerUp1;
        field.MagicCards[2, 2] = PowerUp2;
        field.MagicCards[3, 3] = PowerUp3;
        field.MagicCards[4, 4] = PowerUp4;

        // �J�[�h�̏��Ԃ��w��(�����w�ɒu�����ꏊ�ɑΉ������邱��)(�ȉ���5�s�͏��Ԋ֌W����̂Œ���)
        MoveHistory.Add(new Vector2Int(0, 0));
        MoveHistory.Add(new Vector2Int(1, 1));
        MoveHistory.Add(new Vector2Int(2, 2));
        MoveHistory.Add(new Vector2Int(3, 3));
        MoveHistory.Add(new Vector2Int(4, 4));

        // ���@���쐬���Ĕ��˂��閂�@�ɓo�^
        ShootPlayer.usingMagic = MagicCreater.Create(field, MoveHistory);
    }

}
