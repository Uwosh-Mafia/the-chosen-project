﻿#pragma checksum "..\..\..\..\Windows\TeamCreationWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B50B879F2521AF1216E2BF4B369F64C85F37EC98"
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


namespace FamilyFeudGame {
    
    
    /// <summary>
    /// TeamCreationWindow
    /// </summary>
    public partial class TeamCreationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTeam1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTeam2;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTeam1;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Windows\TeamCreationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTeam2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnTeam1 = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Windows\TeamCreationWindow.xaml"
            this.btnTeam1.Click += new System.Windows.RoutedEventHandler(this.BtnTeam1_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnTeam2 = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\Windows\TeamCreationWindow.xaml"
            this.btnTeam2.Click += new System.Windows.RoutedEventHandler(this.BtnTeam2_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTeam1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtTeam2 = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

