﻿#pragma checksum "..\..\medecin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C38944F6B7A8E044862C5C9524F6DF73BE766F84F9EEC4063042F0FC15E26F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using nlh;


namespace nlh {
    
    
    /// <summary>
    /// medecin
    /// </summary>
    public partial class medecin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nss;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNSS;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRechercher;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDonnerConge;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQuitter;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrenom;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\medecin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNom;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/nlh;component/medecin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\medecin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nss = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtNSS = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnRechercher = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\medecin.xaml"
            this.btnRechercher.Click += new System.Windows.RoutedEventHandler(this.btnRechercher_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDonnerConge = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\medecin.xaml"
            this.btnDonnerConge.Click += new System.Windows.RoutedEventHandler(this.btnDonnerConge_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnQuitter = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\medecin.xaml"
            this.btnQuitter.Click += new System.Windows.RoutedEventHandler(this.btnQuitter_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtPrenom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtNom = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
