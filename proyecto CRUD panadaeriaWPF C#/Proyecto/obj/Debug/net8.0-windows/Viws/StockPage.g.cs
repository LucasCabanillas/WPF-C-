﻿#pragma checksum "..\..\..\..\Viws\StockPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9D195A9CFBAEE134FE5E55B8A48703D66B378E9F"
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
    /// StockPage
    /// </summary>
    public partial class StockPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Viws\StockPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridStock;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Viws\StockPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarProducto;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Viws\StockPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarProducto;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Viws\StockPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarProducto;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Viws\StockPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frameStock;
        
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
            System.Uri resourceLocater = new System.Uri("/Proyecto;component/viws/stockpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Viws\StockPage.xaml"
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
            this.dataGridStock = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnAgregarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Viws\StockPage.xaml"
            this.btnAgregarProducto.Click += new System.Windows.RoutedEventHandler(this.AgregarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnModificarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Viws\StockPage.xaml"
            this.btnModificarProducto.Click += new System.Windows.RoutedEventHandler(this.ActualizarStock_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnEliminarProducto = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Viws\StockPage.xaml"
            this.btnEliminarProducto.Click += new System.Windows.RoutedEventHandler(this.EliminarProducto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.frameStock = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

