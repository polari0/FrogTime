using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace FrogTime
{
    namespace NetworkCore
    {
        public class NetworkButtons : NetworkBehaviour
        // This class handles connecting and disconnecting
        {
            [SerializeField] private GameObject connectUI; // Parent UI element of the connect buttons
            [SerializeField] private GameObject disconnectUI; // Parent UI element of the disconnect button;

            // If we are running a Dedicated Server Build, we want to start the server immediately when the scene has finished loading
#if UNITY_SERVER && !UNITY_EDITOR
    public void Start()
    {
        NetworkManager.Singleton.StartServer();
    }
#else

            private void Start()
            {
                // Set the OnClientDisconnectCallback method to listen for the OnClientDisconnectCallback event
                NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;
            }

            // This script is only ran on the server and on the local client that disconnects.
            private void OnClientDisconnectCallback(ulong clientID)
            {
                // Only run if we were the client that disconnected
                if (NetworkManager.Singleton.LocalClientId == clientID)
                {
                    disconnectUI.SetActive(false);
                    connectUI.SetActive(true);
                }
            }

            public void StartHost()
            {
                // Switch the UI and start a session as host
                disconnectUI.SetActive(true);
                connectUI.SetActive(false);
                NetworkManager.Singleton.StartHost();
            }

            public void StartClient()
            {
                // Switch the UI and connect to a host/server as client
                disconnectUI.SetActive(true);
                connectUI.SetActive(false);
                NetworkManager.Singleton.StartClient();
            }

            public void StartServer()
            {
                // Switch the UI and start a session as server
                disconnectUI.SetActive(true);
                connectUI.SetActive(false);
                NetworkManager.Singleton.StartServer();
            }

            public void Disconnect()
            {
                //  Switch the UI and disconnect from a session
                disconnectUI.SetActive(false);
                connectUI.SetActive(true);
                NetworkManager.Singleton.Shutdown();
            }
#endif
        }  
    }
}
