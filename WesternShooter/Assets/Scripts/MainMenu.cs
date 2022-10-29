using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   /// <summary>
   /// This function loads the next scene in the build index
   /// </summary>
   public void PlayGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   /// <summary>
   /// QuitGame() is a function that quits the game
   /// </summary>
   public void QuitGame()
   {
      Debug.Log("Quit");
      Application.Quit();
   }
   
   
}
