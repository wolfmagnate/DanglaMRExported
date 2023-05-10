using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioSelectSceneControl : MonoBehaviour
{
    public Sprite NotViewed;

    public static readonly string[] Scripts = new string[]
    {
        @"<Begin id='1'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CharaName name='須能 哉'>
(俺は須能哉(はじめ)。この春高校に入ったばかり、ただの受かれた新入生、だったはずなんだが...)
<CharaName name='ウイルス'>
ヴォォォ...！
<CharaName name='須能 哉'>
またかよちくしょう！
おらっ！そらっ！
<CharaName name='ウイルス'>
グ...ガラァァ！
<CharaName name='須能 哉'>
クソッ！しぶといな...
これで止めだ！
<CharaName name='ウイルス'>
グワァァァ...
<CharaName name='須能 哉'>
やっと倒れたか...
（と、まぁこんな感じで所謂「ニュータイプ」と呼ばれるウイルスによく襲われるっていう厄介な体質（？）が生まれつき備わっている）
（そして極めつけは...）
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<CreateFigure id='convA' source='49' position='-400,0'>
<CharaName name='？？？'>
...さっきはかなり危なかったんじゃないか？というか最近気味が過ぎるぞ？気を抜きすぎなんじゃないか？
まったく君という奴は私がついていながらどうして苦戦するのだ？
<CharaName name='須能 哉'>
ちょっとうるさいなぁ。わかってるよ最近ピンチが多いって事はさ。でもコンビラスも気づいているだろ？
<CharaName name='コンビラス'>
あぁもちろんわかっている。明らかに敵が強くなっていること、はな。
<CharaName name='須能 哉'>
（俺は体内にコンビラスというウイルスを持っている。）
（こいつはニュータイプウイルスの中でも人の認知機能を乗っとる珍しいウイルスらしい。）
<CharaName name='コンビラス'>
それはそうと、君、オーセントって知ってるかい？
<CharaName name='須能 哉'>
ああ。あのウイルスバスターの
<CharaName name='コンビラス'>
そうだ。最近私はあの組織に一寸興味が湧いてしまってね。ちょっと尋ねに行こうじゃないか。
<CharaName name='須能 哉'>
はぁ...お前何年生きてんだ？そろそろ常識ってもんを覚えたらどうなんだよ。そんなもん行ったところでこんなガキの相手をしてくれるわけ...
<CharaName name=''>
ドゴーーーン！！！
<Wait duration='1'>
<CharaName name='須能 哉'>
何だ？
<CharaName name='コンビラス'>
どうやら私と同類のウイルスが来ているようだ。オーセントも来るかもしれん！ちょうどいい、行くぞ！身体を貸せ！
<CharaName name='須能 哉'>
おいちょっと待っ...！うわわっいきなり身体を持ってくな！
<CharaName name=''>
ザッザッザッ
<CharaName name='コンビラス'>
見たまえ！オーセント隊員が沢山だ！行ってみよう！
<CharaName name='須能 哉'>
おいばか、やめろ！ウイルスだっているんだぞ！
<CharaName name='コンビラス'>
ハッ！そうだった、私としたことが冷静さを欠いてしまった。失敬失敬、ここはオーセントに任せて戻ろうじゃないか...
<Wait duration='1'>
<CharaName name=''>
ゴッ！
<CharaName name='須能 哉'>
！？（何か頭に当たって...意識が...）
<CharaName name=''>
ドサッ
<DeleteFigure id='convA'>
<Wait duration='1'>
<CharaName name='須能 哉'>
（これは...走馬灯って奴か？死に際の思い出がこれか...）
<Wait duration='1'>
<CreateFigure id='mushuA' source='64' position='-300,-100'>
おい、本当に空き巣なんてやるのか？
（俺は両親がウイルスで殺されてから中学まで孤児院で暮らしていた。そこで出会ったのがこの無州尚己(なおみ)だ）
（俺たちは共にウイルス被害者だったからすぐに仲良くなった）
（窮屈な生活への不満からかいつもヤンチャしては怒られていた。今思えばストレスの捌け口が間違っていたとも思う）
（だけど、いや、そんな仲だったからこそ今でも一番の友人である）
<CharaName name='無州 尚己'>
当ったり前だろ？大丈夫だって、お前の頭脳と俺様のパーフェクツなパワーで失敗なんかありえん！ガハハハッ！
それに、お前だって院の飯にはうんざりだろ？
<CharaName name='須能 哉'>
そりゃそうだけどさ、これはやっぱまずいって！
<CharaName name='無州 尚己'>
いいや、いけるね。お前、自分でここの人間の生活リズム監視したんだろ？もっと自信持てよ！ほら、早くしねぇとここの家主の筋肉ダルマが帰って来ちまうぜ？
<CharaName name='須能 哉'>
（こうなった尚己はもうどうしようもないか）
はぁ、分かったよ
<CharaName name='無州 尚己'>
よし来た！じゃ行くぜ！
<CharaName name=''>

移動後

<CharaName name='須能 哉'>
(とにかく近所の屋敷にやってきたわけだが...)
ちゃちゃっと冷蔵庫の中身を頂いてずらかるぞ！いやーこんなに食いもん持って帰ったら俺達英雄じゃね？
<CharaName name='須能 哉'>
そーゆーのは終わってからにしろよな...
粗方物色した後
<CharaName name='無州 尚己'>
よし！大方漁り終わったな！
<CharaName name='須能 哉'>
ちょっと静かに！誰か入ってくる！
<CharaName name='無州 尚己'>
ちょ、今の時間は大丈夫なんじゃないのかよ！
<CharaName name='家主'>
おいお前たち！そこで何をやってる！
<CharaName name=''>
・・・
<CharaName name='須能 哉'>
この後は想像通り署で叱られ院で叱られ謝罪して回ることになったのだが、今思い出すとなんであんなことをしたのかと思わないでもない。
中学卒業後俺は進学校になんとか入ることができたが、あいつのその後は全く知らない。死に際に親友を見せてくれるとは神様も案外情に厚いらしい)
<CharaName name=''>
・・・
<CharaName name='須能 哉'>
...！
(どこだここは...というか助かったのか？視界の全てが未知のものだ)
<CharaName name='？？？'>
おっ、目覚めたか。調子はどうだい？
<CharaName name='須能 哉'>
ッ！
<CharaName name='須能 哉'>
(声に反応しようとした瞬間、また気を失ってしまった...)

<End>",
        @"<Begin id='2'>
<CreateFigure id='uratsujiA' source='8' position='400,0'>
<CharaName name='？？？'>
おっ目覚めたみたいだな。どうだい？気分は？
<CreateFigure id='sunoA' source='24' position='0,0'>
<CharaName name='須能 哉'>
(生きていたら父親くらいの歳だろうか。精悍ながらも親しみのある顔が視界を覆っている。
声に答えようとしてハッと我に返る。もしウイルス側だったらどうするんだ？そうだ、コンビラスに聞こう。)
おい、起きてるだろ？コンビラス？
<CreateFigure id='convA' source='49' position='-400,0'>
<CharaName name='コンビラス'>
ううん？あぁどうやら本格的に目覚めたみたいだね。君が眠っている間に体を調べさせてもらったが異常はないようだね。
<CharaName name='須能 哉'>
ああ。多少の痛みはあるが無事らしい。須能d　いやそうじゃなくて！ここはどこで目の前のこいつは誰なんだ？
<CharaName name='？？？'>
おーい？聞こえてるか？おかしいなぁ、数値は正常なんだが。
<CharaName name='コンビラス'>
おっと、早めに切り上げたほうが良さそうだな。ここはオーセントの施設で目の前の偉丈夫はオーセントの隊員のようだ。ウイルスは...まぁ大丈夫だろう。
<CharaName name='須能 哉'>
そうか。とりあえずありがとう。(なんでウイルスについて濁したんだろう)
<CharaName name='コンビラス'>
いやいや君に死なれるとこちらとしても困るからね。さ、早く返事をしてやるといい。
(洗脳型ウイルスに感染してはいるが私程強力ではないし、平気そうだから大丈夫だろう)
<CharaName name='？？？'>
ほんとに大丈夫か？聞こえてたら返事、してくれよー？
<CharaName name='須能 哉'>
はい、聞こえています
<CharaName name='？？？'>
うわ！急に喋るなよ！
<CharaName name='須能 哉'>
あ、すいません、少し頭を整理してました。
<CharaName name='？？？'>
そ、そうか、とにかく無事そうで良かった。
<CharaName name='須能 哉'>
あの、俺は一体？
<CharaName name='？？？'>
うん。そうだよそこからだよな。まず、君はウイルスバスターのドローンに襲われて倒れていたところを我々「オーセント」が助けたんだ。
見たところ目立った外傷はないようだが、念の為普通の病院ではなくこちらで引きとったんだ。
<CharaName name='須能 哉'>
そうだったんですか。ではもう帰っても？
<CharaName name='？？？'>
いや、まだ帰すわけにはいかないんだ。
<CharaName name='須能 哉'>
...なぜですか？
<CharaName name='？？？'>
最近、いや昔から君はウイルスに襲われやすいんじゃないか？
<CharaName name='須能 哉'>
(！！)い、いやそんなことないですよ。
(どうすんだよコンビラス！)
<CharaName name='コンビラス'>
コンビラスa　(動揺するべきではない。もう少し様子を見よう)
<CharaName name='？？？'>
そうか？こちらとしては君のその「体質」を野放しにするわけにはいかないんだ。
だから我々の組織に加わらないかという話をしたかったのだが...君自身の安全の保証と過去の悪行の帳消し、そしてウイルスへの復讐まで出来る。
悪くないだろう？それに断ったとしたら君をどうするかはこちらの自由、という状況だ。
<CharaName name='須能 哉'>
ちょ、ちょっと待てよ。今なんて？
<CharaName name='？？？'>
ん？いや、もう関係ない話なんだろ？これさえ確認出来ればもういいよ。
<CharaName name='須能 哉'>
いや、良くない、俺はその話受けるぞ。
<CharaName name='コンビラス'>
(まて、哉！もう少し考えろ！)
<CharaName name='須能 哉'>
(いいや、これはチャンスなんだお前自身のこともわかるかもしれないだろ？それに...)
ただしだ、お前達はまだ信用ならないからな、俺からも一つ条件を出させてもらう。
<CharaName name='コンビラス'>
(お、おい強気すぎるぞ！)
<CharaName name='須能 哉'>
それは、俺の相棒、無州を隊に入れることだ！信用出来るやつを一人くらい近くに置くくらいは許してもらいたい！
<CharaName name='裏辻 要'>
ふふふっ、ははははっ！そういうと思っていたぞ！そうかそうかそれくらいの条件なら飲もう。
さっきは怖い顔してすまなかったな。俺の名前は辻裏要だ。じゃあ...ええと須能哉くん！おれの隊へ入ってもらう！よろしくな！
<CharaName name='須能 哉'>
え、えぇ...
(軽すぎるだろ...それに何も聞かずに終わっちまった...)

<DeleteFigure id='convA'>
<DeleteFigure id='uratsujiA'>
<CharaName name='無州 尚己'>
そうして俺は学生の傍らオーセントとして活動することになる。

<CharaName name=''>
数日後

<CreateFigure id='mushuA' source='64' position='300,-100'>
<CharaName name='無州 尚己'>
おお！久しぶりだな！哉！
<CharaName name='須能 哉'>
ほんとに来たのかお前！会えて嬉しいよ！
<CreateFigure id='uratsujiA' source='8' position='600,0'>
<CharaName name='裏辻 要'>
約束は約束だからな。じゃ、オーセントについて説明しよう、といきたいところなんだがあと一人足りないんだ。
<CreateFigure id='umehanaA' source='32' position='-900,-150'>
<MoveFigure id='umehanaA' duration='1' destination='-400,-150'>
<CharaName name='？？？'>
？？？h　すーみーまーせーん！遅れちゃいました！もう始まっちゃってますか？
<CharaName name='裏辻 要'>
ギリギリセーフ、だな。紹介しよう、こっちはお前達と同期となるサポート科の梅花。んで、こちらが戦闘科の須能と無州だ。
<CharaName name='須能 哉'>
え？俺戦闘科だったんですか？危なくないですか？
<CharaName name='無州 尚己'>
いいじゃねぇか！ウイルスボコボコに出来てさ！
<CharaName name='裏辻 要'>
それなんだが、こちらが守るよりも君自身が強くなる方が安全だと判断したんだ。だからこれからの訓練や説明もそのつもりで聞いてほしい。
<CharaName name='須能 哉'>
なるほど。わかりました。
<CharaName name='梅花 瑞貴'>
じゃ二人ともよろしくねっ！
<CharaName name='須能 哉'>
よろしく。
<CharaName name='無州 尚己'>
おう。よろしくな。
<Wait duration='1'>
<CharaName name=''>
隊長による説明後
<Wait duration='1'>
<CharaName name='裏辻 要'>
説明はこんなもんだな。わからないことがあったらさっき渡したその端末のヘルプを見るといい。というわけで明日から実技込の訓練だからそのつもりで。じゃあな！
<CharaName name='一同'>
えぇ〜！

<End>",
        @"<Begin id='3'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='uratsujiA' source='8' position='600,0'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>
<CharaName name='裏辻 要'>
よし、今日は昨日言った通り実際の戦闘をしながら学んでもらう。気を引き締めてな！
<CharaName name='一同'>
はい！
<CharaName name='裏辻 要'>
これがウイルスを攻撃する薬剤武装だ。拳銃のような形をしているが、中身は全く異なる。
拳銃でいう弾倉を外してみてくれ。それが武装の効果を決める部分だ。これは梅花隊員が主に触ることになるだろうが、
戦闘科員も戦闘で何が必要か考えてメンテナンスを頼む必要があるから理解しておくようにな。
本当にこれでウイルスを倒せるんですか？
<CharaName name='無州 尚己'>
そうだぜ殴った方が早いに決まってる！
<CharaName name='裏辻 要'>
須能隊員には違和感があると思うがこいつの能力は実践で見てもらうとしよう。では行くぞ！
<Wait duration='1'>
<DeleteFigure id='umehanaA'>
<DeleteFigure id='uratsujiA'>
<CreateFigure id='convA' source='49' position='-300,0'>
<CharaName name=''>
バシュッ！バシュッ！

<CharaName name='無州 尚己'>
おお、こりゃすげえよ！哉、お前もやってみろよ。
<CharaName name='須能 哉'>
もうやってるさ。本当に効いてるぞ、これ。どうなってんだ？
<CharaName name='無州 尚己'>
でもよーやっぱり殴りたいぜ。お前の頭使えばどうにかして改造出来たりしないか？
<CharaName name='須能 哉'>
いやいや、それは梅花達に頼むべきだろ。
<CharaName name='無州 尚己'>
それもそうだ！後で聞いてみるぜ！
<CharaName name='須能 哉'>
(なぁコンビラス、これはどういう仕組みなんだ？)
<CharaName name='コンビラス'>
(ふむ。これは実在の薬品を元に特別に調合したものを発射してるらしい。)
<CharaName name='須能 哉'>
(俺たちのとどう違うんだ？)
(我々が今まで使ってきたのは私が生成した、ある意味血清、を君の打撃で打ち込んでいたんだ。
だからウイルス達は耐性がつくのが早いし効果も薄い。だが、これはそもそもが抗生剤で効果が高い。
そして薬剤は体の外部で独立しているから君のように体力を消耗することもない。)
<CharaName name='須能 哉'>
(つまり？)
<CharaName name='コンビラス'>
(完全上位互換ってことさ。ただし、人によって使える武装に制限があるみたいだね。
君は私の能力で全て扱えるようになっているが、例えば無州君はコネクテミス規格が使えないようだ。もっとも、彼の戦闘センスなら問題はないだろう。)
<CharaName name='須能 哉'>
(なるほどな、それも踏まえて連携する必要がありそうだ。)

<CharaName name='裏辻 要(無線通信)'>
おーい聞いてるか？
<CharaName name='須能 哉'>
はっはい！なんでしょうか？
<CharaName name='裏辻 要(無線通信)'>
そっちに少し強い反応がある。今向かっているから出来るだけ戦闘は避けるんだ。
<CharaName name='須能 哉'>
わかりました！おい無州...ってどこだ！？
<CharaName name='無州 尚己'>
哉！こっちに沢山ドローンがいるぜ。やっちまおう！
<CharaName name='須能 哉'>
待て、そいつらはさっきの奴らよりも強いんだ！
<CharaName name='無州 尚己'>
何？ん、ぐわっ！
<CharaName name='須能 哉'>
大丈夫か！くそっ見つかっちまった！なんとか倒し切るしかない！

<CreateFigure id='kurokiA' source='0' position='600,-100'>
<CharaName name='？？？'>
(なんだあいつら。新入か？まぁいい、早く終わらせて帰ろう。なんで俺がこんな任務...クソッ！ディバインのやつめ。)

<CharaName name='無州 尚己'>
うぉぉぉ！
<CharaName name='須能 哉'>
ふぅ、少しは引き始めたぞ。

？？？h　何だと？ドローン達が帰ってきている。あいつ等がやったのか。少し興味が出てきたな。よし、あいつ等がやれるのか見てやろう。いけっGK-089型！

<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<DeleteFigure id='convA'>
<MoveFigure id='kurokiA' destination='0,-100' duration='1'>
<CharaName name='黒木 止'>
俺の名前は黒木止(とどめ)。ウイルスバスター幹部だ。妻はウイルスに殺されている。
一人娘は身の安全のために縁を切ってある。どこで何をしているからを知る由もない。
うちの組織ではボスに逆らった奴は尽くウイルスに乗っ取られていったが俺はなんとか人間を保っている。
しかしそんな俺が幹部にいることを快く思わない奴もいるようで、その一人、一体？
まぁとにかくディバインというウイルスが執拗に俺を貶めようとしてくる。今日の出撃だって別に俺がいくようなものではないのに押し付けられた。
そもそも人間だから俺は人間を攻撃したいわけではない。自分の身を守るためにやっているだけだ。
だからこそ今だってボスを潰せる若葉を試しているわけだ。せいぜい死なないようにとだけ願っているが果たしてどうかな。
<MoveFigure id='kurokiA' destination='1600,-100' duration='1'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CharaName name='無州 尚己'>
オイ、オイオイ、オイオイオイ！何だよそりゃあ！
<CharaName name='須能 哉'>
どうした無州？
<CharaName name='須能 哉'>
はっ！な、何だあのドローンは！さっきのとは全然違うぞ、そしてとにかくヤバそうだ！

ドゴーン！

<CharaName name='二人'>
二人　ぐわぁー！
<CharaName name='無州 尚己'>
とにかく撃ちまくれ！
<CharaName name='須能 哉'>
だめだ全然効いてない！
<CharaName name='無州 尚己'>
おい、またあの攻撃が来るぞ！避けろ！

<CharaName name=''>
ドガーン！

<End>",
        @"<Begin id='4'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CharaName name='無州 尚己'>
避けろ哉！こっちの物陰だ！
<CharaName name='須能 哉'>
助かった。次の合図でお前は右に俺は左に飛び出して攻撃だ。3,2,1いけっ！
<CharaName name=''>
ブゥーン...
<CharaName name='無州 尚己'>
やっぱり全然効かない！
<CharaName name='須能 哉'>
一点を狙え無州！俺が今撃ってるところだ！
<CharaName name=''>
ゴゴゥーン...
<CharaName name='無州 尚己'>
防御したぞ！少しはダメージがあるんだ！
<CharaName name='須能 哉'>
いや違う！あれは強力な攻撃の予備動作だ！
<CharaName name='無州 尚己'>
な、何ーっ！？
<CharaName name='須能 哉'>
この建物に隠れるんだ、早く！

<CharaName name='無州 尚己'>
ふぃーっ、危ないところだった。にしてもよ、アイツどうするんだ？
<CharaName name='須能 哉'>
そうだな、少し考えさせてくれ。
<CharaName name='須能 哉'>
(コンビラス、あいつにウイルスはついているか？)
<CreateFigure id='convA' source='49' position='-300,0'>
<CharaName name='コンビラス'>
(いや、純粋に機械として動いているよ。どうするつもりなんだい？)
<CharaName name='須能 哉'>
(それと、この中で機械に効果がありそうなカードはどれかわかるか？)
<CharaName name='コンビラス'>
(ふむ。これが火属性で、こちらは回路をショートさせることが出来そうだ。なるほど、そういうことか！)
<CharaName name='須能 哉'>
(ふっ、わかったみたいだな。)
<CharaName name='須能 哉'>
無州、デカいとしてもドローンはドローンだ。そしてドローンはウイルスと違って必ず操作している人間がいる。そいつを叩く。
俺たちの力量ではそれしかない。ウイルスは付いてないようだから、これをこうして...これで機械の動きが止められる武装になったはすだ。
<CharaName name='無州 尚己'>
うぉぉー！やっぱお前はすげーな！で、どうすればいい！
<CharaName name='須能 哉'>
俺がこれを使ってあのデカブツを止める。その隙にお前は本体を探すんだ！できるな？
<CharaName name='無州 尚己'>
任せとけって！
<CharaName name='須能 哉'>
よし、行くぞ！喰らえっ！
グググ...
<CharaName name='須能 哉'>
今だっ！探しに行くんだ！

<CharaName name='無州 尚己'>
飛び出したはいいがどこだ、どこにいる？電波が届く物陰だって哉は言ってたからな。虱潰しにいくしかねぇ！

<CharaName name='須能 哉'>
まずい、咄嗟に組み替えたからか薬剤の消費が激しい！まだなのか！まだ見つからないのか！

<CharaName name='無州 尚己'>
見つけた！そこだぜ！
<CreateFigure id='kurokiA' source='0' position='-600,-100'>
<CharaName name='黒木 止'>
(見つかっただと？とりあえず今は逃げるしかない！)GK-089型！撤退だ！
<MoveFigure id='kurokiA' destination='-1500,-100' duration='1'>
<CharaName name='須能 哉'>
(ドローンが攻撃を止めて後退していく。やったみたいだな。俺の弾倉にはもう何も無い、間一髪だ。)
<CharaName name='無州 尚己'>
逃げるんじゃねぇー！顔覚えたからなー！チクショー！

<CharaName name='無州 尚己'>
大丈夫か哉！
<CharaName name='須能 哉'>
あぁあと少し遅かったらやられてたぞ、もっと早くしろよ〜ったく。
<CharaName name='無州 尚己'>
すまんすまん。でも追い払えて良かったぜ。だけど本体はドローンと一緒にどっか行っちまったぞ？
<CharaName name='須能 哉'>
まぁ、とりあえずは無事切り抜けたことを喜ぼう。敵のことは隊長たちがやってくれるさ。
<CharaName name='無州 尚己'>
にしてもよー最初からこんなの普通あるかよ？
<CharaName name='須能 哉'>
でも俺たちは戦えた、だろ？
<CharaName name='須能 哉'>
(確かにおかしい。隊長達と少し離れた一瞬のうちに分断され、明らかに俺たちだけを狙ってきた。やはりこれもコンビラスを宿しているからなのか？)
<CharaName name='無州 尚己'>
(それは違うぞ。なんでも俺のせいにされては困る。さっきからずっとウイルスの反応はないからね。偶然だろう。)
<CharaName name='須能 哉'>
(そんなもんか。)

<DeleteFigure id='convA'>
隊長らが到着
<CreateFigure id='uratsujiA' source='8' position='600,0'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>

<CharaName name='裏辻 要'>
大丈夫だったか？状況は？
<CharaName name='須能 哉'>
ええ、なんとか。にわかに大量のドローンが現れて襲われました。
最初は雑魚だけだったのですが、そいつらを倒したあと強力な奴が出てきました。おそらく人間が操っています。
<CharaName name='無州 尚己'>
ドローンのやつの顔は俺が見たぜ。次は逃さねえ。
<CharaName name='裏辻 要'>
わかった。ありがとう、君たちは思っていた何倍もやれるようだ。
だが、なおさら無理は禁物だな！後処理はやっておくから今日は休むといい。
<CharaName name='須能 哉'>
分かりました。いらぬ心配だとは思いますがまだ近くにいるかもしれないので気をつけてください。
<DeleteFigure id='sunoA'>
<DeleteFigure id='uratsujiA'>
<DeleteFigure id='mushuA'>
<DeleteFigure id='umehanaA'>
<CreateFigure id='kurokiA' source='0' position='0,-100'>
<CharaName name='黒木 止'>
やれやれだ。とんだ不良品を掴まされたな。しかし、だ。彼らは使えるかもしれんな。
一人は何か秘密がありそうだが、卓越した頭脳を持っている。
もう一人は人並み外れの戦闘センスと直感を持っている。早速コンタクトするとしよう。

<End>",
        @"<Begin id='5'>
翌日
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CharaName name='須能 哉'>
お前、敵の顔も見たって言ってたよな。どんなだよ。やっぱウイルスにかかってたか？
<CharaName name='無州 尚己'>
んーそんなんじゃなくて人間っぽかったぞ。若く見えるがそれなりの年で、
<CharaName name='須能 哉'>
あの人くらいか？
<CharaName name='無州 尚己'>
そうそう本当にあんな顔してt...っておい！アイツだ！
<CharaName name='須能 哉'>
こっちに来るぞ！武装は仕舞ったままだ！
<CreateFigure id='kurokiA' source='0' position='-600,-100'>
<CharaName name='黒木 止'>
や、先日はどうも。
<CharaName name='無州 尚己'>
何がすまなかった、だ。俺たちを始末しにきたのか？
<CharaName name='黒木 止'>
違うな。俺は君たちの手助けに来たんだ。
<CharaName name='須能 哉'>
は？
<CharaName name='黒木 止'>
俺の名前は黒木止、ウイルスバスターの幹部だ。見ての通り純人間だからそいつで打っても痛くも痒くもないぞ。
<CharaName name='無州 尚己'>
さっきから何言ってんのかわかんねえぞお前！手助けって何だ！何でだ！
<CharaName name='須能 哉'>
待て、話だけは聞こう。(コンビラスも反応していないから嘘は言ってないみたいだ)
<CharaName name='黒木 止'>
物分りがよくて助かるよ。まず、俺はウイルスバスターを裏切ろうとしている。
<CharaName name='二人'>
！！
<CharaName name='黒木 止'>
理由は様々だが、自分のやってることに嫌気が差したことといったところか。
元々は俺もウイルスを倒すためにウイルスバスターに入ったんだ。しかし、だ。自分でやるには危険すぎる。
<CharaName name='須能 哉'>
だから俺たちに協力しろと？
<CharaName name='黒木 止'>
その通りだ。おっと、君たちにもメリットはあるんだぜ？世界を救った英雄になるのはもちろん、復讐にも近づく。
無州君、ウイルスバスターを潰せば大量の隠し金も手に入る。
<CharaName name='無州 尚己'>
お前、俺たちのこと知ってるな。
<CharaName name='黒木 止'>
もちろんだとも。ここから君たちが協力しないという道を潰すためにも必要だったからね。
これでお互いにお互いの命を取れる刃を手にしたという訳さ。さぁ、答えを聞こう。
<CharaName name='須能 哉'>
くっ従うしかないってことじゃないか...
<CharaName name='無州 尚己'>
いいのか？こんな怪しいやつぶっ飛ばそうぜ。
<CharaName name='須能 哉'>
いやだめだここは従うべきだ。
<CharaName name='黒木 止'>
よし。決まりだな。ではついてくるんだ。
<Wait duration='1'>
<CharaName name=''>
移動

<CharaName name='黒木 止'>
ここでいいだろう。稽古をつけるにあたって二人の力量を把握したい。
纏めてでいいからかかってくるんだ。もちろんフル装備でな。
<CharaName name='無州 尚己'>
舐めやがって...！
<CharaName name='須能 哉'>
息を合わせるんだ行くぞ！
<Wait duration='1'>
<CharaName name=''>
訓練後

<CharaName name='無州 尚己'>
だめだぞ、全然攻撃が当たらない...！
<CharaName name='須能 哉'>
俺はもう体力が無い...
<CharaName name='黒木 止'>
よし今日のところはここまでとする。どうだ？自分達の無力さを実感出来たか？
<CharaName name='須能 哉'>
あぁ。それは十分にわかったさ。だがわからないな。俺達を援助するにはやはり理由が薄いんじゃないか？
既に無関係ではなくなったわけだし本当の理由ってのを教えてくれないか？
<CharaName name='無州 尚己'>
...？(体を動かせて強くなれるならもうどうでもいいとおもっている)
<CharaName name='黒木 止'>
確かに君の言うことももっともだ。実はな先日の戦いで目的を達成出来なかった私はウイルスバスターでの立場が悪くなってしまったのだ。
ウイルスに感染していない幹部は私一人であるがゆえに、常日頃から身を狙われる身分ではあったし、
その策略の一つが先日の戦闘で、偶然失敗しただけかもしれない。今までやってきたことを考えるとただ死んでもいいのだが、
感染して利用されるのも癪だ。さらに私には生き別れた娘がいる。その娘と再会するためにも生き延びてきたがそれも危うい状態となった。
そこで事を早めるために君たちに助けてもらったというわけさ。
<CharaName name='須能 哉'>
...なるほどな。それで、このまま訓練だけをしていって勝てる相手なのか？
<CharaName name='黒木 止'>
そこなんだが、私は「事を早めた」と言っただろう。
つまり準備は別に進んでいる。だから君たちは私の特訓を受けてくれるだけでいい。
<CharaName name='須能 哉'>
とりあえずわかったよ。お前はどうだ？
<CharaName name='無州 尚己'>
え？ああ俺はなんでもいいよ？
...(何も聞いてなかったな)
<CharaName name='黒木 止'>
それと、これだけは守って欲しいんだが。
<CharaName name='須能 哉'>
まだ何かあるのか？
<CharaName name='黒木 止'>
私と知り合ったことは君たちと私との間の秘密にするんだ。
私を執拗に追い込みたいらしい奴はディバインと言って、擬態がとても上手いらしく正体を掴めていない。
もし周りにいると私はもちろん君たちにも危険が及ぶことはわかるだろう。では今後もよろしく頼むよ。

<End>",
        @"<Begin id='6'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='uratsujiA' source='8' position='300,0'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>
<CharaName name='裏辻 要'>　
おい、今日は直巳のやつはいないのか？早速サボりとは肝が座っているというか横着というか。
<CharaName name='須能 哉'>
まぁ、多めに見てやって下さいよ。そもそもあいつが共同生活に応じるのさえ珍しいんですから...
<CharaName name='裏辻 要'>
だがしかしなぁ、今それが揺らいでるんだが。仕方ない、今日は梅花と二人で任務に行ってもらおうかな。それでいいか？
<CharaName name='須能 哉'>
わかりました。直己のことは後で言っとくんで任せて下さい。じゃあ今日はよろしく。
<CharaName name='梅花 瑞希'>
うん、よろしくね。
<DeleteFigure id='uratsujiA'>
<CharaName name=''>
移動中にて

<CharaName name='須能 哉'>
そういえば梅花は戦闘科じゃないのにどうして戦闘訓練、もとい実務に充てられてるんだ？
<CharaName name='梅花 瑞希'>
そ、それはね、私がお願いして参加させてもらってるの。
<CharaName name='須能 哉'>
理由を聞くのは野暮かな？
<CharaName name='梅花 瑞希'>
ううん、そんなことないよ。実は私お父さんがいないんだ。
ウイルスに罹ったから死んだってお母さんは言ってるけど、ある時お父さんの仕事を知っちゃって。
それがウイルスバスターの職員だったの。
<CharaName name='須能 哉'>
まさか。
<CharaName name='梅花 瑞希'>
私も最初はそう思ったの。だけど一度探し始めると沢山証拠がでてきて。だから絶対今もどこかで生きてると思うの。
<CharaName name='須能 哉'>
それで探すために慣れない戦闘に参加してるのか。
<CharaName name='梅花 瑞希'>
少しでも外に出て除染活動をすれば何か父に関する手がかりが見つかるかもしれないしゃない？
<CharaName name='須能 哉'>
それはそうだけど、可能性は低いし危険すぎやしないかい？
<CharaName name='梅花 瑞希'>
それでもいいの。須能君達だってお父さんとお母さんをウイルスで亡くしてるんでしょ？だからわかってくれない？私のわがままかもしれないけど役には立つから！
<CharaName name='須能 哉'>
どこで聞いたんだとは聞かないけどさ、そういうことなら俺たちもできるだけのことはするよ。それに優秀なメカ屋がいると助かることには違いないし。
<CharaName name='梅花 瑞希'>
ありがとう！
<CharaName name=''>
戦闘後

<CharaName name='須能 哉'>
ふぅ。今日の担当区域のウイルスは全滅させたみたいだ。イチチ...
<CharaName name='梅花 瑞希'>
やったね！ん？どうしたの怪我したの？
<CharaName name='須能 哉'>
大したことないよ。本部に帰って手当すればいいし。
<CharaName name='梅花 瑞希'>
駄目だよ、怪我は応急処置が一番大事何だから！それにその場所ってことは私を庇ったときのでしょ？なおさら手当させてよね。
<CharaName name='須能 哉'>
じゃあお願いしようかな。
<CharaName name='梅花 瑞希'>
これをこうして...これでよし！本部に帰ったら医務室で手当してもらってね。
<CharaName name='須能 哉'>
あぁわかってるよ。ありがとう。
<CharaName name=''>
<DeleteFigure id='umehanaA'>
帰路にて

<CreateFigure id='convA' source='49' position='-300,0'>
<CharaName name='須能 哉'>
さっき梅花と触れただろ。それで遺伝子とかそんなんで親の手がかりがあったりしないか？
<CharaName name='コンビラス'>
あのねぇ...私とてそうそう万能ではないと何度言えばいいんだい？そうだね、君の求める情報かは分からないが彼女は君と同様に全規格のカードを扱えるみたいだね。
<CharaName name='須能 哉'>
それまた珍しいね。やっぱり自分で使えるとメカ屋としても優秀なんだろうか。
<CharaName name='コンビラス'>
それは当たり前だろう。加えて手当の手際も良い。彼女は間違いなく優秀なエンジニアになるさ。
ところで、カード規格への適性に遺伝的なものが関わっている可能性がないだろうか。
<CharaName name='須能 哉'>
というと？
<CharaName name='コンビラス'>
例えば君はウイルスに感染、まぁ君の親が私を仕込んだわけだが、そのおかけで全規格の適性がある。同様の技術があったとしたら、だ。
<CharaName name='須能 哉'>
親が優秀なウイルス科学者である可能性が高いと。
<CharaName name='コンビラス'>
あくまで可能性の話だ。だが闇雲よかましだろう。
<CharaName name='須能 哉'>
頭には入れておくよ。
<DeleteFigure id='convA'>
<CharaName name=''>
黒木の特訓へ

<CreateFigure id='kurokiA' source='0' position='-600,-100'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CharaName name='黒木 要'>
今日も休まず来たな。感心感心。
<CharaName name='無州 直己'>
遅いぞ〜哉〜何してたんだ？
<CharaName name='須能 哉'>
お前なぁ...サボってるくせによく言えたな。
<CharaName name='黒木 要'>
む、やけに来るのが早いと思ったらサボりか。全く。それでいて私の特訓には来るあたり君らしいというか。
<CharaName name='無州 直己'>
それはおいといて特訓しようぜ！今日は何教えてくれんだ？黒木さんよ？
<CharaName name='黒木 要'>
うむ。それでは今日の特訓だが...

特訓後

<CharaName name='黒木 要'>
今日ここまでだ。ここで解散と行きたいが大事な話がある。例のディバインについてだ。
<CharaName name='二人'>
...！！
<CharaName name='黒木 要'>
大規模侵攻に合わせて準備と言ったが、どうやらそれより先におれの命が危ういらしい。というのもあいつが俺の調査を始めたようなんだ。
だから明日からは奴に特化した訓練に切り替える。しっかりとついてこいよ。
<CharaName name='二人'>
分かりました！

<End>",
        @"<Begin id='7'>
<CreateFigure id='kurokiA' source='0' position='-600,-100'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CharaName name='黒木 止'>
どうした須能？動きが遅いぞ。
<CharaName name='須能 哉'>
い、いえ少し疲れてきただけです。
<CharaName name='黒木 止'>
それだけならいいが。よし時間がないからな今日はもう1セットやるぞ！
<CharaName name='無州 直己'>
よーしいくぜー！
<CharaName name=''>
終了後
<DeleteFigure id='mushuA'>
<DeleteFigure id='kurokiA'>
<CreateFigure id='convA' source='49' position='-300,0'>
<CharaName name='須能 哉'>
(こんなんじゃ全然ダメだ。本当は体力が無いだけじゃない。スキルも全然足りてないんだ。さらに日々の任務や訓練にも支障をきたしてしまっている。もっと頑張らなくては。)
<CharaName name='コンビラス'>
(...)
<DeleteFigure id='convA'>
<CharaName name=''>
そんな日々が続いたある日

<CreateFigure id='uratsujiA' source='8' position='300,0'>
<CreateFigure id='mushuA' source='64' position='-300,-100'>
<CharaName name='裏辻 要'>
最近調子悪いんじゃないか須能 哉？
<CharaName name='須能 哉'>
や、そんなことはないと思います。
<CharaName name='裏辻 要'>
そんなことはない、だぁ？自分の体調をわかっていないのに大丈夫なわけないだろ。どうした、悩みがあるなら聞くぞ。
<CharaName name='無州 直己'>
そうだぜ。特訓のときも全然やる気ないぞ。
<CharaName name='須能 哉'>
(何言ってるんだ！それは秘密だろ！)
<CharaName name='裏辻 要'>
へぇ。お前ら任務後に特訓やってるのか。
<CharaName name='無州 直己'>
そうなんすよ。なんか黒木っていうおっさんが稽古つけてくれてるんすよ。
<CharaName name='須能 哉'>
(あちゃー...)
<CharaName name='無州 直己'>
あ
<CharaName name='須能 哉'>
はぁー...えぇとですね。実はウイルスバスターの幹部を名乗る黒木って男がウイルスバスター侵攻に備えるという名目で俺たちに特訓をしてくれてるんですよ。
で、近いうちに大規模な侵攻があるっていうんで俺は焦ってしまって何も手につかないって状態なんです。
<CharaName name='裏辻 要'>
へぇ。そうだったのか。でもな須能、スキルアップは大事でもやるべきことを見失ったら駄目だぞ？
<CharaName name='須能 哉'>
えぇそうですね。気をつけます。
<CharaName name='裏辻 要'>
というわけで、今日は休め！な！任務はこいつに任せよう。いつかのお返しだ！
<CharaName name='須能 哉'>
そうさせてもらいます...
<DeleteFigure id='uratsujiA'>
<DeleteFigure id='sunoA'>
<CharaName name=''>
黒木との特訓

<CreateFigure id='kurokiA' source='0' position='-600,-100'>
<CharaName name='黒木 止'>
おや？今日は哉休みなのか？お前じゃあるまいし珍しいな。
<CharaName name='無州 直己'>
それが、ですね...
<CharaName name='黒木 止'>
...なにか？
<CharaName name='無州 直己'>
哉の奴、なんか上手くいってるおれと迫ってきた侵攻で焦って何も手につかない感じで、今日は休みもらったんすよ。
<CharaName name='黒木 止'>
はぁ〜そんなことか。特訓は今の所肉体トレーニングしかしてないからな、そうなるのも無理はないか。でもその顔を見るにそれだけじゃないだろ？
<CharaName name='無州 直己'>
流石っすね黒木さん。そうなんですよ、実は黒木さんのこと隊長に喋っちゃって...
<CharaName name='黒木 止'>
何！！それは本当か！？誰だそいつは、特徴は？
<CharaName name='無州 直己'>
えーっと黒木さんと同い年位で、気さくで、全カード規格を使えます。
<CharaName name='黒木 止'>
おいおいおい。それはかなりまずいことになってるぜ！多分そいつがディバインだ。全カード規格対応者は全て把握しているし、オーセントもそうだろう。
しかしそいつの存在が何も無く許されてるってことは、だぞ。ほぼ確定だ。
<CharaName name='無州 直己'>
えぇ〜！ど、どうするんすか？
<CharaName name='黒木 止'>
こうなったら仕方ない。本当は特訓後に伝える予定だったことを今伝える。哉にもちゃんと言っとけよ。
<CharaName name='無州 直己'>
わかりました！
<CharaName name='黒木 止'>
まずあいつは洗脳型ウイルスに感染している。だから人型である上にウイルスもばら撒けるんだ。
まぁこれはボスにも言えることだが。要するに俺がお前達を襲った時のようなドローン兵器も、いつも戦ってるウイルスも両方繰り出してくるってことだ。
だがそんな奴にも弱点はある。この大量の個体を同時に操作することは最大の脅威でありながら欠点もある。
流石の奴も頭脳を複数持っている訳ではないからな、攻撃中の反撃にはラグがある。つまりカウンターが有効だ。
哉と協力して上手い作戦を立てておけ。俺はやることがあるからな今日はこれでお別れだ。
<CharaName name='無州 直己'>
また明日ですか？
<CharaName name='黒木 止'>
いや、多分今後は今までのようには会えない。会うときは連絡をするが、それまでに何かあれば港の第三埋立島の工場まで来るように。
そこがボスの居場所だ。その時には俺は助けられない立場だろうからきちんと準備してくるんだぞ。そうならないように祈っているが。
とにかく、こうなった以上気を引き締めろよ。それと、哉のことだが、あいつの得意分野は頭脳戦だ。
お前さえそれがわかっていればどうとでもなるだろう。ではな。

<End>",
        @"<Begin id='8'>
<CreateFigure id='sunoA' source='24' position='0,0'>
<CreateFigure id='mushuA' source='64' position='-300,-100'>
<CharaName name=''>
明くる日

<CharaName name='無州 直己'>
大変だぜ哉！隊長の奴がディバインだってよ！
<CharaName name='須能 哉'>
待て待てどうしてそうなる？説明をしてくれ。
<CharaName name='無州 直己'>
おっとすまねえ。それが昨日黒木さんに裏辻隊長に秘密を言っちゃったことを話したらさ、特徴から隊長がディバインだって言うんだ。だから俺は対策を聞いて帰ってきたんだよ。
<CharaName name='須能 哉'>
え？まさか、いや、でも黒木さんが言うなら間違いないか...わかった。しばらく考えておくからとりあえず別れよう。本部基地外で必要以上に集まってるとこを見られでもしたらまずい。また基地で会おう。
<CharaName name='無州 直己'>
おう。

<CreateFigure id='convA' source='49' position='300,0'>
<CharaName name='須能 哉'>
おいコンビラス！
<CharaName name='コンビラス'>
久しぶりに呼び出したと思ったらなんだね？
<CharaName name='須能 哉'>
どうしたもこうしたもない！どうして裏辻がそんな危険なウイルスだと黙ってたんだ！まさかお前、
<CharaName name='コンビラス'>
いや違うんだ哉、実は奴のウイルスは擬態がとても上手いらしく、初めて会ったときも殆ど弱毒化していたんだ。
<CharaName name='須能 哉'>
本当か？信じていいんだな？
<CharaName name='コンビラス'>
もちろんだとも。君も会ったときに何も感じなかっただろう？そして特有の靄も見られなかった。
そうだろ？その点我々のようにウイルスと宿主が仲良し、といった感じなのか、あるいは...
<CharaName name='須能 哉'>
わかったわかった。信じるよ。

<CharaName name='須能 哉'>
(にしても藪蛇じゃないか。クソっ俺はどうして成長出来ないんだ！無州はどんどん強くなってるのに俺はっ！)
<CharaName name=''>
<DeleteFigure id='convA'>
基地にて

<CharaName name='須能 哉'>
あれ？梅花とディvいや裏辻隊長は？
<CharaName name='無州 直己'>
それがさ、今日はまだ来てないみたいなんだ。それよりも大変だ。資材センターの中身が殆ど壊されたらしいんだ！今は開発室のカードしかないって話だ！
<CharaName name='須能 哉'>
たしか資材センターは隊長以上の人間しか入れないはず...多分ディバインだ。そして今そんな行動を起こすってことは...
<CharaName name='無州 直己'>
も、もしかしてヤバい？
<CharaName name='須能 哉'>　
あぁ。とにかくこれを知って動けるのは俺たちだけだ。ど、どうしよう。
<CharaName name='無州 直己'>
ふっふっふ。実は黒木さんがここに来るようにと言ってた場所があるんだな！二人で乗り込もうぜ！
<CharaName name='須能 哉'>　
いやお前はともかく俺ではやられるだけだ...あんなに弱いんだから...他に方法は...
<CharaName name='無州 直己'>
だからそれでいいんじゃねーの？
<CharaName name='須能 哉'>
は？
<CharaName name='無州 直己'>
だからさ、お前は俺より頭いいんだからさ、動けない分の工夫を考えればいいんだよ。初めて黒木さんと戦った時みたいにさ。
<CharaName name='須能 哉'>　
でも...
<CharaName name='無州 直己'>
いいって、危ないときは俺が助けるしお前もそのために俺を呼んだんだろ？じゃあさっさと行くぞ！
<CharaName name='須能 哉'>
そこまで言うならとりあえず行くよ。
<CharaName name=''>
工場へ

<CreateFigure id='uratsujiA' source='48' position='800,0'>
<MoveFigure id='uratsujiA' destination='300,0' duration='1'>
<CharaName name='裏辻 要'>
？　ククク...来たか。
<CharaName name='須能 哉'>
ディバイン、なのか？
<CharaName name='ディバイン'>
そうだ。黒木だな、喋ったのは。まぁいい。娘共々今は我々の手の内だからな。
<CharaName name='無州 直己'>
何がしたいんだ！
<CharaName name='ディバイン'>
そう喧嘩腰になるなよ。考えてもみろ、計画を邪魔されると知って放置するアホはお前くらいだろう、なぁ須能哉、いや今はコンビラスとやらもいるかな。
<CharaName name='無州 直己'>
バカにしやがって！須能 哉、コンビラスって何だ？
<CharaName name='須能 哉'>　
それの話は後だ。とにかく今は二人を助けることを考えろ。そのために来たんだろ。
<CharaName name='ディバイン'>
ハハハ...二人を助けるって聞こえた気がするんだが気の所為ではないよな？二人でか？黒木に言われなかったか？あまり我々を舐めないほうがいい。
せいぜい私の暇つぶしに付き合ってもらおう。ククク...ハハハ！
<CharaName name=''>
ヴァァー！ブォーン！

<CharaName name='無州 直己'>
出たな！でもその形は黒木さんとの特訓で対策済みだぜ！おらっ！須能も反対を頼む！
<CharaName name='須能 哉'>　
あ、あぁ。任せてくれ。
<CharaName name='無州 直己'>　
あっちもか！あらよっと。大丈夫か哉！
<CharaName name='須能 哉'>　
助かった。敵はこれで全滅か？
<MoveFigure id='uratsujiA' destination='1000,0' duration='1'>
<CharaName name='無州 直己'>
そうみたいだ。ディバインはどっか行っちまったみたいだな。それよりさ、俺たちめちゃくちゃ強くなってるぜ！
<CharaName name='須能 哉'>
お前は、な。やっぱり俺は帰った方が...
<CharaName name='無州 直己'>
も〜、もっと元気出せよ！須能が活躍するときが絶対あるからさ！
<CharaName name='須能 哉'>　
(今は自分の方が活躍したって思ってるんだ...)だといいけどな。
<CharaName name='無州 直己'>　
よっしゃ突入だー！

<End>",
        @"<Begin id='9'>
<CharaName name='無州 直己'>　
<CreateFigure id='mushuA' source='64' position='300,-100'>
そういえばさっきディバインが言ってた娘ってのとコンビニってなんだ？
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
コンビラス、な。娘ってのはそのままの意味だろ。
<CharaName name='無州 直己'>
そのまま？
<CharaName name='須能 哉'>　
まじかお前、まだ気づいてないのか？黒木さんは娘と生き別れた。これだけでわかりそうなものだが、もう一つ俺だけが知ってるヒントをやるよ。<CharaName name='梅花 瑞希'>は父親がいないんだ。
<CharaName name='無州 直己'>
えぇーーーっ！まじかよ！
<CharaName name='須能 哉'>
ちょっ静かにしろよ。まぁそういうことだ。黒木さんと<梅花は親子だったんだ。
<CharaName name='無州 直己'>
で、コンビラスってのは何だ？
<CharaName name='須能 哉'>
まぁお前だし話してもいいか。
<CharaName name='コンビラス'>
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='convA' source='49' position='-400,0'>
やぁ無州直己君。私がそのコンビラスだ。もっともこの名前は哉がつけたものだがね。
<CharaName name='無州 直己'>
うわ、気持ち悪っ！なんか変なモヤモヤ出てるし。
<CharaName name='須能 哉'>　
とまぁこんな感じで俺と体を共有してるウイルスだ。ディバインと裏辻隊長みたいなもんだ。
<CharaName name='無州 直己'>
お前は大丈夫なのか？
<CharaName name='コンビラス'>　
失敬な！哉がいなくなれば私も生きてはいられないんだぞ。危害を加えるなんてとんでもない。
<CharaName name='須能 哉'>　
こいつとはずっと一緒だから問題無いんだよ。危害も殆どない。むしろ俺が全カードを使えるのもこいつのお陰なんだ。
<CharaName name='無州 直己'>　
へぇー。よくわからんけどすごいだな。じゃあよろしくな。
<CharaName name='コンビラス'>　
うむ。よろしく頼むよ。
<DeleteFigure id='convA'>
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>

ある一室にて

<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
黒木さんはこの辺の部屋って言ってたけど...
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
あれじゃないか？あの机に置いてあるやつだよ。
<CharaName name='無州 直己'>　
どれどれ...手紙だな。哉、読んでくれ。
<CharaName name='須能 哉'>　
全く。こういうことのために連れてきたんじゃないだろうな。ふむふむ...防御が手薄な時には特に水属性が有効。って防御が手薄な時ってなんだ？なんかあいつめちゃくちゃ機械とウイルス飛ばしてたけど...
<CharaName name='無州 直己'>　
あー！言い忘れてたわ。ディバインは攻撃から直ぐには防御に移れないからカウンターに弱いって教えてもらったんだった！
<CharaName name='須能 哉'>　
そういうのは早く言えよな...

<CharaName name='放送'>
どうやら私の下僕はやられてしまったみたいだね。だが入ってきた時点で君たちの負けのような物だ。
<CharaName name='放送'>
須能くん！無州くん！早く逃げて！じゃないと...
<CharaName name='放送'>
おっとっと。さぁどうしようね？君たちの自由さ。

<CharaName name='無州 直己'>
今のって
<CharaName name='須能 哉'>　
やはりここに二人ともいるみたいだな。
<CharaName name='無州 直己'>　
自由ってことは助けるのめ自由、だよな。
<CharaName name='須能 哉'>
そうだ。さっさと片付けて帰ろう。
<CharaName name='無州 直己'>
何だよ。急に自信出しやがってよ。梅花の声で勇者気取りか？
<CharaName name='須能 哉'>　
そういうことにしといてやるよ。とにかく手持ちのカードで有効打を作る。奴もあれが本気ではないだろう。
<CharaName name='無州 直己'>
それでこそ哉だぜ。やっぱ連れてきて良かったな。
<CharaName name='須能 哉'>　
こういうことは任せてくれ。コンビラス、カードの分析を頼む。
<CharaName name='無州 直己'>
黒木さんの時もこうやって俺に武装を作ってくれてたのかよ。
<CharaName name='須能 哉'>
そうだ。コンビラスにはスキャンだけやってもらっているけどな。
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='convA' source='49' position='-400,0'>
<CharaName name='コンビラス'>
計30枚終わったぞ。
<CharaName name='須能 哉'>　
それで内訳は。
<CharaName name='コンビラス'>
術式カードが2枚、水属性化カードが2枚。都合よくあるね。
<CharaName name='須能 哉'>　
そうか。俺はなんでも使えるが、直己の分はそうもいかないからな、うーんこれとこれで最大火力か...これも仕込んでおこう。
<CharaName name='無州 直己'>　
なんか一人で会話してるみたいで変な感じだな...
<CharaName name='須能 哉'>
何か言ったか？とりあえず二人分出来たからこれで行こう。ディバインはもうウイルスを隠すこともしてないし俺でもどこにいるかわかる。
<CharaName name='無州 直己'>
そんなことも出来たのかよ...それで自信をなくすお前の向上心はすごいな
<CharaName name='須能 哉'>　
お世辞はいいから進むぞ。こっちだ。
<CharaName name='無州 直己'>
はいよ。

<End>",
        @"<Begin id='10'>
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
この先のデカい部屋だ。気を引き締めろ。
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
くーっ！いよいよか。
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CharaName name='ディバイン'>　
おーいその向こうにいるんだろ？そしてそちらにも私の居場所はわかっている。そうだろ？だったら早く出てこないか？
<CharaName name='無州 直己'>
あのやろームカつくぜ！
<CharaName name='須能 哉'>
まて、タイミングを合わせて突入するぞ。向こうは俺というか<CharaName name='コンビラス'>の位置しかわかっていない筈だ。だから、な。
<CharaName name='無州 直己'>
おっとそうだった。危ない危ない。
<CharaName name='須能 哉'>
カウント行くぞ。３、２、１、突入！
<CharaName name='ディバイン'>
<CreateFigure id='divineA' source='48' position='-400,0'>
何！？須能一人か！
<CharaName name='無州 直己'>
バーカ後ろだ！うららららら！
<CharaName name='須能 哉'>
やったぞ！はさみうち作戦成功だ！
<CharaName name='ディバイン'>
クッ、この私が防戦を強いられるなど、あってはならないッ！しかし舐めていた私も仕方ない。こうなれば、フンッ！ハァァッ！
<CharaName name='二人'>　
うわぁぁー！
<CharaName name='須能 哉'>　
何て風圧だ！やはり形態移行を残していたか！そっちはどうだ！
<CharaName name='無州 直己'>
殆ど怪我はないけど、あれはまさか！
<CharaName name='ディバイン'>
フハハハハ！はさみうちに苦手属性攻撃と中々良かったがここまでにしようじゃないか、んん？流石の黒木もこの形態までは知らなかっただろうな。そうだな、確かお前らは10年前の大規模侵攻で両親が殺されたんだったな。特にお前、須能の親父は最後まで抵抗してお前にコンビラスを仕込んでいやがった。だがその想いも虚しくここでお前らは死ぬ！アーハッハッハ！
<CharaName name='須能 哉'>　
それだけベラベラ喋るなんて余裕かましてると俺達にまた足を掬われるぞ。
<CharaName name='ディバイン'>
足を掬われる？悪役がベラベラと喋る時の相場は決まってるんだ。それは勝ちを確信した時だよ！
<CharaName name=''>
ゴゴゴ...ドガーン！

<CharaName name='ディバイン'>
この私が生み出した最高傑作が起動すればお前らなど瞬で終わらせてくれる！
<CharaName name='須能 哉'>
このときを待ってたぞ！今だ直己！カードを逆に繋げ！
<CharaName name='無州 直己'>　
こうか？なんだ属性が反転したぞ！
<CharaName name='須能 哉'>　
よし、それで黒木さんが言ってた場所を撃てー！
<CharaName name='無州 直己'>　
おりゃおりゃおりゃー！
<CharaName name='ディバイン'>　
な、何ぃーっ！お前ら、まさかここまで読んで...グワァァァー！
<DeleteFigure id='divineA'>
<CharaName name=''>
ミシミシ...ガラガラガシャーン！

<CharaName name='無州 直己'>　
ほ、ほんとにやったのか！
<CharaName name='須能 哉'>　
まだ終わってないぞ！建物が崩れかかってるし早く二人を探して救出だ！
<CharaName name='無州 直己'>
そうだったそうだった。どこにいるかわかるか？
<CharaName name='須能 哉'>　
梅花は独特のウイルス感があるからなぁ、あそこだ。ガラス窓の奥の部屋だ！俺では無理だから頼んだぞ！俺は黒木さんを探してくる！
<CharaName name='無州 直己'>　
わかった！無理はすんなよ！
<MoveFigure id='mushuA' destination='1000,0' duration='1'>
<CharaName name=''>
ズズズ...ドガシャーン！
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
結局黒木さんは見つからなかった。建物も崩壊してしまったし生きていたとしても...
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
とりあえず今は梅花が助かったことを喜ぼうぜ。
<CharaName name='須能 哉'>　
そういや梅花は動けないのか？
<CharaName name='無州 直己'>
いや、寝てるだけだな。
<CharaName name='須能 哉'>
ならよかった。とりあえず今日はめぼしい物を持って帰ろう。<CharaName name='黒木 止'>さんの手紙についてたデータのことも気になるし。
<CharaName name='無州 直己'>
そうだな。
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<CharaName name=''>
時を同じくして

<CharaName name='ディバイン'>　
<CreateFigure id='divineA' source='48' position='0,0'>
やられた...私としたことがあんな若造に...！咄嗟に生体部を切り離さなければ確実に死んでいた...早くボス...パンデミア様に報告しなければ...
<DeleteFigure id='divineA'>
<CharaName name=''>
またまた別の場所で

<CharaName name='黒木 止'>
<CreateFigure id='kurokiA' source='0' position='0,-100'>
あいつらやったみたいだな...やはり見込んだ通りだった。だがまだ終わっちゃいない...俺はもうウイルスバスターから出られないだろう。だから頼む...！あのデータを正しく分析してボスを倒してくれ...！
<DeleteFigure id='kurokiA'>

<End>",
        @"<Begin id='11'>
<CharaName name='梅花 瑞希'>　
<CreateFigure id='umehanaA' source='32' position='400,-150'>
二人とも、助けに来てくれて本当にありがとう！私、何てお礼を言えば...
<CharaName name='無州 直己'>　
<CreateFigure id='mushuA' source='64' position='0,-100'>
でもよ、親父さんが...
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-400,0'>
そうだ。俺達は梅花の親父さんを助けられなかった。ごめん。
<CharaName name='梅花 瑞希'>
でも、二人が負い目を感じることじゃないよ！それに、お父さんが生きてて、人の役に立とうと頑張ってたことがわかっただけで嬉しいよ。そうだ！お父さんが残してくれたデータを早く分析しようよ。
<CharaName name='無州 直己'>
梅花...そうだな。早くやろうぜ哉！
<CharaName name='須能 哉'>　
結局俺なんだよなぁ...どれどれ。これはボスの詳細なデータか？それに俺達二人の訓練データと特性もある。んで、これは...新しいカードだ！
<CharaName name='梅花 瑞希'>
カードの設計図があるの？それなら私に任せて！頑張って作っちゃうんだから！
<CharaName name='無州 直己'>
マジかよ～新しい武装使えるなんて最高じゃねぇか！
<CharaName name='須能 哉'>
俺達はこっちだぞ。見てみろ、特訓中に行った攻撃、防御、カードの組み合わせ...何でも載ってる。これを活かしてボスを倒せってことじゃないのか？
<CharaName name='無州 直己'>
うげげーそういうのはお前に任せるわ。
<CharaName name='須能 哉'>
駄目だ。これからは全部自分たちでやっていかなくちゃならない。黒木さんがいない今俺達3人でやるしかないんだ。
<CharaName name='梅花 瑞希'>　
じゃあこのことは私達だけの秘密なの？
<CharaName name='須能 哉'>　
いや、上層部に報告するのは構わないだろう。ウイルスバスター側からオーセントにわざわざディバインなんていう幹部クラスを送り込んでたわけだから、他に送りこむ理由がない。後で報告はしておく。その間無州はちゃんと読んどけよ？
<CharaName name='無州 直己'>　
はーい
<CharaName name='梅花 瑞希'>　
じゃあ私もラボに行くね。
<CharaName name='須能 哉'>　
また呼ばれるだろうし今は解散だ。
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<DeleteFigure id='umehanaA'>
<CharaName name=''>
報告会

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='0,0'>
・・・ということです。
<CharaName name='オーセント幹部'>　
なるほど。最近増大していたウイルス被害の裏でそんなことが...わかった。我々の方でも作戦は立てる。だが実行部隊は恐らく君たち3人になるだろう。可能性は低いとはいえスパイがもういないとは言い切れない。周辺の安全確保は突入部隊は組織するが、実際にボスと対峙するのは君たちになる。それでいいかな？
<CharaName name='須能 哉'>
わかりました。
<DeleteFigure id='sunoA'>
<CharaName name=''>
二人の元へ

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
・・・というわけだ。各々自分のやるべきことをやって決戦に備えよう。で、どうだ無州、自分のやるべきことはわかったか？
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
もちろんだぜ！俺はやっぱ実戦訓練だ！
<CharaName name='須能 哉'>
あのなぁ
<CharaName name='無州 直己'>
待ってくれよ！ちゃんと理由はあるんだ。まず特訓の時の成績は実戦の時の方が伸びが大きかったんだ。だけど須能はそうでもない。その代わり少ない戦術訓練やカード生成訓練でもメキメキ成績を伸ばしてる。極めつけはディバインとの戦いだ。俺の身体能力と哉の頭脳、それぞれを生かした立ち回りで勝てたんだよ。てことはさ、もう基礎訓練よりも得意分野を伸ばした方がいいんじゃねえかなって思ったんだよ。
<CharaName name='須能 哉'>　
...
<CharaName name='無州 直己'>
おい、どうしたんだ？
<CharaName name='須能 哉'>
いやいや、どうしたんだよ急にそんなまともになっちゃって！
<CharaName name='無州 直己'>
失礼な！俺でもやれば出来るんだぜ？
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>
<CharaName name='梅花 瑞希'>
ぷっあははっ！もうダメ、耐えられない！
<CharaName name='須能 哉'>　
どうかしたのか？
<CharaName name='梅花 瑞希'>
このセリフ考えたの実は私なの。でもでも、分析はちゃんと取り組んでたから怒らないであげて？
<CharaName name='無州 直己'>
あぁ〜バレちったよ...
<CharaName name='須能 哉'>
まぁここは梅花に免じて許してやるよ。でも途中で止めたりすんなよな。
<CharaName name='無州 直己'>
本当か！絶対最後まで訓練しまくるぜ約束する！
<CharaName name='梅花 瑞希'>
哉くんは何するの？
<CharaName name='須能 哉'>　
ん？あぁ俺はデータ分析の続きだな。特にボス...パンデミアについての分析だ。梅花が開発してるカードのより良い使い道を考える。
<CharaName name='梅花 瑞希'>　
うわ〜私の責任重大？でも絶対完成させるから！
<CharaName name='須能 哉'>　
よし、二人とも頼りにしてるぞ！
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<DeleteFigure id='umehanaA'>

<End>",
        @"<Begin id='12'>
<CharaName name=''>
数日後

<CreateFigure id='sunoA' source='24' position='-300,0'>
<CharaName name='須能 哉'>　
(とりあえず俺は自由にカードを使えるから二人にも分けられるように持っていくことにしよう。それから梅花に開発を任せっきりの例のカードの進捗はどうだろうか？全カードを使えるからこそどの規格に落とし込もうかとか変なことで悩んでないといいけど。)
<CharaName name='コンビラス'>　
<CreateFigure id='convA' source='49' position='300,0'>
哉、余り一人で考えるのは良くないぞ。だがこの状態で二人に不安を打ち明けるのも良くないな。
<CharaName name='須能 哉'>
何が言いたいんだよ。
<CharaName name='コンビラス'>
私をもう少し頼れと言っている。君の性格だから私にも頼るわけにはいかないとでも思っているんだろう？だが君はそこまで強くない。それを見越して両親は私を君に託したんだ。何より君の体の中にいるんだから頼らないなんて無理さ。
<CharaName name='須能 哉'>　
こうして思ったことも見透かされる訳だしな。
<CharaName name='コンビラス'>
おいおい、そんな野暮なことは言うな。それにそれはお互い様だろう？
<CharaName name='須能 哉'>　
そうだったそうだった。じゃあここ一番の仕事をしてもらおうかな。
<CharaName name='コンビラス'>
ふふ、それでいいのさ。結局君の脳を間借りして働くだけだからね。
<CharaName name='須能 哉'>
この規格のカードなんだが。
<CharaName name='コンビラス'>
む、グリーデミゴッド規格だな。これが何か？
<CharaName name='須能 哉'>
この規格って基本的に一つしか使えないだろ？適性に関係なく。でも一つは使えるという点で違う。ここで、俺達みたいなウイルス感染者を見てみると全部の規格を使えるんだ。どうにかして上手く改良出来ないかなと思ってさ。
<CharaName name='コンビラス'>
つまり複数同時使用がしたいということか。中々難しそうなことを言うね。ただ可能性がないでもないだろう。例えば、梅花君も恐らく<CharaName name='黒木 止'>君に仕込まれたおかげで全ての規格を使える。が、ウイルスに感染してはいない。なにか見えてこないか？
<CharaName name='須能 哉'>　
黒木さんのデータにその方法が？
<CharaName name='コンビラス'>
かもしれないだろう？今梅花君が開発しているカードに組み込めるならあるいは...
<CharaName name='須能 哉'>
確かに希望はあるな。よし、もう一回取り込んだデータを探してみてくれ。
<CharaName name='コンビラス'>
わかった。また何か分かれば伝えるよ。
<DeleteFigure id='sunoA'>
<DeleteFigure id='convA'>

<CharaName name='梅花 瑞希'>
<CreateFigure id='umehanaA' source='32' position='300,-150'>
(うーん中々進まないなぁ。あれ？須能くんからメールだ。なになに、開発中のカードを複数同時使用可能なグリーデミゴッド規格に出来るかも、ですって？確かにこの設計はその規格専用だけど...あ、電話になった。)
<CharaName name='梅花 瑞希'>
もしもし？須能くん？
<MoveFigure id='umehanaA' destination='-600,0' duration='1'>
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='300,0'>
あぁメールは見てくれた？多分まだ信じてないと思ったから説明しようと思って。
<CharaName name='梅花 瑞希'>　
その通りだよ〜、あの規格じゃ使い物にならないから別のにしようと頑張ってたからね。
<CharaName name='須能 哉'>
実は君が全規格に適性があるのは黒木さんが仕組んだものかもしれないんだ。そこで黒木さんのデータを見てみたらその方法があった。それによると、他の規格に移すのが精一杯だが、俺達でなんとか改良して二枚同時使用が実現出来そうなんだ。
<CharaName name='梅花 瑞希'>
え、えと突然すぎて話が入ってこないんだけど、すごすぎない！？
<CharaName name='須能 哉'>
そうなんだよ。でも時間がない。だから早速明日からやろう。
<CharaName name='梅花 瑞希'>
わかった！こっちで出来る準備はしとくね！
<DeleteFigure id='sunoA'>
<DeleteFigure id='umehanaA'>
<CharaName name=''>
ウイルスバスターの廃工場にて

<CharaName name='ディバイン'>　
<CreateFigure id='divineA' source='48' position='300,0'>
申し訳ありません！私が不覚をとったばかりにパンデミア様をこのような場所に...！
<CharaName name='パンデミア'>　
<CreateFigure id='pandA' source='22' position='-300,0'>
あ～いいよいいよ〜、もう君いらないから、ッハハ！じゃあいただきま〜す！
<CharaName name='ディバイン'>　
も、もう一度チャンスをくd..グワァァァ！
<CharaName name='パンデミア'>
ふーっ。どうやら向こうは思ったよりめんどくさいね。そしてこの子もやられちゃった。油断はしちゃだめだよね〜。先にやっちゃおっかな！
<DeleteFigure id='divineA'>
<DeleteFigure id='pandA'>

<End>",
        @"<Begin id='13'>
<CharaName name=''>
新カードが完成しようとした頃

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
何？それは本当か？
<CharaName name='無州 直己'>　
<CreateFigure id='mushuA' source='64' position='300,-100'>
あぁ多分マジだぜ。さっきお偉いさんが喋ってたからな。
<CharaName name='須能 哉'>　
クソっこんなときに先手を打たれるなんて！前のディバインの被害からやっと復活したってのに！
<CharaName name='無州 直己'>　
そしてどうやらこれ以上時間はないみたいだぜ。これを見ろよ。
<CharaName name='須能 哉'>　
こ、これは...！奴らのボス、パンデミアの置き手紙か？
<CharaName name='無州 直己'>
襲撃にあったところに置いてあったらしい。
<CharaName name='須能 哉'>　
ふむふむ...やはり大規模作戦のた
めに人員を割いたことも、それで資材庫が手薄なことも筒抜けか...さらに作戦の手筈まで！？これは本格的にまずいぞ...
<CharaName name='無州 直己'>　
まずいったって攻め込むにも何も残ってないぜ？
<CharaName name='須能 哉'>
いや、元々作戦は俺達の単独攻撃だ。それに、必要なものは梅花に任せてある。そこが生き残っているなら大丈夫だ。むしろこちらの回復を待つとジリ貧だ。新カードの開発が終わってないことだけが心残りだが...
<CharaName name='無州 直己'>　
行くしかない、ってコト...！？
<CharaName name='須能 哉'>　
そうなるな。よし、梅花のところに行くぞ。
<CharaName name=''>
ラボにて
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>
<CharaName name='梅花 瑞希'>
わわっ！二人してどうしたの？何事？
<CharaName name='無州 直己'>
あれ？知らないのか？
<CharaName name='須能 哉'>
ラボは防音だからな。それに研究者を邪魔するのは得策じゃないからね。
<CharaName name='梅花 瑞希'>
え、何々？何かあったの？
<CharaName name='須能 哉'>
実はウイルスバスターがオーセントの資材を先制攻撃してきたんだ。それで作戦の始動を早めるという話になってさ。さっき上層部とも話して来たんだ。
<CharaName name='梅花 瑞希'>　
で、でもこのカードは...
<CharaName name='須能 哉'>
あぁ、わかってる。だけど今、俺達の突入に邪魔なウイルスを抑えてるオーセントの部隊も時間が経てば補給が出来なくなる。それよりは今行くべきだという判断なんだ。
<CharaName name='梅花 瑞希'>
じゃあこれはどうするの？みんなで色々試してやっとここまで出来たのに...
<CharaName name='須能 哉'>
それは...この際諦めるしかない。
<CharaName name='梅花 瑞希'>　
そんな...
<CharaName name='須能 哉'>
でもこればかりはどうしようもないんだ。わかってほしい。
<CharaName name='梅花 瑞希'>
うん。仕方ない、よね。
<CharaName name='須能 哉'>　
新カードは残念だけど、作戦が始まるからまだまだやることは沢山ある。俺達は戦闘の最終調整をするから、装備の整備を頼んでいいかな？
<CharaName name='梅花 瑞希'>　
もちろんだよ。それが私の仕事だもん。
<CharaName name='無州 直己'>
(あれ？俺ハブられてね？？？まぁ、このカードは俺が持ってこーっと)
<DeleteFigure id='umehanaA'>
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<CharaName name=''>
黒木との特訓場

<CharaName name='須能 哉'>
<CreateFigure id='sunoA' source='24' position='-300,0'>
さて、お互いの自己鍛錬の成果を見てみようじゃないか。
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
それは良いけどよ、コンビラスは禁止だぞ？
<CharaName name='コンビラス'>
安心したまえ。私の戦闘能力は皆無だ。やるだけ無駄さ。
<CharaName name='須能 哉'>　
というわけだから安心しろ。武装は二人で組んだ物だけど。
<CharaName name='無州 直己'>
ま、俺にとってはそれくらいで十分だぜ。哉一人だと負ける気がしないからな。
<CharaName name='須能 哉'>
言ってな！いくぞ！
<CharaName name=''>
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
その後

<CharaName name='須能 哉'>
<CreateFigure id='sunoA' source='24' position='-300,0'>
ゼェゼェ...流石の身のこなしだな...
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
それはこっちのセリフだ...それになんだその武装は...
<CharaName name='須能 哉'>
ふふこれはな...ん？無線だ。何々？第2倉庫も襲撃？近くの隊員は向かうようにってすぐそこじゃないか！
<CharaName name='無州 直己'>
マジかよ...もうヘトヘトだぞ。
<CharaName name='須能 哉'>　
行くしかないだろ...ほらっ！
<CharaName name='無州 直己'>
わかったよ。さっさと片付けようぜ。
<CharaName name=''>
帰路にて

<CharaName name='無州 直己'>
も、もうだめだ、ホントに無理だ。
<CharaName name='須能 哉'>
俺ももう眠すぎて倒れそうだ。
<CharaName name='無州 直己'>
その眠気を覚ますのがこれだ！
<CharaName name='須能 哉'>
それは開発中の新カード？どうしてお前が持ってるんだ？
<CharaName name='無州 直己'>　
お前らが喋ってる間暇だったから弄ってたのを持ってきたんだ。んで、ここ見てくれ。
<CharaName name='須能 哉'>
なんか書き込まれてるな。
<CharaName name='無州 直己'>
多分これ今日の戦闘データなんだよ。
<CharaName name='須能 哉'>
梅花が仕込んだのか？最後まで可能性を残すために？しかし俺のデータを取り込んでるから人間専用からはかけ離れてるな...まぁこれは俺とコンビラスでもっと分析しとくよ。ありがとな。
<CharaName name='無州 直己'>
いいってことよ。じゃおやすみ〜。
<MoveFigure id='mushuA' destination='-500,0' duration='1'>
<CharaName name='須能 哉'>
おいっ！もたれかかって寝るなよー！

<End>",
        @"<Begin id='14'>
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
いよいよ明日が決行日だ。二人とも緊張してないか？
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='300,-100'>
俺はぜーんぜん。
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='umehanaA' source='32' position='-400,-150'>
<CharaName name='梅花 瑞希'>
私はすこーし、だけ？
<CharaName name='須能 哉'>
ま、関係なく行くんだけどね。
<CharaName name='無州 直己'>
なんだそりゃ。ところであのカードはどうなったんだ？
<CharaName name='梅花 瑞希'>
そうだよ！いきなりなくなっちゃって心配してたんだから！
<CharaName name='須能 哉'>
あ、そういえば梅花には無断だったね。実は二人のデータを書き込んでてさ。
<CharaName name='梅花 瑞希'>　
あの機能ね。明日の戦闘中に完成したらいいかなって思って入れてたんだけど、どうだったの？
<CharaName name='須能 哉'>　
結論から言うと、なんもわからん。
<CharaName name='無州 直己'>
なんだそりゃ！
<CharaName name='須能 哉'>　
これ単体では、な。でもこのデータとパンデミアの特徴のデータを合わせると色々分かってきたんだ。パンデミアの弱点は存在しないということだったが、それこそが盲点だったんだ。
<CharaName name='無州 直己'>　
意味わからないし、それと何が関係してんだよ？
<CharaName name='須能 哉'>　
まぁ最後まで聞けって。ディバインのように弱点属性が無い分全部に対して強いというわけでもないみたいなんだ。そして戦闘データから俺と直己は得意属性が同じだとわかった。したがって、弱点を探して多数の属性で攻めるより一つの属性で攻め立てれば効率がいいんだ。そしてそれを実現出来ることがわかったんだ。
<CharaName name='無州 直己'>
...！
<CharaName name='梅花 瑞希'>
私も別の準備が出来るね。
<CharaName name='須能 哉'>　
最後までこのカード自体を使えるようには出来なかったけど、有効には使えたと思う。ありがとう、黒木さん、そして梅花。
<CharaName name='梅花 瑞希'>
お父さん...
<CharaName name='須能 哉'>
あっ、ごめん。思い出させちゃったかな。でもあの黒木 さんだ。絶対生きてるよ。今は隠れてるだけでパンデミアを倒せば何事もなく出てくるはずだよ！
<CharaName name='無州 直己'>
俺たちだって半分はそのために戦ってるんだし任せてくれよ！
<CharaName name='梅花 瑞希'>　
うん！ありがと！二人とも！
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>
<DeleteFigure id='umehanaA'>
<CharaName name=''>
出撃の日

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-400,0'>
この地点まではオーセントの部隊が制圧しているからパンデミアがいるとしたらこの先だ。気を引き締めていくぞ！
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='0,-100'>
おう！
<CharaName name='梅花 瑞希'>
<CreateFigure id='umehanaA' source='32' position='400,-150'>
ふぅーっ、えいえいおーっ！
<CharaName name='須能 哉'>　
それと、ここから先は戦闘は俺たちに任せて欲しい。俺たちとしても補給役がいなくなるのは危険だ。
<CharaName name='梅花 瑞希'>
うん、わかった。じゃあこのカードを渡しておくね。
<CharaName name='無州 直己'>　
それって例のカードじゃんかよ。
<CharaName name='須能 哉'>
...なるほどね。絶対完成させてみせるよ。とりあえずコンビラス、限界まで分析よろしく。
<CharaName name='無州 直己'>
コンビラスかーい！
<CharaName name=''>
その後しばらく

<CharaName name='須能 哉'>
まて、何か変じゃないか？
<CharaName name='無州 直己'>
何がだよ。
<CharaName name='梅花 瑞希'>
敵が、出てこない...
<CharaName name='無州 直己'>
なんだよ、オーセントの別部隊がやったんじゃないのか？
<CharaName name='須能 哉'>
その範囲は過ぎてるんだよ...それに死んでるウイルスも薬品武装で倒された感じじゃない。何かに捕食されたような...
<CharaName name='無州 直己'>
おいおい怖いこと言うなよ〜なぁ梅花？
<CharaName name='？？？'>　そうだよね〜。にしても意外と気づくの遅かったねぇ〜。
<CharaName name='須能 哉'>　
梅花なんか言った？
<CharaName name='梅花 瑞希'>
え？何も言ってないよ。
<CharaName name='須能 哉'>
...梅花、俺たちから離れろ！
<CharaName name='梅花 瑞希'>
う、うん！
<MoveFigure id='umehanaA' destination='1000,0' duration='1'>
<DeleteFigure id='umehana'>
<CharaName name='無州 直己'>
なんだよ！じゃあこいつは...誰ー！？
<CharaName name='須能 哉'>
無州も早くこっちに！
<MoveFigure id='sunoA' destination='400,0' duration='1'>
<MoveFigure id='mushuA' destination='400,0' duration='1'>
<CharaName name='？？？'>　
<CreateFigure id='pandA' source='22' position='-400,0'>
おっと、動きはまぁまぁだね。だけど頭悪そ。
<CharaName name='無州 直己'>
なんだとお前！まず名乗れよ！
<CharaName name='須能 哉'>
この殺気、ディバイン以上のステルス力、直己、こいつは...
<CharaName name='パンデミア'>
やっと気づいたみたいだね。そう、僕がパンデミアだよ。コンビラス君も気づかなかったみたいだね。
<CharaName name='コンビラス'>
すまない...全くわからなかった...
<CharaName name='パンデミア'>
とりあえず...君たちは殺すよ？
<CharaName name='須能 哉'>　
やれるもんならやってみろ！
<CharaName name='無州 直己'>　
そうだ！俺たちはディバインを倒したときより強くなってるんだぞ！
<CharaName name='パンデミア'>　
じゃこのドローンでまずはいこうかな。
<CharaName name='須能 哉'>
(人間体のようでウイルス体としてドローンに入り込めるのか...ここまでは聞いてた通りだが...)
<CharaName name='須能 哉'>　
よし！作戦通り水属性で攻めろ！
<CharaName name='無州 直己'>　
任せな！うおおお！
<CharaName name='パンデミア'>
あれ？知らないのかな？何を打っても無駄だよ？
<CharaName name='須能 哉'>　
知ってるさ！お前はその万能装甲が自慢のようだが
<CharaName name='無州 直己'>
一つに集約するとどうなるかな！
<CharaName name='パンデミア'>　
何？うわぁ〜やられちゃった！
<CharaName name='無州 直己'>
やったか！？
<CharaName name='須能 哉'>　
(直己、それフラグや)
<CharaName name='パンデミア'>　
思った通り中々やるねぇ。じゃ、本体で相手しようか。<CharaName name='黒木 止'>くんのデータには無い形態だよ。ふふっ。
<CharaName name='須能 哉'>　
(内部のウイルス体だけ抜けたのか？見えなかった！)
<CharaName name='コンビラス'>　
(あの密度のウイルスは...)まずい！哉！代われ！
<CharaName name='パンデミア'>　
よーいしょっと！
<CharaName name='須能 哉'>　
ぬわァァァー！
<CharaName name='無州 直己'>
そ、そんな哉が一瞬で...
<CharaName name='須能 哉'>　
う、ぐ、俺は生きてるぞ...だがコンビラスがウイルス体を吐き出して消滅した...
<CharaName name='パンデミア'>
あれ？生きてるね？まぁいっか次はきみだよーん<CharaName name='無州 直己'>くん。
<CharaName name='無州 直己'>　
うわっあぶねっ！
<CharaName name='須能 哉'>　
よくそれで避けれてるな...とにかく今はあの攻撃に注意して攻撃だ！

<End>",
        @"<Begin id='15'>
<CharaName name=''>
戦闘すること一時間

<CharaName name='パンデミア'>　
<CreateFigure id='pandA' source='22' position='-400,0'>
ま、まだやれるんだねぇ、ふぅーん強いじゃん？
<CharaName name='須能 哉'>
<CreateFigure id='sunoA' source='24' position='0,0'>
くっ、ハァハァ...これだけやってあいつは疲れた程度かよ...
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='400,-100'>
おい！哉！
<CharaName name='須能 哉'>　
なんだよ！今話しかけるな！
<CharaName name='無州 直己'>
違うって、新カードが光ってるんだよ！
<CharaName name='須能 哉'>　
え？本当だ！しかも規格がグリーデミゴッドからフリーリスに変わってるぞ！これなら使える！でもどうして...
<CharaName name='無州 直己'>
そんなことは後だ！とりあえず使え！
<CharaName name='須能 哉'>　
よ、よし！これでどうだ？
<CharaName name='コンビラス'>
あーあー、聞こえてるかな？
<CharaName name='須能 哉'>　
コンビラス！？
<CharaName name='無州 直己'>
どうした哉、コンビラスの幻覚か？
<CharaName name='須能 哉'>　
とりあえずお前もこれ使え！
<CharaName name='無州 直己'>　
危なっ！攻撃がない時に投げろよ、焼けそうだったぞ！どれどれ、うわっ！
<CharaName name='コンビラス'>　
やぁ無州くん。
<CharaName name='コンビラス'>　
これで二人に同時に喋れるね。説明はパンデミアを倒してからだ。そして奴の分析は既に終わっている！少々無茶な指示をするが君たちなら対応できるはずだ。
<CharaName name='二人'>　
(よくわからんが勝てるならヨシ！)
<CharaName name='コンビラス'>
なんかアホな思考を感じたがまぁいい。哉！火属性カードに組み替えてその十秒後に毒カードを打つんだ。無州くん！哉の初撃のあとにそのまま水属性弾を打ち込め！
<CharaName name='須能 哉'>　
そんな早く組み替えるなんて、いややるしかない！
<CharaName name=''>
ズドドド！

<CharaName name='パンデミア'>
な、何？毒がめちゃくちゃ染み込んで...ぐっ
<CharaName name='コンビラス'>
哉は氷属性+スタンカード！無州くんは足を攻撃！
<CharaName name='二人'>　
よし！いけーっ！
<CharaName name='パンデミア'>　
あれっ、急に力が...ちょっとこれ、まずいよー！
<CharaName name='コンビラス'>　
とどめ行くぞ！哉は闇属性で、無州くんは光属性で挟み込め！
<CharaName name='二人'>　
おららららららららら！
<CharaName name='パンデミア'>
くっこんな、こんな若造に負けるなど、許さん！ヌワァァァア！
<MoveFigure id='pandA' destination='-1000,0' duration='1'>
<CharaName name=''>
パンデミアを倒して二人は倒れ込んだ
<MoveFigure id='sunoA' destination='0,500' duration='1'>
<MoveFigure id='sunoA' destination='0,500' duration='1'>
<DeleteFigure id='sunoA'>
<DeleteFigure id='mushuA'>

<CreateFigure id='umehanaA' source='32' position='400,-150'>
<CharaName name='梅花 瑞希'>　
須能くん！無州くん！しっかりして！もう終わったんだよ！
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='0,0'>
あれ、いつから寝て...
<CharaName name='無州 直己'>
<CreateFigure id='mushuA' source='64' position='-400,-100'>
スゥスゥ...
<MoveFigure id='mushuA' destination='700,0' duration='2'>
<DeleteFigure id='mushuA'>
<CharaName name='須能 哉'>　
無州は、まぁいいか。どれ位寝てたんだ？
<CharaName name='梅花 瑞希'>
駆け寄るまでだからそんなにだけど、二人ともボロボロじゃない！今は早く本部に帰るよ！
<CharaName name='須能 哉'>　
う、うんそうしたいんだけど力が...
<MoveFigure id='sunoA' destination='700,0' duration='2'>
<DeleteFigure id='sunoA'>
<CharaName name='梅花 瑞希'>　
須能くん！？また寝ちゃった...
<DeleteFigure id='umehanaA'>
<CharaName name=''>
本部にて

<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='0,0'>
(知ってる天井。だけど前とは違う。安心感がある。そうだ、コンビラスだ。おい！起きろ！...反応が無いな。何だったんだろうかあれは。もう一回寝るか...)
<DeleteFigure id='sunoA'>
<CharaName name=''>
数日後

<CharaName name='無州 直己'>　
<CreateFigure id='mushuA' source='64' position='300,-100'>
すっかりもとの体調だぜ！
<CharaName name='須能 哉'>　
<CreateFigure id='sunoA' source='24' position='-300,0'>
あぁ、それ故に本当にパンデミアを倒したっていう実感がないよ。
<CharaName name='無州 直己'>　
そうだなぁ。それと倒す直前のコンビラスみたいな奴は何だったんだろう？
<MoveFigure id='sunoA' destination='300,0' duration='1'>
<MoveFigure id='mushuA' destination='100,0' duration='1'>
<CreateFigure id='convA' source='49' position='-400,0'>
<CharaName name='コンビラス'>　
それについては私から説明しよう！
<CharaName name='須能 哉'>　
うわ！びっくりした！どこから...ってカードから生えてるのか？
<CharaName name='コンビラス'>
生えてるとは心外だが、まぁいい。その通り、私は君を庇って一度体を殆ど失ったが、その後このカードに入り込んだんだ。今日は無州くんがこれを持ってきてくれたから話しかけられたんだよ。
<CharaName name='無州 直己'>
いやーまたまたお手柄ですなぁ
<CharaName name='須能 哉'>　
盗んでるだけじゃんか...
<CharaName name='コンビラス'>
とにかく、これからは私はここにいるからな。もちろん武装に組み込めば脳内に入ってあのようなことも出来る。
<CharaName name='須能 哉'>
いや、本当良かった、生きててくれて。前に言われた気がするけど、お前は俺の一部だしやっぱ寂しかったよ。
<CharaName name='コンビラス'>
うむ。しかし体の動きは無州くんの方が良かったから今後は無州くんに使ってもらおうと思う。
<CharaName name='須能 哉'>　
お前なぁ...
<DeleteFigure id='mushuA'>
<DeleteFigure id='convA'>

こうしてオーセントはパンデミアに乗っ取られていたウイルスバスターを壊滅させることに成功した。俺たち二人は両親の仇を取れたし、ひょっこり帰ってきた黒木さんと再会した梅花も幸せそうだ。今後オーセントはパンデミア一派の残党を倒す組織になるらしい。今までは世間的にはウイルスバスターの外局として活動していたが、これを期に堂々とウイルスを駆逐出来るようになったみたいだ。俺たち二人はというと、これ以上自分達のような人を生み出さないために活動を続けることにした。何より給料がいいし。

<End>",
    };

    // Start is called before the first frame update
    void Start()
    {
        int allowedLevel = FlagManager.ScenarioFlag();
        // 通常のボタン制御
        for (int i = 0; i < allowedLevel; i++)
        {
            GameObject buttonParent = GameObject.Find($"To Stage {i + 1}");
            var number = buttonParent.transform.Find("Body/Number").gameObject;
            number.SetActive(true);
            buttonParent.transform.Find("Body/Accessor").gameObject.SetActive(false);
            GameObject ButtonBase = buttonParent.transform.Find("Body/Base").gameObject;
            ButtonBase.GetComponent<Button>().enabled = false;
            int a = i;
            number.GetComponent<Button>().onClick.AddListener(()=> {
                ScenarioViewerControl.Script = Scripts[a];
                SceneManager.LoadScene("Project/ScenarioViewer/ScenarioViewer");
            });

            // 初見制御
            if (!FlagManager.GetFlag($"__{i + 1}__scenario__viewed__"))
            {
                ButtonBase.GetComponent<Image>().sprite = NotViewed;
            }
        }
    }
}
