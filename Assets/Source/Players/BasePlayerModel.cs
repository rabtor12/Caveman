﻿using System;
using System.Collections;
using System.Collections.Generic;
using Caveman.Setting;
using Caveman.Utils;
using Caveman.Weapons;
using UnityEngine;
using Random = System.Random;

namespace Caveman.Players
{
    public class BasePlayerModel : MonoBehaviour
    {
        public Action<Player> Respawn;
        public Action<Vector2> Death;
        public Action<Player, Vector2, Vector2> ThrowStone;

        protected Player player;
        protected Vector2 delta;
        protected Animator animator;
        protected Vector2 target;
        protected Random random;

        private float timeCurrentThrow;

        public virtual void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        public void Init(Player player, Vector2 positionStart, Random random)
        {
            name = player.name;
            this.player = player;
            this.random = random;
            transform.position = positionStart;
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (Time.time < 1) return;
            var weapon = other.gameObject.GetComponent<BaseWeaponModel>();
            if (weapon != null)
            {
                if (weapon.owner == null)
                {
                    player.weapons++;
                    animator.SetTrigger(Settings.AnimPickup);
                    weapon.Destroy();
                }
                else
                {
                    if (weapon.owner != player)
                    {
                        weapon.owner.kills++;
                        player.deaths++;
                        weapon.Destroy();
                        Death(transform.position);
                        Respawn(player);
                        // todo use Object pool pattern
                        Destroy(gameObject);
                    }
                }
            }
        }

        public void Throw()
        {
            ThrowStone(player, transform.position, FindClosest(transform.parent));
            player.weapons--;
        }

        protected void ThrowStoneOnTimer()
        {
            timeCurrentThrow = player.countRespawnThrow * Settings.TimeThrowStone - Time.timeSinceLevelLoad;
            if (timeCurrentThrow-- >= 0) return;
            player.countRespawnThrow++;

            if (player.weapons > 0)
            {
                animator.SetTrigger(Settings.AnimThrowF);
            }
            timeCurrentThrow = Settings.TimeThrowStone;
        }

        

        protected bool MoveStop()
        {
            if (delta.magnitude > UnityExtensions.ThresholdPosition &&
                Vector2.SqrMagnitude((Vector2) transform.position - target) < UnityExtensions.ThresholdPosition)
            {
                animator.SetFloat(delta.y > 0 ? Settings.AnimRunB : Settings.AnimRunF, 0);
                delta = Vector2.zero;
                return true;
            }
            return false;
        }

        protected void Move()
        {
            if (delta.magnitude > UnityExtensions.ThresholdPosition)
            {
                 var position = new Vector3(transform.position.x + delta.x * Time.deltaTime,
                transform.position.y + delta.y * Time.deltaTime);
                transform.position = position;
            }
        }

        protected Vector2 FindClosest(Transform container)
        {
            float minDistance = 0;
            var nearPosition = Vector2.zero;
            // todo use array instead ienumerable
            // todo после того как засуну в пул игроков. кидать камни в ближайшего, идти к ближайшему 
            foreach (Transform child in container)
            {
                if (!child.gameObject.activeSelf) continue;
				var childModelPlayer = child.gameObject.GetComponent<BasePlayerModel>();
                if (childModelPlayer != this)
                {
                    if (minDistance < 0.1f)
                    {
                        minDistance = Vector2.Distance(child.position, transform.position);
                        nearPosition = child.position;
				    	//break;
                    }
                    else
                    {
                        var childDistance = Vector2.Distance(child.position, transform.position);
                        if (minDistance > childDistance)
                        {
                            minDistance = childDistance;
                            nearPosition = child.position;
                        }
                    }
                }
            }
            return nearPosition;
        }
    }
}

