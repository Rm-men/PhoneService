﻿#pragma checksum "..\..\..\..\Admin\mainw_admin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E6EFDE1350CFF9DEDBF192C7C9238C2BB61B0C61"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF.Admin;


namespace WPF.Admin {
    
    
    /// <summary>
    /// mainw_admin
    /// </summary>
    public partial class mainw_admin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_services;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_product_list;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_orders;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_clients;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_employees;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_supplies;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Admin\mainw_admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame View_frame;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF;component/admin/mainw_admin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admin\mainw_admin.xaml"
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
            this.b_services = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_services.Click += new System.Windows.RoutedEventHandler(this.B_to_Services);
            
            #line default
            #line hidden
            return;
            case 2:
            this.b_product_list = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_product_list.Click += new System.Windows.RoutedEventHandler(this.B_to_Product);
            
            #line default
            #line hidden
            return;
            case 3:
            this.b_orders = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_orders.Click += new System.Windows.RoutedEventHandler(this.B_to_Orders);
            
            #line default
            #line hidden
            return;
            case 4:
            this.b_clients = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_clients.Click += new System.Windows.RoutedEventHandler(this.B_to_Clients);
            
            #line default
            #line hidden
            return;
            case 5:
            this.b_employees = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_employees.Click += new System.Windows.RoutedEventHandler(this.B_to_Employees);
            
            #line default
            #line hidden
            return;
            case 6:
            this.b_supplies = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Admin\mainw_admin.xaml"
            this.b_supplies.Click += new System.Windows.RoutedEventHandler(this.B_to_Supply);
            
            #line default
            #line hidden
            return;
            case 7:
            this.View_frame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

