// Updated by XamlIntelliSenseFileGenerator 15.06.2022 12:00:24
#pragma checksum "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17AD1B773329C377A131B5B481CE719EA0606B9E"
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
using WPF.Admin.Frames;


namespace WPF.Admin.Frames.Employees
{


    /// <summary>
    /// F_emlpoyees
    /// </summary>
    public partial class F_emlpoyees : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 18 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_emp_list;

#line default
#line hidden


#line 19 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_emp_insert;

#line default
#line hidden


#line 21 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame spase;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF;V1.0.0.0;component/admin/frames/employees/f_emlpoyees.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.b_emp_list = ((System.Windows.Controls.Button)(target));

#line 18 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
                    this.b_emp_list.Click += new System.Windows.RoutedEventHandler(this.Bto_list);

#line default
#line hidden
                    return;
                case 2:
                    this.b_emp_insert = ((System.Windows.Controls.Button)(target));

#line 19 "..\..\..\..\..\..\Admin\Frames\Employees\F_emlpoyees.xaml"
                    this.b_emp_insert.Click += new System.Windows.RoutedEventHandler(this.Bto_add);

#line default
#line hidden
                    return;
                case 3:
                    this.spase = ((System.Windows.Controls.Frame)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
