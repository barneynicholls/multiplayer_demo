using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }
}
