   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Proyecto.VentasVistaBotonesProyecto.VentasVistaBotones  5      )    #Proyecto.VentasVistaBotones.Agregar   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Proyecto.VentasVistaBotones     5        N� Title$  Agregar��5	      .��5      �� ���#2d3250$��Stretch=�6"   $��Stretch=�6@   ._�5   
   �� $
��Auto=�6   $
��Auto=�6:   $��Stretch=�6_   $��Stretch=�6{   .��5      � $��Stretch=�6   $��Stretch=�61    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    � ColumnDefinitions 5       �� 5"      $��* �6'   �� 5#      $��* �6'   �� 5%      $��* �6'   .+�5(      �� $��Cargar venta��6   $��3��60   $��	0,10,0,20q�6D   $��0��6W   $��20(�6d   $
��Bold"�6r   
������� �� Padding$ 20,0,0,0q�6�   $��Center=�6�   $	��Top=�6�   �� 5+      -   5         ��Name$ 	btnVolver��5+      $��Volver��6,      ButtonStyle#��[  6=   $��0��6b   $��0��6r   $��80��6   $��
10,10,0,20q�6�   $
��Left=�6�   $
��Bold"�6�   6�   �� 5.      $��Producto��6   $��0��6+   $��1��6;   $��Stretch=�6H   $��
0,0,130,30q�6f   $��25��6z   $��90��6�   
�������$
��Bold"�6�   �� 5/      -   5         ��Name$ 	productos��5/      $��0��6.   $��1��6>   $��0,18,0,0q�6K   $	��220��6]   $��25��6i   6u   �� 52      $��Cantidad��6   $��1��6,   $��1��6<   
�������$��Stretch=�6\   $��
0,0,130,30q�6z   $��25��6�   $��90��6�   $
��Bold"�6�   �� 53      -   5        $ cantidad��53      $��1��6-   $��1��6=   $	��220��6J   $��25��6V   $��0,18,0,0q�6b   6t   �� 56      $
��Peso��6   $��2��6(   $��1��68   
�������$��Stretch=�6X   $��
0,0,130,30q�6v   $��25��6�   $��90��6�   $
��Bold"�6�   �� 57      -   5        $
 peso��57      $��2��6)   $��1��69   $	��220��6F   $��25��6R   $��0,18,0,0q�6^   �� 5:      -   5         ��Name$ lblTotal��5:      $��	Total: $0��6*   $��5��6>   $��2��6K   
�������$
��Left=�6n   $��0,0,0,0q�6�   $��40(�6�   $
��Bold"�6�   �� 5=      -   5         ��Name$ contenedorComboBoxes��5=      $��4��6;   $��3��6H   $��5,20,0,0q�6\   $��Stretch=�6n   $	��Top=�6�   �� 5@      -   5        $ btnMasAgregarCB��5@        ButtonStyle2#���  62   $��Right=�6Y   $��+��6u   $��0,10,15,150q�6�   $��6��6�   $��2��6�   $��25��6�   $��25��6�   6�   �� 5C      -   5        $��Cargar��5C      $��6��6*   $��1��67   $	��150��6G   $��40��6S   #��[  6_   6�   5D      5E      5F      5G      