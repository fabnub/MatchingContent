   M S B A M L   `   `   `  ����G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      )    #MatchingDash.Views.TeacherStep2View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8
Controller!clr-namespace:MatchingDash.Shared     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight  5      `	 \Xceed.Wpf.Toolkit, Version=2.8.15465.16500, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5
      :d2http://schemas.microsoft.com/expression/blend/2008 	 5      %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed��5   ;    � Title$< 6Secondary Teacher Education II: MENTOR SCHEDULING FORM��5       � DataContext 5	   	   �� *	MenuStep2+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts 5      +  %MahApps.Metro.Controls.FlyoutsControl  5   
   -   5          Name$ flyoutsControl��5   "   .@�5      #  MahApps.Metro.Controls.Flyout  -   5          Name$ settingsFlyout��5         AreAnimationsEnabled .  $��	100 0 0 0q�5         Header$ RECORD VIEW��5      	   Position$	 Right=�5      $
��Bold"�5   P   ��5      �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement 5      ��  �� ElementName$ 
PeopleName��.��5      � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      �� .+�5      �� $��0��6$   $%��Something above the ScrollPanel��5    $   �� 5!      $��0��6$   $@��:This Flyout animates its opacity when opening and closing.��5"   $   5#      �� 5$      $��1��6#   $
��Auto=�5%   #   .��5&      ��  �� Orientation$ Vertical=�6%   .+�5)      �� $��Search on Name��6$   $
��Left=�6=   $	��Top=�6Y   $��25��6q   $��	217,9,0,0q�6}   $	��110��6�   $
��Bold"�6�   �� 5*      -   5        $��
PeopleName��5*   &   $
��Left=�69   $	��Top=�6U   $��23��6n   $��
310,11,0,0q�6z    �� TextWrapping$ NoWrap=�6�   $	��239��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��6�   .��6  5,      &   System.Windows.Controls.DataGrid  5.      -   5          Name$ Record��5.   '   $
��Left=�68   $	��Top=�6S   $	��500��6k   $	��400��6w      AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�50      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�51         HeadersVisibility$	 All=�52      $��0,5,0,0q�6,   ��5/   /   �� *
Teachers+ �� Mode$ TwoWay=���54   "   �� 55   &     MetroDataGrid �� BasedOn# [ 6,    �� 
TargetType"  56      .�57   *   ��  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �  58      59   '      RowStyle 5;   "   �� 5<   &     MetroDataGridRow# [ 6,   )  #System.Windows.Controls.DataGridRow"  5=         Columns 5?   "   0	  *System.Windows.Controls.DataGridTextColumn	  5@   &   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 
FIRST NAME��69     
  
IsReadOnly  . ! 
  MinWidth$	! 200Q�6_   " 	  
FontWeight$
" Bold"�5A   C   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6%   �� *	FirstName+6C   	  5B   &   $ 	LAST NAME��69     . $	! 200Q�6^   $
" Bold"�5C   B   # 6%   �� *
LastName+6B   5E      5F      5G      5J      5K      5L      .��5N      �� $��Visible=�6   $��Visible=�6;   $
��Auto��6a   $
��Auto��6o   .��5P   
   � $
��Auto=�6   $
��Auto=�6A   $
��Auto��6q   $
��Auto��6    5R      �� 5S      $��60 �6"   �� 5T      $��60 �6"   �� 5U      $��60 �6"   �� 5V      $	��150 �6"   �� 5W      $	��460 �6"   �� 5Y      $��60 �6"   �� 5Z      $	��100 �6"   �� 5[      $��60 �6"   �� 5\      $��60 �6"   �� 5]      $��60 �6"   �� 5^      $��60 �6"   �� 5_      $��60 �6"   .+�5b      �� $��
First Name��6   $
��Left=�6)   $	��Top=�6E   $��25��6]   $��0��6i   $��10,7,0,0q�6v   $	��100��6�   �� 5c      $��0��6   $
��Left=�6#   $	��Top=�6?   $��23��6X   $��	125,7,0,0q�6d   $ NoWrap=�6x   $	��160��6�   $ 	Type here��6�   ��6�   �� *	FirstName+$ TwoWay=��� 5d      $��0��6   $
��Left=�6#   $��23��6>   $��	391,7,0,0q�6J   $
 Wrap=�6]   $ 	Type here��6q   $	��Top=�6�   $	��156��6�   ��6�   �� *
LastName+$ TwoWay=�6�   �� 5e      $��0��6   $��	Last Name��6!   $
��Left=�65   $��	302,6,0,0q�6P   $	��Top=�6c   $��26��6{   $��84��6�   �� 5f      $��0��6   $��Email��6!   $
��Left=�61   $��	567,7,0,0q�6L   $	��Top=�6_   $��24��6w   $��84��6�   �� 5g      $��0��6   $
��Left=�6#   $��23��6>   $��	670,7,0,0q�6J   $
 Wrap=�6]   $ 	Type here��6q   $	��Top=�6�   $	��269��6�   ��6�   �� *Email+$ TwoWay=�6�   �� 5h      $��0��6   $��Grade(s) Subject(s)��6!   $
��Left=�6?   $��	961,8,0,0q�6Z   $	��Top=�6m   $	��115��6�   �� 5i      $��0��6   $
��Left=�6#   $��23��6>   $��
1131,6,0,0q�6J   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��184��6�   $ J� RenderTransformOrigin$$ 0.658,0.683&�6�   ��6�   �� *Course+$ TwoWay=�6�   �� 5j      $��School��6   $
��Left=�6&   $��	10,10,0,0q�6A   $��1��6T   $	��Top=�6a   $��94��6y   �� 5k      $
��Left=�6   $��23��61   $��
125,11,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��249��6�   ��6�   �� *School+$ TwoWay=�6�   �� 5l      $��School Phone��6   $
��Left=�6+   $��
410,11,0,0q�6F   $��1��6Z   $	��Top=�6g   $��88��6   �� 5m      $
��Left=�6   $��23��61   $��
538,12,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��177��6�   ��6�   �� *SchoolPhone+$ TwoWay=�6�   �� 5n      $��Cell/Home Phone��6   $
��Left=�6.   $��	748,9,0,0q�6I   $��1��6\   $	��Top=�6i   $	��116��6�   �� 5o      $
��Left=�6   $��23��61   $��
892,11,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��204��6�   ��6�   �� *Phone+6�   �� 5p      $��2��6   $��Room number��6!   $
��Left=�67   $��	19,10,0,0q�6R   $	��Top=�6e   $	��115��6}   �� 5q      $
��Left=�6   $��23��61   $��
165,10,0,0q�6=   $��2��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��177��6�   ��6�   �� *Room+$ TwoWay=�6�   �� 5r      $��Preferred Contact��6   $
��Left=�60   $��
410,11,0,0q�6K   $��2��6_   $	��Top=�6l   $	��156��6�   �� 5s      $��2��5t      $
��Left=�5u      $	��Top=�5v      $��
591,10,0,0q�5w      %   ClearTextButton% . $ select��5y      $��26��5z       $	��144��6,   & �� Text& 5y   F   �� *PreferredContact+$ TwoWay=�.@�5{      �� .��6   Email6&   �� 5|      .��6   Phone6&   5}      �� 5~      $=��7Willing to work with more than a pair of these students��6   $
��Left=�6V   $��	748,9,0,0q�6q   $��2��6�   $	��Top=�6�   $	��311��6�   �� 5      $��2��5�      $
��Left=�5�      $	��Top=�5�      $��1078,11,0,0q�5�      % . $ select��5�      $��26��5�       $	��144��6,   & 5�   F   �� *Pair+$ TwoWay=�.@�5�      �� .��6   Yes6$   �� 5�      .��6   No6#   5�      � 5�      -   5        $��3��5�      .+�5�      �� $��3��6   $��Define Schedule��6%   $
��Left=�6?   $��	19,10,0,0q�6Z   $	��Top=�6m   $
��1208��6�   �� 5�      $��3��6   $	��Day��6%   $
��Left=�63   $��	19,41,0,0q�6N   $	��Top=�6a   $��61��6y   �� 5�      -   5        $	��day��5�      $��3��5�      $
��Left=�5�      $	��Top=�5�      $��	92,41,0,0q�5�      % . $ select��5�      $��26��5�       $	��144��6,   & 5�   F   �� *Day+$ TwoWay=�.@�5�      �� .��6#   Monday6+   �� 5�      .��6#   	Tuesday6,   �� 5�      .��6#   	Wednesday6.   �� 5�      .��6#   
Thursday6-   �� 5�      .��6#   Friday6+   5�      �� 5�      $��Subject��6   $
��Left=�6*   $��
254,41,0,0q�6E   $��3��6Y   $	��Top=�6f   $��88��6~   �� 5�      -   5        $��subject��5�      $��3��5�      $
��Left=�5�      $	��Top=�5�      $��
354,41,0,0q�5�      % . $ select��5�      $��26��5�       $	��144��6,   & 5�   F   �� *	Subject+$ TwoWay=�.@�5�      �� .��6#   	Algebra 16.   �� 5�      .��6#   	Biology6,   �� 5�      .��6#   	Chemestry6.   �� 5�      .��6#   Math6)   �� 5�      .��6#   PRE-AP Math60   �� 5�      .��6#   	Science6,   �� 5�      .��6#   PRE-AP Science63   �� 5�      .��6#   TEKS6)   �� 5�      .��6#   Other6*   5�      �� 5�      $��Grade��6   $
��Left=�6(   $��
524,41,0,0q�6C   $��3��6W   $	��Top=�6d   $��88��6|   *  $MahApps.Metro.Controls.NumericUpDown  5�      -   5        $��grade��5�   )   $��3��66   $��637,41,657,84q�6C   '   Speedup' .  (   Minimum$( 3Q�6�   )   Maximum$) 12Q�6�   *   Value* 6Z   �� *Grade+$ TwoWay=�6�   �� 5�      $��3��6   $��
start time��6%   $
��Left=�6:   $��	19,87,0,0q�6U   $	��Top=�6h   $��85��6�   " 	 Xceed.Wpf.Toolkit.TimePicker  5�      -	   5        $��start��5�   "   $��3��6/   $��125,87,1107,38q�6<   � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]+   Value+ 6U   �� *	StartTime+$ TwoWay=�6~   �� 5�      $��End Time��6   $
��Left=�6+   $��
354,87,0,0q�6F   $��3��6Z   $	��Top=�6g   $��88��6     5�      -
   5        $	��end��5�   "   $��3��6.   $��491,87,741,38q�6;   + 6S   �� *	EndTime+$ TwoWay=�6z   �� 5�      -   5        $	��add��5�      $
��Left=�6$   $��
733,81,0,0q�6?   $��3��6S   $	��Top=�6�   $��50��6�   $��32��6�   $	��Add��6�   {�6`   �� *IsEnabledAddSchedule+$ OneWay=�.  (System.Windows.Interactivity.Interaction,   Triggers, 5�      /  )System.Windows.Interactivity.EventTrigger  5�      -   	EventName$- Click��6)   .  (System.Windows.Interactivity.TriggerBase.   Actions.. 5�      /  )GalaSoft.MvvmLight.Command.EventToCommand  /   Command/ 62   �� $ ExecuteAddSchedule�$ OneWay=�5�      5�      5�        5�      -   5        $��
stepResult��5�   $   $��4��6   $
��Left=�67   $	��Top=�6R   $	��650��6j   $	��400��6v    .  0   
IsReadOnly0 . $ Enabled=�5�      $ Display=�5�      $	 All=�5�      $��309,10,333,34q�6+   ��5�   0   �� *TeachSchedule+$ TwoWay=���5�      �� 5�      # [ 6   "  5�      .�5�      ��   �@ AlternatingRowBackground# �  5�      5�       5�      �� 5�      # [ 6   "  5�       5�      	  5�      $
 DAYS��5�   )   $	! 140Q�67   # 5�   )   �� *Days+$ OneWay=�	  5�      $ 	Sart Time��6)     . $	! 120Q�6N   $
" Bold"�5�   C   # 6%   �� *	StartTime+6C   	  5�      $ End Time��6)     . $	! 120Q�6M   $
" Bold"�5�   A   # 6%   �� *	EndTime+6A   	  5�      $ SUBJECT��5�   )   $	! 140Q�6:   # 5�   )   �� *	Subject+$ OneWay=�	  5�      $ GRADE��5�   )   $	! 100Q�68   # 5�   )   �� *Grade+$ OneWay=�5�      �� 5@     $#��Choose  School district area ��6   $
��Left=�6<   $��
155,14,0,0q�6W   $��5��6k   $	��Top=�6x   $	��166��6�   �� 5A     $��5��5B     $
��Left=�5C     $	��Top=�5D     $��
344,14,0,0q�5E     % . $ select��5G     $��26��5H      $	��144��6,   & 5G  F   �� *
District+$ TwoWay=�.@�5I     �� .��6   Denton6'   �� 5J     .��6   
Lewisville6+   �� 5K     .��6   
McKinney6)   �� 5L     .��6   Forth-Worth6,   5M     �� 5N     $
��Left=�6   $��
391,10,0,0q�61   $��6��6p   $	��Top=�6}   $��60��6�   $��32��6�   {�6E   �� *	CanSave+$ OneWay=�, 5O       5P     $- Click��6%   .. 5Q       / 6.   �� $ ExecuteSave�$ OneWay=�5R     .��5T     �� $��/Pics/Save.jpg��6   $��23��61   $��Stretch=�6=   $��40��6[   5U     �� 5V     $
��Save��6   $
��Left=�6#   $��
302,10,0,0q�6>   $��6��6R   $	��Top=�6_   $��32��6w   $��72��6�   $
��Bold"�6�   �� 5W     $��Reset��6   $
��Left=�6$   $��
538,10,0,0q�6?   $��6��6S   $	��Top=�6`   $��32��6x   $��74��6�   $
��Bold"�6�   �� 5X     $
��Left=�6   $��
637,10,0,0q�61   $��6��6E   $	��Top=�6S   $��50��6k   $��32��6v   , 5Y       5Z     $- Click��6%   .. 5[       / 6.   �� $ ExecuteReset�$ OneWay=�5\     .��5^     �� $��/Pics/Reset.png��6   $��23��62   $��Stretch=�6>   $��40��6\   5_     �� 5`     $
��Left=�6   $��
391,10,0,0q�61   $��7��6v   $	��Top=�6�   $��60��6�   $��32��6�   {�6E   �� *CanViewRecord+$ OneWay=�, 5a       5b     $- Click��6%   .. 5c       / 6.   �� $ ExecuteRecord�$ OneWay=�5d     .��5f     �� $��/Pics/Records.png��6   $��23��64   $��41��6@   5g     �� 5h     $��View RECORDS��6   $
��Left=�6+   $��
273,13,0,0q�6F   $��7��6Z   $	��Top=�6g   $	��100��6   $��29��6�   $
��Bold"�6�   �� 5i     $��View RESULTS��6   $
��Left=�6+   $��
521,10,0,0q�6F   $��7��6Z   $	��Top=�6g   $	��101��6   $��32��6�   $
��Bold"�6�   �� 5j     $
��Left=�6   $��
637,13,0,0q�61   $��7��6E   $	��Top=�6�   $��50��6�   $��29��6�   {�6R   �� *CanViewResult+$ OneWay=�, 5k       5l     $- Click��6%   .. 5m       / 6.   �� $ ExecuteResult�$ OneWay=�5n     .��5p     �� $��/Pics/results.jpg��6   $��23��64   $��Stretch=�6@   $��40��6^   5q     �� 5r     $
��Left=�6   $��	19,10,0,0q�61   $��4��6D   $	��Top=�6Q   $	��217��6i   $	��194��6u   5w     5�     5�     5�     