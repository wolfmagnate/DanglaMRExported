using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �����w�̃J�[�h��I�����鏇�Ԃ����߂邱�Ƃ��ڕW�B
/// �ŏI�I��List<Vector2int>���쐬���Ă����ɁA�I������Vector2Int������
/// �܂�A(1,4)��(3,1)��(0,1)��(2,2)��(4,3)�̏��ɃJ�[�h��I�񂾏ꍇ�ɂ�
/// new List<Vector2Int> {new Vector2Int(1,4), new Vector2Int(3,1), new...}�݂����Ȋ����̃��X�g���쐬����
/// 
/// ����ɁASetMagicCards.magicCards�̖����w�f�[�^�����킹��
/// MagicCreater.CreateMagic(MagicCard[,] �����w�f�[�^,List<Vector2Int> ��L�̓��e�̃��X�g)
/// ���Ăяo�����ƂŁA���@�̏�񂪂��ׂē�����Magic�C���X�^���X�𓾂���
/// 
/// </summary>
public class CreateMagicFieldManager : MonoBehaviour
{
    public Sprite DefaultIcon;
    public Sprite NumberBackground;
    public Sprite PowerUpNumberBackground;
    public Color NumberSpriteColor;
    public Color PowerUpNumberSpriteColor;
    public Sprite PowerUpArrow;
    public Sprite UsedPowerUpArrow;

    MagicFieldChainModel model;
    void Start()
    {
        model = new MagicFieldChainModel(SetMagicCards.magicCards);
        for(int x = 0;x < 5; x++)
        {
            for(int y = 0;y < 5; y++)
            {
                int X = x;
                int Y = y;
                var eachButton = transform.Find($"Panel/X{X}Y{Y}").gameObject.GetComponent<CreateMagicFieldEachButton>();
                eachButton.SetPosition(new Vector2Int(X, Y));
                eachButton.SetModel(model);
                eachButton.SetManager(this);
                eachButton.ChangeIcon();
            }
        }
    }

    public Sprite GetChainNumberSprite(int number)
    {
        switch (number)
        {
            case 1:
                return one;
            case 2:
                return two;
            case 3:
                return three;
            case 4:
                return four;
            case 5:
                return five;
            default:
                return null;
        }
    }
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;


    public void Back()
    {
        SceneManager.LoadScene("Project/CreateMagic/CreateMagic");
    }

}
