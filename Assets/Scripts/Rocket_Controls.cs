using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rocket_Controls : MonoBehaviour
{
    InputSystem_Actions inputMap;
    [SerializeField] private GameObject boosterMain;
    [SerializeField] private GameObject booster1;
    [SerializeField] private GameObject booster2;
    [SerializeField] private GameObject booster3;
    [SerializeField] private GameObject booster4;
    [SerializeField] private GameObject ThrusterR;
    [SerializeField] private GameObject ThrusterL;
    [SerializeField] private GameObject ThrusterOFF1;
    [SerializeField] private GameObject ThrusterOFF2;
    [SerializeField] private GameObject ThrusterOFF3;
    private Vector2 move;
    public delegate void fuelLevel();
    public static event fuelLevel OnFuel;
    public float speed;
    public float acceleration = 1.0f;
    public float deAcceleration = 4.0f;

    private float LeftRightSpeed = 15f;
    private float miniSpeed = 0;
    private float maxSpeed = 300;
    private Rigidbody rigidBody;
    public FuelBar fuel;
    private bool buttonlaunch = false;
    private bool isDead = false;
    private bool thrustLeft = false;
    private bool thrustRight = false;

    public delegate void Death();
    public static event Death OnDeath;

    private void Awake()
    {
        inputMap = new InputSystem_Actions();
       // inputMap.Player.Thrust.performed += OnThrustEnable;
       // inputMap.Player.Move.performed += OnMove;
    }

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputMap.Player.Enable();
    }

    private void OnDisable()
    {
        inputMap.Player.Disable();
    }

    private void Update()
    {
        move = inputMap.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (inputMap.Player.Booster.triggered == true || buttonlaunch == true)
        {
            if (isDead == false)
            {
                ThrusterOFF1.SetActive(false);
                ThrusterOFF2.SetActive(false);
                ThrusterOFF3.SetActive(false);
                boosterMain.SetActive(true);
                booster1.SetActive(true);
                booster2.SetActive(true);
                booster3.SetActive(true);
                booster4.SetActive(true);
                AudioManager.instance.PlaySoundLooped1(AudioManager.instance.audioClips.Booster);

                //boostersnd.SetActive(true);
            rigidBody.AddForce(Vector3.up * speed);
            speed += acceleration;
            fuel.slidervalue -= Time.deltaTime;
            fuel.SetFuelLevel(fuel.slidervalue);
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            if (fuel.slidervalue <= 0)
            {
                isDead = true;
                    ThrusterOFF1.SetActive(true);
                    ThrusterOFF2.SetActive(true);
                    ThrusterOFF3.SetActive(true);
                }
            }
            else
            {
                
                boosterMain.SetActive(false);
                booster1.SetActive(false);
                booster2.SetActive(false);
                booster3.SetActive(false);
                booster4.SetActive(false);
                AudioManager.instance.PlaySoundLoopedStop1();

               // boostersnd.SetActive(false);
                speed -= acceleration;
                if (speed <= miniSpeed)
                {
                    speed = miniSpeed;
                }
            }
        }
        else
        {
            rigidBody.AddForce(Vector3.down * speed);

            ThrusterOFF1.SetActive(true);
            ThrusterOFF2.SetActive(true);
            ThrusterOFF3.SetActive(true);
            boosterMain.SetActive(false);
            booster1.SetActive(false);
            booster2.SetActive(false);
            booster3.SetActive(false);
            booster4.SetActive(false);
            AudioManager.instance.PlaySoundLoopedStop1();
            //boostersnd.SetActive(false);
            speed -= acceleration;
            if (speed <= miniSpeed)
            {
                speed = miniSpeed;
            }
              
        }
        // Move Left
        if (move.x == -1 || thrustLeft && rigidBody.linearVelocity.magnitude >= 15f)
        {
            rigidBody.AddForce(-LeftRightSpeed, 0, 0, ForceMode.Force);
            ThrusterR.SetActive(true);
            AudioManager.instance.PlaySoundLooped2(AudioManager.instance.audioClips.Thruster);
            //Thrustersnd1.SetActive(true);
        }
        else
        {
            ThrusterR.SetActive(false);
            AudioManager.instance.PlaySoundLoopedStop2();

            //Thrustersnd1.SetActive(false);
        }
        // Move Right
        if (move.x == 1 || thrustRight && rigidBody.linearVelocity.magnitude >= 15f)
        {
            rigidBody.AddForce( LeftRightSpeed, 0, 0, ForceMode.Force);
            ThrusterL.SetActive(true);
            AudioManager.instance.PlaySoundLooped3(AudioManager.instance.audioClips.Thruster);
            //Thrustersnd2.SetActive(true);
        }
        else
        {
            ThrusterL.SetActive(false);
            AudioManager.instance.PlaySoundLoopedStop3();
            //Thrustersnd2.SetActive(false);
        }
    }

    public void ThrustLeftButton (bool thrustEnable)
    {
        thrustLeft = thrustEnable;
    }

    public void ThrustRightButton (bool thrustEnable)
    {
        thrustRight = thrustEnable;
    }

    public void boosterToggle()
    {
        buttonlaunch = !buttonlaunch;
    }

    public void RocketDeath()
    {
        OnDeath();
    }
}
