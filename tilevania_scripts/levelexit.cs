using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelexit : MonoBehaviour
{
   [SerializeField] float levelLoadDelay=1f;
   void OnTriggerEnter2D(Collider2D other) {
      if(other.tag=="Player"){
      StartCoroutine(loadNextLevel());   
      }
      
    
   }

IEnumerator loadNextLevel(){
   yield return new WaitForSecondsRealtime(levelLoadDelay);
   int currentSceneIndex= SceneManager.GetActiveScene().buildIndex;
   int nextSceneIndex= currentSceneIndex+1;
   if(nextSceneIndex==SceneManager.sceneCountInBuildSettings){
      nextSceneIndex=0;
   }
    FindObjectOfType<scenePersist>().ResetScenePersist();
    SceneManager.LoadScene(nextSceneIndex);
}

    

}

