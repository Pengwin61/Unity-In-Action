using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }



    private NetworkService _network;

    // —юда добавл€ютс€ элементы управлени€ громкостью

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");

        _network = service;


        // «десь инициализируютс€ источники музыки
        status = ManagerStatus.Started;
    }


}
