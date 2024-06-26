using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // Variables
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }


    private void Player_OnSelectedCounterChanged(
        object sender, Player.SelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }


    private void Show()
    {
        visualGameObject.SetActive(true);
    }


    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
