﻿using Caveman.Setting;
using Newtonsoft.Json;

namespace Caveman.Specification
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WeaponSpecification : ISettings
    {
        //todo binding constr and data json
        public WeaponSpecification(string name, float speed, int timeRespawn, int countPickup, int timeThrow, int maxOnPlayer, int initialLying, int rotateParameter, Types type)
        {
            this.name = name;
            this.speed = speed;
            this.timeRespawn = timeRespawn;
            this.countPickup = countPickup;
            this.timeThrow = timeThrow;
            this.maxOnPlayer = maxOnPlayer;
            this.initialLying = initialLying;
            this.rotateParameter = rotateParameter;
            this.type = type;
        }

        [JsonProperty] private readonly string name;
        [JsonProperty] private readonly float speed;
        [JsonProperty] private readonly int timeRespawn;
        [JsonProperty] private readonly int countPickup;
        [JsonProperty] private readonly int timeThrow;
        [JsonProperty] private readonly int maxOnPlayer;
        [JsonProperty] private readonly int initialLying;
        [JsonProperty] private readonly int rotateParameter;
        [JsonProperty] private readonly Types type;

        public string Name
        {
            get { return name; }
        }

        public float Speed
        {
            get { return speed; }
        }

        public int TimeRespawn
        {
            get { return timeRespawn; }
        }

        public int TimeThrow
        {
            get { return timeThrow; }
        }

        public int MaxOnPLayer
        {
            get { return maxOnPlayer; }
        }

        public int InitialLying
        {
            get { return initialLying; }
        }

        public int RotateParameter
        {
            get { return rotateParameter; }
        }

        public int CountPickup
        {
            get { return countPickup; }
        }

        public Types Type
        {
            get { return type; }
        }

        public enum Types
        {
            Stone,
            Skull
        }
    }
}