using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// ���̃X�N���v�g�̍ŏI�ڕW��
/// magicCards�̓񎟌��z��̓K�؂ȏꏊ�ɁA�K�؂�MagicCard�^�̃C���X�^���X�����đ��̏ꏊ��null�����邱�Ƃł��B
/// ���ӓ_��magicCards[y���W,x���W]�Ƃ����w��ɂȂ邱�ƂƁA
/// y���W�̂����̌������������ł��邱�Ƃł��B
/// </summary>
public class SetMagicCards : MonoBehaviour
{
    DecideOrderModel model;

    void Start()
    {
        model = new DecideOrderModel(magicCards);
        for(int x = 0;x < 5; x++)
        {
            for(int y = 0;y < 5; y++)
            {
                var eachButton = transform.Find($"Panel/X{x}Y{y}").gameObject.GetComponent<SetMagicCardEachButton>();
                eachButton.SetManager(this);
                eachButton.SetModel(model);
                eachButton.SetPosition(new Vector2Int(x, y));
            }
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("Project/SelectCards/SelectCards");
    }

    public void OK()
    {
        SceneManager.LoadScene("Project/CreateMagic/CreateMagicField");
    }

    public static MagicCard[,] magicCards { get; set; }
    public Sprite DefaultlIcon;
}
