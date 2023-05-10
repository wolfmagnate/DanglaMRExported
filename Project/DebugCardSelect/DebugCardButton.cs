using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCardButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonPush);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<MagicCard> CardList;

    public void SetCardList(List<MagicCard> cards)
    {
        CardList = cards;
    }

    int i = 0;
    void ButtonPush()
    {
        GameObject.Find("Canvas").GetComponent<DebugCardSelectControl>().AddMagicCard(CardList[i]);
        i++;
    }

    public void ReStart()
    {
        i = 0;
    }
}
