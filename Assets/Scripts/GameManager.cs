using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool isGameOver { get; private set; } = false;


    public TextMeshProUGUI healthText;
    [SerializeField] int healthPoints = 3;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        SetHealthText();
    }

    public void DecreaseHealth()
    {
        healthPoints--;
        SetHealthText();
        if (healthPoints <= 0)
        {
            Destroy(player);
            isGameOver = true;
        }
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + healthPoints;

    }
}
