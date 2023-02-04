using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class gamesession : MonoBehaviour
{
  [SerializeField] int playerLives=3;
  [SerializeField] int score=0;
  [SerializeField] TextMeshProUGUI livesText;
  [SerializeField] TextMeshProUGUI scoreText;
   void Awake() {
    int numGameSessions=FindObjectsOfType<gamesession>().Length;
    if(numGameSessions>1){
        Destroy(gameObject);
    }
    else
    DontDestroyOnLoad(gameObject);
  }
void Start() {
   livesText.text=playerLives.ToString(); 
   scoreText.text=score.ToString(); 
}
public void ProcessPlayerDeath(){
    if(playerLives>1)
    {
        TakeLife();
    }
    else{
        ResetGameSession();
    }
}

public void addToScore(int pointsToAdd){
    score+=pointsToAdd;
     scoreText.text=score.ToString(); 
}
void TakeLife() {
playerLives--;
int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
SceneManager.LoadScene(currentSceneIndex);
 livesText.text=playerLives.ToString(); 
}


void ResetGameSession(){
    FindObjectOfType<scenePersist>().ResetScenePersist();
   SceneManager.LoadScene(0);
   Destroy(gameObject); 
}


  

   
}
