   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProyectoProyecto  5   	       Proyecto.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   "localclr-namespace:Proyecto  5   	     � WindowStyle$
  none=�5	   	   
������  � Title$ 
MainWindow��5   	   $	��550��6   $	��450��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5      �� 
���   �$��1q�6!    �� CornerRadius$ 15��65   ���#2d3250._�5   
   � $��1,1,0,0q�6   $	��548��6    $	��Top=�6-   $
��Left=�6E   $	��448��6`    � Cursor$  ��6l    � RowDefinitions 5      �� 5      $
��319* �6    �� 5      $
��229* �6     � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6#   $��74.077��60   .+�5      �� -   5         ��Name$ 	btnCerrar��5   >      StyleButtonExit#��[  6   ���#292F4F$��0q�6g   $��X��6{   $��
54,9,3,291q�6�   
������ 	 J� RenderTransformOrigin$	 0.521,0.546&�6�   $��1��6�   �� 5      -   5        $ btnMinimizar��5      $��_��6+   $��Center=�67   $��0,9,0,0q�6T   $	��Top=�6e   
������ 
������ #��[  6�   $��1��6�   $��19��6�   $��17��6  �� 5!      -   5        
 ��Name$
 lblDni��5!      $	��DNI��6$   
�������$
��Left=�6E   $��120,176,0,0q�6`   $	��Top=�6u   $��Arial Black)�6�   $��24��6�   $��61��6�   �� 5"      -   5         ��Name$ txtDNI��5"      
�������$
��Left=�69   $��120,200,0,0q�6T    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��219��6�     TextBoxStyle#��[ 6�   $��16(�6�   $��Italic$�6�   $��27��6�   6Z  �� 5%      -   5        $
 lblContraseña��5%      $��Contraseña��6+   
�������$
��Left=�6S   $��120,262,0,0q�6n   $	��Top=�6�   $��Arial Black)�6�   $��24��6�   $��86��6�   � 5&      $
��Left=�6   $��50��6.   $��2��69   $��7,0,0,0q�6J   .+�5(      �� -   5        $ txtContraseñaVisible��5(      #��[ 69   $��116,288,-283,232q�6`   $
 Wrap=�6z   $��16(�6�   
�������$y�	Collapsed=�6�   $
{�True��6�   $��Italic$�6�   $��TextBox��6�   $	��Top=�6�   $	��217��6  6H  G� 5)      -   5         G�Name$ txtContraseña��5)      $��116,288,-283,236q�65     PassBoxStyle#���  6P   $��16(�6w   6�   !  FontAwesome.Sharp.IconImage  5*      -   5          Name$ ojoContraseña��5*      �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$	 Eye=�66   $��20��6A   $��20��6L   $��338,292,-308,236q�6Y   $	 	0.5,0.607&�6�   5+      �� 5/      -	   5        $ btnIngresar��5/        ButtonStyle#��[ 6*   $��Ingresar��6O   $
��Left=�6b   $��
157,33,0,0q�6}   $	��Top=�6�   $	��151��6�   $��49��6�   ���#e18a46
�������$��Italic)�6�   $��20(�6�   $
��Bold"�6  $��Italic$�6  $��1��6L  55      56      57      