   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProyectoProyecto  5   	       Proyecto.Principal   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Proyecto     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � WindowState$  	Maximized=�5
   	   ���#2d3250 � Title$* $Delicias la Familia - Versión 1.0.1��5   	   $	��452��65   $	��850��6B    � WindowStartupLocation$ CenterScreen=�6N    � 	Resources 5      ��%    5      .��5      �  � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ barraDeNavegacion��5   +   $	��170 �6   6+   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Stretch=�6!   $��Stretch=�6?   
���   �$��1q�6o   ��5      �� 5      .��5      �  � Color$ #1E2341��6#   5      ._�5#      �� .+�5%      �� $��60��6   $	��167��6)   $��0,0,0,0q�65    �� Orientation$ 
Horizontal=�6F   $��Stretch=�6_   $��Stretch=�6}   .+�5&      �� -   5         ��Name$
 logo��5&      $��60��6*   $��60��66   $��Source/logo_proyecto.png��6A   $��50,0,0,0q�6c   $y�Visible=�6u   !  FontAwesome.Sharp.IconImage  5'      -   5        	  Name$	 iconBars��5'   #   �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]
   Icon$

 bars=�65    � Cursor$
 Hand��6A   $
��Left=�6O   $��Center=�6j   $��35,0,0,0q�6�   $��20��6�   6�   5(      	� 5+      -   5         	�Name$ 	btnVentas��5+         
menuButton#��[  61   $��Stretch=�6U   $��50��6s   .��5,      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�5-        $
 cartshopping=�6'     	menuIcono#��[ 6;   �� 5.      -   5         ��Name$ 	txtVentas��5.   3   $�� Ventas��6$   $��Center=�6F   $��Stretch=�6a   5/      50      	� 52      -   5        $ 
btnPedidos��52      #��[  62   $��Stretch=�6V   $��50��6t   .��53      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�54        $
 	clipboard=�6'   #��[ 68   �� 55      -   5        $ 
txtPedidos��55   4   $�� Pedidos��6$   $��Center=�6H   $��Stretch=�6c   56      57      	� 59      -   5        $ btnStock��59      #��[  60   $��Stretch=�6T   $��50��6r   .��5:      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�5;        $
 boxesstacked=�6'   #��[ 6;   �� 5<      -	   5        $ txtStock��5<   2   $�� Stock��6$   $��Center=�6D   $��Stretch=�6_   5=      5>      	� 5@      -
   5        $ btnPdf��5@      #��[  6.   $��Stretch=�6R   $��50��6p   .��5A      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�5B        $
 FilePdf=�6'   #��[ 66   �� 5C      -   5        $ txtEstadistica��5C   8   $�� Pedidos pdf��6$   $��Center=�6P   $��Stretch=�6k   5D      5E      	� 5G      -   5        $ btnPersonal��5G      #��[  63   $��Stretch=�6W   $��50��6u   .��5H      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�5I        $
 users=�6'   #��[ 64   �� 5J      -   5        $ txtPersonal��5J   5   $��	 Personal��6$   $��Center=�6J   $��Stretch=�6e   5K      5L      	� 5O      -   5        $ 
btnPrecios��5O      #��[  62   $��Stretch=�6V   $��50��6t   .��5P      �� $ 
Horizontal=�6!   $��Stretch=�6:   .+�5Q        $
 CashRegister=�6'   #��[ 6;   �� 5R      -   5        $ 
txtPrecios��5R   @   $�� Productos y precios��6$   $��Center=�6T   $��Stretch=�6o   5S      5T      �� 5W      -   5         ��Name$ usuarioOperando��5W   w   $��Bottom=�6   $	��100��68   $��Center=�6E   $y�Visible=�6b   .+�5X        $
 
circleuser=�6#   $��50��65   $��50��6@   $��0,10,0,0q�6L   �� 5Y      -   5        $ nombreDelPersonal��5Y       $	��Top=�6<   $��Center=�6T   $��0,5,0,0q�6q   
�������6�   5Z      5[      5\      �� 5_   
   $��1��6   $��Center=�6%   $��Center=�6@   .+�5a      �� -   5         ��Name$ 	labelHora��5a      $�� ��6'   
�������$��40(�5b      $
��Bold"�5c      $��Italic$�6   $��Center=�5d      $��Center=�5e      $��0q�5f      $��0,0,0,10q�6   �� 5i      -   5        $ 
labelFecha��5i      $�� ��6(   
�������$��24(�5j      $��Center=�5k      $��Center=�5l      $��0q�5m      5n       � 5o   
   -   5          �Name$ miFrame��5o      $��1��6!     � NavigationUIVisibility$ Hidden=�61   6Q   5p      5q      