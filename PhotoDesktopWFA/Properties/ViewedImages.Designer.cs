﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schalken.PhotoDesktop.WFA.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class ViewedImages : global::System.Configuration.ApplicationSettingsBase {
        
        private static ViewedImages defaultInstance = ((ViewedImages)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ViewedImages())));
        
        public static ViewedImages Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.NameValueCollection Images {
            get {
                return ((global::System.Collections.Specialized.NameValueCollection)(this["Images"]));
            }
            set {
                this["Images"] = value;
            }
        }
    }
}
