﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterFriendshipTracker.Infra {
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
    internal class TaskXml {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TaskXml() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TwitterFriendshipTracker.Infra.TaskXml", typeof(TaskXml).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-16&quot;?&gt;
        ///&lt;Task version=&quot;1.2&quot; xmlns=&quot;http://schemas.microsoft.com/windows/2004/02/mit/task&quot;&gt;
        ///  &lt;RegistrationInfo&gt;
        ///    &lt;Date&gt;2011-07-21T16:20:03.9553849&lt;/Date&gt;
        ///    &lt;Author&gt;Juan Lopes&lt;/Author&gt;
        ///  &lt;/RegistrationInfo&gt;
        ///  &lt;Triggers&gt;
        ///    &lt;CalendarTrigger&gt;
        ///      &lt;StartBoundary&gt;2011-07-21T22:00:00&lt;/StartBoundary&gt;
        ///      &lt;Enabled&gt;true&lt;/Enabled&gt;
        ///      &lt;RandomDelay&gt;PT1H&lt;/RandomDelay&gt;
        ///      &lt;ScheduleByDay&gt;
        ///        &lt;DaysInterval&gt;1&lt;/DaysInterval&gt;
        ///      &lt;/ScheduleByDay&gt;
        ///    &lt;/Calen [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Daily {
            get {
                return ResourceManager.GetString("Daily", resourceCulture);
            }
        }
    }
}
