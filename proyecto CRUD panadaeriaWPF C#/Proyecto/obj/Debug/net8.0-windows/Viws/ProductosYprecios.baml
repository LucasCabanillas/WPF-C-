   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Proyecto.ViwsProyecto.Viws  5      %    Proyecto.Viws.ProductosYprecios   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Proyecto.Viws     5        N� Title$  ProductosYprecios��5	      .��5      �� ���#2d3250._�5   
   � $��Stretch=�6   $��Stretch=�6+   .+�5      �� $��Center=�6   $	��Top=�66   $
��Wrap=�6N   $$��Control de productos y precios��6b   $��20(�6�   $��italic)�6�   $
��Bold"�6�   $��Italic$�6�   
�������6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ datagriproductosyprecios��5         AutoGenerateColumns$ False��69      CanUserAddRows$ False��6U   $
��True��6l   $
��Auto=�6�   $	��200��6�   $��	0,0,0,100q�6�      
IsReadOnly$
 True��6�   $��Center=�6$  $��Center=�6?  
������ $��0,0,0,0q�6u     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Producto��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
producto+6X     5      $ Precio��6)   $ 60 6T    69   �� *precio+6T   5      �� 5      -   5        	 ��Name$	 btnAgregarProducto��5      $��Agregar��61      ButtonStyle#��[  6C   $
��Left=�6h   $��
220,0,0,80q�6�   $��Bottom=�6�   $��45��6�   $	��128��6�   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5      -   5        $	 btnModificarProducto��5      $��	Modificar��63   #��[  6G   $��Center=�6l   $��0,0,0,80q�6�   $��Bottom=�6�   $��45��6�   $	��128��6�   $
��Bold"�6�   6�   �� 5      -   5        $	 btnEliminarProducto��5      $��Eliminar��62   #��[  6E   $��Right=�6j   $��
0,0,100,80q�6�   $��Bottom=�6�   $��45��6�   $	��128��6�   $
��Bold"�6�   $y�	Collapsed=�6�    � 5      -   5        
  �Name$
 frameRegistrarProducto��5      $��1��64     � NavigationUIVisibility$ Hidden=�6D   6d   5      5      5      