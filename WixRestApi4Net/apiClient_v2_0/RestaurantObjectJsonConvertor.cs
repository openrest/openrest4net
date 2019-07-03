﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters;

namespace wixrest.v2_0
{
    public class RestaurantObjectJsonConvertor : JsonConverter
    {
        private const string TYPE_PROPERTY = "type";

        public override bool CanConvert(Type objectType)
        {
            return typeof(WixRestObject).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
                object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            Type targetType = GetType(jObject);
            object target = Activator.CreateInstance(targetType);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            JsonSerializer.Create(new JsonSerializerSettings()).Serialize(writer, value);
        }

        private static Type GetType(JObject jObject)
        {
            string typeStr = (string) jObject.Property(TYPE_PROPERTY);
            if (typeStr == null)
            {
                throw new ApplicationException("Missing type property");
            }

            switch (typeStr)
            {
                case Restaurant.TYPE:
                    return typeof(Restaurant);
                case Chain.TYPE:
                    return typeof(Chain);
                case Portal.TYPE:
                    return typeof(Portal);
                case Distributor.TYPE:
                    return typeof(Distributor);
                case RestaurantFullInfo.TYPE:
                    return typeof(RestaurantFullInfo);
                case DeliveryDispatchInfo.TYPE:
                    return typeof(DeliveryDispatchInfo);
                case PickupDispatchInfo.TYPE:
                    return typeof(PickupDispatchInfo);
            }

            throw new ApplicationException(String.Format("Unknown object type: {0}", typeStr));
        }
    }
}
