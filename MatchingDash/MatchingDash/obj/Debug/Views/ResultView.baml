   M S B A M L   `   `   `  ����G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      #    MatchingDash.Views.ResultView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8
Controller!clr-namespace:MatchingDash.Shared     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5	      %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed��5   L   $	��800��5      $
��1390��6&    � Title$ RESULT VIEW��5   8    � DataContext 5
      �� *Result+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts 5      +  %MahApps.Metro.Controls.FlyoutsControl  5   
   -   5          Name$ flyoutsControl��5   "   .@�5      #  MahApps.Metro.Controls.Flyout  -   5          Name$ settingsFlyout��5         AreAnimationsEnabled .  $��	100 0 0 0q�5         Header$# RESULT OF NO MATCHING CONTENT��5      	   Position$	 Right=�5      $
��Bold"�5   L   ��5      �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement 5      ��  �� ElementName$ People��.��5      � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      �� .+�5      �� $��0��6$   $%��Something above the ScrollPanel��5    $   �� 5!      $��0��6$   $@��:This Flyout animates its opacity when opening and closing.��5"   $   5#      �� 5$      $��1��6#   $
��Auto=�5%   #   .��5&      ��  �� Orientation$ Vertical=�6%   .+�5'      �� $�� Search on Name��6$   $
��Left=�6>   $	��Top=�6Z   $��25��6r   $��	217,9,0,0q�6~   $	��110��6�   $
��Bold"�6�   �� 5(      -   5        $��People��5(   &   $
��Left=�65   $	��Top=�6Q   $��23��6j   $��
310,11,0,0q�6v    �� TextWrapping$ NoWrap=�6�   $	��239��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��6�   .��6�   5*      �� 5+      -   5        $��
NoIdentity��5+   '   $
��Left=�5-      $	��Top=�5.      $��
584,10,0,0q�5/       $��0��50         ClearTextButton . $ Select Type ��52      $��26��53   "   $	��236��6.   .@�59   "   �� .��6/   	Teacher68   �� 5:   "   .��6/   	Student68   5;      &   System.Windows.Controls.DataGrid  5<      -   5          Name$ Record��5<   '   $
��Left=�69   $	��Top=�6T   $
��1150��6l   $	��400��6y      AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�5>      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5?         HeadersVisibility$	 All=�5@      $��0,5,0,0q�6,   {�5=   /   �� *	CanShow+��6M   �� *NoConditionResult+ �� Mode$ OneWay=���5B   "   �� 5C   &     MetroDataGrid �� BasedOn# [ 6,    �� 
TargetType"  5D      .�5E   *   ��  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �  5F      5G   '      RowStyle 5I   "   �� 5J   &     MetroDataGridRow# [ 6,   )  #System.Windows.Controls.DataGridRow"  5K         Columns 5M   "   0	  *System.Windows.Controls.DataGridTextColumn	  5N   &   ,
  &System.Windows.Controls.DataGridColumn  
  Header$  MENTOR TEACHER NAME��69   ! 
  
IsReadOnly! . " 
  MinWidth$	" 200Q�6h   # 	  
FontWeight$
# Bold"�5O   E   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 6%   �� *TeacherName+6E   	  5P   &   $  STUDENT NAME��69   ! . $	" 200Q�6a   $
# Bold"�5Q   E   $ 6%   �� *StudentName+6E   	  5R   &   $  SUBJECT��69   ! . $	" 150Q�6\   $
# Bold"�5S   ?   $ 6%   �� *Major+6?   	  5T   &   $
  HOUR��69   ! . $	" 120Q�6Y   $
# Bold"�5U   >   $ 6%   �� *Hour+6>   	  5V   &   $
  DAYS��5W   )   $	" 100Q�67   ! . $
# Bold"�5X   C   $ 6)   �� *Days+6C   	  5Y   &   $  SCHOOL��5Z   )   $	" 190Q�69   ! . $
# Bold"�5[   D   $ 6)   �� *School+6D   	  5\   &   $
  ROOM��5]   )   $" 90Q�67   ! . $
# Bold"�5^   C   $ 6)   �� *Room+6C   4  .System.Windows.Controls.DataGridTemplateColumn  5_   &   $  DETAILS��6=   $" 90Q�6O   % 
  Width5  /System.Windows.Controls.DataGridLengthConverter$% SizeToCells 6]   ! . &   CellTemplate& 5`   *   �� 5a   .   .R�5b   2   �� $	��eff��69   -   5        $��Stretch=�5b   D   $��Stretch=�6b   $��30��6~   .��5d   6   �� $ ��/Pics/info-square-blue.png��6<   $��20��6a   5e   3   5f   /   5h   '   5j      5k      5l      5o      5p      5q      .��5s      �� $��Visible=�5t       .��5u   
   �  5v      �� 5w      $��60 �6"   �� 5x      $	��430 �6"   �� 5y      $��60 �6"   .+�5{      �� $�� Name��6   $
��Left=�6$   $	��Top=�6@   $��25��6X   $��0��6d   $��	217,9,0,0q�6q   $��66��6�   �� 5|      -   5        $��
PeopleName��5|      $��0��6(   $
��Left=�65   $	��Top=�6Q   $��23��6j   $��
310,11,0,0q�6v   $ NoWrap=�6�   $	��239��6�   $ 	Type here��6�   6�   �� 5      $��SEARCH BASED ON:��6   $
��Left=�6/   $��	49,10,0,0q�6J   $	��Top=�6]   $	��137��6u   $
��Bold"�6�   �� 5�      -   5        $��Identity��5�      $
��Left=�5�      $	��Top=�5�      $��
584,10,0,0q�5�       $��0��5�       . $ Select Type ��5�      $��26��5�   "   $	��236��6.   .@�5�      �� .��6   	Teacher6(   �� 5�      .��6   	Student6(   5�        5�      -	   5        $��
resultgrid��5�      $��1��6*   $
��Left=�68   $	��Top=�6S   $
��1340��6k   $	��400��6x    .  $ Enabled=�5�      $ Display=�5�      $	 All=�5�      $��	10,10,0,0q�6+   {�5�   /   �� *	CanShow+��6M   �� *	Results+$ TwoWay=���5�      �� 5�      # [ 6   "  5�      .�5�      ��   �@ AlternatingRowBackground# �  5�      5�       5�      �� 5�      # [ 6   "  5�       5�      	  5�      $  MENTOR TEACHER NAME��6)   ! . $	" 200Q�6X   $
# Bold"�5�   E   $ 6%   �� *TeacherName+6E   	  5�      $  STUDENT NAME��6)   ! . $	" 200Q�6Q   $
# Bold"�5�   E   $ 6%   �� *StudentName+6E   	  5�      $  SUBJECT��6)   ! . $	" 150Q�6L   $
# Bold"�5�   ?   $ 6%   �� *Major+6?   	  5�      $
  HOUR��6)   ! . $	" 120Q�6I   $
# Bold"�5�   >   $ 6%   �� *Hour+6>   	  5�      $
  DAYS��5�   )   $	" 100Q�67   ! . $
# Bold"�5�   C   $ 6)   �� *Days+6C   	  5�      $  SCHOOL��5�   )   $	" 190Q�69   ! . $
# Bold"�5�   D   $ 6)   �� *School+6D   	  5�      $
  ROOM��5�   )   $" 90Q�67   ! . $
# Bold"�5�   C   $ 6)   �� *Room+6C   	  5�      $  	TRANSPORT��5�   )   $" 90Q�6<   ! . $
# Bold"�5�   M   $ 6)   �� *Transportation+6M   	  5�      $  SECTION��5�   )   $	" 110Q�6:   ! . $
# Bold"�5�   F   $ 6)   �� *	section+6F     5�      $  DETAILS��6-   $" 90Q�6?   $% SizeToCells 6M   ! . & 5�      �� 5�      .R�5�   "   �� $��info_eff��6)   -
   5        $��Stretch=�5�   9   $��Stretch=�6W   $��30��6s   .��5�   &   �� $ ��/Pics/info-square-blue.png��6,   $��20��6Q   5�   #   5�      5�      5�      �� 5�      $
��Left=�6   $��
391,10,0,0q�61   $��2��6p   $	��Top=�6}   $��60��6�   $��32��6�   {�6E   �� *	CanSave+$ OneWay=�.  (System.Windows.Interactivity.Interaction'   Triggers' 5�      /  )System.Windows.Interactivity.EventTrigger  5�      (   	EventName$( Click��6%   .  (System.Windows.Interactivity.TriggerBase)   Actions.) 5�      /  )GalaSoft.MvvmLight.Command.EventToCommand  *   Command* 6.   �� $ ExecuteSave�$ OneWay=�5�      .��5�      �� $��/Pics/Save.jpg��6   $��23��61   $��Stretch=�6=   $��40��6[   5�      �� 5�      $
��Save��6   $
��Left=�6#   $��
302,10,0,0q�6>   $��2��6R   $	��Top=�6_   $��32��6w   $��72��6�   $
��Bold"�6�   �� 5�      $��Reset��6   $
��Left=�6$   $��
538,10,0,0q�6?   $��2��6S   $	��Top=�6`   $��32��6x   $��74��6�   $
��Bold"�6�   �� 5�      $
��Left=�6   $��
637,10,0,0q�61   $��2��6E   $	��Top=�6S   $��50��6k   $��32��6v   ' 5�        5�      $( Click��6%   .) 5�        * 6.   �� $ ExecuteReset�$ OneWay=�5�      .��5�      �� $��/Pics/Reset.png��6   $��23��62   $��Stretch=�6>   $��40��6\   5�      �� 5�      $
��Left=�6   $��391,71,0,-42q�61   $��2��6H   $	��Top=�6U   $��60��6m   $��32��6x   ' 5�        5�      $( Click��6%   .) 5�        * 6.   �� $ ExecuteView�$ OneWay=�5�      .��5�      �� $��/Pics/Records.png��6   $��23��64   $��41��6@   5�      �� 5�      $��results of no matching��6   $
��Left=�65   $��215,74,0,-42q�6P   $��2��6f   $	��Top=�6s   $	��159��6�   $��29��6�   $
��Bold"�6�   5�      5�      5�      