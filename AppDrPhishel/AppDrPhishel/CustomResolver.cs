using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Newtonsoft.Json;

namespace AppDrPhishel
{

    /**
     * Clase para desearilzar de buena manera el Json de los historiales
     * */
    class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
                                            MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(ClaseHistorial) &&
                property.PropertyName == "Offender")
            {
                property.ShouldSerialize = instanceOfProblematic => false;
            }

            return property;
        }

    }
}