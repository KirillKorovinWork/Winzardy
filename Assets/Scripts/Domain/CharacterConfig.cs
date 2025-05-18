using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class CharacterConfig : ScriptableObject
{
    public string Id;
    public string LocalizedName;
    public Sprite IconSmall;
    public Sprite IconBig;
    public int Level;
    public float CurrentExp;
    public float ExpToNext;
}
