   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Proyecto.PreciosyVentasProyecto.PreciosyVentas  5      :    4Proyecto.PreciosyVentas.ProductoYPrecioModificarPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Proyecto.PreciosyVentas     5        N� Title$"  ProductoYPrecioModificarPage��5	      .��5      �� ���#2d3250$��Stretch=�6"   $��Stretch=�6@   ._�5   
   �� $
��Auto=�6   $
��Auto=�6:   $��Stretch=�6_   $��Stretch=�6{   .��5      � $��Stretch=�6   $��Stretch=�61    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'   .+�5"      �� $��Cargar productos y precio��6   $��3��6=   $��	0,10,0,20q�6Q   $��0��6d   $��20(�6q   $
��Bold"�6   
������� �� Padding$ 0,0,0,0q�6�   $��Center=�6�   $	��Top=�6�   �� 5%      -   5         ��Name$ 	btnVolver��5%      $��Volver��6,      ButtonStyle#��[  6=   $��0��6b   $��0��6r   $��80��6   $��
10,10,0,20q�6�   $
��Left=�6�   $
��Bold"�6�   6�   �� 5(      $��Producto��6   $��1��6+   $��1��6;   $��Stretch=�6H   $��0,70,130,30q�6f   $��25��6{   $��90��6�   
�������$
��Bold"�6�   �� 5)      -   5         ��Name$ txtProductos��5)      $��1��60   $��1��6@   $��	0,100,0,0q�6M   $	��220��6`   $��25��6l     TextBoxStyle#��[ 6x   67  �� 5,      $��Precio��6   $��2��6)   $��1��66   
�������$��Stretch=�6Y   $��
0,0,130,30q�6w   $��25��6�   $��90��6�   $
��Bold"�6�   �� 5-      -   5        $ 	txtPrecio��5-      $��2��6-   $��1��6:   $��5,25,5,5q�6J   $	��220��6\   $��28��6h   #��[ 6t   6�   �� 50      -   5         ��Name$ contenedorComboBoxes��50      $��4��6;   $��3��6H   $��5,20,0,0q�6\   $��Stretch=�6n   $	��Top=�6�   �� 55      -   5        $ 	btnCargar��55      $��Cargar��6,   $��6��6=   $��1��6J   $	��150��6Z   $��40��6f   #��[  6r   6�   56      57      58      59      