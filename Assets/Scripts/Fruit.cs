using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject Shell;
    public GameObject Whole;
    public GameObject Sliced;
    [SerializeField] private int FruitCode = 0;
    [SerializeField] private Collider SpawnArea;
    public float MinAngle = -15f;
    public float MaxAngle = 15f;
    public float MinForce = 18f;
    public float MaxForce = 22f;

    private Rigidbody FruitRB;
    private Collider FruitCLR;
    private ParticleSystem JuicePteEf;
    private AudioSource SliceFrt;

    [SerializeField] bool _isFruit = true;
    [SerializeField] bool _isRotten = false;
    [SerializeField] bool _isNut = false;
    [SerializeField] bool _hasShell = false;
    [SerializeField] float _speed;
    [SerializeField] float _delay;
    IAdvance _currentAdvance;
    IAdvance _myFallAdvance;
    IAdvance _mySinuousAdvance;
    IAdvance _myLeftAdvance;
    IAdvance _myRightAdvance;

    [SerializeField] private int _timer = 0;
    [SerializeField] private int _changea = 0;
    [SerializeField] private int _changeb = 0;
    [SerializeField] private int _changec = 0;
    [SerializeField] private int _chance = 0;

    public int Points = 1;
    public int PMTimer = 0;

    private void Awake()
    {
        FruitRB = GetComponent<Rigidbody>();
        FruitCLR = GetComponent<Collider>();
        JuicePteEf = GetComponentInChildren<ParticleSystem>();
        SliceFrt = GetComponentInChildren<AudioSource>();

        if (_isRotten)
        {
            _myFallAdvance = new FallAdvance(transform, _speed);
            _mySinuousAdvance = new SinuousAdvance(transform, _speed);
            _myLeftAdvance = new LeftAdvance(transform, _speed);
            _myRightAdvance = new RightAdvance(transform, _speed);
            _currentAdvance = _myFallAdvance;
            _changea = Random.Range(40, 70);
            _changeb = Random.Range(100, 120);
            _changec = Random.Range(150, 180);
        }
    }

    void FixedUpdate()
    {
        if (_isRotten)
        {
            if (_timer < _changea)
            {
                if (_currentAdvance != _myFallAdvance)
                {
                    _currentAdvance = _myFallAdvance;
                }
                _timer++;
                _chance = Random.Range(0, 2);
            }
            else if (_timer < _changeb)
            {
                if (_chance == 1)
                {
                    if (_currentAdvance != _myLeftAdvance)
                    {
                        _currentAdvance = _myLeftAdvance;
                    }
                }
                else
                {
                    if (_currentAdvance != _myRightAdvance)
                    {
                        _currentAdvance = _myRightAdvance;
                    }
                }
                _timer++;
            }
            else if (_timer < _changec)
            {
                if (_chance == 0)
                {
                    if (_currentAdvance != _myLeftAdvance)
                    {
                        _currentAdvance = _myLeftAdvance;
                    }
                }
                else
                {
                    if (_currentAdvance != _myRightAdvance)
                    {
                        _currentAdvance = _myRightAdvance;
                    }
                }
                _timer++;
            }
            else
            {
                _timer = 0;
            }

            _currentAdvance?.Advance();
        }
        if (_delay > 0)
        {
            _delay -= Time.deltaTime;
        }
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        // Added
        if (_isNut && _hasShell)
        {
            FindObjectOfType<GameManager>().IncreaseScore(0);

            Shell.SetActive(false);
            Whole.SetActive(true);

            FruitCLR.enabled = false;
            JuicePteEf.Play();
            SliceFrt.Play();
            _hasShell = false;
            _isFruit = true;
            _delay = 1f;
        }
        // End

        if (_isFruit && (_delay <= 0))
        {
            FindObjectOfType<GameManager>().IncreaseScore(Points);
            // Added
            FindObjectOfType<GameManager>().PointMultiplier(PMTimer);
            // End

            Whole.SetActive(false);
            Sliced.SetActive(true);

            FruitCLR.enabled = false;
            JuicePteEf.Play();
            SliceFrt.Play();

            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Sliced.transform.rotation = Quaternion.Euler(0f, 0f, Angle);

            Rigidbody[] slices = Sliced.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody slice in slices)
            {
                slice.velocity = FruitRB.velocity;
                slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (_isRotten)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        FindObjectOfType<TutorialManager>().rottencheck();
        //    }

        //}
        if (_isFruit)
        {
            if (other.CompareTag("Player"))
            {
                Blade blade = other.GetComponent<Blade>();
                Slice(blade.direction, blade.transform.position, blade.SliceForce);
                FindObjectOfType<TutorialManager>().fruitcheck();

            }
        }
        if (_isNut)
        {
            if (other.CompareTag("Player"))
            {
                Blade blade = other.GetComponent<Blade>();
                Slice(blade.direction, blade.transform.position, blade.SliceForce);
            }
        }
        if (other.CompareTag("Limits"))
        {
            switch (FruitCode)
            {
                case 0:
                    AppleFactory.Instance.ReturnFruit(this);
                    break;
                case 1:
                    KiwiFactory.Instance.ReturnFruit(this);
                    break;
                case 2:
                    WMFactory.Instance.ReturnFruit(this);
                    break;
                case 3:
                    OrangeFactory.Instance.ReturnFruit(this);
                    break;
                case 4:
                    LemonFactory.Instance.ReturnFruit(this);
                    break;
                case 5:
                    BombFactory.Instance.ReturnFruit(this);
                    break;
                case 6:
                    RotFactory.Instance.ReturnFruit(this);
                    break;
                case 7:
                    NutFactory.Instance.ReturnFruit(this);
                    break;
                case 8:
                    SugarFactory.Instance.ReturnFruit(this);
                    break;
            }

            Vector3 position = new Vector3(0, -9, -1);
            this.transform.position = position;
            FruitRB.velocity = Vector3.zero;
            FruitRB.angularVelocity = Vector3.zero;
        }
    }

    private void Reset()
    {
        if (_isNut)
        {
            _hasShell = true;
            _isFruit = false;
            Shell.SetActive(true);
            Whole.SetActive(false);
            Sliced.SetActive(false);
            FruitCLR.enabled = true;
        }
        if (_isFruit)
        {
            Whole.SetActive(true);
            Sliced.SetActive(false);
            FruitCLR.enabled = true;
        }
    }

    public static void TurnOn(Fruit b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Fruit b)
    {
        b.Reset();
        b.gameObject.SetActive(false);
    }
}
