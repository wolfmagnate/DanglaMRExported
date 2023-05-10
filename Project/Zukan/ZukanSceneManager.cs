using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ZukanSceneManager : MonoBehaviour
{
    public GameObject ZukanListItem;
    public Sprite NotFoundIcon;
    GameObject ZukanContent;
    ZukanOrderCanvas orderCanvas;

    void Start()
    {
        ZukanDataPrefs.Load();
        ZukanContent = transform.Find("ZukanList/Viewport/Content").gameObject;
        orderCanvas = GameObject.Find("OrderCanvas").GetComponent<ZukanOrderCanvas>();
    }

    public void MakeVirusList()
    {
        ResetList();
        AddVirusList();
    }

    public void MakeCoreList()
    {
        ResetList();
        AddCoreList();
    }

    public void MakeCellList()
    {
        ResetList();
        AddCellList();
    }

    void ResetList()
    {
        for(int i = 0;i < ZukanContent.transform.childCount; i++)
        {
            Destroy(ZukanContent.transform.GetChild(i).gameObject);
        }
    }

    void AddVirusList()
    {
        MenuSESoundManager.Instance.PlayClick();
        var viruses = Resources.LoadAll<ZukanEnemy>("Project/Zukan/Enemy");
        var mode = orderCanvas.GetSearchMode();
        int virusID = 0;
        viruses = viruses.OrderBy(x => x.Stage).ToArray();
        if (! orderCanvas.IsAscent())
        {
            viruses = viruses.Reverse().ToArray();
            virusID = viruses.Length - 1;
        }
        foreach (var virus in viruses)
        {
            if(virus.Stage <= FlagManager.StageFlag())
            {
                ZukanDataPrefs.FoundVirus[virus.Name] = true;
                ZukanDataPrefs.Save();
            }
            if (ZukanDataPrefs.FoundVirus[virus.Name])
            {
                if(mode == SearchMode.Found || mode == SearchMode.Both)
                {
                    var listItem = CreateFoundVirus(virus, virusID);
                    listItem.transform.parent = ZukanContent.transform;
                }
            }
            else
            {
                if (mode == SearchMode.NotFound || mode == SearchMode.Both)
                {
                    var listItem = CreateNotFoundVirus(virus, virusID);
                    listItem.transform.parent = ZukanContent.transform;
                }
            }
            if (! orderCanvas.IsAscent())
            {
                virusID--;
            }
            else
            {
                virusID++;
            }
        }
    }

    GameObject CreateFoundVirus(ZukanEnemy virus, int ID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = virus.Icon;
        ans.transform.Find("Name").GetComponent<Text>().text = virus.Name;
        ans.transform.Find("Description").GetComponent<Text>().text = $"ウイルスNo.{ID}";
        ans.transform.Find("Detail").GetComponent<Button>().onClick.AddListener(() =>
        {
            MenuSESoundManager.Instance.PlayOK();
            GameObject.Find("VirusZukanCanvas").GetComponent<VirusZukanDetailSceneManager>().VirusZukanDetailScene(virus, ID);
        });
        return ans;
    }

    GameObject CreateNotFoundVirus(ZukanEnemy virus, int ID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = NotFoundIcon;
        ans.transform.Find("Name").GetComponent<Text>().text = "？？？";
        ans.transform.Find("Description").GetComponent<Text>().text = $"ウイルスNo.{ID}";
        ans.transform.Find("Detail").gameObject.SetActive(false);
        return ans;
    }

    void AddCoreList()
    {
        MenuSESoundManager.Instance.PlayClick();
        var magictypes = Resources.LoadAll<ZukanMagicType>("Project/Zukan/MagicTypeCards");
        var mode = orderCanvas.GetSearchMode();
        int cardID = 0;
        if (!orderCanvas.IsAscent())
        {
            cardID = magictypes.Length - 1;
            magictypes = magictypes.Reverse().ToArray();
        }
        var displayAttributes = orderCanvas.GetDisplayAttributes();
        foreach(var magictype in magictypes)
        {
            if (displayAttributes.Contains(magictype.magicType.Attribute))
            {
                if (ZukanDataPrefs.FoundCore[magictype.magicType.CardName])
                {
                    if (mode == SearchMode.Found || mode == SearchMode.Both)
                    {
                        var listItem = CreateFoundCoreCard(magictype, cardID);
                        listItem.transform.parent = ZukanContent.transform;
                    }
                }
                else
                {
                    if (mode == SearchMode.NotFound || mode == SearchMode.Both)
                    {
                        var listItem = CreateNotFoundCoreCard(magictype, cardID);
                        listItem.transform.parent = ZukanContent.transform;
                    }
                }
            }
            if (!orderCanvas.IsAscent())
            {
                cardID--;
            }
            else
            {
                cardID++;
            }
        }
    }

    GameObject CreateFoundCoreCard(ZukanMagicType magicType, int cardID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = magicType.magicType.Icon;
        ans.transform.Find("Name").GetComponent<Text>().text = magicType.magicType.CardName;
        ans.transform.Find("Description").GetComponent<Text>().text = $"コアカードNo.{cardID}";
        ans.transform.Find("Detail").GetComponent<Button>().onClick.AddListener(() =>
        {
            MenuSESoundManager.Instance.PlayOK();
            GameObject.Find("CoreZukanCanvas").GetComponent<CoreZukanCanvas>().SetCoreCard(magicType, cardID);
        });
        return ans;
    }

    GameObject CreateNotFoundCoreCard(ZukanMagicType magicType, int cardID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = NotFoundIcon;
        ans.transform.Find("Name").GetComponent<Text>().text = "？？？";
        ans.transform.Find("Description").GetComponent<Text>().text = $"コアカードNo.{cardID}";
        ans.transform.Find("Detail").gameObject.SetActive(false);
        return ans;
    }

    void AddCellList()
    {
        MenuSESoundManager.Instance.PlayClick();
        var powerups = Resources.LoadAll<ZukanPowerUp>("Project/Zukan/PowerUpCards");
        var mode = orderCanvas.GetSearchMode();
        int cardID = 0;
        if (!orderCanvas.IsAscent())
        {
            cardID = powerups.Length - 1;
            powerups = powerups.Reverse().ToArray();
        }
        var displayAttributes = orderCanvas.GetDisplayAttributes();
        foreach (var powerup in powerups)
        {
            Debug.Log(powerup.powerUp.CardName);
            if(powerup.powerUp.CardName.Contains("パワーブースター"))
            {
                int a = 3;
            }
            if (displayAttributes.Contains(powerup.powerUp.CardAttribute))
            {
                if (ZukanDataPrefs.FoundCell[powerup.powerUp.CardName])
                {
                    if (mode == SearchMode.Found || mode == SearchMode.Both)
                    {
                        var listItem = CreateFoundCellCard(powerup, cardID);
                        listItem.transform.parent = ZukanContent.transform;
                    }
                }
                else
                {
                    if (mode == SearchMode.NotFound || mode == SearchMode.Both)
                    {
                        var listItem = CreateNotFoundCellCard(powerup, cardID);
                        listItem.transform.parent = ZukanContent.transform;
                    }
                }
            }
            if (!orderCanvas.IsAscent())
            {
                cardID--;
            }
            else
            {
                cardID++;
            }
        }
    }

    GameObject CreateFoundCellCard(ZukanPowerUp powerUp, int cardID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = powerUp.powerUp.Icon;
        ans.transform.Find("Name").GetComponent<Text>().text = powerUp.powerUp.CardName;
        ans.transform.Find("Description").GetComponent<Text>().text = $"セルカード.{cardID}";
        ans.transform.Find("Detail").GetComponent<Button>().onClick.AddListener(() => {
            MenuSESoundManager.Instance.PlayOK();
            GameObject.Find("CellZukanCanvas").GetComponent<CellZukanCanvas>().SetCellCard(powerUp, cardID);
        });
        return ans;
    }

    GameObject CreateNotFoundCellCard(ZukanPowerUp powerUp, int cardID)
    {
        var ans = Instantiate(ZukanListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = NotFoundIcon;
        ans.transform.Find("Name").GetComponent<Text>().text = "？？？";
        ans.transform.Find("Description").GetComponent<Text>().text = $"セルカードNo.{cardID}";
        ans.transform.Find("Detail").gameObject.SetActive(false);
        return ans;
    }

    public void OpenSettings()
    {
        ResetList();
        orderCanvas.Open();
    }
}
