using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Launcher : Photon.PunBehaviour
{
    private const string _version = "1";
    private const string _playerNameKey = "PlayerName";

    public InputField playerNameInputField;
    public Button playButton;

    private string _playerName = "";//当前玩家名称

    void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
    }

    // Use this for initialization
    void Start()
    {
        ReadPlayerName();
        ValidatePlayerName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReadPlayerName()
    {
        //如果缓存中有玩家名称缓存，则读取并使用
        if (PlayerPrefs.HasKey(_playerNameKey))
        {
            _playerName = PlayerPrefs.GetString(_playerNameKey);           
        }
        else
        {
            _playerName = "SpaceCraft.io";
        }
        playerNameInputField.text = _playerName;
    }

    public void ValidatePlayerName()
    {
        //不填或者全空格则无法开始游戏
        if(playerNameInputField.text.Trim() == "")
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString(_playerNameKey, playerNameInputField.text);
        _playerName = playerNameInputField.text;
    }

    public void Connect()
    {
        PhotonNetwork.playerName = _playerName;//设置Photon玩家名称
        PhotonNetwork.ConnectUsingSettings(_version);//连接
    }

    public override void OnConnectedToMaster()
    {
        //连接到photon后加入随机房间
        Debug.Log("connected to photon");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        //连接失败
        Debug.LogError("connect failed");
    }

    public override void OnDisconnectedFromPhoton()
    {
        //连接断开
        Debug.Log("disconnected");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        //加入房间失败则创建一个房间
        Debug.Log("create a room");
        PhotonNetwork.CreateRoom("", new RoomOptions() { MaxPlayers = 10 }, null);
    }

    public override void OnJoinedRoom()
    {
        //加入房间成功，切换到加载场景
        Debug.Log("joined a room");
        PhotonNetwork.LoadLevel(1);
    }
}