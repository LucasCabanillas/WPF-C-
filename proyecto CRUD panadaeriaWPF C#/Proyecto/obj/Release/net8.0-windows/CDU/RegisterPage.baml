   M S B A M L   `   `   `  ����   Proyecto    Proyecto.CDU.RegisterPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    N� Title$  RegisterPage��.���� ���#2d3250$��Stretch=�$��Stretch=�._��� $
��Auto=�$
��Auto=�$��Stretch=�$��Stretch=�.��� $��10q�$��Stretch=� � RowDefinitions �� $
��auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� -   $��Volver��$
��Left=�$��80��$��
10,10,0,20q�$��0��$��0��   ButtonStyle#��[  $
��Bold"��� $��Carga de personal��
�������$��24(�$
��Bold"�$��Center=�$	��Top=�$��0��$��3��$��	0,10,0,20q��� $��Nombre��
�������$��1��$��0��$��Stretch=�$��
0,0,130,30q�$��25��$��90��$
��Bold"��� -    ��Name$ 	txtNombre��$��1��$��0��$��5,25,5,5q�$	��220��  TextBoxStyle#��[ $��28���� $��Apellido��
�������$��2��$��0��$��Stretch=�$��
0,0,130,30q�$��25��$��90��$
��Bold"��� -   $ txtApellido��$��2��$��0��$��5,25,5,5q�$	��220��#��[ $��28���� $	��DNI��
�������$��3��$��0��$��Stretch=�$��
0,0,160,30q�$��25��$��60��$
��Bold"��� -   $ txtDNI��$��3��$��0��$��5,25,5,5q�$	��220��#��[ �� $��Fecha de Nacimiento��
�������$��4��$��0��$��Stretch=�$��	0,0,70,30q�$��25��$
��Bold"�$	��150���� $��4��$��0��$��Stretch=�.+�(  "System.Windows.Controls.DatePicker  -     Name$ fechaDeNacimiento��$��4��$��0��$��5,25,5,5q�$	��220��$��Stretch=�  DatePickerStyle#��[ �� $��	Teléfono��
�������$��5��$��0��$��Stretch=�$��
0,0,140,30q�$��25��$��80��$
��Bold"��� -   $ txtTelefono��$��5��$��0��$��5,25,5,5q�$	��220��#��[ �� $��Email��
�������$��1��$��1��$��Stretch=�$��
0,0,140,30q�$��25��$��80��$
��Bold"��� -   $ txtEmail��$��1��$��1��$��5,25,5,5q�$	��220��$��28��#��[ �� $��	Domicilio��
�������$��2��$��1��$��Stretch=�$��
0,0,120,30q�$��25��$	��100��$
��Bold"��� -   $ txtDomicilio��$��2��$��1��$��5,25,5,5q�$	��220��#��[ �� $��	Localidad��
�������$��3��$��1��$��Stretch=�$��
0,0,120,30q�$��25��$	��100��$
��Bold"��� -	   $ txtLocalidad��$��3��$��1��$��5,25,5,5q�$	��220��$��28��#��[ �� $��	Provincia��
�������$��4��$��1��$��Stretch=�$��
0,0,120,30q�$��25��$	��100��$
��Bold"��� -
   $ txtProvincia��$��4��$��1��$��5,25,5,5q�$	��220��$��28��#��[ �� $��Contraseña��
�������$��1��$��2��$��Stretch=�$��
0,0,120,30q�$��25��$	��100��$
��Bold"��� -   $# txtContraseñaPrimariaVisible��$y�	Collapsed=�$��1��$��2��$��5,25,5,5q�$	��220��#���  $��16(� �� 
IsReadOnly$
 True��
�������$��Italic$�!  FontAwesome.Sharp.IconImage  -     Name$ ojoContraseña���  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$	 Eye=�$��20�� J� RenderTransformOrigin$ 	0.5,0.607&�$��1��$��2��$��
245,20,0,0q�$��Center=�$��20��G� -   	 G�Name$	 txtContraseña��$��1��$��2��$��5,25,5,5q�$	��220��  PassBoxStyle#��[ �� $��Repetir Contraseña��
�������$��2��$��2��$��Stretch=�$��	0,0,70,30q�$��25��$	��150��$
��Bold"��� -   $ txtContraseñaVisible��$y�	Collapsed=�$��2��$��2��$��5,25,5,5q�$	��220��#���  $��28��$��16(�$
 True��
�������$��Italic$�  -   $ ojoRepetirContraseña��$	 Eye=�$��20��$ 	0.5,0.658&�$��2��$��2��$��
245,20,0,0q�$��20��G� -   $	 txtRepetirContraseña��$��2��$��2��$��5,25,5,5q�$	��220��#��[ �� $��Fecha de Contratación��
�������$��3��$��2��$��Stretch=�$��	0,0,60,30q�$��25��$	��160��$
��Bold"�  -   $ fechaDeContratacion��$��3��$��2��$��5,25,5,5q�#��[ $	��220���� -   
 ��Name$
 lblTipoContrato��$��Tipo de contrato��
�������$��3��$��2��$��Stretch=�$��	0,0,70,30q�$��25��$	��150��$
��Bold"�$��3���� -    ��Name$ tipoDeContrato��$��4��$��2��$��0,18,0,0q�$	��220��$��25��  ComboBoxStyle1#��[ �� -   $
 lblRango��$��Rango��
�������$��5��$��2��$��Stretch=�$��	0,0,70,29q�$��26��$	��150��$
��Bold"��� -   $ rango��$��5��$��2��$��0,19,0,0q�$	��220��$��25��#��[ �� -   $��	Registrar��$��6��$��3��$��Center=�$��
0,30,10,40q�$	��150��$��40��#��[  $
��Bold"��� $��1��$�� ��$
��Left=�$��
55,-24,0,0q�$	��Top=�