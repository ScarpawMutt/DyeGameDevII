/* Charlie Dye - 2024.02.27

This is the script for weapon data */

using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Gun Data")]

public class GunData : ScriptableObject
{

    public float range = 1000f;
    public int ammo_per_clip = 12;
    public bool automatic = false;

}
