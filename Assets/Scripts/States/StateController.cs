using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
   private static StateController instance;

   public static StateController Instance{
        get{
            if(instance == null){
                instance = FindObjectOfType<StateController>();
            }

            return instance;
        }
   }

   public StateDefinition lastState;
   public StateDefinition currentState;

   public void ChangeDefinition(StateDefinition state){
       lastState = currentState;

       currentState = state;
   }
}

public enum StateDefinition{
    GAME,
    PAUSE,
    CUTSCENE,
    COMBAT,
    BACKPACK,
    MINING
}
