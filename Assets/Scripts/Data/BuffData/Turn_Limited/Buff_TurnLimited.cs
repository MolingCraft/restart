using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_TurnLimited : Buff
{
   public int sustainedNum;
   public void sustainedNum_Add(){sustainedNum++;}
   public void sustainedNum_Add(int num){sustainedNum+=num;}
   public void sustainedNum_Reduce(){sustainedNum--;}
   public void sustainedNum_Reduce(int num){sustainedNum-=num;}

}
