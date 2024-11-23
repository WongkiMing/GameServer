using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    Slider HpBar;
    [SerializeField]
    int MaxHP = 100;
    [SerializeField]
    int MinHP = 0;
    [SerializeField]
    Text hpText;

    float CurrentHp;

    bool isLocal;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = MaxHP;
        hpText.text = CurrentHp.ToString();
        HpBar.maxValue = MaxHP;
        HpBar.minValue = MinHP;
        HpBar.value = CurrentHp;

        if(GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = GetComponent<PlayerController>();
            isLocal = playerController.islocal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hurt(10);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            heal(20);
        }
    }

    void hurt(float damageAmount)
    {
        CurrentHp -= damageAmount;
        //Net
        HpBar.value = CurrentHp;
        CurrentHp = Mathf.Clamp(CurrentHp, MinHP, MaxHP);
        hpText.text = CurrentHp.ToString();
        Debug.Log(CurrentHp);
    }

    void heal(float healAmount)
    {
        CurrentHp += healAmount;
        //net
        HpBar.value = CurrentHp;
        CurrentHp = Mathf.Clamp(CurrentHp, MinHP, MaxHP);
        hpText.text = CurrentHp.ToString();
        Debug.Log(CurrentHp);
    }

    void isLose()
    {
        
    }
}
