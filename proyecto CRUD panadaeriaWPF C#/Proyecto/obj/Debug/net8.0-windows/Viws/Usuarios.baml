   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Proyecto.ViwsProyecto.Viws  5          Proyecto.Viws.Usuarios   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Proyecto.Viws     5      .��5	      �� ���#2d3250._�5
   
   � $��Stretch=�6   $��Stretch=�6+   .+�5      �� $��Center=�6   $	��Top=�66   $
��Wrap=�6N   $��Control de usuarios��6b   $��20(�6}   $��italic)�6�   $
��Bold"�6�   $��Italic$�6�   
�������6�   &   System.Windows.Controls.DataGrid  5      -   5           Name$  datagridusuarios��5         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M   $
��True��6d   $
��Auto=�6�   $	��150��6�      
IsReadOnly$
 True��6�   $��Center=�6	  $��Stretch=�6$  
������ $��0,0,0,0q�6[     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 DNI��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *dni+  5      $ Nombre��6)    69   �� *nombre+  5      $ Apellido��6)    6;   �� *
apellido+  5      $ Fecha de nacimiento��6)    6F   �� *fechaDeNacimiento+  5      $ Telefono��6)    6;   �� *
telefono+  5      $ Email��6)    68   �� *email+  5      $ 	Domicilio��6)    6<   �� *	domicilio+  5      $ 	Localidad��6)    6<   �� *	localidad+  5      $ 	Provincia��6)    6<   �� *	provincia+  5      $ Fecha de contratacion��6)    6H   �� *fechaDeContratacion+  5      $ Tipo de contrato��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6f    6C   �� *tipoDeContrato+6f     5      $ Rango��6)   $ 65 6R    68   �� *rango+6R   5      �� 5      $��Buscar por DNI:��6   $��Center=�6.   $��	0,80,80,0q�6K   $	��Top=�6^   
�������$
��Bold"�6�   �� 5      -   5         ��Name$ txtBuscarPorDni��5      $��Stretch=�60   $��	0,106,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6a   $	��Top=�6v   $	��172��6�      TextBoxStyle#��[  6�   6D  �� 5       -   5        
 ��Name$
 btnBuscarPorDni��5       $��Buscar��6.   $��Stretch=�6?   $	��Top=�6]     ButtonStyle#��[ 6u   $��240,107,0,0q�6�   $��23��6�   $��56��6�   $
��Bold"�6�   �� 5!      -   5        $
 btnAgregarUsuario��5!      $��Agregar��60   #��[ 6B   $��Stretch=�6g   $��
0,0,300,80q�6�   $��Bottom=�6�   $��45��6�   $	��128��6�   $
��Bold"�6�   6�   �� 5"      -   5        $
 btnModificarUsuario��5"      $��	Modificar��62   #��[ 6F   $��Stretch=�6k   $��
350,0,0,80q�6�   $��Bottom=�6�   $��45��6�   $	��128��6�   $
��Bold"�6�   6�    � 5#      -   5          �Name$ frameRegistrarUsuario��5#      $��1��63     � NavigationUIVisibility$ Hidden=�6C   6c   5%      5&      5'      