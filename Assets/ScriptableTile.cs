using UnityEngine;

[CreateAssetMenu(fileName = "KeyDoorBehavior", menuName = "Tiles/Key Door Behavior")]
public class KeyDoorBehavior : ScriptableObject
{
    public string requiredKeyID = "red_key";
    public Color openedColor = Color.gray;
    public int openedLayer = 0;
}
