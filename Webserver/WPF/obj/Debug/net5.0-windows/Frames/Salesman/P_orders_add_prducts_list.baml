   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPF.Frames.SalesmanWPF.Frames.Salesman  5      3    -WPF.Frames.Salesman.P_orders_add_prducts_list   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPF.Frames.Salesman     5        N� Title$  P_orders_add_prducts_list��5      $	��450��6)   $	��800��66   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
         AutoGenerateColumns$ False��6&   $��10 0 0 0q�5      $��14(�6   $��1q�6'      
IsReadOnly$
 True��6;      SelectionMode$ Single=�6M      SelectionUnit$ FullRow=�5         CanUserResizeColumns$ False��6      CanUserReorderColumns$ False��6<    �� TextAlignment$ Center=�6Z   ��5
   B   �� 	   	CellStyle	 5      �� 5      
 �� 
TargetType*  $System.Windows.Controls.DataGridCell"
  6   .�5      ��  �� Property � �� �� Value$ 0q�68    �� Triggers 5      P� 5       P� Property �@ 
IsSelected P� Value$
 True��6E   . �5      ��  � �� �	#ffdadada6;   �� 5       � ��
 �   �6;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ 	IdProduct�  5      $ Тип��6%    62   �� $
 Type�  5      $ Название��6%    67   �� $
 Name�  5      $ Цена��6%    63   �� $ Price�  5      $ Количество��6%    69   �� $ Counts���5"      �� 5#      )  #System.Windows.Controls.DataGridRow"
  6   .�5$      -   5        5%      5'      5)      5*      