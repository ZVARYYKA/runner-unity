using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
   public void PlayGame() {

    Application.LoadLevel("Gamesession");

   }
  public void Exit() {

    Application.Quit();
  }
}
