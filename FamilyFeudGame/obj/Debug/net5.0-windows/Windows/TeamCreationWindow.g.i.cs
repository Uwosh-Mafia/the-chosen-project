// Updated by XamlIntelliSenseFileGenerator 11/8/2021 11:56:28 AM
#pragma checksum "..\..\..\..\Windows\TeamCreationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72A248D4E48F8C24DDD92FB237DA3798A3A2201D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FamilyFeudGame;
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


namespace FamilyFeudGame
{


    /// <summary>
    /// TeamCreationWindow
    /// </summary>
    public partial class TeamCreationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 13 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTeam1;

#line default
#line hidden


#line 14 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTeam2;

#line default
#line hidden


#line 16 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbTeam1;

#line default
#line hidden


#line 17 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbTeam2;

#line default
#line hidden


#line 18 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContinue;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]

        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FamilyFeudGame;V1.0.0.0;component/windows/teamcreationwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Windows\TeamCreationWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.lblTeamCreation = ((System.Windows.Controls.Label)(target));
                    return;
                case 2:
                    this.lblTeam1 = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.lblTeam2 = ((System.Windows.Controls.Label)(target));
                    return;
                case 4:
                    this.txtTeam1 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.txtTeam2 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.lblSelectTeam = ((System.Windows.Controls.Label)(target));
                    return;
                case 7:
                    this.rbTeam1 = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 8:
                    this.rbTeam2 = ((System.Windows.Controls.RadioButton)(target));
                    return;
                case 9:
                    this.btnContinue = ((System.Windows.Controls.Button)(target));

#line 18 "..\..\..\..\Windows\TeamCreationWindow.xaml"
                    this.btnContinue.Click += new System.Windows.RoutedEventHandler(this.BtnContinue_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock lblTeamCreation;
    }
}

