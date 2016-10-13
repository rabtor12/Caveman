﻿using Caveman.Pools;
using Caveman.Setting;
using Caveman.Utils;
using UnityEngine;

namespace Caveman.Players
{
    public class PlayerModelAi : PlayerModelClient
    {
        private Vector2 targetPosition;

        protected void Start()
        {
            GetComponent<SpriteRenderer>().color = new Color32((byte) rand.Next(255), (byte) rand.Next(255),
                (byte) rand.Next(255), 255);
        }

        public void Update()
        {
            if (Vector2.SqrMagnitude(moveUnit) > UnityExtensions.ThresholdPosition &&
                Vector2.SqrMagnitude((Vector2)transform.position - targetPosition) > UnityExtensions.ThresholdPosition)
            {
                Move();
            }
            else
            {
                if (IsEnoughStrength(WeaponConfig.Weight))
                {
                    var closestPosition = FindClosestLyingWeapon;
                    targetPosition = closestPosition == Vector2.zero ? RandomPosition : closestPosition;
                    CalculateMoveUnit(targetPosition);
                }
                else
                {
                    targetPosition = RandomPosition;
                    CalculateMoveUnit(targetPosition);
                }
            }
        }
     
        private Vector2 FindClosestLyingWeapon
        {
            get
            {
                var minDistance = (float)Settings.HeightMap*Settings.WidthMap;
                var nearPosition = Vector2.zero;

                foreach (Transform weapon in PoolsManager.instance.containerStones)
                {
                    if (!weapon.gameObject.activeSelf) continue;
                    var childDistance = Vector2.SqrMagnitude(weapon.position - transform.position);
                    if (minDistance > childDistance)
                    {
                        minDistance = childDistance;
                        nearPosition = weapon.position;
                    }
                }
                return nearPosition;
            }
        }

        private Vector2 RandomPosition
        {
            get { return new Vector2(rand.Next(Settings.WidthMap), rand.Next(Settings.HeightMap)); }
        }
    }
}

