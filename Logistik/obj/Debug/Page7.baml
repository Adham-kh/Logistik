   M S B A M L   `   `   `  ����C  ?Logistik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LogistikLogistik  5          Logistik.Page7   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Logistik     5        N� Title$  Page7��5      $	��949��6   $	��502��6!   .��5
      � 
���iii�$	��500��6    $
��1000��6-   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         CanUserAddRows .    AutoGenerateColumns .  $
��Left=�6X   $	��141��6s   $	��Top=�6�   $	��794��6�   $��	37,24,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код заказа��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *	OrderID+  5      $ Имя Клиента��6%    6;   �� *	FirstName+  5      $ Пункт приема��6%    6;   �� *LocationIDO+  5      $% Пункт назначения��6%    6?   �� *LocationIDN+  5      $ Дата заявки  ��6%    6<   �� *	OrderDate+ �� StringFormat$ {0:dd.MM.yyyy}��  5      $ Дата приема  ��6%    6<   �� *
PriyomDate+$ {0:dd.MM.yyyy}��  5      $! Статус заказа  ��6%    6>   �� *StatusDescrip+$ {0:dd.MM.yyyy}��5      �� 5   
   -   5        $��Закрить заказ��5      $��12(�6)   $
��Left=�67   $��410,216,0,0q�6S   $	��Top=�6h   $��90��6�   $��34��6�      SidebarButtonStyle#��[  6�    J� RenderTransformOrigin$ 0.5,0.6&�6�   �� 5   
   -   5        $��Poisk��5      $��12(�6!   $
��Left=�6/   $��255,217,0,0q�6K   $	��Top=�6`   $��90��6x   $��30��6�   #��[  6�   6�   �� 5   
   -   5        $��Очистит��5      $
��Left=�6#   $��731,170,0,0q�6>   $	��Top=�6S   $	��100��6�   $��30��6�   �� 5   
   -   5        	 ��Name$	 Poisk��5        StylishTextBox#��[ 6!   $	��200��6I   $��37,213,763,249q�6U   �� 5   
   $:��4Для поска введите Код заказа��6   $
��Left=�67   $��
43,182,0,0q�6R   $	��Top=�6f   $	��194��6~   5      5      