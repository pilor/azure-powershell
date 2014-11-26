﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Dns.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Azure.Commands.Dns.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Cannot add a record of type {0} to a record set of type {1}. The types must match..
        /// </summary>
        internal static string AddRecordTypeMismatch {
            get {
                return ResourceManager.GetString("AddRecordTypeMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to overwrite any existing record set &apos;{0}&apos; of type {1} in zone &apos;{2}&apos;? You will lose any existing records in that record set..
        /// </summary>
        internal static string ConfirmOverwriteRecord {
            get {
                return ResourceManager.GetString("ConfirmOverwriteRecord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to permanently remove record set &apos;{0}&apos; from zone &apos;{1}&apos;?.
        /// </summary>
        internal static string ConfirmRemoveRecordSet {
            get {
                return ResourceManager.GetString("ConfirmRemoveRecordSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to permanently remove zone &apos;{0}&apos;?.
        /// </summary>
        internal static string ConfirmRemoveZone {
            get {
                return ResourceManager.GetString("ConfirmRemoveZone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating empty record set ....
        /// </summary>
        internal static string CreatingEmptyRecordSet {
            get {
                return ResourceManager.GetString("CreatingEmptyRecordSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ETag property of the {0} object is empty or &quot;*&quot;. In order to perform this operation with optimistic concurrency checks, please set the Etag property (you may need to Get the {0} first). In order to perform the operation without optimistic concurrency checks, please specify the -IgnoreEtag switch. .
        /// </summary>
        internal static string EtagNotSpecified {
            get {
                return ResourceManager.GetString("EtagNotSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There already exists a CNAME record in this set. A CNAME record set can only contain one record..
        /// </summary>
        internal static string MultipleCnames {
            get {
                return ResourceManager.GetString("MultipleCnames", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot remove a record of type {0} from a record set of type {1}. The types must match..
        /// </summary>
        internal static string RemoveRecordTypeMismatch {
            get {
                return ResourceManager.GetString("RemoveRecordTypeMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing record set ....
        /// </summary>
        internal static string RemovingRecordSetMessage {
            get {
                return ResourceManager.GetString("RemovingRecordSetMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing zone ....
        /// </summary>
        internal static string RemovingZoneMessage {
            get {
                return ResourceManager.GetString("RemovingZoneMessage", resourceCulture);
            }
        }
    }
}
