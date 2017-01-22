﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Caveman.Setting
{
    // This for developer settings, when game on build, possible changed parameters
    public class ForceSettings : MonoBehaviour
    {
        public InputField roundTime;

        public InputField weaponTimeRespawn;
        public InputField weaponInitialCount;
        public InputField weaponSpeed;
        public InputField weaponCooldown;
        public InputField weaponCountItems;
        public InputField weaponWeight;

        public InputField bonusSpeedMaxCount;
        public InputField bonusSpeedTimeRespawn;
       
        public InputField botsCount;
        public InputField playerSpeed;

        public InputField serverPingTime;
        public InputField ip_server;
        public Toggle disableSendMove;

        public void Start()
        {
            //roundTime.text = Settings.RoundTime.ToString();
            //botsCount.text = Settings.BotsCount.ToString();
            //playerSpeed.text = Settings.PlayerSpeed.ToString();
            //weaponSpeed.text = Settings.StoneSpeed.ToString();
            //weaponCooldown.text = Settings.WeaponTimerThrow.ToString();
            //weaponInitialCount.text = Settings.WeaponInitialLying.ToString();
            //weaponTimeRespawn.text = Settings.WeaponTimeRespawn.ToString();
            //weaponCountItems.text = Settings.WeaponCountPickup.ToString();
            //bonusSpeedMaxCount.text = Settings.BonusSpeedMaxCount.ToString();
            //bonusSpeedTimeRespawn.text = Settings.BonusTimeRespawn.ToString();
            //weaponWeight.text = Settings.WeaponsMaxOnPlayer.ToString();
            serverPingTime.text = Settings.ServerPingTime.ToString();    

            ip_server.text = PlayerPrefs.HasKey(Settings.KeyIpServer) ? PlayerPrefs.GetString(Settings.KeyIpServer) : Settings.IP_SERVER;

            //roundTime.onEndEdit.AddListener(delegate
            //{
            //    Settings.RoundTime = Convert.ToInt32(roundTime.text);
            //});
            botsCount.onEndEdit.AddListener(delegate
            {
              //  Settings.BotsCount = Convert.ToInt32(botsCount.text);
            });
            //playerSpeed.onEndEdit.AddListener(delegate
            //{
            //    Settings.PlayerSpeed = Convert.ToInt32(playerSpeed.text);
            //});
            //weaponSpeed.onEndEdit.AddListener(delegate
            //{
            //    Settings.StoneSpeed = Convert.ToInt32(weaponSpeed.text);
            //});
            //weaponTimeRespawn.onEndEdit.AddListener(delegate
            //{
            //    Settings.WeaponTimeRespawn = Convert.ToInt32(weaponTimeRespawn.text);
            //});
            //weaponCooldown.onEndEdit.AddListener(delegate
            //{
            //    Settings.WeaponTimerThrow = Convert.ToInt32(weaponCooldown.text);
            //});
            //weaponInitialCount.onEndEdit.AddListener(delegate
            //{
            //    Settings.WeaponInitialLying = Convert.ToInt32(weaponInitialCount.text);
            //});
            //weaponCountItems.onEndEdit.AddListener(delegate
            //{
            //    Settings.WeaponCountPickup = Convert.ToInt32(weaponCountItems.text);
            //});
            //weaponWeight.onEndEdit.AddListener(delegate
            //{
            //    Settings.WeaponsMaxOnPlayer = Convert.ToInt32(weaponWeight.text);
            //});
            bonusSpeedMaxCount.onEndEdit.AddListener(delegate
            {
                //Settings.BonusSpeedMaxCount = Convert.ToInt32(bonusSpeedMaxCount.text);
            });
            bonusSpeedTimeRespawn.onEndEdit.AddListener(delegate
            {
                //Settings.BonusTimeRespawn = Convert.ToInt32(bonusSpeedTimeRespawn.text);
            });
            serverPingTime.onEndEdit.AddListener(delegate
            {
                Settings.ServerPingTime = Convert.ToInt32(serverPingTime.text);
            });
            ip_server.onEndEdit.AddListener(delegate
            {
                Settings.IP_SERVER = Convert.ToString(ip_server.text);
                PlayerPrefs.SetString(Settings.KeyIpServer, Convert.ToString(ip_server.text));
            });

            disableSendMove.onValueChanged.AddListener(delegate
            {
                if (disableSendMove.isOn)
                {
                    Settings.DisableSendMove = true;
                }
                else {
                    Settings.DisableSendMove = false;
                }
            });
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}