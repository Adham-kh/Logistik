   M S B A M L   `   `   `  ����  Logistik    Logistik.Page4   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Page4��5      .��5      � 
���iii�$	��500��6    $
��1000��6-   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridVeh��5         CanUserAddRows .    AutoGenerateColumns .  $
��Left=�6[   $	��187��6v   $	��Top=�6�   $	��781��6�   $��	30,28,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ номерной знак��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *LicensePlate+  5      $> 8модель транспортного средства��6%    6M   �� *Model+  5      $. (грузоподъёмность в кг��6%    6E   �� *
Capacity+4  .System.Windows.Controls.DataGridComboBoxColumn  5      $> 8статус транспортного средства��6)      SelectedValueBinding 6P   �� *
V_Status+5      �� 5   
   -   5        $��Добавить��5      $��12(�6$   $
��Left=�62   $��30,0,0,0q�6N   $��Center=�6`   $��90��6{   $��30��6�      SidebarButtonStyle#��[  6�    J� RenderTransformOrigin$ 0.5,0.6&�6�   �� 5   
   -   5        $��Обновить��5      $��12(�6$   $
��Left=�62   $��	147,0,0,0q�6N   $��Center=�6a   $��90��6|   $��30��6�   #��[  6�   $ 0.5,0.6&�6�   �� 5   
   -   5        $��Удалить��5      $��12(�6#   $
��Left=�61   $��	270,0,0,0q�6M   $��Center=�6`   $��90��6{   $��30��6�   #��[  6�   $ 0.5,0.6&�6�   �� 5   
   -   5        $��Poisk��5      $��12(�6!   $
��Left=�6/   $��270,332,0,0q�6K   $	��Top=�6`   $��90��6x   $��30��6�   #��[  6�   6�   �� 5   
   -   5        $��Очистит��5      $
��Left=�6#   $��711,220,0,0q�6>   $	��Top=�6S   $	��100��6�   $��30��6�   �� 5   
   -   5        	 ��Name$	 Poisk��5        StylishTextBox#��[ 6!   $	��200��6I   $��37,328,763,134q�6U   5      5      