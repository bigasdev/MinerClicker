using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
     public virtual void Enter(){
          StateController.Instance.ChangeDefinition(StateDefinition.CUTSCENE);
     }

     public virtual void Exit(){
          StateController.Instance.ChangeDefinition(StateDefinition.GAME);
     }

     public virtual void Act(){
     }

     public IEnumerator changeCutscene(float delay){
          yield return new WaitForSeconds(delay);
          StateController.Instance.ChangeDefinition(StateDefinition.GAME);
     }
}
