﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A573529C8B49EAC38DCBDDCC7B95877EF374DA51"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.Sharp;
using Proyecto;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Proyecto {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimizar;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDni;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDNI;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblContraseña;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtContraseñaVisible;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtContraseña;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.Sharp.IconImage ojoContraseña;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIngresar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\MainWindow.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnMinimizar = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.btnMinimizar.Click += new System.Windows.RoutedEventHandler(this.btnMinimizar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblDni = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtDNI = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.txtDNI.LostFocus += new System.Windows.RoutedEventHandler(this.txtDNI_LostFocus);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.txtDNI.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtDNI_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.txtDNI.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtDNI_TextChanged);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.txtDNI.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtDNI_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblContraseña = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtContraseñaVisible = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.txtContraseñaVisible.LostFocus += new System.Windows.RoutedEventHandler(this.txtContraseñaVisible_LostFocus);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.txtContraseñaVisible.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtContraseñaVisible_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtContraseña = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.txtContraseña.LostFocus += new System.Windows.RoutedEventHandler(this.txtContraseña_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ojoContraseña = ((FontAwesome.Sharp.IconImage)(target));
            
            #line 42 "..\..\..\MainWindow.xaml"
            this.ojoContraseña.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.EyeIcon_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnIngresar = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\MainWindow.xaml"
            this.btnIngresar.Click += new System.Windows.RoutedEventHandler(this.btnIngresar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

