using UnityEngine;
using UnityEngine.SceneManagement ;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
  void OnGUI()
  {
    const int buttonWidth = 120;
    const int buttonHeight = 60;

    // Affiche un bouton pour démarrer la partie
    if (
      GUI.Button(
        // Centré en x, y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (Screen.height / 2) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Jouer"
      )
    )
    {
      // Sur le clic, on démarre le premier niveau
      SceneManager.LoadScene("MiniGame");
    }
  }
}
