   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF.Frames.SalesmanWPF.Frames.Salesman  5      )    #WPF.Frames.Salesman.P_orders_update   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPF.Frames.Salesman     5      c _MaterialDesignThemes.MahApps, Version=0.2.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5        N� Title$  P_orders_update��5
      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5      �� -   5         ��Name$ label��5      $��16(�6#   $+��%Содержимое заказа №��61   6Q   �� 5      -   5        $ 	labelInfo��5      $��16(�6'   67   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGrid��5         AutoGenerateColumns$ False��6*   $��1��6_   $��3��6m   $��10 0 0 0q�5      $��14(�6   $��1q�6'      
IsReadOnly$
 True��6;      SelectionMode$ Single=�6M   	   SelectionUnit$	 FullRow=�5      
   CanUserResizeColumns$
 False��6      CanUserReorderColumns$ False��6<    �� TextAlignment$ Center=�6Z   ��5   F   ��    	CellStyle 5      �� 5        �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5!      ��  �� Property � �� �� Value$ 0q�6<    �� Triggers 5"      P� 5#       P� Property �@ 
IsSelected P� Value$
 True��6I   . �5$   "   ��  � �� �	#ffdadada6?   �� 5%   "    � ��
 �   �6?   5&      5(         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ 	IdProduct�  5-      $ Тип��6)    66   �� $
 Type�  5.      $ Название��6)    6;   �� $
 Name�  5/      $ Цена��6)    67   �� $ Price�  50      $ Количество��6)    6=   �� $ Counts���53      �� 54      )  #System.Windows.Controls.DataGridRow"  6   56      58      �� 5<   
   -   5         ��Name$ b_prd_delete��5<      $��2��6(   $	��103��68   $��32��6G   $��5 5 5 0q�6S   .��6s   Вернуться6~   5>      5?      