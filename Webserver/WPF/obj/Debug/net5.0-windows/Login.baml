   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.Window1   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   localclr-namespace:WPF   5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Авторизация��5
   	   $	��300��6   $	��250��6*    � Topmost$
 True��66   .��5      � -   5         �Name$ start_window��5      $��0,0,0,0q�6   ���	#FFFBFBFB � Cursor$
 Hand��6I    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0,5* �6   �� 5      $
��0,5* �6   �� 5      $��8* �6   �� 5      $��8* �6   .+�5   
   �� -   5         ��Name$ TextBoxLogin��5      $��0��6(   $��1��65   $��30��6E   $��5 0 5 0q�6Q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6c   $��2 5 0 0 q�5      $��18(�6%   $ IBeam��64   G� 5   
   -   5        	 G�Name$	 
paswordbox��5      $��1��6+   $��1��6;   $��30��6I   $��5 0 5 0q�6U   $��Stretch=�6f   $��Stretch=�6�   
 G� PasswordChar$
 *��6�   $! Введите пароль��5      $��18(�6F   $ IBeam��6U   6f   �� 5   
   -   5         ��Name$ btnLogin��5      $��1��6#   $��2��63   $"��Войти в систему��6@   $��30��6Z   $��5 0 5 0q�6f   $�� ��6w   6�   �� 5   
   $��1��6   $��3��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5      �� -   5        $ btnLoginADM��5      $��А��6+   $��30��67   $��50��6C   $��5 0 5 0q�6N   $�� ��6_   $��10(�6}   �� 5       -   5        $ btnLoginMNG��5       $��М��6+   $��30��67   $��50��6C   $��5 0 5 0q�6N   $�� ��6_   $��10(�6}   5!      5#      5$      