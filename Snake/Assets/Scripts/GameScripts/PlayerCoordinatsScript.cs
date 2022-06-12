using TMPro;
using UnityEngine;

public class PlayerCoordinatsScript : MonoBehaviour
{
    public TextMeshProUGUI CoordinatsText;
    public Transform Player;

    private void Update()
    {
        CoordinatsText.text = $"x: {Player.position.x}, y: {Player.position.y}";
    }

    public void CoordinatsInstantiate()
    {
        this.gameObject.SetActive(true);
    }
}
