   M S B A M L   `   `   `  ����G  CMatchingDash, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MatchingDash.SharedMatchingDash.Shared  5      T PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      )    #MatchingDash.Views.StudentStep2View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8
Controller!clr-namespace:MatchingDash.Shared     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      ` \Xceed.Wpf.Toolkit, Version=2.8.15465.16500, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	      f	 bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1+mvvm http://www.galasoft.ch/mvvmlight 	 5
      %   MatchingDash.Shared.DockManager    Closed$  DockManager_Closed��5   7    � Title$2 ,Secondary Teacher Education II: STUDENT FORM��6    � DataContext 5   	   �� *	MenuStep2+   Locator �� Source# [  (  "MahApps.Metro.Controls.MetroWindow   Flyouts 5      +  %MahApps.Metro.Controls.FlyoutsControl  5   
   -   5          Name$ flyoutsControl��5   "   .@�5      #  MahApps.Metro.Controls.Flyout  -   5          Name$ settingsFlyout��5         AreAnimationsEnabled .  $��	100 0 0 0q�5         Header$ RECORD VIEW��5      	   Position$	 Right=�5      $
��Bold"�5   P   ��5      �� 
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ Controls:MetroWindowL� �� Path$ ActualWidth�   FocusedElement 5      ��  �� ElementName$ 
PeopleName��.��5      � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      �� .+�5      �� $��0��6$   $%��Something above the ScrollPanel��5    $   �� 5!      $��0��6$   $@��:This Flyout animates its opacity when opening and closing.��5"   $   5#      �� 5$      $��1��6#   $
��Auto=�5%   #   .��5&      ��  �� Orientation$ Vertical=�6%   .+�5'      �� $�� Search on Name��6$   $
��Left=�6>   $	��Top=�6Z   $��25��6r   $��	217,9,0,0q�6~   $	��110��6�   $
��Bold"�6�   �� 5(      -   5        $��
PeopleName��5(   &   $
��Left=�69   $	��Top=�6U   $��23��6n   $��
310,11,0,0q�6z    �� TextWrapping$ NoWrap=�6�   $	��239��6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	Type here��6�   .��6  .��5-   =   5.      &   System.Windows.Controls.DataGrid  50      -   5          Name$ Record��50   '   $
��Left=�68   $	��Top=�6S   $	��500��6k   $	��400��6w      AutoGenerateColumns .   �� ClearTypeHint$ Enabled=�52      &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�53         HeadersVisibility$	 All=�54      $��0,5,0,0q�6,   ��51   /   �� *
Students+ �� Mode$ TwoWay=���56   "   �� 57   &     MetroDataGrid �� BasedOn# [ 6,    �� 
TargetType"  58      .�59   *   ��  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �  5:      5;   '      RowStyle 5=   "   �� 5>   &     MetroDataGridRow# [ 6,   )  #System.Windows.Controls.DataGridRow"  5?         Columns 5A   "   0	  *System.Windows.Controls.DataGridTextColumn	  5B   &   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 
FIRST NAME��69     
  
IsReadOnly  . ! 
  MinWidth$	! 200Q�6_   " 	  
FontWeight$
" Bold"�5C   C   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6%   �� *	FirstName+6C   	  5D   &   $ 	LAST NAME��69     . $	! 200Q�6^   $
" Bold"�5E   B   # 6%   �� *
LastName+6B   5G      5H      5I      5L      5M      5N      .��5P      �� $��Visible=�6   $��Visible=�6;   $
��Auto��6a   $
��Auto��6o   .��5R   
   � $
��Auto=�6   $
��Auto=�6A   $
��Auto��6q   $
��Auto��6    5T      �� 5U      $��60 �6"   �� 5V      $��60 �6"   �� 5W      $	��460 �6"   �� 5X      $��60 �6"   �� 5Y      $��60 �6"   �� 5Z      $	��100 �6"   �� 5[      $��60 �6"   �� 5^      $��60 �6"   �� 5_      $��60 �6"   .+�5b      �� $��
First Name��6   $
��Left=�6)   $	��Top=�6E   $��25��6]   $��0��6i   $��10,7,0,0q�6v   $	��100��6�   �� 5c      $��0��6   $
��Left=�6#   $	��Top=�6?   $��23��6X   $��	125,7,0,0q�6d   $ NoWrap=�6x   $	��160��6�   $ 	Type here��6�   ��6�   �� *	FirstName+$ TwoWay=��� 5d      $��0��6   $
��Left=�6#   $��23��6>   $��	391,7,0,0q�6J   $
 Wrap=�6]   $ 	Type here��6q   $	��Top=�6�   $	��156��6�   ��6�   �� *
LastName+$ TwoWay=�6�   �� 5e      $��0��6   $��	Last Name��6!   $
��Left=�65   $��	302,6,0,0q�6P   $	��Top=�6c   $��26��6{   $��84��6�   �� 5f      $��0��6   $��	UNT Email��6!   $
��Left=�65   $��	567,7,0,0q�6P   $	��Top=�6c   $��24��6{   $��84��6�   �� 5g      $��0��6   $
��Left=�6#   $��23��6>   $��	670,7,0,0q�6J   $
 Wrap=�6]   $ 	Type here��6q   $	��Top=�6�   $	��269��6�   ��6�   �� *Email+$ TwoWay=�6�   �� 5h      $��0��6   $��Major(math or science)��6!   $
��Left=�6B   $��	961,8,0,0q�6]   $	��Top=�6p   $	��170��6�   �� 5j      $��0��5k      $
��Left=�5l      $	��Top=�5m      $��1146,10,0,0q�5n      $   ClearTextButton$ . $ select��5p      $��26��5q   C   $	��184��6P   % �� Text% 6    �� *Major+$ TwoWay=�.@�5r      �� .��6   	Biology6(   �� 5s      .��6   	Chemestry6*   �� 5t      .��6   Computer Science61   �� 5u      .��6   Mathematics6,   �� 5v      .��6   	Physics6(   5w      �� 5x      $��Address��6   $
��Left=�6'   $��	10,10,0,0q�6B   $��1��6U   $	��Top=�6b   $��94��6z   �� 5y      $
��Left=�6   $��23��61   $��
125,11,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��249��6�   ��6�   �� *	Address+$ TwoWay=�6�   �� 5z      $��Mobile Phone��6   $
��Left=�6+   $��
396,10,0,0q�6F   $��1��6Z   $	��Top=�6g   $��97��6   �� 5{      $
��Left=�6   $��23��61   $��
512,10,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��177��6�   ��6�   �� *Phone+$ TwoWay=�6�   �� 5|      $��
Home Phone��6   $
��Left=�6)   $��
718,11,0,0q�6D   $��1��6X   $	��Top=�6e   $��97��6}   �� 5}      $
��Left=�6   $��23��61   $��
836,10,0,0q�6=   $��1��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��204��6�   ��6�   �� *AlternativePhone+6�   �� 5~      $
��Left=�6   $��	19,10,0,0q�61   $��2��6D   $	��Top=�6Q   $	��217��6i   $	��194��6u   ��5      �� 5�      & �� TextWrapping$
& Wrap=�6!   $����In the table, select in ALL 2-HOUR OR LONGER blocks of times that you ARE AVAILABLE to teach in the table below: A teaching block will include:                                 At least 30 min prior to start of teach for travel to school, check-in and set-up; 30 min after teach for clean-up and travel back to campus��65   5�        5�      -   5        $��step2Stu��5�      $��2��6'   $
��Left=�65   $	��Top=�6P   $	��750��6h   $	��400��6t    .  $ Enabled=�5�      $ Display=�5�      $	 All=�5�      $��309,10,333,34q�6+   ��5�   0   �� *
Schedule+$ TwoWay=���5�      �� 5�      # [ 6   "  5�      .�5�      ��   �@ AlternatingRowBackground# �  5�      5�       5�      �� 5�      # [ 6   "  5�       5�      	  5�      $
 HOUR��6)     . $	! 200Q�6I   $
" Bold"�5�   >   # 6%   �� *Time+6>   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�        MetroDataGridCheckBox'   ElementStyle#' �  6-   (   EditingElementStyle#( �  5�   )   $ MONDAY��5�   )   $	! 100Q�69   # 5�   )   �� *Monday+) �� UpdateSourceTrigger$) PropertyChanged=�  5�      #' �  6-   #( �  5�   )   $ TUESDAY��5�   )   $	! 100Q�6:   # 5�   )   �� *	Tuesday+$) PropertyChanged=�  5�      #' �  6-   #( �  5�   )   $ 	WEDNESDAY��5�   )   $	! 100Q�6<   # 5�   )   �� *	Wednesday+$) PropertyChanged=�  5�      #' �  6-   #( �  5�   )   $ THURSDAY��5�   )   $	! 100Q�6;   # 5�   )   �� *
Thursday+$) PropertyChanged=�  5�      #' �  6-   #( �  5�   )   $ FRIDAY��5�   )   $	! 100Q�69   # 5�   )   �� *Friday+$) PropertyChanged=�5�      �� 5�      $)��#Do You Have Your Own Transportation��6   $
��Left=�6B   $��	10,10,0,0q�6]   $��3��6p   $	��Top=�6}   $	��235��6�   �� 5�      $��3��5�      $
��Left=�5�      $	��Top=�5�      $��262,10,1050,25q�5�      $ . $ select��5�      $��26��5�   L   $��80��6Y   % 6    �� *Transportation+$ TwoWay=�.@�5�      �� .��6   Yes6$   �� 5�      .��6   No6#   5�      �� 5�      $?��9If Neccessary, would you be willing to drive someone else��6   $
��Left=�6X   $��
365,10,0,0q�6s   $��3��6�   $	��Top=�6�   $	��324��6�   �� 5�      $��3��5�      $
��Left=�5�       $	��Top=�5�      $��702,10,620,25q�5�      $ . $ select��5�      $��26��5�   D   $��80��6P   % 6    �� *Drive+$ TwoWay=�.@�5�      �� .��6   Yes6$   �� 5�      .��6   No6#   5�      �� 5�      $7��1If necessary, would you be willing to teach alone��6   $
��Left=�6P   $��
795,10,0,0q�6k   $��3��6   $	��Top=�6�   $	��322��6�   �� 5�      $��3��5�      $
��Left=�5�      $	��Top=�5�      $��1131,10,177,25q�5�      $ . $ select��5�      $��26��5�       $��80��6,   % 5�   F   �� *
Teaching+$ TwoWay=�.@�5�      �� .��6   Yes6$   �� 5�      .��6   No6#   5�      �� 5�      $��Preferred Days��6   $
��Left=�6-   $��	10,10,0,0q�6H   $��4��6[   $	��Top=�6h   %  Xceed.Wpf.Toolkit.CheckComboBox  5�      $��4��6!   $��Center=�5�      $��Center=�5�      * �� DisplayMemberPath$* Color��5�      +  %Xceed.Wpf.Toolkit.Primitives.Selector+   ValueMemberPath$+ Level��5�      $��125,10,1132,21q�5�   I   $	��145��6a   ,   Text, 6   �� *PreferredDays+$ TwoWay=���5�      �� *Mydays+$ OneWay=�5�      �� 5�      $��Do you live on campus��6   $
��Left=�64   $��
379,10,0,0q�6O   $��4��6c   $	��Top=�6p   $	��141��6�   �� 5�      $��4��5�      $
��Left=�5�      $	��Top=�5�      $��
542,10,0,0q�5�      $ . $ select��5�      $��26��5�   D   $��96��6Q   % 6    �� *Campus+$ TwoWay=�.@�5�      �� .��6   Yes6$   �� 5�      .��6   No6#   5�      �� 5�      $%��If no, what town do you live in��6   $
��Left=�6>   $��
702,10,0,0q�6Y   $��4��6m   $	��Top=�6z   �� 5�      $
��Left=�6   $��23��61   $��
913,10,0,0q�6=   $��4��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��204��6�   ��6�   �� *Town+6�   �� 5�      $W��QPlease rank your district preference(1-4. 1=most preferred and 4=least preffered)��6   $
��Left=�6p   $��	10,10,0,0q�6�   $��5��6�   $	��Top=�6�   $	��441��6�   �� 5�      $��Denton��6   $
��Left=�6%   $��	19,41,0,0q�6@   $��5��6S   $	��Top=�6`   $��69��6x   *  $MahApps.Metro.Controls.NumericUpDown  5�      $��5��6%   $��94,41,1225,34q�62   -   Speedup- .  .   Minimum$. 1Q�6�   /   Maximum$/ 4Q�6�   $��80��6�   0   Value0 6I   �� *DentonDistrict+$ TwoWay=�6�   �� 5�      $��Forth Worth��6   $
��Left=�6*   $��
187,41,0,0q�6E   $��5��6Y   $	��Top=�6f   $��83��6~     5�      $��5��6%   $��282,41,1029,34q�62   - .  $. 1Q�6�   $/ 4Q�6�   0 6J   �� *ForthWorthDistrict+$ TwoWay=�6�   �� 5�      $��
Lewisville��6   $
��Left=�6)   $��
379,41,0,0q�6D   $��5��6X   $	��Top=�6e   $��82��6}     5�      $��5��6%   $��470,41,836,34q�62   - .  $. 1Q�6�   $/ 4Q�6�   0 6I   �� *LewisvilleDistrict+$ TwoWay=�6�   �� 5�      $��McKinney��6   $
��Left=�6'   $��
567,41,0,0q�6B   $��5��6V   $	��Top=�6c   $��96��6{     5�      $��5��6%   $��670,41,641,34q�62   - .  $. 1Q�6�   $/ 4Q�6�   0 6I   �� *MckinneyDistrict+$ TwoWay=�6�   �� 5�      $J��DAnything else you need to know for scheduling your field placement ?��6   $
��Left=�6c   $��	19,10,0,0q�6~   $��6��6�   $	��Top=�6�   $	��394��6�   �� 5�      $
��Left=�6   $��23��61   $��
459,10,0,0q�6=   $��6��6Q   $
 Wrap=�6^   $ 	Type here��6r   $	��Top=�6�   $	��569��6�   ��6�   �� *AnythingElse+$ TwoWay=�6�   �� 5�      $
��Left=�6   $��
391,10,0,0q�61   $��7��6p   $	��Top=�6}   $��60��6�   $��32��6�   {�6E   �� *	CanSave+$ OneWay=�.  (System.Windows.Interactivity.Interaction1   Triggers1 5�      /  )System.Windows.Interactivity.EventTrigger  5�      2   	EventName$2 Click��6%   .  (System.Windows.Interactivity.TriggerBase3   Actions.3 5      / 	 )GalaSoft.MvvmLight.Command.EventToCommand  4   Command4 6.   �� $ ExecuteSave�$ OneWay=�5     .��5     �� $��/Pics/Save.jpg��6   $��23��61   $��Stretch=�6=   $��40��6[   5     �� 5     $
��Save��6   $
��Left=�6#   $��
302,10,0,0q�6>   $��7��6R   $	��Top=�6_   $��32��6w   $��72��6�   $
��Bold"�6�   �� 5     $��Reset��6   $
��Left=�6$   $��
538,10,0,0q�6?   $��7��6S   $	��Top=�6`   $��32��6x   $��74��6�   $
��Bold"�6�   �� 5     $
��Left=�6   $��
637,10,0,0q�61   $��7��6E   $	��Top=�6S   $��50��6k   $��32��6v   1 5       5	     $2 Click��6%   .3 5
       4 6.   �� $ ExecuteReset�$ OneWay=�5     .��5     �� $��/Pics/Reset.png��6   $��23��62   $��Stretch=�6>   $��40��6\   5     �� 5     $
��Left=�6   $��
391,10,0,0q�61   $��8��6v   $	��Top=�6�   $��60��6�   $��32��6�   {�6E   �� *CanViewRecord+$ OneWay=�1 5       5     $2 Click��6%   .3 5       4 6.   �� $ ExecuteRecord�$ OneWay=�5     .��5     �� $��/Pics/Records.png��6   $��23��64   $��41��6@   5     �� 5     $��View RECORDS��6   $
��Left=�6+   $��
273,13,0,0q�6F   $��8��6Z   $	��Top=�6g   $	��100��6   $��29��6�   $
��Bold"�6�   �� 5     $��View RESULTS��6   $
��Left=�6+   $��
521,10,0,0q�6F   $��8��6Z   $	��Top=�6g   $	��101��6   $��32��6�   $
��Bold"�6�   �� 5     $
��Left=�6   $��
637,13,0,0q�61   $��8��6E   $	��Top=�6�   $��50��6�   $��29��6�   {�6R   �� *CanViewResult+$ OneWay=�1 5       5     $2 Click��6%   .3 5       4 6.   �� $ ExecuteResult�$ OneWay=�5     .��5     �� $��/Pics/results.jpg��6   $��23��64   $��Stretch=�6@   $��40��6^   5      �� 5!     $
��Year��6   $
��Left=�6#   $��1060,11,0,0q�6>   $��1��6S   $	��Top=�6`   $��57��6x   �� 5"     $��1��5#     $
��Left=�5$     $	��Top=�5%     $��1146,10,0,0q�5&     $ . $ select��5(     $��26��5)  B   $	��184��6O   % 6    �� *Year+$ TwoWay=�.@�5*     �� .��6   
Freshman6)   �� 5+     .��6   	Sophomore6*   �� 5,     .��6   Junior6'   �� 5-     .��6   Senior6'   �� 5.     .��6   
Post-Bac6)   5/     51     52     53     