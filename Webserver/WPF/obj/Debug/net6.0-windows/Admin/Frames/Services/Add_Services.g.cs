﻿#pragma checksum "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4623FC249635253B0901B65B172BF0BA0F02F695"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPF.Admin.Frames.Services;


namespace WPF.Admin.Frames.Services {
    
    
    /// <summary>
    /// Add_Services
    /// </summary>
    public partial class Add_Services : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Name;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Type;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Garranty_id;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_descr;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Price;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF;V1.0.0.0;component/admin/frames/services/add_services.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TB_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TB_Type = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TB_Garranty_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TB_descr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TB_Price = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
            this.TB_Price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.InputOnlyNumbs);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\..\Admin\Frames\Services\Add_Services.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.B_add);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
