using UnityEngine;

public class HouseSetup : MonoBehaviour{
    private void Awake(){
        PlayerData playerData = Player.playerData;
        playerData.isInside = true;
    }
}