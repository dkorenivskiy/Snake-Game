using UnityEngine;

public class DifficultyMenuScript : MonoBehaviour
{
    public void EasyButton()
    {
        Time.fixedDeltaTime = 0.1f;
    }

    public void MediumButton()
    {
        Time.fixedDeltaTime = 0.07f;
    }

    public void HardButton()
    {
        Time.fixedDeltaTime = 0.04f;
    }
}
