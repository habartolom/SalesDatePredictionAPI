﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Infrastructure.Database.StoreProcedures {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StoreProcedures {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StoreProcedures() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("App.Infrastructure.Database.StoreProcedures.StoreProcedures", typeof(StoreProcedures).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_CreateOrderWithProduct @customerId, @employeeId, @orderDate, @requiredDate, @shipperId, @freight, @shipName, @shipAddress, @shipCity, @shipCountry, @productId, @unitPrice, @quantity, @discount, @orderId OUTPUT.
        /// </summary>
        internal static string AddOrderWithProduct {
            get {
                return ResourceManager.GetString("AddOrderWithProduct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetAllEmployees.
        /// </summary>
        internal static string GetAllEmployees {
            get {
                return ResourceManager.GetString("GetAllEmployees", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetAllProducts.
        /// </summary>
        internal static string GetAllProducts {
            get {
                return ResourceManager.GetString("GetAllProducts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetAllShippers.
        /// </summary>
        internal static string GetAllShippers {
            get {
                return ResourceManager.GetString("GetAllShippers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetNextPredictedOrder @customerName, @sortColumn, @orderingDirection, @pageNumber, @pageSize, @total OUTPUT.
        /// </summary>
        internal static string GetNextPredictedOrderStoreProcedure {
            get {
                return ResourceManager.GetString("GetNextPredictedOrderStoreProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetOrdersByCustomer @customerId, @sortColumn, @orderingDirection, @pageNumber, @pageSize, @total OUTPUT.
        /// </summary>
        internal static string GetOrdersByCustomer {
            get {
                return ResourceManager.GetString("GetOrdersByCustomer", resourceCulture);
            }
        }
    }
}
