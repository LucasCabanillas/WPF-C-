   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType ��Name!  System.Windows.SystemColors   ControlBrushKey J� SnapsToDevicePixels	 �Name
 J� Opacity � Points �� Stretch �� Triggers P� Property P� Value �� 
TargetName   ControlDarkBrushKey   DataGridStyle1   ControlTextBrushKey �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column  ��Name! �� CanContentScroll" ��Name# �� ScrollableHeight$ � Maximum% �� Orientation& �� ViewportHeight' �� ViewportSize*( �� #ComputedVerticalScrollBarVisibility) � Value* �� Mode+ �� Mode, �� ScrollableWidth- �� ViewportWidth,. �� %ComputedHorizontalScrollBarVisibility/ �� Triggers0 ]� 
Conditions1 �� Property2 �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader0  *System.Windows.Controls.DataGridCellsPanel*  $System.Windows.Controls.DataGridCell�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      %V  (��       $" DataGridSelectAllButtonStyle��"   )&	  �    '  l    '  �    '  �    �� "  ��.���  � �� �� " ��.R�� 
���  ��.+��� $ Border��#���  $
 True��� $	 Arrow��
���   �$��Right=�$��8,8,3,3q�$

 0.15Q� �   ��� ��� ��� ��� $ Uniform=�$��Bottom=� P�  �@J�IsMouseOver$
 True��. ��� $ Border��# �   � ��P�  � ��$
 True��. ��� $ Border��# �   � ��P�  � {�$ False��. ��� $ Arrow�� � y�$ 	Collapsed=��� "    .���  � ��
 ���� ��  � ��# �  ��  � ��
 �   ���  � ��$	 1.5q���   �@  RowDetailsVisibilityMode$ VisibleWhenSelected=���  � ��$
 true����  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled$ False����  � �� �� "   .R��� #��z��#��z��#��z��# z��$
 True��._��� $ DG_ScrollViewer��$|�false��
���  ������ " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z $|�false����C� *�� $" DataGridSelectAllButtonStyle��"   +y��� *HeadersVisibility+# Z # Z  �� "   ���� *CellsPanelHorizontalOffset+ �� "     $! PART_ColumnHeadersPresenter��$��1��
���  ��y��� *HeadersVisibility+# Z # Z  �� "   �� $!  PART_ScrollContentPresenter��#! z��$��2��$��1���� $" PART_VerticalScrollBar��$��2��#$ z# $% Vertical=�$��1��#' z& #y�z( ) �� *VerticalOffset+$* OneWay=� �� $+ TemplatedParent=�� $��1��$��2��
���  �� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� $��* �.+��� $" PART_HorizontalScrollBar��$��1��#$ z, $% 
Horizontal=�#' z- #y�z. ) �� *HorizontalOffset+$* OneWay=� �� $+ TemplatedParent=�.���� # z / ]� 0 �� 1 �@��
IsGrouping$
2 true���� "1 �@%�IsVirtualizingWhenGrouping$2 false��./���  � ��$ false���� "   .���  � �� �#424769��  � ��
 ������� "   .���  � �� �#2d3250�� "   .���  � ��
 �����