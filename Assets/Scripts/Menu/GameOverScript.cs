using UnityEngine;
using UnityEngine.SceneManagement ;

/// <summary>
/// Relance ou quitte la partie en cours
/// </summary>
public class GameOverScript : MonoBehaviour
{
  void OnGUI()
  {
    const int buttonWidth = 120;
    const int buttonHeight = 60;

    if (
      GUI.Button(
        // Centré en x, 1/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (Screen.height / 4) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Rejouer"
      )
    )
    {
      // Recharge le niveau
      
      SceneManager.LoadScene("MiniGame",LoadSceneMode.Single);
    }

    if (
      GUI.Button(
        // Centré en x, 2/3 en y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (Screen.height) - (buttonHeight*3),
          buttonWidth,
          buttonHeight
        ),
        "Menu principal"
      )
    )
    {
      // Retourne au menu
      SceneManager.LoadScene("Menu");
    }
  }
}

