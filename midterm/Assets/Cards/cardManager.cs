using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class cardManager : MonoBehaviour
{
    public cardObj cardChar;
    public cardObj cardMax;
    public TextMeshProUGUI textMax;
    public TextMeshProUGUI textChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMax.text = cardMax.cardName + '\n' + cardMax.cardNickname + '\n' + cardMax.cardTeam;
        textChar.text = cardChar.cardName + '\n' + cardChar.cardNickname + "\n" + cardChar.cardTeam;
    
    }
}
