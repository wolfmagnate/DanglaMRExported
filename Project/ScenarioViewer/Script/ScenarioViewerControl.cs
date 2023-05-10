using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ScenarioViewerControl : MonoBehaviour
{
    public static string Script =
        @"";

    public List<Sprite> FigureSprites;
    public List<Sprite> FaceSprites;
    public List<AudioClip> BGMs;
    public List<AudioClip> SEs;
    public GameObject FigureBase;
    public GameObject RewardRow;
    Text mainText;
    Dictionary<string, GameObject> figures;
    Image face;
    Text characterName;
    bool canNext = true;
    ScenarioScriptInterpreter interpreter;
    AudioSource BGMSource;
    AudioSource SESource;
    Canvas mainCanvas;
    Canvas configCanvas;
    Canvas historyCanvas;
    Slider textSpeed;
    Slider autoWait;
    float textWaitDuration { get => -(textSpeed.value - 1) * 0.1f + 0.01f; }
    float autoWaitDuration { get => autoWait.value * 2; }
    GameObject rewardWindow;

    Text history;

    IEnumerator MainCoroutine()
    {
        while (true)
        {
            if (canNext && (!interpreter.IsEnd))
            {
                interpreter.Excecute();
                interpreter.MoveNext();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Start()
    {
        int allowedLevel = FlagManager.ScenarioFlag();
        for (int i = 0; i < allowedLevel; i++)
        {
            FlagManager.SetFlag($"__{i + 1}__scenario__viewed__", true);
        }
        mainText = transform.Find("TextArea/Panel/Text").gameObject.GetComponent<Text>();
        characterName = transform.Find("TextArea/Panel/CharacterName/Text").gameObject.GetComponent<Text>();
        figures = new Dictionary<string, GameObject>();
        face = transform.Find("TextArea/Panel/Face/Image").gameObject.GetComponent<Image>();

        BGMSource = transform.Find("BGM").gameObject.GetComponent<AudioSource>();
        SESource = transform.Find("SE").gameObject.GetComponent<AudioSource>();
        BGMSource.volume = SettingSceneControl.BGMVolume;
        SESource.volume = SettingSceneControl.SEVolume;

        interpreter = new ScenarioScriptInterpreter(Script);
        interpreter.WriteMainText.AddListener(WriteMainTextWithAnimation);
        interpreter.ChangeMainTextFontColor.AddListener(ChangeMainTextFontColor);
        interpreter.ChangeMainTextFontSize.AddListener(ChangeMainTextFontSize);
        interpreter.ChangeCharacterName.AddListener(ChangeCharacterName);
        interpreter.ChangeFace.AddListener(ChangeFace);
        interpreter.CreateFigure.AddListener(CreateFigure);
        interpreter.MoveFigure.AddListener(MoveFigure);
        interpreter.DeleteFace.AddListener(DeleteFace);
        interpreter.DeleteFigure.AddListener(DeleteFigure);
        interpreter.FadeFigure.AddListener(FadeFigure);
        interpreter.SetFlag.AddListener(SetFlag);
        interpreter.PlayBGM.AddListener(PlayBGM);
        interpreter.PlaySE.AddListener(PlaySE);
        interpreter.Wait.AddListener(Wait);
        interpreter.RewardMagicType.AddListener(RewardMagicType);
        interpreter.RewardPowerUp.AddListener(RewardPowerUp);
        interpreter.RewardMoney.AddListener(RewardMoney);
        interpreter.EndScenarioView.AddListener(EndScenarioView);
        interpreter.BeginScenarioView.AddListener(BeginScenarioView);

        StartCoroutine(MainCoroutine());

        // クリック判定
        var trigger = transform.Find("TextArea/Panel/Text").GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventDate) => {
            mainTextClicked = true;
        });
        trigger.triggers.Add(entry);

        // ヒストリー
        history = GameObject.Find("HistoryCanvas/TextArea/Scroll View/Viewport/Content/History").GetComponent<Text>();
        mainCanvas = GetComponent<Canvas>();
        historyCanvas = GameObject.Find("HistoryCanvas").gameObject.GetComponent<Canvas>();
        configCanvas = GameObject.Find("ConfigCanvas").gameObject.GetComponent<Canvas>();
        // コンフィグ
        textSpeed = GameObject.Find("ConfigCanvas/TextSpeed").gameObject.GetComponent<Slider>();
        textSpeed.value = 0.5f;
        autoWait = GameObject.Find("ConfigCanvas/AutoWait").gameObject.GetComponent<Slider>();
        autoWait.value = 0.5f;
        // 報酬
        rewardWindow = transform.Find("RewardWindow").gameObject;
    }

    void ChangeMainTextFontSize(int size)
    {
        mainText.text = "";
        mainText.fontSize = size;
    }

    void ChangeMainTextFontColor(float r, float g, float b, float a)
    {
        mainText.text = "";
        mainText.color = new Color(r, g, b, a);
    }

    void WriteMainTextWithAnimation(string text)
    {
        canNext = false;
        StartCoroutine(WriteMainTextWithAnimationCoroutine(text));
    }
    bool mainTextClicked = false;
    public bool AutoMode { get; set; } = false;
    bool AutoWaitFinished = false;

    IEnumerator WriteMainTextWithAnimationCoroutine(string text)
    {
        AddLineToHistory(text);
        mainText.text = "";
        foreach(char s in text)
        {
            if (mainTextClicked)
            {
                mainText.text = text;
                mainTextClicked = false;
                break;
            }
            mainText.text = mainText.text + s.ToString();
            yield return new WaitForSeconds(textWaitDuration);
        }
        if (AutoMode)
        {
            StartCoroutine(AutoWaitCoroutine());
        }
        while (true)
        {
            if (mainTextClicked || (AutoMode && AutoWaitFinished))
            {
                mainTextClicked = false;
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
        canNext = true;
    }
    void AddLineToHistory(string text)
    {
        if(characterName.text != "")
        {
            history.text = history.text + $"{characterName.text}：「{text}」\n";
        }
        if(characterName.text == "")
        {
            history.text = history.text + $"{text}\n";
        }
    }
    IEnumerator AutoWaitCoroutine()
    {
        AutoWaitFinished = false;
        yield return new WaitForSeconds(autoWaitDuration);
        AutoWaitFinished = true;
    }

    void ChangeCharacterName(string charactername)
    {
        canNext = false;
        characterName.text = charactername;
        canNext = true;
    }

    void CreateFigure(string id, int source, Vector2 position)
    {
        canNext = false;
        figures[id] = Instantiate(FigureBase, Vector3.zero, Quaternion.identity);
        figures[id].transform.parent = transform.Find("Characters");
        figures[id].GetComponent<Image>().sprite = FigureSprites[source];
        figures[id].GetComponent<RectTransform>().anchoredPosition = position;
        figures[id].GetComponent<RectTransform>().sizeDelta = new Vector2(FigureSprites[source].texture.width, FigureSprites[source].texture.height);
        canNext = true;
    }

    void ChangeFace(int source)
    {
        face.sprite = FaceSprites[source];
        face.color = Color.white;
    }

    void MoveFigure(string id, Vector2 position, float duration)
    {
        canNext = false;
        if(duration > 0.05f)
        {
            figures[id].GetComponent<RectTransform>().DOLocalMove(position, duration).OnComplete(() => { canNext = true; });
        }
        else
        {
            figures[id].GetComponent<RectTransform>().localPosition = position;
            canNext = true;
        }
    }

    void DeleteFace()
    {
        face.color = new Color(0,0,0,0);
    }

    void DeleteFigure(string id)
    {
        Destroy(figures[id]);
        figures.Remove(id);
    }

    void FadeFigure(string id, float alpha, float duration)
    {
        canNext = false;
        var image = figures[id].GetComponent<Image>();
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b, alpha),duration).OnComplete(() => { canNext = true; });
    }

    void SetFlag(string flagName, bool value)
    {
        FlagManager.SetFlag(flagName, value);
        FlagManager.Save();
    }

    void PlaySE(int id, bool isWait)
    {
        SESource.PlayOneShot(SEs[id]);
        if (isWait)
        {
            Wait(SEs[id].length);
        }
    }
    void PlayBGM(int id)
    {
        BGMSource.clip = BGMs[id];
        BGMSource.Play();
    }
    void Wait(float duration)
    {
        canNext = false;
        StartCoroutine(WaitCoroutine(duration));
    }
    IEnumerator WaitCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        canNext = true;
    }

    public void EnterHistoryMode()
    {
        mainCanvas.enabled = false;
        configCanvas.enabled = false;
        historyCanvas.enabled = true;
    }

    public void ExitHistroyMode()
    {
        mainCanvas.enabled = true;
        historyCanvas.enabled = false;
        configCanvas.enabled = false;
    }

    public void EnterConfigMode()
    {
        mainCanvas.enabled = false;
        historyCanvas.enabled = false;
        configCanvas.enabled = true;
    }

    public void ExitConfigMode()
    {
        mainCanvas.enabled = true;
        historyCanvas.enabled = false;
        configCanvas.enabled = false;
    }

    int money = 0;
    void RewardMoney(int money)
    {
        if (FlagManager.GetFlag($"__{currentId}__scenario__viewed__")) { return; }
        this.money = money;
    }
    MagicType magicType = null;
    void RewardMagicType(MagicType magicType)
    {
        if (FlagManager.GetFlag($"__{currentId}__scenario__viewed__")) { return; }
        this.magicType = magicType;
    }
    PowerUp powerUp = null;
    void RewardPowerUp(PowerUp powerUp)
    {
        if (FlagManager.GetFlag($"__{currentId}__scenario__viewed__")) { return; }
        this.powerUp = powerUp;
    }

    void EndScenarioView()
    {
        canNext = false;
        Transform rewardsParent = rewardWindow.transform.Find("Rewards");

        rewardWindow.GetComponent<RectTransform>().DOScale(Vector3.one, 0.5f).OnComplete(() => {
            canNext = true;
            if (money != 0)
            {
                var row = Instantiate(RewardRow);
                var text = row.transform.Find("Text").gameObject.GetComponent<Text>();
                text.text = $"獲得金額：{money}";
                row.transform.parent = rewardsParent;
            }
            if (magicType != null)
            {
                var row = Instantiate(RewardRow);
                var text = row.transform.Find("Text").gameObject.GetComponent<Text>();
                text.text = $"術式カード：{magicType.CardName}";
                row.transform.parent = rewardsParent;
            }
            if (powerUp != null)
            {
                var row = Instantiate(RewardRow);
                var text = row.transform.Find("Text").gameObject.GetComponent<Text>();
                text.text = $"強化カード：{powerUp.CardName}";
                row.transform.parent = rewardsParent;
            }
            if(FlagManager.StageFlag() <= currentId)
            {
                FlagManager.ChangeStageFlag(currentId + 1);
            }
        });
    }

    int currentId;
    void BeginScenarioView(int id)
    {
        currentId = id;
    }

    public void GetReward()
    {
        FlagManager.SetFlag($"__{currentId}__scenario__viewed__", true);
        MoneyManager.Load().Gain(money);
        MoneyManager.Save(MoneyManager.Load());
        if(powerUp != null)
        {
            CardStore.Load().AddCard(new PowerUpCard(powerUp));
        }
        if(magicType != null)
        {
            CardStore.Load().AddCard(new MagicTypeCard(magicType));
        }
        CardStore.Save(CardStore.Load());
    }
}
