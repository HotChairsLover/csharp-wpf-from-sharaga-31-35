   M S B A M L   `   `   `  ����b  ^Syncfusion.SfChart.WPF, Version=19.3460.0.54, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts  5      G CPermDynamics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PermDynamics.PagesPermDynamics.Pages 5      7 clr-namespace:PermDynamics.ChartPermDynamics.Chart 5      #   PermDynamics.Pages.ChartsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5      2local clr-namespace:PermDynamics.Pages     5      3local2 clr-namespace:PermDynamics.Chart     5        N� Title$  
ChartsView��5       � DataContext 5      ' !PermDynamics.Chart.SavesViewModel  5   
   .��5      � 
�������.+�5   
   � $	��Top=�6   $��10,10,10,50q�6'   .+�5      '   !Syncfusion.UI.Xaml.Charts.SfChart  -   5          Name$ stocks��5   4   
�������
���   �$��1q�6X   )   #Syncfusion.UI.Xaml.Charts.ChartBase   Header$ Акции PermDynamics��6l      PrimaryAxis 5      ,   &Syncfusion.UI.Xaml.Charts.DateTimeAxis  5      )   #Syncfusion.UI.Xaml.Charts.ChartAxis   Header$ 
Время��6.      LabelFormat$ hh:mm:ss��6=      SecondaryAxis 5      -   'Syncfusion.UI.Xaml.Charts.NumericalAxis  5      $ рублей 1 акция��6/      Legend 5      +   %Syncfusion.UI.Xaml.Charts.ChartLegend  5      	   Series.	 5      4   .Syncfusion.UI.Xaml.Charts.FastLineBitmapSeries  -   5        
  Name$
 perStock��5   _   /	   )Syncfusion.UI.Xaml.Charts.ChartSeriesBase 	  Label$ Рублей 1 акция��62    	  Interior
 ����   EnableAntiAliasing .   	  XBindingPath$
 time��6�   ,
   &Syncfusion.UI.Xaml.Charts.XyDataSeries 
  YBindingPath$ rublesPerStock��6�    	  ItemsSource 6�   �� *
OpenData+5        5      -   5        $
 avgStock��5   X   $ Среднее акций��62   
 ��  � .  $
 time��6�   $ avgRublesPerStock��6�    6�   �� *
OpenData+5      5      5       �� 5!   
   -   5        $��
Назад��5!      $	��100��6.   $��30��6:   
�������
���   �$��Bottom=�5"      $��Right=�6,   $��10q�6H   6V   5#      5$      