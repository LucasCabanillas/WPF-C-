﻿#pragma checksum "..\..\..\..\Viws\ProductosYprecios.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65DDB601EA1F106A685199D272051E152A2870B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto.Viws;
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


namespace Proyecto.Viws {
    
    
    /// <summary>
    /// ProductosYprecios
    /// </summary>
    public partial class ProductosYprecios : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Viws\ProductosYprecios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagriproductosyprecios;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Viws\ProductosYprecios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarProducto;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Viws\ProductosYprecios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarProducto;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Viws\ProductosYprecios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarProducto;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Viws\ProductosYprecios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frameRegistrarProducto;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto;component/viws/productosyprecios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Viws\ProductosYprecios.xaml"
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
            this.datagriproductosyprecios = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnAgregarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Viws\ProductosYprecios.xaml"
            this.btnAgregarProducto.Click += new System.Windows.RoutedEventHandler(this.btnAgregarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnModificarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Viws\ProductosYprecios.xaml"
            this.btnModificarProducto.Click += new System.Windows.RoutedEventHandler(this.btnModificarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnEliminarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\Viws\ProductosYprecios.xaml"
            this.btnEliminarProducto.Click += new System.Windows.RoutedEventHandler(this.btnEliminarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.frameRegistrarProducto = ((System.Windows.Controls.Frame)(target));
            
            #line 25 "..\..\..\..\Viws\ProductosYprecios.xaml"
            this.frameRegistrarProducto.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.frameRegistrarProducto_Navigated);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

