using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceCraft : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;

    public int maxHealth;//生命上限
    public float enginePower;//引擎推力
    public float speedDamp;//速度衰减
    public float maxSpeed;//最大速度
    public float rotateSpeed;//拐弯速度
    public float shootCoolDown;//射击间隔
    [SerializeField]
    private Transform _leftFirePoint;//左开火点
    [SerializeField]
    private Transform _rightFirePoint;//右开火点
    [SerializeField]
    private GameObject _ammoPrefab;//子弹预设

    private int _health;
    public int health { get { return _health; } }
    private float _speed;
    private bool _shootInCD;
    private bool _leftFire;

    private Dictionary<string,Buff> _buffs;//buff列表

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        _health = maxHealth;
        _speed = 0.0f;
        _shootInCD = false;
        _leftFire = true;

        _buffs = new Dictionary<string, Buff>();
    }

    void Update()
    {
        UpdateBuff();
    }

    void UpdateBuff()
    {
        List<string> finishedBuffs = new List<string>();

        //更新buff
        foreach (Buff buff in _buffs.Values)
        {
            if (buff.isFinished)
            {
                //如果buff结束了，则移除它
                finishedBuffs.Add(buff.buffName);
            }
            else
            {
                //否则更新它
                buff.OnUpdate(this);
            }
        }

        foreach (string buffName in finishedBuffs)
        {
            Buff buff = _buffs[buffName];
            _buffs.Remove(buffName);
            buff.OnRemove(this);
        }
    }

    public void UpdateInput(bool engine,float rotate, bool shoot)
    {
        MoveManagement(engine, rotate);
        ShootManagement(shoot);
    }

    void MoveManagement(bool engine, float rotate)
    {
        //前进
        if(engine)
        {//启动引擎时加速
            _speed += enginePower * Time.deltaTime;
        }
        else
        {//不启动时减速
            if (_speed > 0)
            {
                _speed -= speedDamp * Time.deltaTime;
            }
        }
        _speed = Mathf.Clamp(_speed, 0.0f, maxSpeed);//把速度限制在0和最大速度之间
        _rigidbody2d.MovePosition(_rigidbody2d.position + (Vector2)transform.up * _speed * Time.deltaTime);
        //旋转方向
        _rigidbody2d.MoveRotation(_rigidbody2d.rotation - rotate * rotateSpeed * Time.deltaTime);
    }

    void ShootManagement(bool shoot)
    {
        if(shoot && !_shootInCD)
        {
            Shoot();
            _shootInCD = true;
            StartCoroutine(ShootCoolDown(shootCoolDown));//CD
        }
    }

    void Shoot()
    {
        Instantiate(_ammoPrefab, _leftFire ? _leftFirePoint.position : _rightFirePoint.position, transform.rotation);
        _leftFire = !_leftFire;
    }

    IEnumerator ShootCoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        _shootInCD = false;
    }

    void OnAttacked(object attack)
    {
        int damage = (int)attack;
        _health = Mathf.Max(_health - damage, 0);
        if(_health == 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {

    }

    public void Heal(int health)
    {
        _health = Mathf.Min(_health + health, maxHealth);
    }

    public void AddBuff(Buff buff)
    {
        if(_buffs.ContainsKey(buff.buffName))
        {
            //如果该buff已经存在，则重置它
            _buffs[buff.buffName].Reset();
        }
        else
        {
            //否则添加一个新的buff
            _buffs.Add(buff.buffName, buff);
            buff.OnAdd(this);
        }
    }
}
