   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Proyecto.ViwsProyecto.Viws  5          Proyecto.Viws.Pedidos   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Proyecto.Viws     5        N� Title$  Pedidos��5	      .��5      �� ���#2d3250._�5   
   � $��Stretch=�6   $��Stretch=�6+   .+�5      �� $��Pedidos��6   $��Center=�6&   $��20(�6C   $��italic)�6Q   $
��Bold"�6e   $	��Top=�6w   
�������6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ datagridusuarios��5         CanUserAddRows$ False��61      AutoGenerateColumns$ False��6H      
IsReadOnly$
 True��6e   $
��True��6w   $
��Auto=�6�   $	��150��6�   $��Center=�6  $��Center=�6#  
������ $��0,0,0,0q�6Y     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	idpedidos+  5      $ 	Teléfono��6)    6;   �� *
telefono+  5      $ Fecha del pedido��6)    6C   �� *fechaRealizoPedido+  5      $ Fecha de Plazo��6)    6A   �� *fechaDePlazo+  5      $ Pedido con Envío��6)    6C   �� *pedidoConEnvio+  5      $ Empleado que lo Gestionó��6)    6K   �� *empleadoQueLoGestiono+  5      $ Total��6)    68   �� *total+5      �� 5      -   5         ��Name$ 	btnCargar��5      $��Agregar��6(      ButtonStyle#��[  6:   $��45��6`   $	��128��6l   $
��Left=�6x   $��
100,0,0,50q�6�   $��Bottom=�6�   $
��Bold"�6�   6�   �� 5      -   5        $ btnModificar��5      $��	Modificar��6+   #��[  6?   $��45��6d   $	��128��6p   $��Center=�6|   $��
0,337,0,50q�6�   $��Bottom=�6�   $
��Bold"�6�   6�   �� 5      -   5        $ btnEliminar��5      $��Elimnar��6*   #��[  6<   $��45��6b   $	��128��6n   $��Right=�6z   $��
0,0,100,50q�6�   $��Bottom=�6�   $
��Bold"�6�   6�    � 5!      -   5        	  �Name$	 framePedidos��5!      6O   5"      5#      5$      