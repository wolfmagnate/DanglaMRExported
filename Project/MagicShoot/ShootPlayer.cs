using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootPlayer : MonoBehaviour
{
    private static Magic _usingMagic;
    public static Magic usingMagic {
        get { return _usingMagic; }
        set {
            _usingMagic = value;
            _usingMagic.AddBuffer(PowerUpItemShop.GetAttackBuffer());
        }
    }
    public static GameObject usingShot;
    public static Vector3 usingDirection;
    public float MP { private set { playerStatus.MP = value; } get { return playerStatus.MP; } }
    private PlayerStatus playerStatus;
    private MagicShooter magicShooter;

    public GameObject StraightShot;
    public GameObject WaveShot;
    public GameObject RayShot;
    public GameObject SphereShot;
    public GameObject SpreadShot;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        var chargeUI = GameObject.Find("UICanvas").GetComponent<ChargeUIControl>();

        magicShooter = usingMagic.MoveType switch
        {
            MoveType.straight => new StraightShooter(this, chargeUI),
            MoveType.spread => new SpreadShooter(this, chargeUI),
            MoveType.wave => new WaveShooter(this, chargeUI),
            MoveType.sphere => new SphereShooter(this, chargeUI),
            MoveType.ray => new RayShooter(this, chargeUI),
            MoveType.gatling => new GatlingShooter(this, chargeUI),
            _ => null
        };

        usingShot = usingMagic.MoveType switch
        {
            MoveType.straight => StraightShot,
            MoveType.spread => SpreadShot,
            MoveType.wave => WaveShot,
            MoveType.sphere => SphereShot,
            MoveType.ray => RayShot,
            MoveType.gatling => StraightShot,
            _ => null
        };

        OnLeftButtonDown = new UnityEvent();
        OnLeftButtonPress = new UnityEvent();
        OnLeftButtonReleased = new UnityEvent();

        OnLeftButtonDown.AddListener(ReInitializeMagic);
        OnLeftButtonPress.AddListener(Charge);
        OnLeftButtonPress.AddListener(TryShot);
        OnLeftButtonReleased.AddListener(AfterKeyLeave);

        // エフェクト関連処理
        var resolver = GameObject.FindGameObjectWithTag("EffectResolver").GetComponent<EffectResolve>();
        magicShooter.Effect = (usingMagic.Attribute, usingMagic.MoveType) switch
        {
            (MagicAttribute.Darkness, MoveType.gatling) => resolver.DarknessGatling,
            (MagicAttribute.Darkness, MoveType.ray) => resolver.DarknessRay,
            (MagicAttribute.Darkness, MoveType.sphere) => resolver.DarknessSphere,
            (MagicAttribute.Darkness, MoveType.spread) => resolver.DarknessSpread,
            (MagicAttribute.Darkness, MoveType.straight) => resolver.DarknessStraight,
            (MagicAttribute.Darkness, MoveType.wave) => resolver.DarknessWave,

            (MagicAttribute.Wind, MoveType.gatling) =>  resolver.WindGatling,
            (MagicAttribute.Wind, MoveType.ray) =>      resolver.WindRay,
            (MagicAttribute.Wind, MoveType.sphere) =>   resolver.WindSphere,
            (MagicAttribute.Wind, MoveType.spread) =>   resolver.WindSpread,
            (MagicAttribute.Wind, MoveType.straight) => resolver.WindStraight,
            (MagicAttribute.Wind, MoveType.wave) =>     resolver.WindWave,

            (MagicAttribute.Water, MoveType.gatling) =>  resolver.WaterGatling,
            (MagicAttribute.Water, MoveType.ray) =>      resolver.WaterRay,
            (MagicAttribute.Water, MoveType.sphere) =>   resolver.WaterSphere,
            (MagicAttribute.Water, MoveType.spread) =>   resolver.WaterSpread,
            (MagicAttribute.Water, MoveType.straight) => resolver.WaterStraight,
            (MagicAttribute.Water, MoveType.wave) =>     resolver.WaterWave,

            (MagicAttribute.Mountain, MoveType.gatling) =>  resolver.MountainGatling,
            (MagicAttribute.Mountain, MoveType.ray) =>      resolver.MountainRay,
            (MagicAttribute.Mountain, MoveType.sphere) =>   resolver.MountainSphere,
            (MagicAttribute.Mountain, MoveType.spread) =>   resolver.MountainSpread,
            (MagicAttribute.Mountain, MoveType.straight) => resolver.MountainStraight,
            (MagicAttribute.Mountain, MoveType.wave) =>     resolver.MountainWave,

            (MagicAttribute.Fire, MoveType.gatling) =>  resolver.FireGatling,
            (MagicAttribute.Fire, MoveType.ray) =>      resolver.FireRay,
            (MagicAttribute.Fire, MoveType.sphere) =>   resolver.FireSphere,
            (MagicAttribute.Fire, MoveType.spread) =>   resolver.FireSpread,
            (MagicAttribute.Fire, MoveType.straight) => resolver.FireStraight,
            (MagicAttribute.Fire, MoveType.wave) =>     resolver.FireWave,

            (MagicAttribute.Light, MoveType.gatling) =>  resolver.LightGatling,
            (MagicAttribute.Light, MoveType.ray) =>      resolver.LightRay,
            (MagicAttribute.Light, MoveType.sphere) =>   resolver.LightSphere,
            (MagicAttribute.Light, MoveType.spread) =>   resolver.LightSpread,
            (MagicAttribute.Light, MoveType.straight) => resolver.LightStraight,
            (MagicAttribute.Light, MoveType.wave) =>     resolver.LightWave,

            (MagicAttribute.Lightning, MoveType.gatling) =>  resolver.LightningGatling,
            (MagicAttribute.Lightning, MoveType.ray) =>      resolver.LightningRay,
            (MagicAttribute.Lightning, MoveType.sphere) =>   resolver.LightningSphere,
            (MagicAttribute.Lightning, MoveType.spread) =>   resolver.LightningSpread,
            (MagicAttribute.Lightning, MoveType.straight) => resolver.LightningStraight,
            (MagicAttribute.Lightning, MoveType.wave) =>     resolver.LightningWave,

            (MagicAttribute.Ice, MoveType.gatling) =>  resolver.IceGatling,
            (MagicAttribute.Ice, MoveType.ray) =>      resolver.IceRay,
            (MagicAttribute.Ice, MoveType.sphere) =>   resolver.IceSphere,
            (MagicAttribute.Ice, MoveType.spread) =>   resolver.IceSpread,
            (MagicAttribute.Ice, MoveType.straight) => resolver.IceStraight,
            (MagicAttribute.Ice, MoveType.wave) =>     resolver.IceWave,

            (MagicAttribute.Metal, MoveType.gatling) =>  resolver.MetalGatling,
            (MagicAttribute.Metal, MoveType.ray) =>      resolver.MetalRay,
            (MagicAttribute.Metal, MoveType.sphere) =>   resolver.MetalSphere,
            (MagicAttribute.Metal, MoveType.spread) =>   resolver.MetalSpread,
            (MagicAttribute.Metal, MoveType.straight) => resolver.MetalStraight,
            (MagicAttribute.Metal, MoveType.wave) =>     resolver.MetalWave,

            (MagicAttribute.Tree, MoveType.gatling) =>  resolver.LifeGatling,
            (MagicAttribute.Tree, MoveType.ray) =>      resolver.LifeRay,
            (MagicAttribute.Tree, MoveType.sphere) =>   resolver.LifeSphere,
            (MagicAttribute.Tree, MoveType.spread) =>   resolver.LifeSpread,
            (MagicAttribute.Tree, MoveType.straight) => resolver.LifeStraight,
            (MagicAttribute.Tree, MoveType.wave) =>     resolver.LifeWave,

            _ => null
        };
        magicShooter.HitEffect = (usingMagic.Attribute, usingMagic.MoveType) switch
        {
            (MagicAttribute.Darkness, MoveType.gatling)  => resolver.DarknessGatlingHit,
            (MagicAttribute.Darkness, MoveType.ray)      => resolver.DarknessRayHit,
            (MagicAttribute.Darkness, MoveType.sphere)   => resolver.DarknessSphereHit,
            (MagicAttribute.Darkness, MoveType.spread)   => resolver.DarknessSpreadHit,
            (MagicAttribute.Darkness, MoveType.straight) => resolver.DarknessStraightHit,
            (MagicAttribute.Darkness, MoveType.wave)     => resolver.DarknessWaveHit,

            (MagicAttribute.Wind, MoveType.gatling)  => resolver.WindGatlingHit,
            (MagicAttribute.Wind, MoveType.ray)      => resolver.WindRayHit,
            (MagicAttribute.Wind, MoveType.sphere)   => resolver.WindSphereHit,
            (MagicAttribute.Wind, MoveType.spread)   => resolver.WindSpreadHit,
            (MagicAttribute.Wind, MoveType.straight) => resolver.WindStraightHit,
            (MagicAttribute.Wind, MoveType.wave)     => resolver.WindWaveHit,

            (MagicAttribute.Water, MoveType.gatling)  => resolver.WaterGatlingHit,
            (MagicAttribute.Water, MoveType.ray)      => resolver.WaterRayHit,
            (MagicAttribute.Water, MoveType.sphere)   => resolver.WaterSphereHit,
            (MagicAttribute.Water, MoveType.spread)   => resolver.WaterSpreadHit,
            (MagicAttribute.Water, MoveType.straight) => resolver.WaterStraightHit,
            (MagicAttribute.Water, MoveType.wave)     => resolver.WaterWaveHit,

            (MagicAttribute.Mountain, MoveType.gatling)  => resolver.MountainGatlingHit,
            (MagicAttribute.Mountain, MoveType.ray)      => resolver.MountainRayHit,
            (MagicAttribute.Mountain, MoveType.sphere)   => resolver.MountainSphereHit,
            (MagicAttribute.Mountain, MoveType.spread)   => resolver.MountainSpreadHit,
            (MagicAttribute.Mountain, MoveType.straight) => resolver.MountainStraightHit,
            (MagicAttribute.Mountain, MoveType.wave)     => resolver.MountainWaveHit,

            (MagicAttribute.Fire, MoveType.gatling)  => resolver.FireGatlingHit,
            (MagicAttribute.Fire, MoveType.ray)      => resolver.FireRayHit,
            (MagicAttribute.Fire, MoveType.sphere)   => resolver.FireSphereHit,
            (MagicAttribute.Fire, MoveType.spread)   => resolver.FireSpreadHit,
            (MagicAttribute.Fire, MoveType.straight) => resolver.FireStraightHit,
            (MagicAttribute.Fire, MoveType.wave)     => resolver.FireWaveHit,

            (MagicAttribute.Light, MoveType.gatling)  => resolver.LightGatlingHit,
            (MagicAttribute.Light, MoveType.ray)      => resolver.LightRayHit,
            (MagicAttribute.Light, MoveType.sphere)   => resolver.LightSphereHit,
            (MagicAttribute.Light, MoveType.spread)   => resolver.LightSpreadHit,
            (MagicAttribute.Light, MoveType.straight) => resolver.LightStraightHit,
            (MagicAttribute.Light, MoveType.wave)     => resolver.LightWaveHit,

            (MagicAttribute.Lightning, MoveType.gatling)  => resolver.LightningGatlingHit,
            (MagicAttribute.Lightning, MoveType.ray)      => resolver.LightningRayHit,
            (MagicAttribute.Lightning, MoveType.sphere)   => resolver.LightningSphereHit,
            (MagicAttribute.Lightning, MoveType.spread)   => resolver.LightningSpreadHit,
            (MagicAttribute.Lightning, MoveType.straight) => resolver.LightningStraightHit,
            (MagicAttribute.Lightning, MoveType.wave)     => resolver.LightningWaveHit,

            (MagicAttribute.Ice, MoveType.gatling)  => resolver.IceGatlingHit,
            (MagicAttribute.Ice, MoveType.ray)      => resolver.IceRayHit,
            (MagicAttribute.Ice, MoveType.sphere)   => resolver.IceSphereHit,
            (MagicAttribute.Ice, MoveType.spread)   => resolver.IceSpreadHit,
            (MagicAttribute.Ice, MoveType.straight) => resolver.IceStraightHit,
            (MagicAttribute.Ice, MoveType.wave)     => resolver.IceWaveHit,

            (MagicAttribute.Metal, MoveType.gatling)  => resolver.MetalGatlingHit,
            (MagicAttribute.Metal, MoveType.ray)      => resolver.MetalRayHit,
            (MagicAttribute.Metal, MoveType.sphere)   => resolver.MetalSphereHit,
            (MagicAttribute.Metal, MoveType.spread)   => resolver.MetalSpreadHit,
            (MagicAttribute.Metal, MoveType.straight) => resolver.MetalStraightHit,
            (MagicAttribute.Metal, MoveType.wave)     => resolver.MetalWaveHit,

            (MagicAttribute.Tree, MoveType.gatling)  => resolver.LifeGatlingHit,
            (MagicAttribute.Tree, MoveType.ray)      => resolver.LifeRayHit,
            (MagicAttribute.Tree, MoveType.sphere)   => resolver.LifeSphereHit,
            (MagicAttribute.Tree, MoveType.spread)   => resolver.LifeSpreadHit,
            (MagicAttribute.Tree, MoveType.straight) => resolver.LifeStraightHit,
            (MagicAttribute.Tree, MoveType.wave)     => resolver.LifeWaveHit,

            _ => null
        };

        if(magicShooter is GatlingShooter)
        {
            GatlingShooter gshooter = (GatlingShooter)magicShooter;
            gshooter.SpecialEffect = usingMagic.Attribute switch
            {
                MagicAttribute.Darkness => resolver.DarknessGatlingEffect,
                MagicAttribute.Fire => resolver.FireGatlingEffect,
                MagicAttribute.Ice => resolver.IceGatlingEffect,
                MagicAttribute.Light => resolver.LightGatlingEffect,
                MagicAttribute.Lightning => resolver.LightningGatlingEffect,
                MagicAttribute.Metal => resolver.MetalGatlingEffect,
                MagicAttribute.Mountain => resolver.MountainGatlingEffect,
                MagicAttribute.Tree => resolver.LifeGatlingEffect,
                MagicAttribute.Water => resolver.WaterGatlingEffect,
                MagicAttribute.Wind => resolver.WindGatlingEffect,
                _ => null,
            };
        }


        if (magicShooter is GatlingShooter)
        {
            GatlingShooter gshooter = (GatlingShooter)magicShooter;
            gshooter.SpecialEffect = usingMagic.Attribute switch
            {
                MagicAttribute.Darkness => resolver.DarknessGatlingEffect,
                MagicAttribute.Fire => resolver.FireGatlingEffect,
                MagicAttribute.Ice => resolver.IceGatlingEffect,
                MagicAttribute.Light => resolver.LightGatlingEffect,
                MagicAttribute.Lightning => resolver.LightningGatlingEffect,
                MagicAttribute.Metal => resolver.MetalGatlingEffect,
                MagicAttribute.Mountain => resolver.MountainGatlingEffect,
                MagicAttribute.Tree => resolver.LifeGatlingEffect,
                MagicAttribute.Water => resolver.WaterGatlingEffect,
                MagicAttribute.Wind => resolver.WindGatlingEffect,
                _ => null,
            };
        }

        playerStatus = GetComponent<PlayerStatus>();
    }

    public void DecreaceMP(float mp)
    {
        playerStatus.MP -= mp;
    }

    private UnityEvent OnLeftButtonPress;
    private UnityEvent OnLeftButtonDown;
    private UnityEvent OnLeftButtonReleased;

    // Update is called once per frame
    void Update()
    {
        if (IsLeftButtonPress())
        {
            OnLeftButtonPress.Invoke();
        }
        SetUsingDirection();
    }

    public void InvokeDown()
    {
        OnLeftButtonDown.Invoke();
    }

    public void InvokeUp()
    {
        OnLeftButtonReleased.Invoke();
    }

    private void SetUsingDirection()
    {
        usingDirection = transform.forward;
    }

    private bool IsLeftButtonPress() => HologlaLeftClickEvents.Clicking;

    private void Charge()
    {
        magicShooter.Charge();
    }


    private void TryShot()
    {
        if (magicShooter.CanShoot())
        {
            var shots = magicShooter.GenerateShot();
            magicShooter.Shoot(shots);
            magicShooter.ConsumeMP(this);
            magicShooter.AfterShoot();
        }
    }



    private void ReInitializeMagic()
    {
        magicShooter.OnClickStart();
    }

    private void AfterKeyLeave()
    {
        magicShooter.OnClickLeave(this);
    }

}
