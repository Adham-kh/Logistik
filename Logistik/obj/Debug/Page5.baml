   M S B A M L   `   `   `  ����C  ?Logistik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LogistikLogistik  5          Logistik.Page5   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Logistik     5        N� Title$  Page5��5      $	��500��6   $
��1000��6"   .��5
      � 
���iii�$	��500��6    $
��1000��6-   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         CanUserAddRows .    AutoGenerateColumns .  $
��Left=�6X   $	��187��6s   $	��Top=�6�   $	��736��6�   $��	36,19,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя Водителя��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	FirstName+  5      $% Фамилия Водителя��6%    6@   �� *
LastName+  5      $! Номер телефона��6%    6>   �� *PhoneNumber+  5      $&  Эл адрес Водителя��6%    6A   �� *Email+5      �� 5   
   -   5        $��Добавить��5      $��12(�6$   $
��Left=�62   $��30,0,0,0q�6N   $��Center=�6`   $��90��6{   $��30��6�      SidebarButtonStyle#��[  6�    J� RenderTransformOrigin$ 0.5,0.6&�6�   �� 5   
   -   5        $��Обновить��5      $��12(�6$   $
��Left=�62   $��	147,0,0,0q�6N   $��Center=�6a   $��90��6|   $��30��6�   #��[  6�   $ 0.5,0.6&�6�   �� 5   
   -   5        $��Удалить��5      $��12(�6#   $
��Left=�61   $��	270,0,0,0q�6M   $��Center=�6`   $��90��6{   $��30��6�   #��[  6�   $ 0.5,0.6&�6�   �� 5   
   -   5        $��Poisk��5      $��12(�6!   $
��Left=�6/   $��270,332,0,0q�6K   $	��Top=�6`   $��90��6x   $��30��6�   #��[  6�   6�   �� 5   
   -   5        $��Очистит��5      $
��Left=�6#   $��666,220,0,0q�6>   $	��Top=�6S   $	��100��6�   $��30��6�   �� 5   
   -   5         ��Name$ Poisk��5        StylishTextBox#��[ 6!   $	��200��6I   $��37,328,763,134q�6U   �� 5   
   $>��8Для поска введите имя водителя��6   $
��Left=�69   $��
36,297,0,0q�6T   $	��Top=�6h   $	��194��6�   5      5      