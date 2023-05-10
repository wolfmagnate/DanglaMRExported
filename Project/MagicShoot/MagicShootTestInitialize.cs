using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShootTestInitialize : MonoBehaviour
{

    public GameObject StraightBullet;
    public GameObject WaveBullet;
    public GameObject RayBullet;
    public GameObject SphereBullet;

    // Start is called before the first frame update
    void Start()
    {
        var HellFire = new MagicTypeCard("HellFire");
        var Amplifier = new PowerUpCard("Amplifier");
        var Generator = new PowerUpCard("Generator");

        var field = new MagicField(5, 5);
        field.MagicCards[0, 0] = HellFire;
        field.MagicCards[1, 1] = Amplifier;
        field.MagicCards[3, 1] = Amplifier;

        var MoveHistory = new List<Vector2Int>();
        MoveHistory.Add(new Vector2Int(0, 0));
        MoveHistory.Add(new Vector2Int(1, 1));
        MoveHistory.Add(new Vector2Int(1, 3));

        var magic = MagicCreater.Create(field, MoveHistory);

        ShootPlayer.usingMagic = magic;
        ShootPlayer.usingShot = magic.MoveType switch{
            MoveType.gatling => StraightBullet,
            MoveType.straight => StraightBullet,
            MoveType.spread => StraightBullet,
            MoveType.sphere => SphereBullet,
            MoveType.wave => WaveBullet,
            MoveType.ray => RayBullet,
            _ => null
        };


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
