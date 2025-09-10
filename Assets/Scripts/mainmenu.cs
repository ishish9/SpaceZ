using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mainmenu : MonoBehaviour
{
     InputSystem_Actions playerActionMap;
    [SerializeField] private GameObject menu;

     private void Awake()
    {
        playerActionMap = new InputSystem_Actions();
        playerActionMap.UI.Menu.performed += OnEscape;

    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        menu.gameObject.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
