﻿#pragma checksum "..\..\..\..\VentasVistaBotones\Agregar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E91BE85BBD2D7D699674F9BBAB6FE0B011EFC76"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto.VentasVistaBotones;
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


namespace Proyecto.VentasVistaBotones {
    
    
    /// <summary>
    /// Agregar
    /// </summary>
    public partial class Agregar : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVolver;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox productos;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cantidad;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox peso;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel contenedorComboBoxes;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMasAgregarCB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto;component/ventasvistabotones/agregar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnVolver = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            this.btnVolver.Click += new System.Windows.RoutedEventHandler(this.btnVolver_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.productos = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            this.productos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.productos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cantidad = ((System.Windows.Controls.ComboBox)(target));
            
            #line 51 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            this.cantidad.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cantidad_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.peso = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.contenedorComboBoxes = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.btnMasAgregarCB = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            this.btnMasAgregarCB.Click += new System.Windows.RoutedEventHandler(this.btnMasAgregarCB_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 67 "..\..\..\..\VentasVistaBotones\Agregar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

