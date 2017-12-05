using System;
using UnityEngine;

namespace KSPCord
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class KSPCord : MonoBehaviour
    {
        DiscordRpc.RichPresence presence;
        
        DiscordRpc.EventHandlers handlers;

        public string StartTimestamp { get => StartTimestamp; set => StartTimestamp = value; }
        public string EndTimestamp { get => EndTimestamp; set => EndTimestamp = value; }

        public KSPCord() => Initialize("295791710376689674");

        /// <summary>
        /// Initialize the RPC. Requires Discord Client ID from KSP App.
        /// </summary>
        private void Initialize(string clientId)
        {
            handlers = new DiscordRpc.EventHandlers();

            handlers.readyCallback = ReadyCallback;
            handlers.disconnectedCallback += DisconnectedCallback;
            handlers.errorCallback += ErrorCallback;

            DiscordRpc.Initialize(clientId, ref handlers, true, null);

            this.PostConsoleMessage("Initialized.");
            Debug.Log("Beep, Boop! Client ID accepted, kerbaling your presence.... " + Time.realtimeSinceStartup);

        }

        /// <summary>
        /// Update the presence status .
        /// </summary>
        private void UpdatePresence()
        {
            presence.details = "KSP Testing";
            presence.state = "Hunting for kerbals";
            presence.largeImageKey = "kerbalspaceprogram";
            presence.largeImageText = "Looking up at the Muun";

            DiscordRpc.UpdatePresence(ref presence);

            Debug.Log("Presence updated. KerbalCord == BestCord! " + Time.realtimeSinceStartup);
        }

        private void PostConsoleMessage(string v)
        {
            Debug.Log(v);
        }

        /// <summary>
        /// Calls ReadyCallback(), DisconnectedCallback(), ErrorCallback().
        /// </summary>
        private void RunCallbacks()
        {
            DiscordRpc.RunCallbacks();

            this.PostConsoleMessage("Rallbacks run.");
        }

        /// <summary>
        /// Stop RPC.
        /// </summary>
        private void Shutdown()
        {
            DiscordRpc.Shutdown();

            this.PostConsoleMessage("Shuted down.");
        }

        /// <summary>
        /// Called after RunCallbacks() when ready.
        /// </summary>
        private void ReadyCallback()
        {
            this.PostConsoleMessage("Ready.");
        }

        /// <summary>
        /// Called after RunCallbacks() in cause of disconnection.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        private void DisconnectedCallback(int errorCode, string message)
        {
            this.PostConsoleMessage(string.Format("Disconnect {0}: {1}", errorCode, message));
        }

        /// <summary>
        /// Called after RunCallbacks() in cause of error.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        private void ErrorCallback(int errorCode, string message)
        {
            this.PostConsoleMessage(string.Format("Error {0}: {1}", errorCode, message));
        }

        /// <summary>
        /// Function will update the displayed presence
        /// </summary>
        public void Update(object sender)
        {
            presence.details = "KSP Updated Presence";
            this.UpdatePresence();
            Debug.Log("Updated!");
        }
        //<summary>
        //Presence will update with map details.... (in the future), just want it to update.. Would be nice :(
        //</summary>
        public void OnLoad(ConfigNode node)
        {
            Debug.Log("Updating Presence");
            presence.details = "KSP Testing";
            presence.state = "Loading a save...";

            this.UpdatePresence();
        }
    }
}
