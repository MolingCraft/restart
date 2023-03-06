using UnityEngine;

[System.Serializable]
public class RaceData 
{
    //所有的Lock都代表该值是否锁定不变

    public string raceName;//种族名

    public float cost;//消耗
    public float priority;//优先级，越大，越先开始行动
    public int actionNum;//行动次数
    public bool LockactionNum;
    public float maxHP;//最大HP
    public bool LockmaxHP;
    public float curHP;//当前HP
    public float luck;//掠夺，杀死敌人时的掉落率增幅
    public bool Lockluck;
    public float speed;//速度
    public bool Lockspeed;
    public bool LockmoveNum;
    public float defend;//防御
    public bool Lockdefend;
    public float attackShield;//攻击护盾
    public bool LockattackShield;
    public float maxEXP;//最大经验值
    public bool LockmaxEXP;
    public float curEXP;//当前经验值
    public bool LockcurEXP;
    public float maxLevel;//最大等级
    public bool LockmaxLevel;
    public float curLevel;//当前等级
    public float rewardNum;//奖励选项数量
    public bool LockrewardNum;
    public float size;//体型大小
    public bool Locksize;
    public float attackDamage;//攻击伤害
    public bool LockattackDamage;
    public int attackLineNum;//攻击线数量（可理解为武器数量
    public bool LockattackLineNum;
    public float attackLineLength;//攻击线长度（攻击距离
    public bool LockattackLineLength;
    public float attackLineAngle;//攻击线角度
    public bool LockattackLineAngle;
    public float knock;//击退

    public int bulletNum;//子弹数量
    public bool LockbulletNum;

    public int bulletpierceNum;//子弹穿刺数量
    public bool LockbulletpierceNum;
}