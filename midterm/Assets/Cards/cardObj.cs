using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card" , menuName = "ScriptaleObjects/Cards" , order = 0)]

public class cardObj : ScriptableObject
{
   public string cardName;
   public string cardNickname;
   public string cardTeam;
    public Sprite cardImage;
}
