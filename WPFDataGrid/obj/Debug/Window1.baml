   M S B A M L   `   `   `  ����  WPFDataGrid    WPFDataGrid.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      8grid-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   -   5          � Title$  Customers Data Grid��5      $	��400��6!   $	��500��6.   .��5      � .+�5   
   )  #Microsoft.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5      
MyDataGrid��   AutoGenerateColumns .   �� AlternationCount$ 2��5         SelectionMode$ Single=�6-   $��0,31,0,0q�6D      Columns 5	      3  -Microsoft.Windows.Controls.DataGridTextColumn  5
      /  )Microsoft.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Customer ID��5   %      Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$ SizeToHeader 6:   4  .Microsoft.Windows.Controls.DataGridBoundColumn	   Binding	 5
   *   �� 
 �� Path$
 
CustomerID�5   :     5      $ Company��5   %   $ SizeToHeader 66   	 5   *   �� $
 CompanyName�5   6     5      $
 Name��5   %   $ SizeToHeader 63   	 5   *   �� $
 ContactName�5   3     5      $
 City��5   %   $ SizeToHeader 63   	 5   *   �� $

 City�5   3     5      $ Country��5   %   $ SizeToHeader 66   	 5   *   �� $
 Country�5   6     5      $ Phone��5   %   $ SizeToHeader 64   	 5   *   �� $
 Phone�5   4   7  1Microsoft.Windows.Controls.DataGridTemplateColumn  5      $ Edit Row��6.      CellTemplate 5      �� 5      .R�5      �� -   5        $
��Edit��5   %   64   5      5        5      $ 
Delete Row��6.    5      �� 5      .R�5       �� -   5        $��Delete��5    %   66   5!      5#      5%      �� 5&   
   -   5        $��
LoadButton��5&   /   $��23��6   $��12,2,0,0q�6   $��Load Customers��6A   $	��Top=�6Z   $
��Left=�6�   $	��126��6�   6�   5'      5(      