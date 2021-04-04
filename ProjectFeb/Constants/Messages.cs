using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = "Urun eklendi";
        public static string ProductNameInvalid = "Urun ismi gecersiz";
        internal static string MaintenanceTime="bakımda";
        internal static string ProductsListed="listelendi";
        internal static SerializationInfo AuthorizationDenied;

        public static string stringAuthorizationDenied = "Gecersiz....";
        public static string UserRegistered = "hata.";
    }
}
